using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
   
        public class InputFileReader
        {
            private readonly IFileReader _fileReader;

            //consturctor dp injection
            public InputFileReader(IFileReader fileReader)
            {
                _fileReader = fileReader;
            }
            public void ReadInputFile()
            {
                _fileReader.ReadDataFromFile();
            }
        }
    
}
