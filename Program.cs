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

            Console.WriteLine("Welcome to the " + "\x1b[38;5;207m" + "JavaDrip." + "\x1b[0m\n");

            while (keepAsk)
            {
                CoffeeMenu menu = new CoffeeMenu();

                string addOnNames = null;
                string drinkName = null;
                decimal drinkPrice = 0m;

                                
                Console.WriteLine("Would you like to see our drink menu?");
                string userChoice1 = Console.ReadLine();
                if (userChoice1 == "yes" || userChoice1 == "y")
                {
                    Console.WriteLine();
                    menu.DisplayDrinks();
                    Console.Write("\nEnter the name of your coffee drink: ");
                    drinkName = Console.ReadLine().ToLower();
                    foreach (var drink in menu.drinks)
                    {
                        if (drink.Key.Equals(drinkName, StringComparison.OrdinalIgnoreCase))
                        {
                            cart.Add(new Cart(drinkName, drinkPrice));
                            total = total + drinkPrice;
                        }
                    }

                }

                // Get the user's add-on selections
                Console.Write("Would you like any add-ons?: ");
                string userChoice2 = Console.ReadLine().ToLower();
                if (userChoice2 == "yes" || userChoice2 == "y")
                {
                    menu.DisplayAddOns();
                    Console.Write("Enter add-on selection(s) (please seperate choices by a comma): ");
                    addOnNames = Console.ReadLine();
                }
                string[] addOnChoices = addOnNames.Split(',');


                // Calculate the total price
                drinkPrice = menu.GetDrinkPrice(drinkName);
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

