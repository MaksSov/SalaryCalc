using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SalaryCalc
{
    class Manager : IManager
    { 
        public string filePath { get; set; }
    
        public void addPersonal(string filePath, Person personal)
        {
            using(var file = new StreamWriter(filePath))
            {

            }
        }

        public void addWorkTime()
        {
            throw new NotImplementedException();
        }

        public void getReport()
        {
            throw new NotImplementedException();
        }

    }
}
