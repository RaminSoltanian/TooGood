using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{

    public class Source2FileReader : IFileReader

    {
        private  List<Source2> SourceTwo = new List<Source2>();
        private  List<StandardFormat> StandardFormatInput = new List<StandardFormat>();
        private Dictionary<string, string> S2toSTDFormatCurrency = new Dictionary<string, string>()
        {
            {"C", "CAD" },
            {"U", "USD" }

        };

        public void ReadDataFromFile()
        {
            // seudo: open the file located in filepath 
            // read the first record in file. assume the following values will be read from file:
            var s2 = new Source2();
            s2.Name = "My Account";
            s2.Type = "RRSP";
            s2.Currency = "C";
            s2.CustodianCode = "";
            SourceTwo.Add(s2);

            var s3 = new Source2();
            s3.Name = "Ramin Account";
            s3.Type = "Trading";
            s3.Currency = "U";
            s3.CustodianCode = "";
            SourceTwo.Add(s3);

            Console.WriteLine("Source2 File Reader Finished Reading Source2 Input.\n");

        }
        public void CreateStandardOutputFromSource2()
        {
            foreach (var s in SourceTwo)
            {
                var sf = new StandardFormat();

                sf.AccountCode = s.CustodianCode;
                sf.Name = s.Name;
                sf.Type = s.Type;
                sf.OpenDate =  DateTime.Parse("1/1/2019");

                string s1Value = "";
                if (S2toSTDFormatCurrency.TryGetValue(s.Currency, out s1Value))
                    sf.Currency = s1Value;
                else
                {
                    Console.WriteLine("Not a valid Source 2 Currency: ", s.Currency);
                    sf.Currency = "";
                }

                StandardFormatInput.Add(sf);
            }
           
        }
        public void PrintStandardOuputData()
        {
            Console.WriteLine("Standard Fromat data created from Source2 Data:\n");
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
        public void PrintSource2Data()
        {
            Console.WriteLine("Source2 Data:\n");
            foreach (var s in SourceTwo)
            {                
                Console.WriteLine("Name: " + s.Name);
                Console.WriteLine("Type: " + s.Type);               
                Console.WriteLine("Currency: " + s.Currency);
                Console.WriteLine("CustodianCode: " + s.CustodianCode);
                Console.WriteLine("\n");
            }

        }
    }

}
