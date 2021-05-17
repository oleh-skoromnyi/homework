using System;
using System.Reflection;

namespace CSVGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personList = PersonList.GetListPerson();
            Type personType = typeof(Person);
            CSVGenerator generator = new CSVGenerator(personList);

            Console.WriteLine("Which properties you want to save?");

            foreach (PropertyInfo property in personType.GetProperties())
            {
                Console.WriteLine($"{property.Name}");
            }

            string properties = Console.ReadLine();
            generator.CreateCSV(properties);
        }
    }
}
