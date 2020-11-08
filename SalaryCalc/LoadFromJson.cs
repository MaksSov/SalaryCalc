using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCalc
{
    static class LoadFromJson
        <T>
    {
        public static List<T> GetListJson(string filePath)
        {
            List<T> listPerson = new List<T>();

            using (var file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {

                    listPerson.Add(JsonConvert.DeserializeObject<T>(line));
                }
            }

            return listPerson;
        }

       
       

    }
}
