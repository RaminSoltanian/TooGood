using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class StandardFileReader:IFileReader
    {
         
        private  List<StandardFormat> SourceStandard = new List<StandardFormat>();

        public void ReadDataFromFile()
        {
            // seudo: open the file located in filepath 
            // read the first record in file. assume the following values will be read from file:
            var sf = new StandardFormat();
            sf.AccountCode = "AbcCode";
            sf.Name = "My Account";
            sf.Type = "RRSP";
            sf.OpenDate = DateTime.Parse("1/1/2018");
            sf.Currency = "CAD";
            SourceStandard.Add(sf);
            Console.WriteLine("Standard Format File Reader Finished Reading Standard format Input.\n");
        }
        public void PrintStandardOuputData()
        {
            foreach (var s in SourceStandard)
            {
                Console.WriteLine("AccountCode: "+s.AccountCode);
                Console.WriteLine("Name: "+ s.Name);
                Console.WriteLine("Type: "+ s.Type);
                Console.WriteLine("OpenDate: "+ s.OpenDate);
                Console.WriteLine("Currency: "+ s.Currency);
                Console.WriteLine("\n");
            }
        }
    }
}

