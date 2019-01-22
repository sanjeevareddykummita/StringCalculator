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
        private const string _customseperators = "//";
        private const int _startIndexOfNumbersIncludingCustomSeperator = 3; 
        private const int _startIndexOfCustomSeperator = 2; 

        public int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers)) return 0;

            if (numbers.StartsWith(_customseperators))
            {
                numbers = GetNumbersExcludingCustomSeperators(numbers);
            }
            numbers = ReplaceBackslashN(numbers);

            return GetSumOfNumbers(numbers);
        }
        
        private int GetSumOfNumbers(string numbers)
        { 
            if (numbers.Contains("\""))
            {
                  numbers = numbers.Replace("\"", "0");
            }

            if (numbers.IndexOf("\n") == 0)
            {
                numbers = numbers.Substring(1);
            }

            if (!String.IsNullOrEmpty(numbers.Trim()))
            {
                var lstNumbers = numbers.Split(_seperators.ToArray(), StringSplitOptions.None).Select(int.Parse).ToList();
                return lstNumbers.Sum();
            }
            return 0;
        }

        private string GetNumbersExcludingCustomSeperators(string numbers)
        {
            var startIndexOfString = IncludeCustomSeperatorAndReturnStartIndexOfNumbers(numbers);

            return numbers.Substring(startIndexOfString);
        }

        private int IncludeCustomSeperatorAndReturnStartIndexOfNumbers(string numbers)
        {
            var customSeperators = GetCustomSeperators(numbers); 
            _seperators.AddRange(customSeperators);
            
            return _startIndexOfNumbersIncludingCustomSeperator;
        }

        private static IList<string> GetCustomSeperators(string numbers)
        {
            numbers = ReplaceBackslashN(numbers);

            var allSeperators = numbers.Substring(_startIndexOfCustomSeperator, numbers.IndexOf("\n") - _startIndexOfCustomSeperator);

            var splitSeperators = allSeperators.Split('[').Select(x => x.TrimEnd(']')).ToList(); 

            if (splitSeperators.Contains(string.Empty))
            {
                splitSeperators.Remove(string.Empty);
            }

            return splitSeperators;
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
