using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace SalaryCalc
{
    class ManagerFunc
    {
        public static void addPersonal()
        {
            //TODO: Функция перезаписывает новый файл а не создает дополнительную строку. Исправить.
            Console.WriteLine();
            Console.Write("Введите имя нового сотрудника: ");
            var name = Console.ReadLine();
            Console.Write("Введите фамилию нового сотрудника: ");
            var secondName = Console.ReadLine();
            Console.Write("Введите должность нового сотрудника: \n" +
                "\t 0 - Руководитель \n" +
                "\t 1 - Штатный сотрудник  \n" +
                "\t 2 - Фриланс \n");
            int.TryParse(Console.ReadLine(), out int value);

            

            var person = new Person(name, secondName, (Position)value);

            using (var file = new StreamWriter(FilePath.LIST_EMPLOYEES))
            {
                file.Write(JsonSerializer.Serialize(person));
            }
        }

        public void addPersonal(string name, string secondName, Position position)
        {
            var person = new Person(name, secondName, position);

            using (var file = new StreamWriter(FilePath.LIST_EMPLOYEES))
            {
                file.Write(JsonSerializer.Serialize(person));
            }
        }

    }
}
