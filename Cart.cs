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
        public int DrinkQuantity { get; private set; }
        public string AddOnName { get; private set; }
        public decimal AddOnPrice { get; private set; }
        public Cart(string drinkName = null, decimal drinkPrice = 0m, int quantity = 0, string addOnName = null, decimal addOnPrice = 0m)
        {
            DrinkName = drinkName;
            DrinkPrice = drinkPrice;
            DrinkQuantity = quantity;
            AddOnName = addOnName;
            AddOnPrice = addOnPrice;


        }
        public void UpdateQuantity(int quantity)
        {
            DrinkQuantity += quantity;
        }
    }
    public class ViewCart
    {
        public decimal TotalPrice { get; private set; }
        public void PrintCart(List<Cart> cart, decimal drinkTotal, decimal addOnTotal, decimal totalPrice)
        {
            TotalPrice = totalPrice;
            decimal subtotal = drinkTotal + addOnTotal;
            decimal salesTax = subtotal * 0.06m;
            totalPrice = subtotal + salesTax;


            for (int i = 0; i < cart.Count; i++)
            {
                drinkTotal = cart[i].DrinkPrice * cart[i].DrinkQuantity;
                //Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0,-15}", cart[i].DrinkName);
                Console.Write("{0, 0}", cart[i].DrinkQuantity);
                Console.WriteLine("\x1b[31m" + "{0,16:C}", drinkTotal);
                Console.Write("{0,-15}", cart[i].AddOnName);
                Console.WriteLine("\x1b[31m" + "{0,17:C}", cart[i].AddOnPrice);
                Console.ResetColor();
            }

            Thread.Sleep(800);
            Console.WriteLine("\x1b[38;5;226m" + "--------------------------------");
            Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Subtotal:" + "\x1b[31m", subtotal);
            Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Sales Tax:" + "\x1b[31m", salesTax);
            Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Total:" + "\x1b[31m", totalPrice);
            Console.ResetColor();
        }
        public bool CurrentCart(List<Cart> cart, decimal drinkPrice, decimal drinkTotal, string userInputA, int itemNo, int quantity, bool browse)
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
