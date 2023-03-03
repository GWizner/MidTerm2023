using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2023
{
    public class Payment
    {
        //decimal change = 0;
        public decimal Cash(decimal tender, decimal orderTotal)
        {
           decimal change = 0;
           return change = Math.Round(tender - orderTotal); // - orderTotal//
        }

        public void CreditCard()
        {
            Console.Write("Please enter your 16 digit credit card number: ");
            string creditcardnumber = Console.ReadLine();
            Console.WriteLine(" ");
            Console.Write("Please enter your cards expiration date:");
            string expiration = Console.ReadLine();
            Console.WriteLine(" ");
            Console.Write("Please enter your cards cvv number:");
            string cvv = Console.ReadLine();
        }

        public void Check()
        {
            Console.WriteLine("Please enter your check number:");
            int checknunber = int.Parse(Console.ReadLine());
        }
    }
}
