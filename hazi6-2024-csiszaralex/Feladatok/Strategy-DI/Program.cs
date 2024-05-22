using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab_Extensibility.AnonymizerAlgorithms;
using Lab_Extensibility.InputReaders;
using Lab_Extensibility.Progresses;
using Lab_Extensibility.ResultWriters;

namespace Lab_Extensibility;

static class Program
{
    static void Main(string[] args)
    {
        Anonymizer p1 = new(new NameMaskingAnonymizerAlgorithm("***"),
            new CsvInputReader("us-500.csv"),
            new CsvResultWriter("us-500-anonymized.csv"),
            AllProgresses.SimpleProgress);
        p1.Run();

        Anonymizer p2 = new(new NameMaskingAnonymizerAlgorithm("***"),
            new CsvInputReader("us-500.csv"),
            new CsvResultWriter("us-500-anonymized.csv"),
            AllProgresses.PercentProgress);
        p2.Run();
    }
}