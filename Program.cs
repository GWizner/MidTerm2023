
using System;

namespace MidTerm2023
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cart> cart = new List<Cart>();
            decimal total = 0;
            int itemNo = 0;
            string userInputA = null;
            bool cashOut = false;
            bool browse = true;
            bool badName = false;
            bool keepAsk = true;


            ViewCart mycart = new ViewCart();

            while (keepAsk)
            {
                CoffeeMenu menu = new CoffeeMenu();

                string addOnNames = null;

                // Get the user's drink selection
                Console.Write("Enter the name of your coffee drink: ");
                string drinkName = Console.ReadLine();

                Console.WriteLine("Would you like to see our drink menu?");
                string userChoice1 = Console.ReadLine();
                if (userChoice1 == "yes" || userChoice1 == "y")
                {
                    menu.DisplayDrinks();
                    Console.Write("Enter the name of your coffee drink: ");
                    drinkName = Console.ReadLine();
                }

                // Get the user's add-on selections
                Console.Write("Would you like any add-ons?: ");
                string userChoice2 = Console.ReadLine();
                if (userChoice2 == "yes" || userChoice2 == "y")
                {
                    menu.DisplayAddOns();
                    Console.Write("Enter add-on selection(s) (please seperate choices by a comma): ");
                    addOnNames = Console.ReadLine();
                }
                string[] addOnChoices = addOnNames.Split(',');


                // Calculate the total price
                decimal drinkPrice = menu.GetDrinkPrice(drinkName);
                decimal addOnPrice = 0.0m;
                foreach (string addOnName in addOnChoices)
                {
                    addOnPrice += menu.GetAddOnPrice(addOnName.Trim());
                }
                decimal subtotal = drinkPrice + addOnPrice;
                decimal salesTax = subtotal * 0.06m;
                decimal totalPrice = subtotal + salesTax;

                // Print the receipt
                Console.WriteLine();
                Console.WriteLine($"Your order: {drinkName} with {string.Join(", ", addOnNames)}");
                Console.WriteLine($"Subtotal: ${subtotal:F2}");
                Console.WriteLine($"Sales Tax: ${salesTax:F2}");
                Console.WriteLine($"Total: ${totalPrice:F2}");
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

                        if (Validator.GetYesNo(yesNo))
                        {
                            if (yesNo.ToLower() == "n")
                            {
                                browse = false;
                            }
                            else
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
                                    bool itemRemoved = mycart.CurrentCart(cart, total, userInputA, itemNo, browse);
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
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, didn't catch that.\n");
                            browse = true;
                        }
                    }
                }
                keepAsk = Validator.getContinue();
            }





        }
    }
}
=======
using MidTerm2023;

List<Cart> cart = new List<Cart>();
decimal total = 0;
int itemNo = 0;
string userInputA = null;
bool cashOut = false;
bool browse = true;
bool badName = false;
bool keepAsk = true;


ViewCart mycart = new ViewCart();

while (keepAsk)
{
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

            if (Validator.GetYesNo(yesNo))
            {
                if (yesNo.ToLower() == "n")
                {
                    browse = false;
                }
                else
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
                        bool itemRemoved = mycart.CurrentCart(cart, total, userInputA, itemNo, browse);
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
            }
            else
            {
                Console.WriteLine("\nSorry, didn't catch that.\n");
                browse = true;
            }
        }
    }
    keepAsk = Validator.getContinue();
}

