using MidTerm2023;

List<Cart> cart = new List<Cart>();
decimal total = 0;
int itemNo = 0;
string userInputA = null;
bool cashOut = false;
bool browse = true;
bool badName = false;


ViewCart mycart = new ViewCart();

while (browse)
{
    for (int i = 0; i < cart.Count; i++)
    {
        //Thread.Sleep(500);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(i + 1 + ".{0,-50}", cart[i].Name);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,10:C}", cart[i].Price);
        Console.ResetColor();
    }

    Thread.Sleep(800);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("--------------------------------------------------" +
        "------------");
    Console.Write(String.Format("{0, -52}", "Total: "));
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(String.Format("{0, 10:C}", total));
    Console.ResetColor();

    if (!cashOut)
    {
        Console.WriteLine("\nWould you like to remove any items from your cart (y/n)?\n");
        string yesNo = Console.ReadLine();

        if (yesNo == "y")
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("\nYour cart is currently empty.");
                browse = false;
            }
            else
            {
                Console.WriteLine("Please enter the name or item number of the item you would like to remove: ");
                userInputA = Console.ReadLine().ToLower();
                browse = int.TryParse(userInputA, out itemNo);
                bool itemRemoved = mycart.CurrentCart(cart, total, userInputA, itemNo, badName, browse);
                if (itemRemoved)
                {
                    Console.WriteLine("\nItem not found in list.\n");
                }
                else
                {
                     Console.WriteLine("\nThat item is not in your cart.\n");
                }
            }
        }
        else if (yesNo == "n")
        {
            browse = false;
        }
        else
        {
            Console.WriteLine("\nSorry, didn't catch that.\n");
            browse = true;
        }
    }
}

