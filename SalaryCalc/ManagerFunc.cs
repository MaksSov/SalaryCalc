using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace SalaryCalc
{
    class ManagerFunc : WorkerFunc
    {
        public static void AddPersonal()
        {

            //TODO: Добавить проверку ввода данных

            Console.WriteLine();
            Console.Write("Введите имя нового сотрудника: ");
            var name = Console.ReadLine();
            Console.Write("Введите фамилию нового сотрудника: ");
            var secondName = Console.ReadLine();
            Console.Write("Введите должность нового сотрудника: \n" +
                "\t\t 0 - Руководитель \n" +
                "\t\t 1 - Штатный сотрудник  \n" +
                "\t\t 2 - Фриланс \n");
            int.TryParse(Console.ReadLine(), out int value);
            

            var person = new Person(name, secondName, (Position)value);

            using (var file = new StreamWriter(FilePath.LIST_EMPLOYEES, true))
            {
                file.WriteLine(JsonSerializer.Serialize(person));
            }
        }

        public static void AddPersonal(string name, string secondName, Position position)
        {
            //TODO: Добавить проверку ввода данных
            var person = new Person(name, secondName, position);

            using (var file = new StreamWriter(FilePath.LIST_EMPLOYEES, true))
            {
                file.Write(JsonSerializer.Serialize(person));
            }
        }

        public static void GetWorkInfo()
        {
            var listHoursWorked = LoadFromJson<HoursWorked>.GetListJson(FilePath.LIST_EMPLOYEES_REPORT);
            HoursWorked checkEmpety = default;
            foreach (var item in listHoursWorked)
            {               
                Console.WriteLine(item);
            }
            if (checkEmpety == default)
            {
                Console.WriteLine("Нет данных");
                Console.WriteLine();
            }
        }

        public static void GetWorkInfo(Person person)
        {
            var listHoursWorked = LoadFromJson<HoursWorked>.GetListJson(FilePath.LIST_EMPLOYEES_REPORT);
            HoursWorked checkEmpety = default;
            foreach (var item in listHoursWorked)
            {
                if (person.name == item.person.name && person.secondName == item.person.secondName)
                {
                    Console.WriteLine(item);
                }                
            }
            if (checkEmpety == default)
            {
                Console.WriteLine("Нет данных");
                Console.WriteLine();
            }
        }

        public static void GetWorkInfo(DateTime EndDate)
        {
            var listHoursWorked = LoadFromJson<HoursWorked>.GetListJson(FilePath.LIST_EMPLOYEES_REPORT);
            HoursWorked checkEmpety = default;
            foreach (var item in listHoursWorked)
            {
                if (EndDate.CompareTo(item.workDay) == -1 || EndDate.CompareTo(item.workDay) == 0)
                {
                    Console.WriteLine(item);
                }
            }
            if (checkEmpety == default)
            {
                Console.WriteLine("Нет данных");
                Console.WriteLine();
            }
        }

        public static void GetWorkInfo(DateTime EndDate, Person person)
        {
            var listHoursWorked = LoadFromJson<HoursWorked>.GetListJson(FilePath.LIST_EMPLOYEES_REPORT);
            HoursWorked checkEmpety = default;

            foreach (var item in listHoursWorked)
            {
                if (EndDate.CompareTo(item.workDay) == -1 || EndDate.CompareTo(item.workDay) == 0 && person == item.person)
                {
                    Console.WriteLine(item);
                }
            }
            if (checkEmpety == default)
            {
                Console.WriteLine("Нет данных");
                Console.WriteLine();
            }
        }

        public static void GetWorkInfo(DateTime StartDate, DateTime EndDate)
        {
            var listHoursWorked = LoadFromJson<HoursWorked>.GetListJson(FilePath.LIST_EMPLOYEES_REPORT);
            HoursWorked checkEmpety = default;

            foreach (var item in listHoursWorked)
            {
                if (StartDate <= item.workDay && EndDate >= item.workDay )
                {
                    checkEmpety = item;
                    Console.WriteLine(item);
                }
            }
            if (checkEmpety == default)
            {
                Console.WriteLine("Нет данных");
                Console.WriteLine();
            }
        }

        public static void GetWorkInfo(DateTime StartDate, DateTime EndDate , Person person)
        {
            var listHoursWorked = LoadFromJson<HoursWorked>.GetListJson(FilePath.LIST_EMPLOYEES_REPORT);
            HoursWorked checkEmpety = default;
            foreach (var item in listHoursWorked)
            {
                if (StartDate <= item.workDay && EndDate >= item.workDay && person == item.person)
                {
                    Console.WriteLine(item);
                }
            }
            if (checkEmpety == default)
            {
                Console.WriteLine("Нет данных");
                Console.WriteLine();
            }
        }

        public static new int GetSalary(Person person)
        {
            var month = new TimeSpan(DateTime.Now.Day, 0, 0, 0);
            var monthAgo = Convert.ToDateTime(DateTime.Now - month);
            var listHoursWorked = LoadFromJson<HoursWorked>.GetListJson(FilePath.LIST_EMPLOYEES_REPORT);
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
                totalSalary += (totalWorkHour - 160) * (20000 / 160 * 8);
            }

            return totalSalary;
        }

        public static int GetTotalSalary()
        {
            var listHoursWorked = LoadFromJson<Person>.GetListJson(FilePath.LIST_EMPLOYEES);
            var totalSalary = 0;
            foreach (var item in listHoursWorked)
            {
                if (item.position == Position.Manager)
                {
                    totalSalary += ManagerFunc.GetSalary(item);
                }
                else
                {
                    totalSalary += WorkerFunc.GetSalary(item);
                }
                
            }
            return totalSalary;
        }

    }
}
