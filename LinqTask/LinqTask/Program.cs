using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LinqTask
{
    class Program
    {

        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
                new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
                new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
                new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
                new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
                new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
                new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
                new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
                new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
                new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
                new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
                new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
                new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
                new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
                new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
                new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
                new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
                new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
                new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
                new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
            };
            //a
            FirstRegistrated(customers);
            //b
            AverageBalance(customers);
            //c
            FilterByDate(customers);
            //d
            FilterById(customers);
            //e
            FilterByName(customers);
            //f
            GroupByMonthAndSortByName(customers);
            //g
            SortByInput(customers);
            //h
            CommaSeparatedNameOutput(customers);
        }

        public static void FirstRegistrated(List<Customer> customers)
        {
            var firstRegistrated = customers.OrderBy(x => x.RegistrationDate).First();
            Console.WriteLine($"first registrated: {firstRegistrated.Name}");
        }
        public static void AverageBalance(List<Customer> customers)
        {
            var averageBalance = customers.Average(x => x.Balance);
            Console.WriteLine($"Average balance: {averageBalance}");
        }
        public static void FilterByDate(List<Customer> customers)
        {
            Console.WriteLine($"Filtered by date from(year-month-day):");
            var dateFromRead = Console.ReadLine();
            Console.WriteLine($"Filtered by date to(year-month-day): ");
            var dateToRead = Console.ReadLine();
            var dateFrom = DateTime.Parse(dateFromRead);
            var dateTo = DateTime.Parse(dateToRead);
            var filteredByDateCustomers = customers.Where(x => x.RegistrationDate >= dateFrom && x.RegistrationDate <= dateTo);
            if (filteredByDateCustomers.Any())
            {
                foreach (var filteredCustomer in filteredByDateCustomers)
                {
                    Console.WriteLine($"{filteredCustomer.Name}::{filteredCustomer.RegistrationDate}");
                }
            }
            else
            {
                Console.WriteLine("No results");
            }
        }
        public static void FilterById(List<Customer> customers)
        {
            Console.WriteLine($"Choose id to filtering:");
            var inputId = int.Parse(Console.ReadLine());

            var filteredByIdCustomers = customers.Where(x => x.Id == inputId);
            if (filteredByIdCustomers.Count() != 0)
            {
                foreach (var filteredCustomer in filteredByIdCustomers)
                {
                    Console.WriteLine($"{filteredCustomer.Name}::{filteredCustomer.Id}");
                }
            }
            else
            {
                Console.WriteLine("No results");
            }
        }
        public static void FilterByName(List<Customer> customers)
        {
            Console.WriteLine($"Filtered by name which consist:");
            var inputNamePart = Console.ReadLine();

            var filteredByNameCustomers = customers.Where(x => x.Name.ToLower().Contains(inputNamePart.ToLower()));
            if (filteredByNameCustomers.Count() != 0)
            {
                foreach (var filteredCustomer in filteredByNameCustomers)
                {
                    Console.WriteLine($"{filteredCustomer.Name}");
                }
            }
            else
            {
                Console.WriteLine("No results");
            }
        }
        public static void GroupByMonthAndSortByName(List<Customer> customers)
        {
            Console.WriteLine($"Grouped by month and sorted by name:");
            var groupedAndSortedCustomers = customers.
                OrderBy(x => x.RegistrationDate.Month).ThenBy(x => x.Name).
                GroupBy(x => x.RegistrationDate.Month);
            if (groupedAndSortedCustomers.Count() != 0)
            {
                foreach (var group in groupedAndSortedCustomers)
                {
                    foreach (var groupedCustomer in group)
                    {
                        Console.WriteLine($"{groupedCustomer.Name}::{groupedCustomer.RegistrationDate.Month}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No results");
            }
        }
        public static void SortByInput(List<Customer> customers)
        {
            Type customerType = typeof(Customer);
            Console.WriteLine($"Choose field to sort:");
            foreach (var prop in customerType.GetProperties())
            {
                Console.WriteLine($"{prop.Name}");
            }
            string chosenField = Console.ReadLine();
            Console.WriteLine($"Choose way to sort(asc/desc):");
            string chosenWayToSort = Console.ReadLine();
            List<Customer> sortedByInput;
            if (chosenWayToSort.Contains("asc"))
            {
                sortedByInput = customers.OrderBy(x => customerType.GetProperty(chosenField).
                                    GetValue(x)).ToList<Customer>();
            }
            else
            {
                sortedByInput = customers.OrderByDescending(x => customerType.GetProperty(chosenField).
                                    GetValue(x)).ToList<Customer>();
            }

            Console.WriteLine($"Ordered by {chosenField} by {chosenWayToSort}");
            foreach (var sortedCustomer in sortedByInput)
            {
                Console.WriteLine($"{sortedCustomer.Id}::{sortedCustomer.Name}::{sortedCustomer.Balance}::{sortedCustomer.RegistrationDate}");
            }
        }
        public static void CommaSeparatedNameOutput(List<Customer> customers)
        {
            Console.WriteLine($"Customer names separated with coma");
            Console.WriteLine(String.Join(',', customers.Select(x=>x.Name)));
        }
    }
}
