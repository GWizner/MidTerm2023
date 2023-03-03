using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2023
{
    public class Cart
    {

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Cart(string newName, decimal newPrice)
        {
            Name = newName;
            Price = newPrice;
        }

    }
    public class ViewCart
    {
        public bool CurrentCart(List<Cart> cart, decimal total, string userInputA, int itemNo, bool badName, bool browse)
        {
            bool itemRemoved = false;
            if (browse)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (i + 1 == itemNo)
                    {
                        total -= cart[i].Price;
                        cart.RemoveAt(i);
                        badName = false;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].Name.Equals(userInputA, StringComparison.CurrentCultureIgnoreCase))
                    {
                        total -= cart[i].Price;
                        cart.RemoveAt(i);
                        badName = false;
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
