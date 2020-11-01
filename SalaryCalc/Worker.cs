using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace SalaryCalc
{
    class WorkerFunc
    {

        public void addTime(string path)
        {
            using (var file = new StreamWriter(path))
            {
                Console.WriteLine("Введите дату в формате дд.мм.гггг");
                var userTime = Console.ReadLine();

                DateTime.TryParse(userTime, out DateTime time);

                

                file.WriteLine(JsonSerializer.Serialize(this));

            }
        }
    }
}
