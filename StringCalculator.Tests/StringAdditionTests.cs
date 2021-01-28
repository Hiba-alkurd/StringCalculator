using Xunit;

namespace StringCalculatorCore.Tests
{
    public class StringAdditionTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void Test1(string numbers, int expected)
        {
            //arrange
            var calculator = new StringCalculator();

            //act
            var result = calculator.Add(numbers);

            //assert
            Assert.Equal(expected, result);
        }
    }
}
