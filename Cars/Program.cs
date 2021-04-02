﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        /// ***********Second Main***********
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            var query = cars.Join(manufacturers, 
                                  c => c.Manufacturer, 
                                  m => m.Name, 
                                  (c, m) => new 
                                  { 
                                      m.Headquarters, 
                                      c.Name, 
                                      c.Combined 
                                  })
                            .OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
            }
        }

        private static List<Car> ProcessCars(string path)
        {
            var query = File.ReadAllLines(path)
                .Skip(1)
                .Where(l => l.Length > 1)
                .ToCar();

            return query.ToList();
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query = File.ReadAllLines(path)
                            .Where(l => l.Length > 1)
                            .Select(l =>
                            {
                                var columns = l.Split(',');
                                return new Manufacturer
                                {
                                    Name = columns[0],
                                    Headquarters = columns[1],
                                    Year = int.Parse(columns[2])
                                };
                            });
            return query.ToList();
        }

        /// ***********First Main***********
        //static void Main(string[] args)
        //{
        //    var cars = ProcessFile("fuel.csv");

        //    var query = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
        //                    .OrderByDescending(c => c.Combined)
        //                    .ThenBy(c => c.Name); // using another orderBy would reorder everything

        //    var top = cars.OrderByDescending(c => c.Combined)
        //                  .ThenBy(c => c.Name)
        //                  .First(c => c.Manufacturer == "BMW" && c.Year == 2016); //  .Last()

        //    var result = cars.Any(c => c.Manufacturer == "Ford"); //  .All()

        //    var query3 = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
        //                    .OrderByDescending(c => c.Combined)
        //                    .ThenBy(c => c.Name)
        //                    .Select(c => new { c.Manufacturer, c.Name, c.Combined }); // anonymous type

        //    var query4 = cars.SelectMany(c => c.Name); 

        //    foreach (var name in query4)
        //    {
        //        Console.WriteLine(name);
        //    }

        //    //foreach (var car in query.Take(10))
        //    //{
        //    //    Console.WriteLine($"{car.Name} : {car.Combined}");
        //    //}
        //}

        //private static List<Car> ProcessFile(string path)
        //{
        //    var query = File.ReadAllLines(path)
        //        .Skip(1)
        //        .Where(l => l.Length > 1)
        //        .Select(Car.ParseFromCsv)
        //        .ToList();

        //    var query2 = File.ReadAllLines(path)
        //        .Skip(1)
        //        .Where(l => l.Length > 1)
        //        .ToCar();

        //    return query2.ToList();
        //}

    }

    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }
}
