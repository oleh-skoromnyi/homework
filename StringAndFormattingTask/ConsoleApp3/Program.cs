using System;
using System.Text.RegularExpressions;

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
            Console.WriteLine("   Part d");
            PhoneNumberReplacer("My phone number +380-98-123-45-67");
        }
        //1)	Написать метод, который принимает строку и печатает на экран все ее символы, которые являются цифрой.
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
        //2)	Преобразовать результат деления двух чисел в число с 2-мя знаками после запятой.
        public static double TransformDivisionResultToNumberWithTwoValueAfterComa(double firstNumber, double secondNumber)
        {
            Console.WriteLine($"Transformed result of {firstNumber}/{secondNumber}:");
            return Math.Round(firstNumber / secondNumber, 2);
        }
        //3)	Прочитать целое число с консоли. Разрешить ввод в экспоненциальной форме.
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
        //4)	Представить текущую дату и время в формате ISO-8601 
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
        //5)	Дана строка с датой: “2016 21-07”. Распарсить в DateTime.
        public static DateTime ParseStringToDateTime(string date = "2016 21-07")
        {
            var dateParts = date.Split(' ','-');
            return new DateTime(
                int.Parse(dateParts[0]),
                int.Parse(dateParts[2]),
                int.Parse(dateParts[1]));
        }
        //6)	Дана строка с целыми числами через запятую. Посчитать сумму всех чисел.
        public static int SumOfCommaSeparatedNumbers(string numbers)
        {
            int sum = 0;
            foreach (var number in numbers.Split(','))
            {
                sum += int.Parse(number);
            }
            return sum;
        }
        //7)	Регулярные выражения:
        //a)	Найти в тексте все подстроки, которые имеют вид “текст123” (любое кол-во символов за которыми следует любое кл-во чисел).
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
        //b)	Валидировать пароль пользователя по след. правилам: минимальная длина - 6 символов, минимум одна прописная буква, заглавная, цифра.
        public static bool PasswordValidator(string password)
        {
            Regex reg = new Regex(@"([a-z]*)([A-Z]*)(\d*)(\w{6,})");
            var result = reg.Match(password);
            Console.WriteLine($"{result.Success}");
            return result.Success;
        }
        //c)	Валидировать ввод на Post Code по след. правилу: 3 цифры, тире, 3 цифры (123-456).
        public static bool PostCodeValidator(string postCode)
        {
            Regex reg = new Regex(@"\d{3}-\d{3}");
            var result = reg.Match(postCode);
            Console.WriteLine($"{result.Success}");
            return result.Success;
        }
        //d)	Валидировать ввод на телефонный номер формата +380-98-123-45-67.
        public static bool PhoneNumberValidator(string phoneNumber)
        {
            Regex reg = new Regex(@"\+\d{3}-\d{2}-\d{3}-\d{2}-\d{2}");
            var result = reg.Match(phoneNumber);
            Console.WriteLine($"{result.Success}");
            return result.Success;
        }
        //e)	Заменить все телефонные номера в тексте(по шаблону выше) на строку "+XXX-XX-XXX-XX-XX”
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
    }
}
