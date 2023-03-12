using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Threading.Channels;

namespace MidTerm2023
{
    class Program
    {
        static void Main(string[] args)
        {
            string addOnName = null;
            string drinkName = null;
            string userDrink = null;
            string userInputA = null;
            string name = null;
            string description = null;
            string selectedName = null;

            //string selectedAddOn = null;


            //string selectedNames = null;
            //string selectedDrinkName = null;

            int quantity = 0;
            int drinkNum = 0;
            int itemNo = 0;
            int id = 0;

            decimal drinkPrice = 0m;
            decimal addOnPrice = 0m;
            decimal addOnTotal = 0m;
            decimal drinkTotal = 0m;
            decimal subtotal = 0m;
            decimal salesTax = 0m;
            decimal totalPrice = 0m;
            decimal price = 0;

            //bool badName = false;
            bool goodDrink = false;
            bool endsWithS = false;
            bool cashOut = false;
            bool browse = true;
            bool keepAsk = true;
            bool viewMenu = true;
            bool noMenu = true;
            
            CoffeeMenu menu = new CoffeeMenu(id, name, description, price);
            ViewCart myCart = new ViewCart();
            List<Cart> cart = new List<Cart>();
            List<CoffeeMenu> coffees = new List<CoffeeMenu>()
            {
                new CoffeeMenu (1, "Espresso", "Strong.", 2.50m) ,
                new CoffeeMenu (2, "Cappuccino", "Classic.", 3.50m),
                new CoffeeMenu (3, "Latte", "Frothed milk.", 4.00m),
                new CoffeeMenu (4, "Americano", "Hot.", 3.00m),
                new CoffeeMenu (5, "Mocha", "Chocolate.", 4.50m),
                new CoffeeMenu (6, "Macchiato", "Beverage.", 3.50m),
                new CoffeeMenu (7, "Flat White", "Similar.", 4.50m),
                new CoffeeMenu (8, "Irish Coffee", "Cocktail.", 6.00m),
                new CoffeeMenu (9, "Affogato", "Vanilla.", 5.00m),
                new CoffeeMenu (10, "French Press", "Coarse.", 6.50m),
                new CoffeeMenu (11, "Cold Brew", "Cold.", 4.50m),
                new CoffeeMenu (12, "Nitro Cold Brew", "Nitrogen.", 5.00m),
                new CoffeeMenu (13, "Iced Coffee", "Iced.", 3.50m)
            };


            Console.WriteLine("Welcome to the " + "\x1b[38;5;207m" + "JavaDrip" + "\x1b[0m" + ".\n");



            while (keepAsk)
            {

                bool goodAns = false;
                
                while (viewMenu)
                {
                    int counter = 1;
                    foreach (CoffeeMenu coffee in coffees)
                    {
                        if (counter > 9)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0, -1}{1, -20}", coffee.Id + ". ", coffee.Name);
                            Console.Write("{0, -30}", "\x1b[38;5;94m" + coffee.Description);
                            Console.WriteLine("{0, 10:C}", "\x1b[31m" + coffee.Price + "\x1b[0m");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0, -1}{1, -21}", coffee.Id + ". ", coffee.Name);
                            Console.Write("{0, -30}", "\x1b[38;5;94m" + coffee.Description);
                            Console.WriteLine("{0, 10:C}", "\x1b[31m" + coffee.Price + "\x1b[0m");
                        }
                        counter++;
                        //Console.WriteLine("{0, -1}{1, -20}{2, -30}{3, 10:C}", coffee.Id + ". ", coffee.Name + 
                        //    "\x1b[38;5;94m" + coffee.Description + "\x1b[31m", "", coffee.Price + "\x1b[0m");
                    }

                    while (noMenu)
                    {
                        while (!goodAns)
                        {
                            Console.Write("\nEnter the name of your coffee drink: ");
                            userDrink = Console.ReadLine().ToLower();
                            goodDrink = int.TryParse(userDrink, out drinkNum);
                            //selectedName = coffees.FirstOrDefault(x => x.Name.Equals(userDrink, StringComparison.OrdinalIgnoreCase));


                            if (goodDrink)
                            {
                                if (drinkNum < 1 || drinkNum > 13)
                                {
                                    Console.WriteLine("We do not have a drink with that number. Please try again.\n");
                                }
                                else if (drinkNum >= 1 && drinkNum <= 13)
                                {
                                    selectedName = coffees[drinkNum - 1].Name;
                                    goodAns = true;
                                }
                            }
                            else if (!goodDrink)
                            {
                                if (coffees.Any(x => x.Name.Equals(userDrink, StringComparison.CurrentCultureIgnoreCase)))
                                {
                                    foreach (CoffeeMenu coffeeSearch in coffees)
                                    {
                                        if (coffeeSearch.Name.Equals(userDrink, StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            selectedName = coffeeSearch.Name;
                                            goodAns = true;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("I do not understand your input. Please try again.\n");
                                }
                            }
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

                        foreach (CoffeeMenu drink in coffees)
                        {
                            if (drink.Name.Equals(drinkName, StringComparison.OrdinalIgnoreCase))
                            {
                                Cart? existingItem = cart.FirstOrDefault(item => item.DrinkName == drinkName && item.DrinkPrice == drinkPrice);
                                if (existingItem != null)
                                {
                                    existingItem.UpdateQuantity(quantity);
                                }
                                else
                                {
                                    cart.Add(new Cart(drinkName, drinkPrice, quantity));
                                }
                                break;
                            }
                            else if (drink.Id == drinkNum)
                            {
                                //drinkTotal += drinkPrice;
                                if (quantity == 1)
                                {
                                    cart.Add(new Cart(drinkName, drinkPrice, quantity));
                                }
                                else
                                {
                                    for (int i = 0; i < quantity; i++)
                                    {
                                        cart.Add(new Cart(drinkName, drinkPrice, quantity));
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
                            foreach (string currAddOn in addOnChoices)
                            {
                                foreach (KeyValuePair<string, decimal> addOn in menu.addOns)
                                {
                                    if (string.Equals(currAddOn.Trim(), addOn.Key, StringComparison.OrdinalIgnoreCase))
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

                        }
                        Console.WriteLine("Would you like to purchse another beverage?");
                        string purchase = Console.ReadLine();
                        if (purchase == "yes" || purchase == "y")
                        {

                        }
                        else if (purchase == "no" || purchase == "n")
                        { }
                        else
                            Console.WriteLine("I do not understand your input. Please try again.\n");
                        Console.WriteLine("Would you like to see our drink menu (y/n)? ");
                        string userChoice1 = Console.ReadLine();
                        if (userChoice1 == "yes" || userChoice1 == "y")
                        { }
                        else if (userChoice1 == "no" || userChoice1 == "n")
                        { }
                        else
                            Console.WriteLine("I do not understand your input. Please try again.\n");
                    }
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
                                    bool itemRemoved = myCart.CurrentCart(cart, drinkPrice, drinkTotal, userInputA, itemNo, quantity, browse);
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

