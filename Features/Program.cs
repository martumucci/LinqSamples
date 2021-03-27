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

            //Console.WriteLine(sales.Count());
            //Console.WriteLine(developers.Count());

            //IEnumerator<Employee> enumerator = developers.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}

            foreach (var employee in developers.Where(
                                        delegate (Employee employee)
                                                {
                                                   return employee.Name.StartsWith("S");
                                                 }
                                         )
                    )
            {
                Console.WriteLine(employee.Name);
            }
        }

        //private static bool NameStartsWithS(Employee employee)
        //{
        //    return employee.Name.StartsWith("S");
        //}
    }
}
