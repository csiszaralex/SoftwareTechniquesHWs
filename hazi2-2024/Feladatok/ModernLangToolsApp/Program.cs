using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ModernLangToolsApp;

public class Program
{
    public static void Main(string[] args)
    {
        klon();
        eventTest();
        delegateTest();
        lambdaTest();
        test6();
        test6b();
        delegate7Test();
    }
    [Description("Feladat2")]
    public static void klon()
    {
        Jedi j = new()
        {
            Name = "ObiWan",
            MidiChlorianCount = 120
        };
        //write
        var serializer = new XmlSerializer(typeof(Jedi));
        var stream = new FileStream("jedi.txt", FileMode.Create);
        serializer.Serialize(stream, j);
        stream.Close();
        //read
        serializer = new XmlSerializer(typeof(Jedi));
        stream = new FileStream("jedi.txt", FileMode.Open);
        var clone = (Jedi)serializer.Deserialize(stream);
        stream.Close();
    }
    [Description("Feladat3")]
    public static void eventTest()
    {
        // Tanács létrehozása
        var council = new JediCouncil();

        council.CouncilChanged += MessageReceived;

        council.Add(new Jedi { Name = "ObiWan", MidiChlorianCount = 120 });
        council.Add(new Jedi { Name = "Yoda", MidiChlorianCount = 900 });

        council.Remove();
        council.Remove();

    }
    [Description("Feladat4")]
    public static void delegateTest()
    {
        JediCouncil j = new();
        initJedis(j);
        List<Jedi> midi = j.midiMax530_Delegate();
        midi.ForEach(jedi => Console.WriteLine(jedi.Name));
    }
    [Description("Feladat5")]
    public static void lambdaTest()
    {
        JediCouncil j = new();
        initJedis(j);
        List<Jedi> midi = j.midiMax530_Lambda();
        midi.ForEach(jedi => Console.WriteLine(jedi.Name));
    }
    [Description("Feladat6")]
    static void test6()
    {
        var employees = new Person[] { new Person("Joe", 20), new Person("Jill", 30) };

        ReportPrinter reportPrinter = new ReportPrinter(
            employees,
            () => Console.WriteLine("Employees"),
            () => Console.WriteLine($"Number of Employees: {employees.Count()}"),
            (p) => Console.WriteLine($"Name: {p.Name} (Age: {p.Age})")
            );

        reportPrinter.PrintReport();
    }
    static void test6b()
    {
        var employees = new Person[] { new Person("Joe", 20), new Person("Jill", 30) };

        ReportBuilder reportBuilder = new ReportBuilder(
            employees,
            () => "Employees",
            () => $"Number of Employees: {employees.Count()}",
            (p) => $"Name: {p.Name} (Age: {p.Age})"
            );

        string res = reportBuilder.GetResult();
        Console.WriteLine(res);

    }
    [Description("Feladat7")]
    static void delegate7Test()
    {
        JediCouncil jc = new();
        initJedis(jc);

        int db = jc.CountIf((Jedi j) => j.MidiChlorianCount < 900);
        int db2 = jc.Count;
        Console.WriteLine($"900 midichlorian alattiak: {db}/{db2}");
    }
    private static void initJedis(JediCouncil j)
    {
        j.Add(new Jedi { Name = "ObiWan", MidiChlorianCount = 120 });
        j.Add(new Jedi { Name = "Yoda", MidiChlorianCount = 900 });
        j.Add(new Jedi { Name = "Anakin", MidiChlorianCount = 1200 });
        j.Add(new Jedi { Name = "Luke", MidiChlorianCount = 800 });
    }
    private static void MessageReceived(string message)
    {
        Console.WriteLine(message);
    }

}
