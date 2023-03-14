using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Xml;

namespace MidTerm2023
{
    class Program
    {
        static void Main(string[] args)
        {
            bool newOrder = true;
            while (newOrder)
            {


                string addOnName = null;
                string userDrink = null;
                string userInputA = null;
                string name = null;
                string description = null;
                string drinkName = null;


                int quantity = 0;
                int drinkNum = 0;
                int itemNo = 0;
                int id = 0;

                decimal drinkPrice = 0m;
                decimal addOnPrice = 0m;
                decimal addOnTotal = 0m;
                decimal subtotal = 0m;
                decimal salesTax = 0m;
                decimal grandTotal = 0m;
                decimal price = 0m;
                decimal drinkTotal = 0m;

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
                new CoffeeMenu (1, "Espresso", "1 oz. of highly concentrated coffee.", 2.50m) ,
                new CoffeeMenu (2, "Cappuccino", "Latte made with more foam than steamed milk", 3.50m),
                new CoffeeMenu (3, "Latte", "A shot of espresso and steamed milk with a touch of foam.", 4.00m),
                new CoffeeMenu (4, "Americano", "1 shot of espresso + 3 oz. of hot water", 3.00m),
                new CoffeeMenu (5, "Mocha", "A chocolate espresso drink with steamed milk and foam", 4.50m),
                new CoffeeMenu (6, "Macchiato", "Espresso-based drink that has a small amount of foam on top", 3.50m),
                new CoffeeMenu (7, "Flat White", "Basically a cappuccino without the foam or sprinkle.", 4.50m),
                new CoffeeMenu (8, "Irish Coffee", "Black coffee, whiskey and sugar, topped with whipped cream.", 6.00m),
                new CoffeeMenu (9, "Affogato", "Served with a scoop of ice cream and a shot of espresso, or two.", 5.00m),
                new CoffeeMenu (10, "French Press", "Heavy body and robust taste", 6.50m),
                new CoffeeMenu (11, "Cold Brew", "Steeped coffee beans with cold milk or cream.", 4.50m),
                new CoffeeMenu (12, "Nitro Cold Brew", "A cold brew coffee with a frothy, Guinness-like consistency", 5.00m),
                new CoffeeMenu (13, "Iced Coffee", "A coffee with ice; served with a dash of milk, cream or sweetener.", 3.50m)
            };


                string textToCenter = "Welcome to the " + "\x1b[38;5;207m" + "JavaDrip" + "\x1b[0m" + ".\n";

                int screenWidth = Console.WindowWidth;
                int stringWidth = textToCenter.Length;
                int spaces = (screenWidth / 2) + (stringWidth / 2);

                Console.WriteLine("{0," + spaces + "}", textToCenter);

                while (keepAsk)
                {



                    while (viewMenu)
                    {
                        int counter = 1;
                        foreach (CoffeeMenu coffee in coffees)
                        {
                            if (counter > 9)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("{0, -1}{1, -20}", coffee.Id + ". ", coffee.Name);
                                Console.Write("{0, -80}", "\x1b[38;5;94m" + coffee.Description);
                                Console.WriteLine("{0, 10:C}", "\x1b[31m" + "$" + coffee.Price + "\x1b[0m");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("{0, -1}{1, -21}", coffee.Id + ". ", coffee.Name);
                                Console.Write("{0, -80}", "\x1b[38;5;94m" + coffee.Description);
                                Console.WriteLine("{0, 10:C}", "\x1b[31m" + "$" + coffee.Price + "\x1b[0m");
                            }
                            counter++;
                        }
                        noMenu = true;

                        while (noMenu)
                        {
                            bool goodAns = false;
                            while (!goodAns)
                            {
                                Console.Write("\nEnter the name or number of the coffee drink you'd like to order: ");
                                userDrink = Console.ReadLine().ToLower();
                                goodDrink = int.TryParse(userDrink, out drinkNum);

                                if (goodDrink)
                                {
                                    if (drinkNum < 1 || drinkNum > 13)
                                    {
                                        Console.WriteLine("We do not have a drink with that number. Please try again.\n");
                                    }
                                    else if (drinkNum >= 1 && drinkNum <= 13)
                                    {
                                        drinkName = coffees[drinkNum - 1].Name;
                                        drinkPrice = coffees[drinkNum - 1].Price;
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
                                                drinkName = coffeeSearch.Name;
                                                drinkPrice = coffeeSearch.Price;
                                                goodAns = true;
                                            }

                                        }
                                    }
                                    Console.WriteLine();
                                    goodAns = true;

                                }
                                else
                                {
                                    Console.WriteLine("I do not understand your input. Please try again.\n");
                                }
                            }


                            if (drinkName.EndsWith('s'))
                            {
                                endsWithS = true;
                            }

                            while (true)
                            {
                                if (endsWithS)
                                {
                                    Console.Write($"\nHow many {drinkName}es would you like? ");
                                }
                                else
                                {
                                    Console.Write($"\nHow many {drinkName}s would you like? ");
                                }
                                bool userDrinks = int.TryParse(Console.ReadLine(), out quantity);
                                drinkTotal = drinkPrice * quantity;

                                if (!userDrinks || quantity == 0)
                                {
                                    Console.WriteLine("Sorry, please enter an integer.");
                                }
                                else if (quantity == 1)
                                {
                                    Console.WriteLine($"\nOkay {quantity} {drinkName} ");
                                    cart.Add(new Cart(drinkName, drinkPrice, drinkTotal, quantity));
                                    break;
                                }
                                else if (endsWithS)
                                {
                                    Console.Write($"\nOkay {quantity} {drinkName}es ");
                                    cart.Add(new Cart(drinkName, drinkPrice, drinkTotal, quantity));
                                    break;
                                }
                                else
                                {
                                    Console.Write($"\nOkay {quantity} {drinkName}s ");
                                    cart.Add(new Cart(drinkName, drinkPrice, drinkTotal, quantity));
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.Write("would you like any add-ons (y/n)? ");
                                string userChoice2 = Console.ReadLine().ToLower();
                                Console.WriteLine();


                                if (userChoice2 == "yes" || userChoice2 == "y")
                                {
                                    menu.DisplayAddOns();
                                    Console.Write("\nEnter add-on selection(s) (please seperate choices by a comma): ");
                                    addOnName = Console.ReadLine();


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
                                        }
                                    }
                                    break;
                                }

                                else if (userChoice2 == "no" || userChoice2 == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nI do not understand your input. Please try again.\n");
                                }
                            }
                            while (browse)
                            {
                                myCart.PrintCart(cart, drinkTotal, addOnPrice, grandTotal);


                                while (true)
                                {
                                    Console.WriteLine("\nWould you like to purchase another beverage?");
                                    string purchase = Console.ReadLine();
                                    if (purchase == "no" || purchase == "n")
                                    {
                                        viewMenu = false;
                                        noMenu = false;
                                        keepAsk = false;
                                        break;
                                    }
                                    else if (purchase == "yes" || purchase == "y")
                                    {

                                        while (true)
                                        {
                                            Console.WriteLine("\nWould you like to see our drink menu (y/n)? ");
                                            string userChoice1 = Console.ReadLine();
                                            if (userChoice1 == "yes" || userChoice1 == "y")
                                            {
                                                viewMenu = true;
                                                noMenu = false;
                                                break;
                                            }
                                            else if (userChoice1 == "no" || userChoice1 == "n")
                                            {
                                                viewMenu = false;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nI do not understand your input. Please try again.\n");
                                            }
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nI do not understand your input. Please try again.\n");
                                    }
                                }
                                break;
                            }
                        }
                    }
                    grandTotal = myCart.GrandTotal;
                    salesTax = myCart.SalesTax;
                    subtotal = myCart.SubTotal;
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
                    decimal change = Payment.Cash(tender, grandTotal);
                    Console.WriteLine("\x1b[38;5;226m" + "--------------------------------");
                    myCart.PrintCart(cart, drinkTotal, addOnPrice, grandTotal);
                    Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Tender:" + "\x1b[31m", tender);
                    Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Change:" + "\x1b[31m", change);
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.ResetColor();
                    Console.WriteLine("Thank you! Have a wonderful day!!!");
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
                    decimal tender = grandTotal;
                    decimal change = 0m;
                    Console.WriteLine("\x1b[38;5;226m" + "--------------------------------");
                    myCart.PrintCart(cart, drinkTotal, addOnPrice, grandTotal);
                    Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Tender:" + "\x1b[31m", tender);
                    Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Change:" + "\x1b[31m", change);
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.ResetColor();
                    Console.WriteLine("Thank you! Have a wonderful day!!!");
                    

                }

                else if (tenderType == "Check" || tenderType == "check" || tenderType == "3")
                {
                    Console.WriteLine("Please enter the check number:");
                    int checknumber = int.Parse(Console.ReadLine());
                    Console.WriteLine(Payment.Check(checknumber));
                    decimal tender = grandTotal;
                    decimal change = 0m;
                    Console.WriteLine("\x1b[38;5;226m" + "--------------------------------");
                    myCart.PrintCart(cart, drinkTotal, addOnPrice, grandTotal);
                    Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Tender:" + "\x1b[31m", tender);
                    Console.WriteLine("{0, -32}{1, 16:C}", "\x1b[38;5;226m" + "Change:" + "\x1b[31m", change);
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.ResetColor();
                    Console.WriteLine("Thank you! Have a wonderful day!!!");
                }

                
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.ReadLine();
                
            }
        }
    }
}

