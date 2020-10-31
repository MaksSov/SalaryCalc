using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalc
{
    interface IManager
    {
        void addPersonal(string file, Person person);
        void addWorkTime();
        void getReport();
    }
}
