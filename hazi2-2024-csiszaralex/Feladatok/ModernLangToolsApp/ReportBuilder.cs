using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernLangToolsApp
{
    class ReportBuilder
    {
        private readonly IEnumerable<Person> people;
        private readonly Func<string> headerPrinter;
        private readonly Func<string> footerPrinter;
        private readonly Func<Person, string> personPrinter;
        private StringBuilder sb = new();

        public ReportBuilder(IEnumerable<Person> people, Func<string> headerPrinter, Func<string> footerPrinter, Func<Person, string> personPrinter)
        {
            this.people = people;
            this.headerPrinter = headerPrinter;
            this.footerPrinter = footerPrinter;
            this.personPrinter = personPrinter;
        }

        public string GetResult()
        {
            sb.AppendLine(headerPrinter());
            sb.AppendLine("-----------------------------------------");
            int i = 0;
            foreach (var person in people)
            {
                sb.Append($"{++i}. ");
                sb.AppendLine(personPrinter(person));
            }
            sb.AppendLine("--------------- Summary -----------------");
            sb.AppendLine(footerPrinter());

            return sb.ToString();
        }

    }
}
