using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace CSVGenerator
{
    public class CSVGenerator
    {
        private List<Person> personList;
        private List<string> propertyList;

        public CSVGenerator(List<Person> list)
        {
            personList = list;
            propertyList = new List<string>();
        }

        public void CreateCSV(string properties, string filename = "default.csv")
        {
            var splitResult = properties.Split(',');
            foreach (var property in splitResult)
            {
                propertyList.Add(property.Trim());
            }

            StringBuilder stringBuilder = new StringBuilder();
            Type personType = typeof(Person);
     
            stringBuilder.Append("sep=,\r\n");

            foreach (var property in propertyList)
            {
                stringBuilder.Append(property);
                if (propertyList.LastIndexOf(property) != propertyList.Count - 1)
                {
                    stringBuilder.Append(',');
                }
                else
                {
                    stringBuilder.Append("\r\n");
                }
            }

            foreach (var person in personList)
            {
                foreach (var property in propertyList)
                {
                    var value = personType.GetProperty(property).GetValue(person);
                    if (value != null)
                    {
                        if (value.ToString().Contains(','))
                        {
                            stringBuilder.Append($"\"{value}\"");
                        }
                        else
                        {
                            stringBuilder.Append($"{value}");
                        }
                    }
                    else
                    {
                        stringBuilder.Append($"{value}");
                    }

                    if (propertyList.LastIndexOf(property) != propertyList.Count - 1)
                    {
                        stringBuilder.Append(',');
                    }
                    else
                    {
                        stringBuilder.Append("\r\n");
                    }
                }
            }

            using (var file = new StreamWriter(filename))
            {
                file.Write(stringBuilder.ToString());
            }
        }
    }
}
