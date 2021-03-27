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
