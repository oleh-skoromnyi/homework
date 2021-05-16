using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            PrintNumbers("1af23fsda34fd 21 wf 23 dw1");
            Console.WriteLine("\nTask 2");
            Console.WriteLine(TransformDivisionResultToNumberWithTwoValueAfterComa(2, 3));
            Console.WriteLine("\nTask 3");
            ReadNumberFromConsoleWithExponentialForm();
            Console.WriteLine("\nTask 4");
            CurrentDateInFormatISO8601();
            Console.WriteLine("\nTask 5");
            Console.WriteLine($"Parsed date :{ParseStringToDateTime()}");
            Console.WriteLine("\nTask 6");
            string numbers = "12,32,21,62";
            Console.WriteLine($"Sum of {numbers} : {SumOfCommaSeparatedNumbers(numbers)}");
            Console.WriteLine("\nTask 7");
            Console.WriteLine("   Part a");
            GetAllSubstringWithFormatTextNumbers("asd546asd456 12asd12 d a s1");
            Console.WriteLine("   Part b");
            PasswordValidator("Oleh22");
            Console.WriteLine("   Part c");
            PostCodeValidator("123-321");
            Console.WriteLine("   Part d");
            PhoneNumberValidator("+380-98-123-45-67");
            Console.WriteLine("   Part e");
            PhoneNumberReplacer("My phone number +380-98-123-45-67");
            Console.WriteLine("\nTask 8");
            string[] names = { "иван иванов", "светлана иванова-петренко" };
            FirstSymbolsToUpper(names);
            Console.WriteLine("\nTask 9");
            string base64String = "0JXRgdC70Lgg0YLRiyDRh9C40YLQsNC10YjRjCDRjdGC0L7RgiDRgtC10LrRgdGCLCDQt9C90LDRh9C40YIg0LfQsNC00LDQvdC40LUg0LLRi9C/0L7Qu9C90LXQvdC+INCy0LXRgNC90L4gOik=";
            DecodeBase64ToUTF8(base64String);
            Console.WriteLine("\n QuickSort");
            List<int> testListForQuickSort = new List<int>
            {
                102, 91, 45, 53, 37, 80, 53, 21, 73, 62
            }; 
            var sortedList = QuickSort<int>(testListForQuickSort);
            Console.WriteLine($"Before sort: {String.Join(',', testListForQuickSort)}");
            Console.WriteLine($"After sort: {String.Join(',', sortedList)}");

        }
        public static void PrintNumbers(string inputString)
        {
            Console.WriteLine($"Numbers in string \"{inputString}\":");
            foreach (var symbol in inputString)
            {
                if (Char.IsDigit(symbol))
                {
                    Console.Write(symbol);
                }
            }
            Console.Write('\n');
        }
        public static double TransformDivisionResultToNumberWithTwoValueAfterComa(double firstNumber, double secondNumber)
        {
            Console.WriteLine($"Transformed result of {firstNumber}/{secondNumber}:");
            return Math.Round(firstNumber / secondNumber, 2);
        }
        public static double ReadNumberFromConsoleWithExponentialForm()
        {
            Console.WriteLine($"Input number: ");
            var number = Console.ReadLine();
            var numberParts = number.Split('E');
            var result = Double.Parse(numberParts[0].Trim());
            if (numberParts.Length > 1)
            {
                var exponentialPartOfNumber = Double.Parse(numberParts[1].Trim());
                result = result * Math.Pow(10, exponentialPartOfNumber);
            }
            Console.WriteLine($"Returned number: {result}");
            return result;
        }
        public static string CurrentDateInFormatISO8601()
        {
            var currentDate = DateTime.Now;
            Console.WriteLine($"Current date : {currentDate}");
            var monthPart = currentDate.Month >= 10 ? currentDate.Month.ToString() : $"0{currentDate.Month}";
            var dayPart = currentDate.Day >= 10 ? currentDate.Day.ToString() : $"0{currentDate.Day}";
            var formattedDate = $"{currentDate.Year}-{monthPart}-{dayPart}";
            Console.WriteLine($"Formatted date : {formattedDate}");
            return formattedDate;
        }
        public static DateTime ParseStringToDateTime(string date = "2016 21-07")
        {
            var dateParts = date.Split(' ','-');
            return new DateTime(
                int.Parse(dateParts[0]),
                int.Parse(dateParts[2]),
                int.Parse(dateParts[1]));
        }
        public static int SumOfCommaSeparatedNumbers(string numbers)
        {
            int sum = 0;
            foreach (var number in numbers.Split(','))
            {
                sum += int.Parse(number);
            }
            return sum;
        }
        public static void GetAllSubstringWithFormatTextNumbers(string text)
        {
            Regex reg = new Regex(@"[a-zA-Z]+\d+");
            var result = reg.Matches(text);
            Console.WriteLine($"{text}");
            Console.WriteLine($"Substrings: ");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ToString()}");
            }
        } 
        public static bool PasswordValidator(string password)
        {
            Regex reg = new Regex(@"([a-z]*)([A-Z]*)(\d*)(\w{6,})");
            var result = reg.Match(password);
            Console.WriteLine($"{result.Success}");
            return result.Success;
        }
        public static bool PostCodeValidator(string postCode)
        {
            Regex reg = new Regex(@"\d{3}-\d{3}");
            var result = reg.Match(postCode);
            Console.WriteLine($"{result.Success}");
            return result.Success;
        }
        public static bool PhoneNumberValidator(string phoneNumber)
        {
            Regex reg = new Regex(@"\+\d{3}-\d{2}-\d{3}-\d{2}-\d{2}");
            var result = reg.Match(phoneNumber);
            Console.WriteLine($"{result.Success}");
            return result.Success;
        }
        public static string PhoneNumberReplacer(string text)
        {
            Regex reg = new Regex(@"\+\d{3}-\d{2}-\d{3}-\d{2}-\d{2}");
            var result = reg.Matches(text);
            var resultText = text;
            foreach (var item in result)
            {
                resultText = resultText.Replace(item.ToString(), "+XXX-XX-XXX-XX-XX");
            }
            Console.WriteLine($"Text with replaced phone numbers : {resultText}");
            return resultText;
        }
        public static string[] FirstSymbolsToUpper(string[] names)
        {
            List<string> resultArray = new List<string>();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            foreach (var name in names)
            {
                resultArray.Add(textInfo.ToTitleCase(name));
            }
            foreach(var result in resultArray)
            {
                Console.WriteLine($"Transformed name: {result}");
            }
            return resultArray.ToArray();
        }
        public static string DecodeBase64ToUTF8(string base64String)
        {
            var utf8String = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64String));
            Console.WriteLine($"Decoded string: {utf8String}");
            return utf8String;

        }
        public static List<T> QuickSort<T>(List<T> genericList)
            where T : IComparable
        {
            if (genericList.Count>1)
            {
                int middle = (genericList.Count / 2) - 1;
                if (genericList.Any(x => x.CompareTo(genericList[middle]) != 0))
                {
                    List<T> result = new List<T>();
                    var lessThenMiddle = QuickSort(genericList.Where(x => x.CompareTo(genericList[middle]) < 0).ToList());
                    var equalMiddle = QuickSort(genericList.Where(x => x.CompareTo(genericList[middle]) == 0).ToList());
                    var biggerThenMiddle = QuickSort(genericList.Where(x => x.CompareTo(genericList[middle]) > 0).ToList());
                    if (lessThenMiddle != null)
                    {
                        result.AddRange(lessThenMiddle);
                    }
                    if (equalMiddle != null)
                    {
                        result.AddRange(equalMiddle);
                    }
                    if (equalMiddle != null)
                    {
                        result.AddRange(biggerThenMiddle);
                    }
                    return result;
                }
                return genericList;
            }
            else
            {
                return genericList;
            }
        }
    }
}
