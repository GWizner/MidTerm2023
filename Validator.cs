using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2023
{
    public class Validator
    {
        public static bool getContinue()
        {
            bool result = true;
            while (true)
            {
                Console.WriteLine();
                Console.Write("Would you like to order anything else? (y/n): ");
                string choice = Console.ReadLine().ToLower().Trim();
                choice = choice.Trim();
                Console.WriteLine();
                if (choice == "y" || choice == "yes")
                {
                    result = true;
                    break;
                }
                else if (choice == "n" || choice == "no")
                {

                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("I do not understand your input. Please try again.");
                    Console.WriteLine();
                }
            }
            return result;
        }
        public static bool GetYesNo(string yesNo)
        {
            if (yesNo.ToLower() == "y" || yesNo.ToLower() == "n")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}