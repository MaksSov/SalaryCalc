using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalc
{
    class HoursWorked
    {
        public Person person { get; set; }
        public DateTime workDay { get; set; }
        public int workHours { get; set; }
        public string coments { get; set; }

        public override string ToString()
        {
            return $"{person.name} {person.secondName} {workDay} {coments}";
        }

    }

}
