using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace SalaryCalc
{
    class Person
    {

        public Person(string name, string secondName, Position position)
        {
            this.name = name;
            this.secondName = secondName;
            this.position = position;
            SetDefaultSalary();
        }

        public string name { get; set; }
        public string secondName { get; set; }
        public Position position { get; set; }
        public int salary { set; get; }

        private void SetDefaultSalary()
        {
            switch (this.position)
            {
                case Position.Manager:
                    salary = 200000;
                    break;

                case Position.Worker:
                    salary = 120000;
                    break;

                case Position.Freelance:
                    salary = 160000;
                    break;

                default:
                    salary = 0;
                    break;
            }
        }

        public override string ToString()
        {
            return $"Имя: {name}, Фамилия: {secondName}, Должность: {position}, Зарплата: {salary}";
        }

    }
}
