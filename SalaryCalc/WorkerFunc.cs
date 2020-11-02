using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace SalaryCalc
{
    class WorkerFunc
    {

        public static void addTime(Person person)
        {

            //TODO:Добавить проверку ввода данных

            Console.WriteLine("Введите дату в формате дд.мм.гггг");
            var userTime = Console.ReadLine();

            bool parseDateTime = DateTime.TryParse(userTime, out DateTime time);

            Console.WriteLine("Введите количетсво отработанных часов: ");

            var workHours = int.Parse(Console.ReadLine());

            var workDay = new HoursWorked { person = person, workDay = time, workHours = workHours };

            using (var file = new StreamWriter(FilePath.LIST_HOURS_WORKER, true))
            {

                file.WriteLine(JsonSerializer.Serialize(workDay));

            }
        }
    }
}
