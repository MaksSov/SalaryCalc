using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalc
{
    class Person
    {
        public string name { get; set; }
        public string secondName { get; set; }
        public Position position { get; set; }

        public override string ToString()
        {
            return $"{name}, {secondName}, {position}";
        }
    }
}
