using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCalc
{
    class FilePath
    {
        public static string FILE_PATH = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        public static string LIST_EMPLOYEES = FILE_PATH + @"\..\employees.json";
        public static string LIST_HOURS_MANAGER = FILE_PATH + @"\..\manager.json";
        public static string LIST_HOURS_WORKER = FILE_PATH + @"\..\worker.json";
        public static string LIST_HOURS_Frilancer = FILE_PATH + @"\..\frilancer.json";
    }
}
