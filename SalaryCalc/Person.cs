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
            this.setDefaultSalary();
        }


        public string name { get; set; }
        public string secondName { get; set; }
        public Position position { get; set; }       
        
        private int Salary;
     
        public int salary
        {
            
            set
            {
                Salary = value;            
            }

            get
            {
                return Salary;
            }
        }

        private void setDefaultSalary()
        {
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

        public override string ToString()
        {
            return $"Имя: {name}, Фамилия: {secondName}, Должность: {position}, Зарплата: {salary}";
        }

    }
}
