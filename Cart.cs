using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2023
{
    public class Cart
    {

        public string DrinkName { get; private set; }
        public decimal DrinkPrice { get; private set; }
        public decimal DrinkTotal { get; private set; }
        public int DrinkQuantity { get; private set; }
        public string AddOnName { get; private set; }
        public decimal AddOnPrice { get; private set; }

        decimal totalPrice = 0m;

        public Cart(string drinkName = null, decimal drinkPrice = 0m, decimal drinkTotal = 0m, int quantity = 0, string addOnName = null, decimal addOnPrice = 0m)
        {
            drinkTotal = drinkPrice * quantity;

            DrinkName = drinkName;
            DrinkPrice = drinkPrice;
            DrinkTotal = drinkTotal; 
            DrinkQuantity = quantity;
            AddOnName = addOnName;
            AddOnPrice = addOnPrice;
            

            
        }
    }
    public class ViewCart
    {
        public decimal GrandTotal { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal SalesTax { get; private set; }
        public void PrintCart(List<Cart> cart, decimal drinkTotal, decimal addOnTotal, decimal grandTotal)
        {
            GrandTotal = grandTotal;
            decimal totalPrice = 0m;
            decimal subtotal = drinkTotal + addOnTotal;
            decimal salesTax = subtotal * 0.06m;
            SubTotal = subtotal;
            SalesTax = salesTax;


            for (int i = 0; i < cart.Count; i++)
            {
                totalPrice += cart[i].DrinkTotal;
                addOnTotal += cart[i].AddOnPrice;

                if (cart[i].DrinkName != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0,-15}", cart[i].DrinkName);
                    Console.Write("\x1b[38;5;80m" + "{0}", cart[i].DrinkQuantity);
                    Console.WriteLine("\x1b[31m" + "{0,16:C}", cart[i].DrinkTotal);
                    Console.ForegroundColor = ConsoleColor.Green;
                }


                if (cart[i].AddOnName != null)
                {
                    Console.Write("{0,-15}", cart[i].AddOnName);
                    Console.Write("{0}", cart[i].DrinkQuantity);
                    Console.WriteLine("\x1b[31m" + "{0,16:C}", cart[i].AddOnPrice);
                    Console.ResetColor();  
                }


                subtotal = totalPrice + addOnTotal;
                salesTax = subtotal * 0.06m;
                grandTotal = subtotal + salesTax;
                GrandTotal = grandTotal;
            }
            
            Thread.Sleep(800);
            Console.WriteLine("\x1b[38;5;226m" + "--------------------------------");
            Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Subtotal:" + "\x1b[31m", subtotal);
            Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Sales Tax:" + "\x1b[31m", salesTax);
            Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Total:" + "\x1b[31m", grandTotal);
            Console.ResetColor();

        }
        public bool CurrentCart(List<Cart> cart, decimal drinkTotal, string userInputA, int itemNo, int quantity, bool browse)
        {
            if (browse)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (i + 1 == itemNo)
                    {
                        drinkTotal -= cart[i].DrinkPrice;
                        quantity -= 1;
                        cart.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].DrinkName.Equals(userInputA, StringComparison.CurrentCultureIgnoreCase))
                    {
                        drinkTotal -= cart[i].DrinkPrice;
                        quantity -= 1;
                        cart.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}