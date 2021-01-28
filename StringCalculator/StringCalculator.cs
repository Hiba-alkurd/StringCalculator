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
                int num;
                if (int.TryParse(character.ToString(), out num))
                    result += num;
            }

            return result;
        }

        static void Main()
        {
            
        }
    }
}
