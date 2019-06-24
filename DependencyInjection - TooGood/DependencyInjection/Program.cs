using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {                       
             //source1 input file reader 
            var s1FileReader = new Source1FileReader();            
            var source1Reader = new InputFileReader(s1FileReader);
            source1Reader.ReadInputFile();
            s1FileReader.PrintSource1Data();
            // create standard input format for source1 input
            s1FileReader.CreateStandardOutputFromSource1();
            // display created standard fromat from source1 input
            s1FileReader.PrintStandardOuputData();            
            
            //source2 input file reader
            var s2FileReader = new Source2FileReader();
            var source2Reader = new InputFileReader(s2FileReader);
            source2Reader.ReadInputFile();
            s2FileReader.PrintSource2Data();
            // create standard input format for source2 input
            s2FileReader.CreateStandardOutputFromSource2();
            // display created standard fromat from source2 input
            s2FileReader.PrintStandardOuputData();             
            
            //standard format input file reader 
            var sDFileReader = new StandardFileReader();
            var standardReader = new InputFileReader(sDFileReader);
            standardReader.ReadInputFile();
            // display created standard fromat from standard input
            sDFileReader.PrintStandardOuputData();

            Console.Read();
        }
    }    
}