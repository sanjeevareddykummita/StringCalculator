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
            Program obj = new Program();
            obj.UserActions();
        }
        public void UserActions()
        {
            Console.WriteLine("Please enter numbers: \n");
            string numbers = Console.ReadLine();

            Stringcalculator stringCal = new Stringcalculator();

            int sum = stringCal.Add(numbers);

            Console.WriteLine("The sum of given numbers is: " + sum.ToString() + "\n");           
            Console.WriteLine("Do you wish to Continue the process? : Y/N");
            String userInput = Console.ReadLine();
            
            if (userInput == "Y" || userInput == "y" || userInput == "Yes" || userInput == "yes")
            {
                UserActions();
            }
            else if (userInput == "N" || userInput == "n" || userInput == "No" || userInput == "no")
            {
                System.Environment.Exit(0);
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

    }
}
