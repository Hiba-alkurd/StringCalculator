using System;

namespace StringCalculatorCore
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "") return 0;

            var result = 0;
            var currentNumber = 0;
            bool numParsing = false;
            foreach (var character in numbers)
            {
                int num;
                if (int.TryParse(character.ToString(), out num))
                {
                    if (numParsing)
                        currentNumber = currentNumber * 10 + num;
                    else
                    {
                        result += currentNumber;
                        currentNumber = num;
                    }
                    numParsing = true;
                }

                else numParsing = false;
            }
            result += currentNumber;

            return result;
        }

        static void Main()
        {

        }
    }
}
