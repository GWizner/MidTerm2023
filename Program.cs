using System.ComponentModel.DataAnnotations;

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
            decimal drinkTotal = 0m;
            decimal drinkPrice = 0m;
            decimal addOnPrice = 0.0m;
            bool goodDrink = false;


            int itemNo = 0;
            string userInputA = null;
            bool cashOut = false;
            bool browse = true;
            bool badName = false;
            bool keepAsk = true;

            int id = 0;
            string name = null;
            decimal price = 0;
            string description = null;

            List<Cart> cart = new List<Cart>();
            CoffeeMenu menu = new CoffeeMenu(id, name, description, price);

            List<CoffeeMenu> coffees = new List<CoffeeMenu>();
            //{
            //    menuList.Add(new CoffeeMenu() { Id = 1, Name = "Espresso", Price = 2.50m, Description = "A strong, concentrated coffee made by forcing hot water through finely ground coffee beans under high pressure." });
            //    menuList.Add(new CoffeeMenu() { Id = 2, Name = "Cappuccino", Price = 3.50m, Description = "A classic Italian coffee beverage made with equal parts espresso, steamed milk, and frothed milk." };
            //    menuList.Add(new CoffeeMenu() { Id = 3, Name = "Latte", Price = 4.00m, Description = "A coffee beverage made with espresso and steamed milk, often topped with a small layer of frothed milk." },
            //    new CoffeeMenu { Id = 4, Name = "Americano", Price = 3.00m, Description = "A coffee beverage made by adding hot water to a shot of espresso." },
            //    new CoffeeMenu { Id = 5, Name = "Mocha", Price = 4.50m, Description = "A coffee beverage made with espresso, steamed milk, and chocolate syrup or powder." },
            //    new CoffeeMenu { Id = 6, Name = "Macchiato", Price = 3.50m, Description = "A coffee beverage made with espresso and a small amount of frothed milk." },
            //    new CoffeeMenu { Id = 7, Name = "Flat White", Price = 4.50m, Description = "A coffee beverage similar to a latte, but with a higher ratio of espresso to milk." },
            //    new CoffeeMenu { Id = 8, Name = "Irish Coffee", Price = 6.00m, Description = "A cocktail made with hot coffee, Irish whiskey, and sugar, topped with whipped cream." },
            //    new CoffeeMenu { Id = 9, Name = "Affogato", Price = 5.00m, Description = "A dessert beverage made by pouring a shot of espresso over a scoop of vanilla ice cream or gelato." },
            //    new CoffeeMenu { Id = 10, Name = "French Press", Price = 6.50m, Description = "A brewing method that involves steeping coarse coffee grounds in hot water, and then pressing the mixture through a metal or mesh filter." },
            //    new CoffeeMenu { Id = 11, Name = "Cold Brew", Price = 4.50m, Description = "A coffee beverage made by steeping coarse coffee grounds in cold water for an extended period of time, often 12-24 hours." },
            //    new CoffeeMenu { Id = 12, Name = "Nitro Cold Brew", Price = 5.00m, Description = "A type of cold brew coffee that is infused with nitrogen gas, giving it a creamy, velvety texture and a foamy top similar to a draft beer." },
            //    new CoffeeMenu { Id = 13, Name = "Iced Coffee", Price = 3.50m, Description = "A coffee beverage served over ice, often made by brewing hot coffee and then chilling it or pouring it over ice." }
            //};
            ViewCart mycart = new ViewCart();


            Console.WriteLine("Welcome to the " + "\x1b[38;5;207m" + "JavaDrip" + "\x1b[0m" + ".\n");



            while (keepAsk)
            {
                Console.WriteLine("Would you like to see our drink menu (y/n)? ");
                string userChoice1 = Console.ReadLine();
                if (userChoice1 == "yes" || userChoice1 == "y")
                {
                    Console.WriteLine();
                    menu.DisplayDrinks(coffees);
                    Console.Write("\nEnter the name of your coffee drink: ");
                    drinkName = Console.ReadLine().ToLower();
                    goodDrink = int.TryParse(drinkName, out drinkNum);
                    selectedName = coffees.FirstOrDefault(x => x.Equals(drinkName, StringComparison.OrdinalIgnoreCase));

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
                            Console.Write($"\nHow many {selectedName}es would you like? ");
                        }
                        else
                        {
                            Console.Write($"\nHow many {selectedName}s would you like? ");
                        }
                        quantity = int.Parse(Console.ReadLine());
                        cart.Add(new Cart(selectedName, drinkPrice, quantity));

                        foreach (var drink in menu.drinks)
                        {
                            if (drink.Key.Equals(drinkName, StringComparison.OrdinalIgnoreCase))
                            {
                                drinkTotal += drinkPrice * quantity;
                                cart.Add(new Cart(selectedName, drinkTotal, quantity));
                                drinkTotal = drinkTotal + menu.drinks[selectedName];
                                break;
                            }
                            else if (menu.drinkMenu.ContainsKey(drinkNum))
                            {
                                drinkTotal += drinkPrice * quantity;
                                cart.Add(new Cart(selectedDrinkName, drinkTotal, quantity));
                                drinkTotal = drinkTotal + menu.drinks[selectedDrinkName];
                                break;
                            }
                        }
                    }

                }

                Get the user's add-on selections
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

                    Calculate the total price
                    drinkTotal = menu.GetDrinkPrice(drinkName, selectedDrinkName, drinkNum);
                    foreach (string addOnName in addOnChoices)
                    {
                        addOnPrice += menu.GetAddOnPrice(addOnName);
                    }
                }
                decimal subtotal = drinkTotal + addOnPrice;
                decimal salesTax = subtotal * 0.06m;
                decimal totalPrice = subtotal + salesTax;


                while (browse)
                {
                    for (int i = 0; i < cart.Count; i++)
                    {
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(i + 1 + ".{0,-13}", cart[i].Name);
                        Console.Write("{0, 2}", cart[i].Quantity);
                        Console.WriteLine("\x1b[31m" + "{0,15:C}", cart[i].Price);
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
                keepAsk = Validator.getContinue();
            }
        }
    }
}