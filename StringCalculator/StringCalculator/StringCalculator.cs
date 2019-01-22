using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Stringcalculator
    {
        private readonly List<string> _seperators = new List<string> { ",", "\n" };

        public int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers)) return 0;

            numbers = ReplaceBackslashN(numbers);

            return GetSumOfNumbers(numbers);
        }

        private int GetSumOfNumbers(string numbers)
        { 
            if (numbers.Contains("\""))
            {
                  numbers = numbers.Replace("\"", "0");
                
            }
            if (!String.IsNullOrEmpty(numbers.Trim()))
            {
                var lstNumbers = numbers.Split(_seperators.ToArray(), StringSplitOptions.None).Select(int.Parse).ToList();
                return lstNumbers.Sum();
            }
            return 0;
        }

        // When we enter 1\n2 System is treated as 1\\n2 . To reduce the double to single slash n by using below method.
        private static string ReplaceBackslashN(string num)
        {
            if (num.Contains("\\n"))
            {
                num = num.Replace("\\n", "\n");
            }
            return num;
        }
    }
}
