using System;
using System.Collections.Generic;



namespace SalaryCalc
{
    class MenuInterface
    {
        public void LoginMenu(List<Person> listPerson)
        {
            Console.Clear();
            Console.WriteLine("Представьтесь пожалуйста");

            var loginPerson = ValidControl.GetPerson();

            if(loginPerson == null)
            {
                LoginMenu(listPerson);
            }

            TopMenu(loginPerson);            

        }
        public void TopMenu(Person person)
        {
            HeadMenu(person);
            switch (person.position)
            {
                case Position.Manager:
                    ManagerMenu(person);
                    break;
                case Position.Worker:
                    WorkerMenu(person);
                    break;
                case Position.Freelance:
                    FreelancerMenu(person);
                    break;
                default:
                    break;
            }

        }

        private void ManagerMenu(Person person)
        {
            HeadMenu(person);
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
                    WorkerMenu(person);
                    break;
                case 2:
                    ManagerFunc.AddPersonal();
                    Done();
                    TopMenu(person);
                    break;
                case 3:
                    if (ValidControl.IsFileCreate(FilePath.LIST_EMPLOYEES_REPORT))
                    {                        
                        MenuPeriodAllPerson(person);
                    }                    
                    TopMenu(person);
                    break;
                case 4:
                    if (ValidControl.IsFileCreate(FilePath.LIST_EMPLOYEES_REPORT))
                    {
                        var userPerson = ValidControl.GetPerson();
                        if(userPerson != null)
                        {
                            MenuPeriod(person, userPerson);
                        }
                        TopMenu(person);
                    }
                    TopMenu(person);
                    break;
                case 5:
                    List<Person> listPerson = LoadFromJson<Person>.GetListJson(FilePath.LIST_EMPLOYEES);
                    LoginMenu(listPerson);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void WorkerMenu(Person person)
        {
            Console.Clear();
            HeadMenu(person);
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
                    WorkerFunc.AddWorkTime(person);
                    Done();
                    TopMenu(person);
                    break;
                case 2:
                    if (ValidControl.IsFileCreate(FilePath.LIST_EMPLOYEES_REPORT))
                    {
                        Console.WriteLine($"Количество отработанных часов за месяц: {WorkerFunc.GetWorkTime(person)}");
                        Console.WriteLine($"Заработная плата за месяц: {WorkerFunc.GetSalary(person)} \n");
                        Console.WriteLine("Для возврата нажмите любую клавишу...");
                        Done();
                    }                    
                    TopMenu(person);
                    break;
                case 3:
                    List<Person> listPerson = LoadFromJson<Person>.GetListJson(FilePath.LIST_EMPLOYEES);
                    LoginMenu(listPerson);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void FreelancerMenu(Person person)
        {
            HeadMenu(person);
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
                    Freelancer.AddWorkTime(person);
                    Done();
                    TopMenu(person);
                    break;
                case 2:
                    if (ValidControl.IsFileCreate(FilePath.LIST_EMPLOYEES_REPORT))
                    {
                        Console.WriteLine($"Количество отработанных часов за месяц: {WorkerFunc.GetWorkTime(person)}");
                        Console.WriteLine($"Заработная плата за месяц: {WorkerFunc.GetSalary(person)} \n");
                        Console.WriteLine("Для возврата нажмите любую клавишу...");
                        Done();
                    }                    
                    TopMenu(person);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }            

        }

        private void MenuPeriodAllPerson(Person person)
        {
            HeadMenu(person);
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
                    ManagerFunc.GetWorkInfo(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                    Done();
                    TopMenu(person);
                    break;
                case 2:
                    var weak = new TimeSpan(7, 0, 0, 0);
                    var weakAgo = Convert.ToDateTime(DateTime.Now - weak);
                    ManagerFunc.GetWorkInfo(weakAgo);
                    Done();
                    TopMenu(person);
                    break;
                case 3:
                    var month = new TimeSpan(DateTime.Now.Day, 0, 0, 0);
                    var monthAgo = Convert.ToDateTime(DateTime.Now - month);
                    ManagerFunc.GetWorkInfo(monthAgo);
                    Done();
                    TopMenu(person);
                    break;
                case 4:
                    GetUserPeriod(out DateTime StartTime,out DateTime EndTime);
                    ManagerFunc.GetWorkInfo(StartTime, EndTime);
                    Done();
                    TopMenu(person);
                    break;
                case 5:
                    ManagerFunc.GetWorkInfo();
                    Done();
                    TopMenu(person);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void MenuPeriod(Person person, Person userPerson)
        {
            HeadMenu(person);
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
                    ManagerFunc.GetWorkInfo(Convert.ToDateTime(DateTime.Now.ToShortDateString()), userPerson);
                    Done();
                    TopMenu(person);
                    break;
                case 2:
                    var weak = new TimeSpan(7, 0, 0, 0);
                    var weakAgo = Convert.ToDateTime(DateTime.Now - weak);
                    ManagerFunc.GetWorkInfo(weakAgo, userPerson);
                    Done();
                    TopMenu(person);
                    break;
                case 3:
                    var month = new TimeSpan(DateTime.Now.Day, 0, 0, 0);
                    var monthAgo = Convert.ToDateTime(DateTime.Now - month);
                    ManagerFunc.GetWorkInfo(monthAgo, userPerson);
                    Done();
                    TopMenu(person);
                    break;
                case 4:
                    GetUserPeriod(out DateTime StartTime, out DateTime EndTime);
                    ManagerFunc.GetWorkInfo(StartTime, EndTime, userPerson);
                    Done();
                    TopMenu(person);
                    break;
                case 5:
                    ManagerFunc.GetWorkInfo(userPerson);
                    Done();
                    TopMenu(person);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void GetUserPeriod(out DateTime StartTime, out DateTime EndTime)
        {
            Console.Write("Укажите дату начала периода в формате дд.мм.гггг: ");
            //TODO: Проверить ввод пользователя.

            StartTime = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Укажите дату окончания периода в формате дд.мм.гггг: ");
            //TODO: Проверить ввод пользователя.

            EndTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();

        }

        private void HeadMenu(Person person)
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
        private void Done()
        {
            Console.WriteLine("--------Далее---------");            
            Console.ReadKey();
        }

    }
}
