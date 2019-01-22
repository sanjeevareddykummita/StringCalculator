using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Stringcalculator
    {
        private readonly List<string> _seperators = new List<string> { "," };
        public int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers)) return 0;

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

    }
}
