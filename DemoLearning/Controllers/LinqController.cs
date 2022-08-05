using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoLearning.Controllers
{
    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        List<string> employeNames = new List<string>() { "Emp1", "Emp2", "Emp3", "Emp4", "Emp5", "Emp6" };
        List<string> employeSurname = new List<string>() { "Sur1", "Emp2", "Emp3", "Emp4", "Emp5", "Emp6" };
        List<int> employeIds = new List<int>() { 1, 2, 3, 4, 5, 6 };
        int[] vectorA = { 1, 2, 3, 4 };
        int[] vectorB = { 9, 8, 7, 6 };

        [HttpGet]
        public List<Employee> GetEmployee()
        {
            // Multithreding
            // Creating and initializing threads
            Thread thr1 = new Thread(method1);
            Thread thr2 = new Thread(method2);
            thr1.Start();
            thr2.Start();

            List<Employee> employees = new List<Employee>() { new Employee { Name = "Emp1", EmployeeId = 1 } };
            employees.Add(new Employee { Name = "Emp2", EmployeeId = 2 });
            employees.AddRange(new List<Employee> {
                new Employee { Name = "Emp3", EmployeeId = 3 },
                new Employee { Name = "Emp4", EmployeeId = 4 },
                new Employee { Name = "Emp5", EmployeeId = 5 },
                new Employee { Name = "Emp6", EmployeeId = 6 },
            });

            //LINQ
            //Using where method
            var emp = employeNames.Where(x => x == "Emp1").ToList();
            //Using where clause
            var data = from employee in employeNames where employee == "Emp1" select employee;

            //Using take merhod
            var take2 = employeIds.Take(2).ToList();
            //Using take method and where clause
            var take3 = (from employe in employees where employe.Name == "Emp1" select (employe.EmployeeId)).Take(3).ToList();
            //Using takewhile method
            var takewhile = employeIds.TakeWhile(x => x < 4).ToList();

            //Using sequencematch
            var sequencematch = employeNames.SequenceEqual(employeSurname);

            //Using zip method
            var zip = vectorA.Zip(vectorB, (a, b) => a + b);

            //Using multiple from
            var from = from a in vectorA from b in vectorB select (a, b);

            //Lazy loading
            int[] numers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int i = 0;
            var q = from num in numers select i++;

            foreach (var v in q)
            {
                Console.WriteLine($"v = {v}, i = {i}");
            }

            return employees;
        }

        // static method one
        public static void method1()
        {

            // It prints numbers from 0 to 10
            for (int I = 0; I <= 10; I++)
            {
                Console.WriteLine("Method1 is : {0}", I);

                // When the value of I is equal to 5 then
                // this method sleeps for 6 seconds
                if (I == 5)
                {
                    Thread.Sleep(6000);
                }
            }
        }

        // static method two
        public static void method2()
        {
            // It prints numbers from 0 to 10
            for (int J = 0; J <= 10; J++)
            {
                Console.WriteLine("Method2 is : {0}", J);
            }
        }
    }
}
