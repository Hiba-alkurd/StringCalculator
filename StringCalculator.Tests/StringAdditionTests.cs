using System;
using Xunit;

namespace StringCalculatorCore.Tests
{
    public class StringAdditionTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2", 3)]

        public void TestAddingString(string numbers, int expected)
        {
            //arrange
            var calculator = new StringCalculator();

            //act
            var result = calculator.Add(numbers);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("3,-1,2", "negatives not allowed: -1")]
        [InlineData("-1,-2,-3", "negatives not allowed: -1 -2 -3")]
        public void TestNegativeNumbersThrowException(string numbers, string expected)
        {
            //arrange
            var calculator = new StringCalculator();

            //act
            var result = calculator.Add("");

            //assert
            // Assert.Throws<Exception>(() => calculator.Add("2,-1"));
            Exception exception = Assert.Throws<Exception>(() => calculator.Add(numbers));
            Assert.Equal(expected, exception.Message);
        }
    }
}
