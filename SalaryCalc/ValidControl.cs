using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace SalaryCalc
{
    class ValidControl
    { 
        public static bool isPerson(List<Person> listPerson, Person person)
        {
            try
            {
                foreach (var user in listPerson)
                {
                    if (person.name == user.name && person.secondName == user.secondName)
                    {
                        return true;
                    }
                }
            }
            catch (NullReferenceException)
            {
                return false;                
            }

            return false;
        }
    
        public static bool isPerson(List<Person> listPerson, string name, string secondName)
        {
            try
            {
                foreach (var user in listPerson)
                {
                    if (name == user.name && secondName == user.secondName)
                    {
                        return true;
                    }
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }

            return false;
        }


        public static Person getPerson(List<Person> listPerson, string name, string secondName)
        {
            foreach (var user in listPerson)
            {
                if (name == user.name && secondName == user.secondName)
                {
                    return user;
                }

            }

            Console.WriteLine("Сотрудник не найден");
            return default(Person);

        }
       
        public static bool isManager(Person person)
        {
            if (person.position == Position.Manager)
            {
                return true;
            }
            return false;
        }

        public static bool isFileEmployeedCreate()
        {
            if (!File.Exists(FilePath.LIST_EMPLOYEES))
            {
                Console.WriteLine("Первый запуск программы создан базовый пользователь с именем и фамилией admin");

                Person person = new Person("admin", "admin", Position.Manager);
                person.salary = 0;

                using (var file = new StreamWriter(FilePath.LIST_EMPLOYEES, true))
                {
                    file.WriteLine(JsonSerializer.Serialize(person));
                }

                return true;
            }            
            return false;
        }

    }
}
