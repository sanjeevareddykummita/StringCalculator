using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Stringcalculator
    {
        #region Constants
        private readonly List<string> _seperators = new List<string> { ",", "\n" };
        private const string _customseperators = "//";
        private const int _startIndexOfNumbersIncludingCustomSeperator = 3; 
        private const int _startIndexOfCustomSeperator = 2;
        #endregion

        #region Methods

        /// <summary>
        /// Add method to calculate
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Method to handle formats
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>sum</returns>
        private int GetSumOfNumbers(string numbers)
        {
            //try
            //{
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
                    var listOfNumbers = numbers.Split(_seperators.ToArray(), StringSplitOptions.None).Select(int.Parse).ToList();

                    ValidateNumbersAreNonNegative(listOfNumbers);

                    return listOfNumbers.Sum();
                }
                return 0;
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return 0 ;       
            //}
        }

        /// <summary>
        /// Validating non negetive numbers
        /// </summary>
        /// <param name="lstNumbers"></param>
        private static void ValidateNumbersAreNonNegative(IReadOnlyCollection<int> lstNumbers)
        {
            if (!lstNumbers.Any(x => x < 0)) return;

            var NegativeNumbers = string.Join(",", lstNumbers.Where(x => x < 0).Select(x => x.ToString()).ToArray());
            Console.WriteLine("Adding negetive numbers is not allowed.");            
            //System.Environment.Exit(0);
            throw new FormatException("Negatives not Allowed :" + NegativeNumbers + "");
        }

        /// <summary>
        /// Returns substring of input on the seperators 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private string GetNumbersExcludingCustomSeperators(string numbers)
        {
            var startIndexOfString = IncludeCustomSeperatorAndReturnStartIndexOfNumbers(numbers);

            return numbers.Substring(startIndexOfString);
        }

        /// <summary>
        /// Handles the custom seperators 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private int IncludeCustomSeperatorAndReturnStartIndexOfNumbers(string numbers)
        {
            var customSeperators = GetCustomSeperators(numbers); 
            _seperators.AddRange(customSeperators);
            
            return _startIndexOfNumbersIncludingCustomSeperator;
        }


        /// <summary>
        /// Getting the custom Seperators and adding to the seperator list.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static IList<string> GetCustomSeperators(string numbers)
        {
            numbers = ReplaceBackslashN(numbers);

            var allSeperators = numbers.Substring(_startIndexOfCustomSeperator, numbers.IndexOf("\n") - _startIndexOfCustomSeperator);
            var splitSeperators = allSeperators.Split(' ').ToList();

            return splitSeperators;
        }

        /// <summary>
        /// When user enters 1\n2, System will treat this as 1\\n2 . To reduce the double slash to single slash have used the below method.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static string ReplaceBackslashN(string num)
        {
            if (num.Contains("\\n"))
            {
                num = num.Replace("\\n", "\n");
            }

            return num;
        }

        #endregion
    }
}
