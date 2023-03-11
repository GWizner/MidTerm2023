namespace MidTerm2023
{
    class Program
    {
        static void Main(string[] args)
        {
            string addOnName = null;
            string selectedAddOn = null;
            string drinkName = null;
            string selectedName = null;
            string selectedNames = null;
            string selectedDrinkName = null;
            int quantity = 0;
            int drinkNum = 0;
            decimal drinkPrice = 0m;
            decimal addOnPrice = 0m;
            decimal addOnTotal = 0m;
            decimal drinkTotal = 0m;
            decimal subtotal = 0m;
            decimal salesTax = 0m;
            decimal totalPrice = 0m;

            bool goodDrink = false;
            bool endsWithS = false;


            List<Cart> cart = new List<Cart>();
            int itemNo = 0;
            string userInputA = null;
            bool cashOut = false;
            bool browse = true;
            bool badName = false;
            bool keepAsk = true;

            CoffeeMenu menu = new CoffeeMenu(drinkName, drinkNum);
            ViewCart myCart = new ViewCart();
            //Cart currCart = new Cart(drinkName, drinkPrice, quantity/*, addOnName, addOnPrice*/);

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
                            drinkPrice = menu.drinks[selectedDrinkName];
                            selectedName = selectedDrinkName;
                        }
                        else
                        {
                            drinkPrice = menu.drinks[selectedName];
                        }

                        if (selectedName.EndsWith('s'))
                        {
                            endsWithS = true;
                        }
                        if (endsWithS)
                        {
                            Console.Write($"\nHow many {selectedName}es would you like? ");
                        }
                        else
                        {
                            Console.Write($"\nHow many {selectedName}s would you like? ");
                        }
                        bool userDrinks = int.TryParse(Console.ReadLine(), out quantity);
                        //int myQuantity = quantity;
                        //cart.Add(new Cart(selectedName, drinkPrice, quantity));

                        // Get the user's add-on selections
                        if (quantity == 1)
                        {
                            Console.WriteLine($"\nOkay {quantity} {selectedName} ");
                        }
                        else if (endsWithS)
                        {
                            Console.Write($"\nOkay {quantity} {selectedName}es ");
                        }
                        else
                        {
                            Console.Write($"\nOkay {quantity} {selectedName}s ");
                        }
                        Console.Write("would you like any add-ons (y/n)? ");
                        string userChoice2 = Console.ReadLine().ToLower();
                        Console.WriteLine();

                        if (userChoice2 == "yes" || userChoice2 == "y")
                        {
                            menu.DisplayAddOns();
                            Console.Write("\nEnter add-on selection(s) (please seperate choices by a comma): ");
                            addOnName = Console.ReadLine();
                        }

                        foreach (var drink in menu.drinks)
                        {
                            if (drink.Key.Equals(drinkName, StringComparison.OrdinalIgnoreCase))
                            {
                                //drinkTotal += drinkPrice;
                                //if (quantity == 0)
                                if (quantity == 1)
                                {
                                    cart.Add(new Cart(selectedName, drinkPrice, quantity));
                                }
                                else
                                {
                                    for (int i = 0; i < quantity; i++)
                                    {
                                        cart.Add(new Cart(selectedName, drinkPrice));
                                    }
                                    cart.Add(new Cart(quantity: quantity));
                                }
                                //drinkTotal = drinkTotal + menu.drinks[selectedName];
                                break;
                            }
                            else if (menu.drinkMenu.ContainsKey(drinkNum))
                            {
                                //drinkTotal += drinkPrice;
                                if (quantity == 1)
                                {
                                    cart.Add(new Cart(selectedDrinkName, drinkPrice, quantity));
                                }
                                else
                                {
                                    for (int i = 0; i < quantity; i++)
                                    {
                                        cart.Add(new Cart(selectedDrinkName, drinkPrice, quantity));
                                    }
                                    //cart.Add(new Cart(quantity: myQuantity));
                                }
                                //drinkTotal = drinkTotal + menu.drinks[selectedName];
                                break;
                            }
                        }

                        if (addOnName != null)
                        {
                            string[] addOnChoices = addOnName.Split(',', StringSplitOptions.RemoveEmptyEntries);
                            foreach (string name in addOnChoices)
                            {
                                foreach (KeyValuePair<string, decimal> addOn in menu.addOns)
                                {
                                    if (string.Equals(name.Trim(), addOn.Key, StringComparison.OrdinalIgnoreCase))
                                    {
                                        cart.Add(new Cart(quantity: 1, addOnName: addOn.Key, addOnPrice: addOn.Value));
                                        break;
                                    }
                                }
                                //foreach (string addOn in addOnChoices)
                                //{
                                //    selectedAddOn = menu.addOns.Keys.FirstOrDefault(x => x.Equals(addOn, StringComparison.OrdinalIgnoreCase));
                                //    decimal addOnChoicePrice = menu.GetAddOnPrice(selectedAddOn);
                                //    addOnPrice += addOnChoicePrice;
                                //    cart.Add(new Cart(addOn, addOnPrice));
                                //}
                            }
                        }
                    }
                    for (int i = 0; i < cart.Count; i++)
                    {
                        addOnTotal += cart[i].AddOnPrice;
                    }
                    drinkTotal = drinkPrice * quantity;
                    subtotal = drinkTotal + addOnTotal;
                    salesTax = subtotal * 0.06m;
                    totalPrice = subtotal + salesTax;

                    while (browse)
                    {
                        //myCart.PrintCart(cart, drinkTotal, addOnPrice, totalPrice);
                        int i = 0;
                        HashSet<string> drinkNames = new HashSet<string>();
                        //while (i < cart.Count)
                        //{
                        for (i = 0; i < cart.Count; i++)
                        {
                            string thisDrinkName = cart[i].DrinkName;
                            //decimal thisDrinkPrice = cart[i].DrinkPrice;
                            int thisDrinkQuantity = cart[i].DrinkQuantity;
                            //Thread.Sleep(500);
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (!drinkNames.Contains(thisDrinkName))
                            {
                                Console.Write("{0,-15}", thisDrinkName);
                                Console.Write("\x1b[38;5;80m" + "{0}", thisDrinkQuantity);
                                Console.WriteLine("\x1b[31m" + "{0,16:C}", drinkTotal);
                                drinkNames.Add(thisDrinkName);
                                //break;
                            }

                            if (cart[i].AddOnName != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("{0,-15}", cart[i].AddOnName);
                                Console.Write("{0}", 1);
                                Console.WriteLine("\x1b[31m" + "{0,16:C}", cart[i].AddOnPrice);
                                Console.ResetColor();
                            }
                        }
                        //}
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
                                        bool itemRemoved = myCart.CurrentCart(cart, drinkPrice, userInputA, itemNo, browse);
                                        if (!itemRemoved)
                                        {
                                            Console.WriteLine("\nThat item is not in your cart.\n");
                                        }
                                        else
                                        {
                                            myCart.PrintCart(cart, drinkTotal, addOnPrice, totalPrice);
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
                }
                keepAsk = Validator.getContinue();
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
                Console.WriteLine("\x1b[38;5;226m" + "--------------------------------");
                Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Subtotal:" + "\x1b[31m", subtotal);
                Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Sales Tax:" + "\x1b[31m", salesTax);
                Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Total:" + "\x1b[31m", totalPrice);
                Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Tender:" + "\x1b[31m", tender);
                Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Change:" + "\x1b[31m", change);
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

                Console.WriteLine(Payment.CreditCard(creditcardnumber, expiration, cvv));

            }

            else if (tenderType == "Check" || tenderType == "check" || tenderType == "3")
            {
                Console.WriteLine("Please enter the check number:");
                int checknumber = int.Parse(Console.ReadLine());
                Console.WriteLine(Payment.Check(checknumber));
            }
        }
    }
}



