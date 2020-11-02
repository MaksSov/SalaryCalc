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
            var userTime = Console.ReadLine();

            bool parseDateTime = DateTime.TryParse(userTime, out DateTime time);

            Console.WriteLine("Введите количетсво отработанных часов: ");

            var workHours = int.Parse(Console.ReadLine());

            Console.WriteLine("Добавьте коментарий о проделаной работе");

            var coments = Console.ReadLine();



            var workDay = new HoursWorked { person = person, workDay = time, workHours = workHours, coments = coments };

            using (var file = new StreamWriter(FilePath.LIST_HOURS_WORKER, true, Encoding.UTF8))
            {

                file.WriteLine(JsonSerializer.Serialize(workDay));

            }
        }

        public static int getWorkTime(Person person)
        {
            var listHoursWorked = LoadFromJson<HoursWorked>.getListJson(FilePath.LIST_HOURS_WORKER);

            int totalWorkHour = 0;

            foreach (HoursWorked item in listHoursWorked)
            {
                if (person.name == item.person.name && person.secondName == item.person.secondName)
                {
                    totalWorkHour += item.workHours;
                }
               
            }

            return totalWorkHour;
        }

        public static int getSalary(Person person)
        {
            var listHoursWorked = LoadFromJson<HoursWorked>.getListJson(FilePath.LIST_HOURS_WORKER);

            int totalWorkHour = 0;
            

            foreach (HoursWorked item in listHoursWorked)
            {
                if (person.name == item.person.name && person.secondName == item.person.secondName)
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
