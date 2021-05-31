using NUnit.Framework;
using StringCalc.BLL;
using System;

namespace StringCalc.Test
{
    public class Tests
    {
        StringCalculator stringCalc = new StringCalculator();
        [SetUp]
        public void Setup()
        {
            stringCalc = new StringCalculator();
        }

        [Test]
        public void StringCalculator_Add_EmptyStringGiveZero()
        {
            string input = "";
            int result = stringCalc.Add(input);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void StringCalculator_Add_String3Return3()
        {
            string input = "3";
            int result = stringCalc.Add(input);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void StringCalculator_Add_String32Return5()
        {
            string input = "3,2";
            int result = stringCalc.Add(input);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void StringCalculator_Add_String321Return6()
        {
            string input = "3,2,1";
            int result = stringCalc.Add(input);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void StringCalculator_Add_String1n23Return6()
        {
            string input = "1\n,2,3";
            int result = stringCalc.Add(input);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void StringCalculator_Add_String123WithDelimeterReturn6()
        {
            string input = "//;\n1;2;3";
            int result = stringCalc.Add(input);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void StringCalculator_Add_OneNegativeNumberExpectException()
        {
            string input = "//;\n1;-2;3";
            var exception = Assert.Catch(() => stringCalc.Add(input));
            Assert.AreEqual("negatives not allowed -2", exception.Message);
        }

        [Test]
        public void StringCalculator_Add_TwoNegativeNumberExpectExceptionWithBothOfThem()
        {
            string input = "//;\n1;-2;-3";
            var exception = Assert.Catch(() => stringCalc.Add(input));
            Assert.AreEqual("negatives not allowed -2,-3", exception.Message);
        }

        [Test]
        public void StringCalculator_GetCalledCount_ExpectReturn8()
        {
            string input = "";
            int result = stringCalc.Add(input);
            Assert.AreEqual(0, result);
            input = "3";
            result = stringCalc.Add(input);
            Assert.AreEqual(3, result);
            input = "3,2";
            result = stringCalc.Add(input);
            Assert.AreEqual(5, result);
            input = "3,2,1";
            result = stringCalc.Add(input);
            Assert.AreEqual(6, result);
            input = "1\n,2,3";
            result = stringCalc.Add(input);
            Assert.AreEqual(6, result);
            input = "//;\n1;2;3";
            result = stringCalc.Add(input);
            Assert.AreEqual(6, result);
            input = "//;\n1;-2;3";
            var exception = Assert.Catch(() => stringCalc.Add(input));
            Assert.AreEqual("negatives not allowed -2", exception.Message);
            input = "//;\n1;-2;-3";
            exception = Assert.Catch(() => stringCalc.Add(input));
            Assert.AreEqual("negatives not allowed -2,-3", exception.Message);

            var count = stringCalc.GetCalledCount();
            Assert.AreEqual(8, count);
        }

        [Test]
        public void StringCalculator_Add_GreaterThen1000IgnoredExpect6()
        {
            string input = "//;\n1;2;3;1001";
            Assert.AreEqual(6, stringCalc.Add(input));
        }

        [Test]
        public void StringCalculator_Add_DelimeterGreaterThen1SymbolExpect9()
        {
            string input = "//[***]\n2***3***4";
            Assert.AreEqual(9, stringCalc.Add(input));
        }

        [Test]
        public void StringCalculator_Add_TwoDelimetersExpect9()
        {
            string input = "//[*][%]\n2*3%4";
            Assert.AreEqual(9, stringCalc.Add(input));
        }
    }
}