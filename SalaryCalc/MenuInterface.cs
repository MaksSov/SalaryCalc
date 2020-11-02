﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SalaryCalc
{
    class MenuInterface
    {
        
        

        public void loginMenu(List<Person> listPerson)
        {
            Console.Clear();
            Console.WriteLine("Представьтесь пожалуйста");

            Console.Write("Введите Имя: ");
            var loginName = Console.ReadLine();

            Console.Write("Введите Фамилию: ");
            var loginSecondName = Console.ReadLine();

            var loginPerson = ValidControl.getPerson(listPerson, loginName, loginSecondName);

            if(loginPerson == null)
            {
                loginMenu(listPerson);
            }

            headMenu(loginPerson);            

        }
        public void headMenu(Person person)
        {
            Console.Clear();
            Console.WriteLine($"");
            Console.WriteLine($"Здравствуйте, {person.name}");
            Console.WriteLine($"");
            Console.WriteLine($"Ваша роль: {person.position}");
            Console.WriteLine($"----------------------------------------");
            switch (person.position)
            {
                case Position.Manager:
                    managerMenu(person);
                    break;
                case Position.Worker:
                    workerMenu(person);
                    break;
                case Position.Frilancer:
                    frilancerMenu(person);
                    break;
                default:
                    break;
            }

        }


        private void managerMenu(Person person)
        {
            Console.WriteLine(
                "\tВыберите желаемое действие:\n" +
                "\t(1).Проверить собственый отчет\n" +
                "\t(2).Добавить сотрудника\n" +
                "\t(3).Просмотреть отчет по всем сотрудникам за период\n" +
                "\t(4).Просмотреть отчет по конкретному сотруднику за период\n" +
                "\t(5).Добавить часы работы\n" +
                "\t(6).Выход из программы\n");
            Console.Write("Ввод: ");

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    workerMenu(person);
                    break;
                case 2:
                    ManagerFunc.addPersonal();
                    Console.WriteLine("---------  Готово  ----------");
                    Thread.Sleep(1000);

                    headMenu(person);
                    break;
                case 3:
                    menuPeriod(person);
                    break;
                case 4:
                    break;
                case 5:
                    
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void menuPeriod(Person person)
        {
            Console.WriteLine(
                "\tВыберите желаемый период:\n" +
                "\t(1).День\n" +
                "\t(2).Неделя\n" +
                "\t(3).Месяц\n" +
                "\t(4).Указать период\n" +
                "\t(5).Выход из программы\n");
            Console.Write("Ввод: ");
            Console.WriteLine();

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    Console.WriteLine();
                    ManagerFunc.getWorkInfo(Convert.ToDateTime(DateTime.Now.ToShortDateString()));                    
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
            Console.Clear();
            Console.WriteLine(
                "\tВыберите желаемое действие:\n" +
                "\t(1).Добавить отработаные часы\n" +
                "\t(2).Просмотреть отчет по отработаному времени и зарплате\n" +
                "\t(3).Вернутся назад\n" +
                "\t(4).Выход из программы");
            Console.Write("Ввод: ");
            Console.WriteLine();

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
                    Console.WriteLine($"Заработная плата: {WorkerFunc.getSalary(person)} \n");
                    Console.WriteLine("Для возврата нажмите любую клавишу...");
                    Console.ReadKey();
                    headMenu(person);
                    break;
                case 3:
                    headMenu(person);
                    break;
                case 4:                    
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
