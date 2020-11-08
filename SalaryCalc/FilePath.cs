using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCalc
{
    class FilePath
    {
        public static readonly string FILE_PATH = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public static readonly string LIST_EMPLOYEES = FILE_PATH + @"\..\employees.json";        
        public static readonly string LIST_EMPLOYEES_REPORT = FILE_PATH + @"\..\employees_report.json";
    }
}
