﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2023
{
    public class Payment
    {
        //decimal change = 0;
        public static decimal Cash(decimal tender, decimal orderTotal)
        {
            decimal change = 0;
            return change = Math.Round(tender - orderTotal); // - orderTotal//
        }

        public static string CreditCard(string ccnumber, string ccexp, string cccvv)
        {
            if (ccnumber == null || ccexp == null || cccvv == null)
            {
                return "Invalid response";
            }

            else
            {
                return "Payment accepted";
            }
        }

        public static string Check(int checknumber)
        {
            return "Thank you for your payment";
        }
    }
}