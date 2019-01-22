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
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(null, ExpectedResult = 0)]
        [TestCase("", ExpectedResult = 0)]
        public void Returns_Zero_When_Zero_Or_Null_Or_Empty(string numbers, int result) 
        {
            int actual = GetSumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [Test]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("6,10", ExpectedResult = 16)]
        [TestCase("50,100,200", ExpectedResult = 350)]
        public void Returns_Sum_When_ValidNumbersEntered_String(string numbers, int result) 
        {
            int actual = GetSumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [Test]
        [TestCase("//;\n1;2;3", ExpectedResult = 6)]
        [TestCase("//;\n12;20;25", ExpectedResult = 57)]
        [TestCase("//$\n2$6$12", ExpectedResult = 20)]
        [TestCase("//$\n5$15$50", ExpectedResult = 60)]
        public void Returns_Sum_When_CustomSeperatorPrefixed_Numbers(string numbers, int result) 
        {
            int actual = GetSumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        //Method calls from StringCalculator class
        private int GetSumOfNumbers(string numbers)
        {
            var calculatedResult = stringCalc.Add(numbers);
            return calculatedResult;
        }
    }
}
