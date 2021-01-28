using System;

namespace StringCalculatorCore
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "") return 0;

            var result = 0;
            foreach (var character in numbers)
            {
                if ( character == ',') continue;
                result += int.Parse(character+"");
            }

            return result;
        }

        static void Main()
        {
            
        }
    }
}
