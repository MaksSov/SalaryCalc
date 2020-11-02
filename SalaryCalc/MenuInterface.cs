using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalc
{
    class MenuInterface
    {
        public void mainMenu(Person person)
        {
            Console.WriteLine($"");
            Console.WriteLine($"Здравствуйте, {person.name}");
            Console.WriteLine($"");
            Console.WriteLine($"Ваша роль: {person.position}");

            switch (person.position)
            {
                case Position.Manager:
                    managerMenu(person);
                    break;
                case Position.Worker:
                    workerMenu(person);
                    break;
                case Position.Frilancer:
                    break;
                default:
                    break;
            }
        }

        private void managerMenu(Person person)
        {
            Console.WriteLine(
                "\tВыберите желаемое действие:\n" +
                "\t(1).Добавить сотрудника\n" +
                "\t(2).Просмотреть отчет по всем сотрудникам\n" +
                "\t(3).Просмотреть отчет по конкретному сотруднику\n" +
                "\t(4).Добавить часы работы\n" +
                "\t(5).Выход из программы");
            Console.Write("Номер:");

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    ManagerFunc.addPersonal();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    
                    break;
                default:
                    break;
            }

        }

        private void workerMenu(Person perosn)
        {
            Console.WriteLine(
                "\tВыберите желаемое действие:\n" +
                "\t(1).Добавить отработаные часы\n" +
                "\t(2).Просмотреть отчет по отработаному времени и зарплате\n" +
                "\t(3).Выход из программы");
            Console.Write("Номер:");

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    WorkerFunc.addTime(perosn);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

        }

    }
}
