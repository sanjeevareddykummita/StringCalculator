using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter numbers\n");
            string numbers = Console.ReadLine();

            Stringcalculator stringCal = new Stringcalculator();

            int sum = stringCal.Add(numbers);

            Console.WriteLine("The sum of given numbers is: " + sum.ToString());
            Console.ReadKey();
        }

    }
}
