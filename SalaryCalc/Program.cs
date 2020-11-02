using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace SalaryCalc
{
    class Program
    {
        static void Main(string[] args)
        {



            List<Person> listPerson = LoadFromJson<Person>.getListJson(FilePath.LIST_EMPLOYEES);

            var menu = new MenuInterface();

            menu.mainMenu(listPerson);




        }
    }
}
