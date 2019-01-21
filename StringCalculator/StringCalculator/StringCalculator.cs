using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Stringcalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers)) return 0;

            return GetSumOfNumbers(numbers);
        }

        private int GetSumOfNumbers(string numbers)
        {
            return Add(numbers);
        }

    }
}
