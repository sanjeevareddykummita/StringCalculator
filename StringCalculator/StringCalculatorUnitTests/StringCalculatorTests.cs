using System;
using StringCalculator;
using NUnit.Framework;

namespace StringCalculatorUnitTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private Stringcalculator stringCalc;

        [SetUp]
        public void SetUp()
        {
            stringCalc = new Stringcalculator();
        }

        [Test]
        [TestCase("0", 0)]
        [TestCase(null, 0)]
        [TestCase("", 0)]
        public void Returns_Zero_When_Zero_Or_Null_Or_Empty(string numbers, int result) 
        {
            int actual = GetSumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("6,10", 16)]
        [TestCase("50,100,200", 350)]
        public void Returns_Sum_When_ValidNumbersEntered_String(string numbers, int result) 
        {
            int actual = GetSumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [Test]
        [TestCase("//;\n1;2;3", 6)]
        [TestCase("//;\n12;20;25", 57)]
        [TestCase("//$\n2$6$12", 20)]
        [TestCase("//$\n5$15$50", 70)]
        public void Returns_Sum_When_CustomSeperatorPrefixed_Numbers(string numbers, int result) 
        {
            int actual = GetSumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [Test]
        [TestCase("-5", -5)]
        [TestCase("12,-12", 0)]
        [TestCase("1,-2,3,-4,-5,6", -1)]
        [TestCase("9\n-11,23", 21)]
        [TestCase("//;\n31;-54;-92", -115)]
        [TestCase("//;\n1;2;3", 6)]
        public void Throws_Exception_When_NegativeNumberIn_String(string numbers, int result)
        {
            try
            {
                int actual = GetSumOfNumbers(numbers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Method calls from StringCalculator class
        private int GetSumOfNumbers(string numbers)
        {
            var calculatedResult = stringCalc.Add(numbers);
            return calculatedResult;
        }
    }
}
