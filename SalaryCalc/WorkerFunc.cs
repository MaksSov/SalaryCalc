using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace SalaryCalc
{
    class WorkerFunc
    {

        public static void addWorkTime(Person person)
        {


            //TODO:Добавить проверку ввода данных

            Console.WriteLine("Введите дату в формате дд.мм.гггг");

            var userTime = Convert.ToDateTime(Console.ReadLine());
            var month = new TimeSpan(DateTime.Now.Day, 0, 0, 0);
            var twoDaysAgo = Convert.ToDateTime(DateTime.Now - month);

            if (userTime > twoDaysAgo)
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

            else{Console.WriteLine("Вы ввели неправильную дату. Дата должна быть текущего месяца");            }

        }

        public static int getWorkTime(Person person)
        {
            var month = new TimeSpan(DateTime.Now.Day, 0, 0, 0);
            var monthAgo = Convert.ToDateTime(DateTime.Now - month);

            var listHoursWorked = LoadFromJson<HoursWorked>.getListJson(FilePath.LIST_EMPLOYEES_REPORT);

            int totalWorkHour = 0;

            foreach (HoursWorked item in listHoursWorked)
            {
                if (person.name == item.person.name && person.secondName == item.person.secondName && item.workDay > monthAgo)
                {
                    totalWorkHour += item.workHours;
                }
               
            }

            return totalWorkHour;
        }

        public static int getSalary(Person person)
        {
            var month = new TimeSpan(DateTime.Now.Day, 0, 0, 0);
            var monthAgo = Convert.ToDateTime(DateTime.Now - month);

            var listHoursWorked = LoadFromJson<HoursWorked>.getListJson(FilePath.LIST_EMPLOYEES_REPORT);

            int totalWorkHour = 0;
            

            foreach (HoursWorked item in listHoursWorked)
            {
                if (person.name == item.person.name && person.secondName == item.person.secondName && item.workDay > monthAgo)
                {
                    totalWorkHour += item.workHours;
                }
            }

            int totalSalary = totalWorkHour * (person.salary / 160);            

            if (totalWorkHour > 160)
            {
                totalSalary += (totalWorkHour - 160) * (person.salary / 160);
            }

            return totalSalary;
        }

       

    }
}
