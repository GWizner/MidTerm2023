namespace MidTerm2023
{
    class Program
    {
        static void Main(string[] args)
        {
            string addOnNames = null;
            string drinkName = null;
            string selectedName = null;
            string selectedDrinkName = null;
            int quantity = 0;
            int drinkNum = 0;
            decimal drinkPrice = 0m;
            decimal addOnPrice = 0.0m;
            bool goodDrink = false;

            List<Cart> cart = new List<Cart>();
            int itemNo = 0;
            string userInputA = null;
            bool cashOut = false;
            bool browse = true;
            bool badName = false;
            bool keepAsk = true;

            CoffeeMenu menu = new CoffeeMenu(drinkName, drinkNum);
            ViewCart mycart = new ViewCart();

            Console.WriteLine("Welcome to the " + "\x1b[38;5;207m" + "JavaDrip" + "\x1b[0m" + ".\n");

            while (keepAsk)
            {
                Console.WriteLine("Would you like to see our drink menu (y/n)? ");
                string userChoice1 = Console.ReadLine();
                if (userChoice1 == "yes" || userChoice1 == "y")
                {
                    Console.WriteLine();
                    menu.DisplayDrinks();
                    Console.Write("\nEnter the name of your coffee drink: ");
                    drinkName = Console.ReadLine().ToLower();
                    goodDrink = int.TryParse(drinkName, out drinkNum);
                    selectedName = menu.drinks.Keys.FirstOrDefault(x => x.Equals(drinkName, StringComparison.OrdinalIgnoreCase));

                    if (selectedName != null || goodDrink)
                    {
                        if (goodDrink)
                        {
                            selectedDrinkName = menu.drinkMenu[drinkNum];
                            //drinkPrice = menu.drinks[selectedDrinkName];
                            selectedName = selectedDrinkName;
                        }
                        else
                        {
                            //drinkPrice = menu.drinks[selectedName];
                        }
                        foreach (var drink in menu.drinks)
                        {
                            if (drink.Key.Equals(drinkName, StringComparison.OrdinalIgnoreCase))
                            {
                                cart.Add(new Cart(selectedName, drinkPrice, quantity));
                                drinkPrice = drinkPrice + menu.drinks[selectedName];
                                break;
                            }
                            else if (menu.drinkMenu.ContainsKey(drinkNum))
                            {
                                cart.Add(new Cart(selectedDrinkName, drinkPrice, quantity));
                                drinkPrice = drinkPrice + menu.drinks[selectedDrinkName];
                                break;
                            }
                        }

                        if (selectedName.EndsWith('s'))
                        {
                            Console.Write($"\nHow many {selectedName}es would you like? ");
                        }
                        else
                        {
                            Console.Write($"\nHow many {selectedName}s would you like? ");
                        }
                        quantity = int.Parse(Console.ReadLine());
                        //cart.Add(new Cart(selectedName, drinkPrice, quantity));
                    }

                }

                // Get the user's add-on selections
                Console.Write("\nWould you like any add-ons (y/n)? ");
                string userChoice2 = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (userChoice2 == "yes" || userChoice2 == "y")
                {
                    menu.DisplayAddOns();
                    Console.Write("\nEnter add-on selection(s) (please seperate choices by a comma): ");
                    addOnNames = Console.ReadLine();
                }
                string selectedAddOns = menu.addOns.Keys.FirstOrDefault(x => x.Equals(addOnNames, StringComparison.OrdinalIgnoreCase));

                if (selectedAddOns != null)
                {
                    string[] addOnChoices = selectedAddOns.Split(',');

                    // Calculate the total price
                    drinkPrice = menu.GetDrinkPrice(drinkName, selectedDrinkName, drinkNum);
                    foreach (string addOnName in addOnChoices)
                    {
                        addOnPrice += menu.GetAddOnPrice(addOnName);
                    }
                }
                decimal subtotal = drinkPrice + addOnPrice;
                decimal salesTax = subtotal * 0.06m;
                decimal totalPrice = subtotal + salesTax;

                

                while (browse)
                {
                    for (int i = 0; i < cart.Count; i++)
                    {
                        //Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0,-15}", cart[i].Name);
                        Console.Write("{0, 0}", cart[i].Quantity);    
                        Console.WriteLine("\x1b[31m" + "{0,16:C}", cart[i].Price);
                        Console.ResetColor();
                    }

                    Thread.Sleep(800);
                    Console.WriteLine("\x1b[38;5;226m" + "--------------------------------");
                    Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Subtotal:" + "\x1b[31m", subtotal);
                    Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Sales Tax:" + "\x1b[31m", salesTax);
                    Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Total:" + "\x1b[31m", totalPrice);
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
                                    bool itemRemoved = mycart.CurrentCart(cart, subtotal, userInputA, itemNo, browse);
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
                    Console.WriteLine("\nHow would you like to pay today?\n");
                    Console.WriteLine("1. Cash");
                    Console.WriteLine("2. Credit Card");
                    Console.WriteLine("3. Check");

                    string tenderType = Console.ReadLine();

                    if (tenderType == "Cash" || tenderType == "cash" || tenderType == "1")
                    {
                        Console.WriteLine("Enter the amount given by customer.");
                        decimal tender = decimal.Parse(Console.ReadLine());
                        decimal change = Payment.Cash(tender, totalPrice);
                    }

                    else if (tenderType == "Credit Card" || tenderType == "credit card" || tenderType == "2")
                    {
                        Console.Write("Please enter your 16 digit credit card number: ");
                        string creditcardnumber = Console.ReadLine();
                        Console.WriteLine(" ");
                        Console.Write("Please enter your cards expiration date:");
                        string expiration = Console.ReadLine();
                        Console.WriteLine(" ");
                        Console.Write("Please enter your cards cvv number:");
                        string cvv = Console.ReadLine();

                        Payment.CreditCard(creditcardnumber, expiration, cvv);
                    }

                    else if (tenderType == "Check" || tenderType == "check" || tenderType == "3")
                    {
                        Console.WriteLine("Please enter the check number:");
                        int checknumber = int.Parse(Console.ReadLine());
                        Payment.Check(checknumber);
                    }

                }
                keepAsk = Validator.getContinue();
            }
        }
    }
}

