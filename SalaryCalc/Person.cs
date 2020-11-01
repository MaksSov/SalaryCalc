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
            salary = salary;
        }

        public string name { get; set; }
        public string secondName { get; set; }
        public Position position { get; set; }
        public DateTime workTime { get; set; }
        
        private int Salary;
     
        public int salary
        {
            
            set {

                switch (this.position)
                {
                    case Position.Manager:
                        Salary = 200000;
                        break;

                    case Position.Worker:
                        Salary = 120000;
                        break;

                    case Position.Frilancer:
                        Salary = 160000;
                        break;

                    default:
                        Salary = 0;
                        break;
                }              
            }

            get
            {
                return Salary;
            }
        }

        public override string ToString()
        {
            return $"Имя: {name}, Фамилия: {secondName}, Должность: {position}, Зарплата: {salary}";
        }

    }
}
