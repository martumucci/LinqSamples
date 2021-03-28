using System;
using System.Collections.Generic;
//using Features.Linq; // My extension methods
using System.Linq; // Linq extension methods

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) =>
            {
                int temp = x + y;
                return temp;
            };

            Action<int> write = x => Console.WriteLine(x); // does not have a return type (returns void)

            write(square(add(3, 5)));

            Console.WriteLine(square(add(3,5)));

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Scott"},
                new Employee {Id = 2, Name = "Chris"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee {Id = 3, Name  = "Alex"}
            };

            foreach (var employee in developers.Where(e => e.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }
        }

    }
}
