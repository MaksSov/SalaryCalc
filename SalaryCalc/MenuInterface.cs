using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalc
{
    class MenuInterface
    {


        public void mainMenu(List<Person> listPerson)
        {

            Console.WriteLine("Представьтесь пожалуйста");
            Console.Write("Введите Имя: ");
            var loginName = Console.ReadLine();

            Console.Write("Введите Фамилию: ");
            var loginSecondName = Console.ReadLine();

            var loginPerson = ValidControl.getPerson(listPerson, loginName, loginSecondName);

            Console.WriteLine($"");
            Console.WriteLine($"Здравствуйте, {loginPerson.name}");
            Console.WriteLine($"");
            Console.WriteLine($"Ваша роль: {loginPerson.position}");

            switch (loginPerson.position)
            {
                case Position.Manager:
                    managerMenu(loginPerson);
                    break;
                case Position.Worker:
                    workerMenu(loginPerson);
                    break;
                case Position.Frilancer:
                    frilancerMenu(loginPerson);
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
                "\t(5).Выход из программы\n");
            Console.Write("Ввод: ");

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    ManagerFunc.addPersonal();
                    this.managerMenu(person);
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

        private void workerMenu(Person person)
        {
            Console.WriteLine(
                "\tВыберите желаемое действие:\n" +
                "\t(1).Добавить отработаные часы\n" +
                "\t(2).Просмотреть отчет по отработаному времени и зарплате\n" +
                "\t(3).Выход из программы");
            Console.Write("Ввод: ");

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    WorkerFunc.addWorkTime(person);
                    break;
                case 2:                    
                    Console.WriteLine($"Количество отработанных часов: {WorkerFunc.getWorkTime(person)}");
                    Console.WriteLine($"Заработная плата: {WorkerFunc.getSalary(person)}");
                    break;
                case 3:

                    break;
                default:
                    break;
            }

        }
        private void frilancerMenu(Person person)
        {
            Console.WriteLine(
                "\tВыберите желаемое действие:\n" +
                "\t(1).Добавить отработаные часы(не ранее чем за два дня от текущего времени)\n" +
                "\t(2).Просмотреть отчет по отработаному времени и зарплате\n" +
                "\t(3).Выход из программы");
            Console.Write("Ввод: ");

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    
                    break;
                case 2:
                    Console.WriteLine($"Количество отработанных часов: ");
                    Console.WriteLine($"Заработная плата: ");
                    break;
                case 3:

                    break;
                default:
                    break;
            }
        }

    }
}
