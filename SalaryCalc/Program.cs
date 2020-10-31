using System;
using System.IO;
using System.Text.Json;

namespace SalaryCalc
{
    class Program
    {

        const string FILE_PATH = @"D:\project\Csharp\SalaryCalc";
        const string LIST_EMPLOYEES = FILE_PATH + @"\employees.csv";
        const string LIST_HOURS_MANAGER = FILE_PATH + @"\manager.csv";
        const string LIST_HOURS_WORKER = FILE_PATH + @"\worker.csv";
        const string LIST_HOURS_Frilancer = FILE_PATH + @"\frilancer.csv";

        static void Main(string[] args)
        {

            var ivan = new Person
            {
                name = "Ivan",
                secondName = "Ivanovich",
                position = Position.Manager,

            };

            var ivanJson = JsonSerializer.Serialize(ivan);




            using (var file = new StreamWriter(LIST_EMPLOYEES, true))
            {
                file.WriteLine(ivanJson);
                file.WriteLine(ivanJson);
                file.WriteLine(ivanJson);


            }

            using (var file = new StreamReader(LIST_EMPLOYEES))
            {
                Person IvanD;

                while (file.ReadLine() != null)
                {

                    IvanD = JsonSerializer.Deserialize<Person>(file.ReadLine());


                }
            }

            Console.WriteLine(IvanD.ToString());


        }
    }
}
