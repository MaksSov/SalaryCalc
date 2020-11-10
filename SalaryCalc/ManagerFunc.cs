using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SalaryCalc
{
    class ManagerFunc : WorkerFunc
    {
        public static void AddPersonal()
        {
            var listPerson = LoadFromJson<Person>.GetListJson(FilePath.LIST_EMPLOYEES);
            var regexName = new Regex(@"^[A-Z][a-z]*$");

            Console.WriteLine();
            Console.Write("Введите имя нового сотрудника: ");
            var name = Console.ReadLine();

            Console.Write("Введите фамилию нового сотрудника: ");
            var secondName = Console.ReadLine();

            if (regexName.IsMatch(name) && regexName.IsMatch(secondName) && !ValidControl.IsPerson(listPerson, name, secondName))
            {
                Console.Write("Введите должность нового сотрудника: \n" +
                    "\t\t 0 - Руководитель \n" +
                    "\t\t 1 - Штатный сотрудник  \n" +
                    "\t\t 2 - Фриланс \n");
                int.TryParse(Console.ReadLine(), out int value);
                if (value > 0 && value < 2)
                {
                    var person = new Person(name, secondName, (Position)value);
                    using (var file = new StreamWriter(FilePath.LIST_EMPLOYEES, true))
                    {
                        file.WriteLine(JsonSerializer.Serialize(person));
                    }
                }
                else
                {
                    Console.WriteLine("Должность сотрудника введена некорректно");
                }
             
            }
            else
            {
                Console.WriteLine("Сотрудник есть в базе или фамилия,имя введены не коректно");
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
