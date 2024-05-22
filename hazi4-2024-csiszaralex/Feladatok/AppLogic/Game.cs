using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;
using System;

namespace MultiThreadedApp.AppLogic;


class Game
{
    // Különböző vonalak x pozíciója (start, depo, finish)
    public const int StartLinePosition = 150;
    public const int DepoPosition = 300;
    public const int FinishLinePosition = 450;
    private ManualResetEvent _isStarted = new ManualResetEvent(false);
    private AutoResetEvent _isDepoFree = new AutoResetEvent(false);
    private bool hasWinner;
    private ConcurrentQueue<int> logs = new();
    private Action<Bike> bikesChanged;

    public List<Bike> Bikes { get; } = new List<Bike>();

    /// <summary>
    /// Verseny előkészítése (biciklik létrehozása és felsorakoztatása
    /// a startvonalhoz)
    /// </summary>
    public void PrepareRace(Action<Bike> changed)
    {
        CreateBike();
        CreateBike();
        CreateBike();
        bikesChanged = changed;
    }

    /// <summary>
    /// Elindítja a bicikliket a startvonalról.
    /// </summary>
    public void StartBikes()
    {
        _isStarted.Set();
    }

    /// <summary>
    /// Elindítja a következő biciklit a depóból (mindig csak egyet)
    /// </summary>
    public void StartNextBikeFromDepo()
    {
        _isDepoFree.Set();
    }

    /// <summary>
    /// Létrehoz egy biciklit.
    /// </summary>
    private void CreateBike()
    {
        // Az új bicikli a következő rajtszámot kapja paraméterben (az első bicikli a 0 rajtszámot kapja)
        var bike = new Bike(Bikes.Count);
        Bikes.Add(bike);

        var thread = new Thread(BikeThreadFunction);
        thread.IsBackground = true;
        thread.Start(bike);
    }

    void BikeThreadFunction(object bikeAsObject)
    {
        Bike bike = (Bike)bikeAsObject;
        while (bike.Position <= StartLinePosition)
        {
            logs.Enqueue(bike.Step());
            bikesChanged?.Invoke(bike);
            Thread.Sleep(100);
        }
        if (WaitHandle.WaitAny(new[] { _isStarted }) == 0)
        {
            while (bike.Position <= DepoPosition)
            {
                logs.Enqueue(bike.Step());
                bikesChanged?.Invoke(bike);
                Thread.Sleep(100);
            }
        }
        if (WaitHandle.WaitAny(new[] { _isDepoFree }) == 0)
        {
            while (bike.Position <= FinishLinePosition)
            {
                logs.Enqueue(bike.Step());
                bikesChanged?.Invoke(bike);
                Thread.Sleep(100);
            }
            lock (this)
            {
                if (!hasWinner)
                {
                    Thread.Sleep(2000);
                    hasWinner = true;
                    bike.SetAsWinner();
                    bikesChanged?.Invoke(bike);
                }
            }
        }
    }

}
