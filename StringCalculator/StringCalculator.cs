using System;
using System.Linq;

namespace StringCalculatorCore
{
    public class StringCalculator
    {
        string[] delimiters = new string[3] {",", "\n" , ""};
        string defaultDelimiter = ",";
        public int Add(string numbers)
        {
            if (numbers == "") return 0;

            numbers = Parsedelimiters(numbers);
            Console.WriteLine(numbers);
            var result = 0;
            var currentNumber = 0;
            bool numParsing = false;

            foreach (var character in numbers)
            {
                if (character.ToString() == defaultDelimiter)
                    numParsing = false;
                else
                {
                    int num = int.Parse(character.ToString());
                    if (numParsing)
                    {
                        currentNumber = currentNumber * 10 + num;
                    }
                    else
                    {
                        result += currentNumber;
                        currentNumber = num;
                    }
                    numParsing = true;
                }
            }

            result += currentNumber;

            return result;
        }

        string Parsedelimiters(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                delimiters[2] = numbers[2..numbers.IndexOf("\n")];
                numbers = numbers[numbers.IndexOf("\n")..];
              
                return numbers.Replace(delimiters[2], defaultDelimiter).Trim();
            }
            
            return numbers.Replace(delimiters[1], defaultDelimiter).Trim();
        }

        static void Main()
        {
        }
    }
}
