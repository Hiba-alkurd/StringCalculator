using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorCore
{
    public class StringCalculator
    {
        const int MaxNumber = 1000;
        readonly string[] delimiters = {",", "\n"};
        string defaultDelimiter;
        readonly List<int> negativeNum = new List<int>();

        public int Add(string numbers)
        {
            if (numbers == "") return 0;

            var numbersStringArray = ParseDelimiters(numbers);
            var numbersArray = ParseStringtoInt(numbersStringArray);

            var result = 0;
            for (var i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] < 0)
                    negativeNum.Add(numbersArray[i]);
                if (numbersArray[i] > MaxNumber)
                    result += 0;
                else result += numbersArray[i];
            }

             if (negativeNum.Count != 0 )
                throw new Exception("negatives not allowed: " + string.Join(" ", negativeNum));
            
            return result;
        }

        private int[] ParseStringtoInt(string[] numbersStringArray)
        {
            int[] nums = new int[numbersStringArray.Length];

            for (int i = 0; i < numbersStringArray.Length; i++)
            {
                 int.TryParse(numbersStringArray[i], out nums[i]);
            }

            return nums;
        }

        private string[] ParseDelimiters(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                defaultDelimiter = numbers[2..numbers.IndexOf("\n")];
                numbers = numbers[numbers.IndexOf("\n")..];

                return numbers.Split(new string[] { defaultDelimiter }, StringSplitOptions.None);
            }

            return numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        static void Main()
        {

        }
    }
}
