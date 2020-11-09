using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;


namespace SalaryCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidControl.CreatedFileEmployees();
            List<Person> listPerson = LoadFromJson<Person>.GetListJson(FilePath.LIST_EMPLOYEES);
            var menu = new MenuInterface();
            menu.LoginMenu(listPerson);

            var regex = new Regex(@"[0-3]{1}[0-9]{1}.[0-1]{1}[0-9]{1}.[2]{1}[0]{1}[0-9]{1}[0-9]{1}");

            menu.GetUserPeriod(out DateTime time, out DateTime endtime);

            Console.WriteLine(time.ToString(), endtime.ToString());
        }
    }
}
