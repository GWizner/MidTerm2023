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
        public int Quantity { get; private set; }
        public Cart(string drinkName, decimal drinkTotal, int quantity)
        {
            Name = drinkName;
            Price = drinkTotal;
            Quantity = quantity;
        }

    }
    public class ViewCart
    {
        public bool CurrentCart(List<Cart> cart, decimal drinkPrice, string userInputA, int itemNo, bool browse)
        {
            if (browse)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (i + 1 == itemNo)
                    {
                        drinkPrice -= cart[i].Price;
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
                    if (cart[i].Name.Equals(userInputA, StringComparison.CurrentCultureIgnoreCase))
                    {
                        drinkPrice -= cart[i].Price;
                        cart.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
