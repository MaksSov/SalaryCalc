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

            ValidControl.fileEmployeedCreate();

            List<Person> listPerson = LoadFromJson<Person>.getListJson(FilePath.LIST_EMPLOYEES);

            var menu = new MenuInterface();

            menu.loginMenu(listPerson);


        }
    }
}
