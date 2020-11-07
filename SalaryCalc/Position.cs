using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalc
{
    [Flags]
    enum Position
    {
        Manager = 0,
        Worker = 1,
        Freelance = 2
    }
}
