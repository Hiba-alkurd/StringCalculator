using System;
using Xunit;

namespace StringCalculatorCore.Tests
{
   
    public class StringAdditionTests
    {
        StringCalculator calculator;

        public StringAdditionTests()
        {
            this.calculator = new StringCalculator();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2", 3)]
        public void TestAddingStringWithDelimiters(string numbers, int expected)
        {
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
            //act and assert
            // Assert.Throws<Exception>(() => calculator.Add("2,-1"));
            Exception exception = Assert.Throws<Exception>(() => calculator.Add(numbers));
            Assert.Equal(expected, exception.Message);
        }

        [Theory]
        [InlineData("1,999", 1000)]
        [InlineData("1,1000", 1001)]
        [InlineData("2,1002", 2)]
        public void TestIgnoreBigNumbers(string numbers, int expected)
        {
            //act
            var result = calculator.Add(numbers);

            //assert
            Assert.Equal(expected, result);
        }

    }
}
