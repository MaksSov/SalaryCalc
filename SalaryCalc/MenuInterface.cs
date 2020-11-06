using System;
using System.Collections.Generic;
using System.Drawing;
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Здравствуйте, {person.name}");
            Console.WriteLine($"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ваша роль: {person.position}", ConsoleColor.Yellow);
            Console.WriteLine($"----------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
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

                    done();
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
            

            //TODO: Проверить ввод пользователя.

            var userChoise = Console.ReadLine();
            int.TryParse(userChoise, out int value);

            switch (value)
            {
                case 1:
                    WorkerFunc.addWorkTime(person);
                    done();
                    break;
                case 2:                    
                    Console.WriteLine($"Количество отработанных часов за месяц: {WorkerFunc.getWorkTime(person)}");
                    Console.WriteLine($"Заработная плата за месяц: {WorkerFunc.getSalary(person)} \n");
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

                    break;
                case 3:

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
                    var weak = new TimeSpan(7, 0, 0, 0);
                    var weakAgo = Convert.ToDateTime(DateTime.Now - weak);
                    ManagerFunc.getWorkInfo(weakAgo);
                    break;
                case 3:
                    var month = new TimeSpan(DateTime.Now.Day, 0, 0, 0);
                    var monthAgo = Convert.ToDateTime(DateTime.Now - month);
                    ManagerFunc.getWorkInfo(monthAgo);
                    break;
                case 4:
                    getUserPeriod(out DateTime StartTime,out DateTime EndTime);
                    ManagerFunc.getWorkInfo(StartTime, EndTime);
                    break;               
                case 5:
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

        private void done()
        {
            Console.WriteLine("-----------------");
            Thread.Sleep(2000);            
        }

    }
}
