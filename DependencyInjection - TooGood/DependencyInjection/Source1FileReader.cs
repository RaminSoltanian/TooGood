using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Source1FileReader: IFileReader
    {
        
        
        private  List<Source1> SourceOne = new List<Source1>();
        private  List<StandardFormat> StandardFormatInput = new List<StandardFormat>();
        private  Dictionary<string, string> S1toSTDFormatCurrency = new Dictionary<string, string>()
        {
            {"CD", "CAD" },
            {"US", "USD" }

        };

        enum AccountType { Trading = 1, RRSP, RESP, Fund };

        public void ReadDataFromFile()
        {
            // seudo: open the file located in filepath 
            // read the first record in file. assume the following values will be read from file:
            var s1 = new Source1();
            s1.Identifier = "123|AbcCode";
            s1.Name = "My Account";
            s1.Type = 2;
            s1.OpenDate = DateTime.Parse("1/1/2018");
            s1.Currency = "CD";
            SourceOne.Add(s1);

            var s2 = new Source1();
            s2.Identifier = "456|efgCode";
            s2.Name = "My Account2";
            s2.Type = 4;
            s2.OpenDate = DateTime.Parse("1/1/2016");
            s2.Currency = "US";
            SourceOne.Add(s2);

            Console.WriteLine("Source1 File Reader Finished Reading Source1 Input.\n");
        }
        public void CreateStandardOutputFromSource1()
        {
            
            foreach (var s1 in SourceOne)
            {
                var sf = new StandardFormat();

                var pipeIndex = s1.Identifier.IndexOf("|");
                if (pipeIndex >= 0)
                    sf.AccountCode = s1.Identifier.Substring(pipeIndex + 1);
                else
                {
                    Console.WriteLine("Cannot find account code in source1 file due to missing pipe symbol.");
                    sf.AccountCode = "";
                }

                sf.Name = s1.Name;
                sf.Type = Enum.GetName(typeof(AccountType), s1.Type);
                sf.OpenDate = s1.OpenDate;

                string s1Value = "";
                if (S1toSTDFormatCurrency.TryGetValue(s1.Currency, out s1Value))
                    sf.Currency = s1Value;
                else
                {
                    Console.WriteLine("Not a valid Source 1 Currency: ", s1.Currency);
                    sf.Currency = "";
                }

                StandardFormatInput.Add(sf);
            }
           
        }
        public void PrintStandardOuputData()
        {
            Console.WriteLine("Standard Fromat data created from Source1 Data:\n");
            foreach (var s in StandardFormatInput)
            {
                Console.WriteLine("AccountCode: " + s.AccountCode);
                Console.WriteLine("Name: " + s.Name);
                Console.WriteLine("Type: " + s.Type);
                Console.WriteLine("OpenDate: " + s.OpenDate);
                Console.WriteLine("Currency: " + s.Currency);
                Console.WriteLine("\n");
            }
        }
        public void PrintSource1Data()
        {
            Console.WriteLine("Source1 Data:\n");
            foreach (var s in SourceOne)
            {
                Console.WriteLine("Identifier: " + s.Identifier);
                Console.WriteLine("Name: " + s.Name);
                Console.WriteLine("Type: " + s.Type);
                Console.WriteLine("OpenDate: " + s.OpenDate);
                Console.WriteLine("Currency: " + s.Currency);
                Console.WriteLine("\n");
            }

        }
    }
}
