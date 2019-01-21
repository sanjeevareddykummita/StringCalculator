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
        public void Returns_0_When_0_Or_Null_Or_EmptyString(string numbers, int result)
        {
            int actual = GetSumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }
        
        private int GetSumOfNumbers(string numbers)
        {
            var calculatedResult = stringCalc.Add(numbers);
            return calculatedResult;
        }
    }
}
