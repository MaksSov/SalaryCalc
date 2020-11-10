using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Threading;

namespace SalaryCalc
{
    class ValidControl
    { 
        public static bool IsPerson(List<Person> listPerson, Person person)
        {
            if (listPerson != null)
            {
                foreach (var user in listPerson)
                {
                    if (person.name == user.name && person.secondName == user.secondName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    
        public static bool IsPerson(List<Person> listPerson, string name, string secondName)
        {
            if (listPerson != null)
            {
                foreach (var user in listPerson)
                {
                    if (name == user.name && secondName == user.secondName)
                    {

                        return true;
                    }
                }
            }
            return false;
        }

        public static Person GetPerson()
        {
            List<Person> listPerson = LoadFromJson<Person>.GetListJson(FilePath.LIST_EMPLOYEES);
            Console.Write("Введите Имя: ");
            var loginName = Console.ReadLine();
            Console.Write("Введите Фамилию: ");
            var loginSecondName = Console.ReadLine();
            return ValidControl.GetPerson(listPerson, loginName, loginSecondName);            

        }

        public static Person GetPerson(List<Person> listPerson, string name, string secondName)
        {
            foreach (var user in listPerson)
            {
                if (name == user.name && secondName == user.secondName)
                {
                    return user;
                }

            }
            Console.WriteLine("-------------------");
            Console.WriteLine("Сотрудник не найден");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для вовзравта...");
            Console.ReadKey();
            return default(Person);

        }

        public static void CreatedFileEmployees()
        {
            if (!File.Exists(FilePath.LIST_EMPLOYEES))
            {
                Console.WriteLine("Первый запуск программы создан базовый пользователь с именем и фамилией admin");
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Person person = new Person("admin", "admin", Position.Manager);
                person.salary = 0;

                using (var file = new StreamWriter(FilePath.LIST_EMPLOYEES, true))
                {
                    file.WriteLine(JsonSerializer.Serialize(person));
                }
                
            }            
            
        }

        public static bool IsFileCreate(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл еще не создан");
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                
                return false;
            }
            return true;
        }

        
    }
}
