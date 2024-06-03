using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab_Extensibility.AnonymizerAlgorithms;
using Lab_Extensibility.InputReaders;
using Lab_Extensibility.Progresses;
using Lab_Extensibility.ResultWriters;

namespace Lab_Extensibility;

public class Anonymizer
{
    // Some variables for statistics BxA6
    private int _personCount;
    private int _trimmedPersonCount;


    //private readonly IProgress _progress;
    private readonly Action<int, int> _progress;
    private readonly IAnonymizerAlgorithm _anonymizerAlgorithm;
    private readonly IInputReader _inputReader;
    private readonly IResultWriter _resultWriter;

    //public Anonymizer(IAnonymizerAlgorithm anonymizerAlgorithm, IInputReader reader,IResultWriter writer, IProgress progress = null)
    public Anonymizer(IAnonymizerAlgorithm anonymizerAlgorithm, IInputReader reader,IResultWriter writer, Action<int, int> progress)
    {
        ArgumentNullException.ThrowIfNull(anonymizerAlgorithm);

        _anonymizerAlgorithm = anonymizerAlgorithm;
        _inputReader = reader;
        _resultWriter = writer;
        _progress = progress;
        //_progress = progress ?? new NullProgress();
    }

    public void Run()
    {
        Console.WriteLine("App started");
        List<Person> persons = _inputReader.Read();
        persons = TrimCityNames(persons);

        List<Person> anonymizedPersons = new();
        for (var i = 0; i < persons.Count; i++)
        {
            Person person = _anonymizerAlgorithm.Anonymize(persons[i]);
            anonymizedPersons.Add(person);

            _progress(persons.Count, i);
        }
        _resultWriter.Write(anonymizedPersons);
        PrintSummary();
    }

    private List<Person> TrimCityNames(List<Person> persons)
    {
        // Cleanup data 1: trim whitespaces and other unneeded characters (_ and #) from beginning and end of city names
        // As Person objects are immutable, let's create new Person objects with trimmed city names and add to new list.
        List<Person> trimmedPersons = new();
        foreach (var person in persons)
        {
            var trimmedCity = person.City.Trim().Trim('_', '#');
            if (trimmedCity != person.City)
                ++_trimmedPersonCount;
            trimmedPersons.Add(new Person(person.FirstName, person.LastName, person.CompanyName,
                person.Address, trimmedCity, person.State, person.Age, person.Weight, person.Decease));
        }
        return trimmedPersons;
    }

    private void PrintSummary()
    {
        // Print summary/statistics
        Console.WriteLine($"Summary - Anonymizer ({_anonymizerAlgorithm.GetAnonymizerDescription()}): Persons: {_personCount}, trimmed: {_trimmedPersonCount}");
    }

}