using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


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


        }
    }
}
