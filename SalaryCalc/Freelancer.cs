using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace SalaryCalc
{
    class Freelancer
    {
        public static void AddWorkTime(Person person)
        {
            //TODO:Добавить проверку ввода данных

            Console.WriteLine("Введите дату в формате дд.мм.гггг");
            var userTime = Convert.ToDateTime(Console.ReadLine());
            var twoDays = new TimeSpan(7, 0, 0, 0);
            var twoDaysAgo = Convert.ToDateTime(DateTime.Now - twoDays);

            if (userTime < twoDaysAgo)
            {
                Console.WriteLine("Введите количетсво отработанных часов: ");
                var workHours = int.Parse(Console.ReadLine());

                Console.WriteLine("Добавьте коментарий о проделаной работе");
                var coments = Console.ReadLine();

                var workDay = new HoursWorked { person = person, workDay = userTime, workHours = workHours, coments = coments };

                using (var file = new StreamWriter(FilePath.LIST_EMPLOYEES_REPORT, true, Encoding.UTF8))
                {

                    file.WriteLine(JsonSerializer.Serialize(workDay));

                }
            }
            Console.WriteLine("Вы ввели неправильную дату");

        }
    }
}
