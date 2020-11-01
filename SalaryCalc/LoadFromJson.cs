using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCalc
{
    class LoadFromJson
    {
        public static List<Person> GetListEmployees()
        {
            List<Person> listPerson = new List<Person>();

            using (var file = new StreamReader(FilePath.LIST_EMPLOYEES))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {

                    listPerson.Add(JsonConvert.DeserializeObject<Person>(line));
                }
            }

            return listPerson;
        }
    }
}
