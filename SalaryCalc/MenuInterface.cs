using System;
using System.Collections.Generic;



namespace SalaryCalc
{
    class MenuInterface
    {
        public void loginMenu(List<Person> listPerson)
        {
            Console.Clear();
            Console.WriteLine("Представьтесь пожалуйста");

            var loginPerson = ValidControl.getPerson();

            if(loginPerson == null)
            {
                loginMenu(listPerson);
            }

            topMenu(loginPerson);            

        }
        public void topMenu(Person person)
        {
            headMenu(person);
            switch (person.position)
            {
                case Position.Manager:
                    managerMenu(person);
                    break;
                case Position.Worker:
                    workerMenu(person);
                    break;
                case Position.Freelance:
                    freelancerMenu(person);
                    break;
                default:
                    break;
            }

        }

        private void managerMenu(Person person)
        {
            headMenu(person);
            Console.WriteLine(
                "\tВыберите желаемое действие:\n" +
                "\t(1).Работа с собственным отчетом\n" +
                "\t(2).Добавить сотрудника\n" +
                "\t(3).Просмотреть отчет по всем сотрудникам за период\n" +
                "\t(4).Просмотреть отчет по конкретному сотруднику за период\n" +
                "\t(5).Сменить пользователя\n" +
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
                    done();
                    topMenu(person);
                    break;
                case 3:
                    if (ValidControl.isFileCreate(FilePath.LIST_EMPLOYEES_REPORT))
                    {                        
                        menuPeriodAllPerson(person);
                    }                    
                    topMenu(person);
                    break;
                case 4:
                    if (ValidControl.isFileCreate(FilePath.LIST_EMPLOYEES_REPORT))
                    {
                        var userPerson = ValidControl.getPerson();
                        menuPeriod(person, userPerson);
                    }
                    topMenu(person);
                    break;
                case 5:
                    List<Person> listPerson = LoadFromJson<Person>.getListJson(FilePath.LIST_EMPLOYEES);
                    loginMenu(listPerson);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void workerMenu(Person person)
        {
            Console.Clear();
            headMenu(person);
            Console.WriteLine(
                "\tВыберите желаемое действие:\n" +
                "\t(1).Добавить отработаные часы\n" +
                "\t(2).Просмотреть отчет по отработаному времени и зарплате за месяц\n" +
                "\t(3).Сменить пользователя\n" +
                "\t(4).Выход из программы");
            Console.Write("Ввод: ");
            

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    WorkerFunc.addWorkTime(person);
                    done();
                    topMenu(person);
                    break;
                case 2:
                    if (ValidControl.isFileCreate(FilePath.LIST_EMPLOYEES_REPORT))
                    {
                        Console.WriteLine($"Количество отработанных часов за месяц: {WorkerFunc.getWorkTime(person)}");
                        Console.WriteLine($"Заработная плата за месяц: {WorkerFunc.getSalary(person)} \n");
                        Console.WriteLine("Для возврата нажмите любую клавишу...");
                        done();
                    }                    
                    topMenu(person);
                    break;
                case 3:
                    List<Person> listPerson = LoadFromJson<Person>.getListJson(FilePath.LIST_EMPLOYEES);
                    loginMenu(listPerson);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void freelancerMenu(Person person)
        {
            headMenu(person);
            Console.WriteLine(
                "\tВыберите желаемое действие:\n" +
                "\t(1).Добавить отработаные часы(не ранее чем за два дня от текущего времени)\n" +
                "\t(2).Просмотреть отчет по отработаному времени и зарплате за месяц\n" +
                "\t(3).Выход из программы");
            Console.Write("Ввод: ");

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    Freelancer.addWorkTime(person);
                    done();
                    topMenu(person);
                    break;
                case 2:
                    if (ValidControl.isFileCreate(FilePath.LIST_EMPLOYEES_REPORT))
                    {
                        Console.WriteLine($"Количество отработанных часов за месяц: {WorkerFunc.getWorkTime(person)}");
                        Console.WriteLine($"Заработная плата за месяц: {WorkerFunc.getSalary(person)} \n");
                        Console.WriteLine("Для возврата нажмите любую клавишу...");
                        done();
                    }                    
                    topMenu(person);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }            

        }

        private void menuPeriodAllPerson(Person person)
        {
            headMenu(person);
            Console.WriteLine(
                "\tВыберите желаемый период:\n" +
                "\t(1).День\n" +
                "\t(2).Неделя\n" +
                "\t(3).Месяц\n" +
                "\t(4).Указать период\n" +
                "\t(5).За все время\n" +
                "\t(6).Выход из программы\n");
            Console.Write("Ввод: ");
            
            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();            
            int.TryParse(userChoise, out int value);
            Console.WriteLine();

            switch (value)
            {
                case 1:                    
                    ManagerFunc.getWorkInfo(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                    done();
                    topMenu(person);
                    break;
                case 2:
                    var weak = new TimeSpan(7, 0, 0, 0);
                    var weakAgo = Convert.ToDateTime(DateTime.Now - weak);
                    ManagerFunc.getWorkInfo(weakAgo);
                    done();
                    topMenu(person);
                    break;
                case 3:
                    var month = new TimeSpan(DateTime.Now.Day, 0, 0, 0);
                    var monthAgo = Convert.ToDateTime(DateTime.Now - month);
                    ManagerFunc.getWorkInfo(monthAgo);
                    done();
                    topMenu(person);
                    break;
                case 4:
                    getUserPeriod(out DateTime StartTime,out DateTime EndTime);
                    ManagerFunc.getWorkInfo(StartTime, EndTime);
                    done();
                    topMenu(person);
                    break;
                case 5:
                    ManagerFunc.getWorkInfo();
                    done();
                    topMenu(person);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void menuPeriod(Person person, Person userPerson)
        {
            headMenu(person);
            Console.WriteLine($"Отчет по {userPerson.name} {userPerson.secondName}");
            Console.WriteLine(
                 "\tВыберите желаемый период:\n" +
                "\t(1).День\n" +
                "\t(2).Неделя\n" +
                "\t(3).Месяц\n" +
                "\t(4).Указать период\n" +
                "\t(5).За все время\n" +
                "\t(6).Выход из программы\n");
            Console.Write("Ввод: ");

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    Console.WriteLine();
                    ManagerFunc.getWorkInfo(Convert.ToDateTime(DateTime.Now.ToShortDateString()), userPerson);
                    done();
                    topMenu(person);
                    break;
                case 2:
                    var weak = new TimeSpan(7, 0, 0, 0);
                    var weakAgo = Convert.ToDateTime(DateTime.Now - weak);
                    ManagerFunc.getWorkInfo(weakAgo, userPerson);
                    done();
                    topMenu(person);
                    break;
                case 3:
                    var month = new TimeSpan(DateTime.Now.Day, 0, 0, 0);
                    var monthAgo = Convert.ToDateTime(DateTime.Now - month);
                    ManagerFunc.getWorkInfo(monthAgo, userPerson);
                    done();
                    topMenu(person);
                    break;
                case 4:
                    getUserPeriod(out DateTime StartTime, out DateTime EndTime);
                    ManagerFunc.getWorkInfo(StartTime, EndTime, userPerson);
                    done();
                    topMenu(person);
                    break;
                case 5:
                    ManagerFunc.getWorkInfo(userPerson);
                    done();
                    topMenu(person);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void getUserPeriod(out DateTime StartTime, out DateTime EndTime)
        {
            Console.Write("Укажите дату начала периода в формате дд.мм.гггг: ");

            //TODO: Проверить ввод пользователя.

            StartTime = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Укажите дату окончания периода в формате дд.мм.гггг: ");

            //TODO: Проверить ввод пользователя.

            EndTime = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine();

        }

        private void headMenu(Person person)
        {
            Console.Clear();
            Console.WriteLine($"");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Здравствуйте, {person.name}");
            Console.WriteLine($"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ваша роль: {person.position}", ConsoleColor.Yellow);
            Console.WriteLine($"----------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void done()
        {
            Console.WriteLine("--------Далее---------");            
            Console.ReadKey();
        }

    }
}
