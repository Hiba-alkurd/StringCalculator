using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorCore
{
    public class StringCalculator
    {
        string[] delimiters = new string[3] {",", "\n" , ""};
        string defaultDelimiter = ",";
        List<int> negativeNum = new List<int>();
        public int Add(string numbers)
        {
            if (numbers == "") return 0;

            numbers = Parsedelimiters(numbers);
            Console.WriteLine(numbers);
            var result = 0;
            var currentNumber = 0;
            bool numParsing = false;

            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].ToString() == defaultDelimiter)
                    numParsing = false;
                else if(numbers[i].ToString() == "-")
                {
                    negativeNum.Add(-1 * int.Parse(numbers[i + 1].ToString()));
                }
                else
                {
                    int num = int.Parse(numbers[i].ToString());
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

            if(negativeNum.Count != 0 )
                throw new Exception("negatives not allowed: " + string.Join(" ", negativeNum));

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
