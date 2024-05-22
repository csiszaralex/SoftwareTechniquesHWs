using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Extensibility.ResultWriters
{
    public class CsvResultWriter: IResultWriter
    {
        private string _path;
        public CsvResultWriter(string path)
        {
            _path = path;
        }
        public void Write(List<Person> persons)
        {
            string outFileName = Path.ChangeExtension(_path, "processed.txt");
            using (StreamWriter writer = new StreamWriter(outFileName))
            {
                foreach (Person p in persons)
                    writer.WriteLine($"{p.FirstName}; {p.LastName}; {p.State}; {p.City}; {p.Age}; {p.Weight}; {p.Decease}");
            }

            Console.WriteLine($"Output file generated ({outFileName})");
        }
    }
}
