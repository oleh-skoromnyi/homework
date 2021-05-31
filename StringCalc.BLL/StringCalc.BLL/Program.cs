using System;

namespace StringCalc.BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator stringCalc = new StringCalculator();
            string input = "//[*][%]\n2*3%4";
            stringCalc.Add(input);
        }
    }
}
