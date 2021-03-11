using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorCore
{
    public class StringCalculator
    {
        const int MaxNumber = 1000;
        readonly string[] delimiters = {",", "\n"};
        

        public int Add(string numbers)
        {
            
            List<int> negativeNum = new List<int>();

            if (String.IsNullOrWhiteSpace(numbers)) return 0;

            var numbersStringArray = ParseDelimiters(numbers);
            var numbersArray = ParseStringtoInt(numbersStringArray);

            negativeNum = numbersArray.Where(num => num < 0).ToList();
            if (negativeNum.Count != 0)
                throw new Exception("negatives not allowed: " + string.Join(" ", negativeNum));

            return numbersArray.Where(num => num <= MaxNumber).Sum();
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
            string defaultDelimiter;

            if (numbers.StartsWith("//"))
            {
                defaultDelimiter = numbers[2..numbers.IndexOf("\n")];
                numbers = numbers[numbers.IndexOf("\n")..];

                return numbers.Split(new string[] { defaultDelimiter }, StringSplitOptions.None);
            }

            return numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
