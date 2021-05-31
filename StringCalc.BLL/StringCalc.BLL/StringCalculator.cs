using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StringCalc.BLL
{
    public class StringCalculator
    {
        private int count;
        public event Action<string, int> AddOccured;

        public StringCalculator()
        {
            count = 0;
            AddOccured += (x, y) =>
            {
                this.count++;
                Console.WriteLine($"input : {x}\nresult: {y}");
            };
        }

        public int GetCalledCount()
        {
            return count;
        }

        public int Add(string numbers)
        {
            string[] splitResult = numbers.Split(new string[] { ",", "\n" },StringSplitOptions.RemoveEmptyEntries);
            if (numbers.StartsWith("//"))
            {
                var substring = numbers.Substring(2);
                var delimeterString = substring.Split('\n')[0];
                var delimeter = delimeterString.Split(new string[] { "[", "]" },StringSplitOptions.RemoveEmptyEntries).ToArray();
                splitResult = substring.Split('\n')[1].Split(delimeter,StringSplitOptions.RemoveEmptyEntries);
            }

            int sum = 0;
            var negativeNumbers = splitResult.Where(x => x.StartsWith('-')).ToList();
            foreach (var number in splitResult)
            {
                int parsedNumber = 0;
                int.TryParse(number, out parsedNumber);
                if (parsedNumber <= 1000)
                { 
                    sum += parsedNumber; 
                }
            }

            AddOccured.Invoke(numbers, sum);
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed {String.Join(',', negativeNumbers)}");
            }
            return sum;
        }
    }
}
