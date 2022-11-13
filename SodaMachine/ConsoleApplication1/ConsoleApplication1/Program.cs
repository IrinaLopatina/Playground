using ConsoleApplication1.Model.SodaTypes;
using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SodaMachine sodaMachine = new SodaMachine();
            sodaMachine.Start();
        }
    }

    public class SodaMachine
    {
        private static int money;

        /// <summary>
        /// This is the starter method for the machine
        /// </summary>
        public void Start()
        {
            var inventory = new ISoda[] { new Coke { Nr = 5 }, new Sprite { Nr = 3 }, new Fanta { Nr = 3 } };

            while (true)
            {
                Console.WriteLine("\n\nAvailable commands:");
                Console.WriteLine("insert (money) - Money put into money slot");
                Console.WriteLine("order (coke, sprite, fanta) - Order from machines buttons");
                Console.WriteLine("sms order (coke, sprite, fanta) - Order sent by sms");
                Console.WriteLine("recall - gives money back");
                Console.WriteLine("-------");
                Console.WriteLine("Inserted money: " + money);
                Console.WriteLine("-------\n\n");

                var input = Console.ReadLine();

                if (input.StartsWith("insert"))
                {
                    //Add to credit
                    money += int.Parse(input.Split(' ')[1]);
                    Console.WriteLine("Adding " + int.Parse(input.Split(' ')[1]) + " to credit");
                }
                if (input.StartsWith("order"))
                {
                    // split string on space
                    var csoda = input.Split(' ')[1];

                    ISoda soda;

                    //Find out witch kind
                    switch (csoda)
                    {
                        case "coke":
                            soda = inventory[0];
                            OrderSoda(csoda, soda);
                            break;

                        case "sprite":
                            soda = inventory[1];
                            OrderSoda(csoda, soda);
                            break;

                        case "fanta":
                            soda = inventory[2];
                            OrderSoda(csoda, soda);
                            break;

                        default:
                            Console.WriteLine("No such soda");
                            break;
                    }
                }
                if (input.StartsWith("sms order"))
                {
                    var csoda = input.Split(' ')[2];
                    //Find out witch kind
                    switch (csoda)
                    {
                        case "coke":
                            if (inventory[0].Nr > 0)
                            {
                                Console.WriteLine("Giving coke out");
                                inventory[0].Nr--;
                            }
                            break;
                        case "sprite":
                            if (inventory[1].Nr > 0)
                            {
                                Console.WriteLine("Giving sprite out");
                                inventory[1].Nr--;
                            }
                            break;
                        case "fanta":
                            if (inventory[2].Nr > 0)
                            {
                                Console.WriteLine("Giving fanta out");
                                inventory[2].Nr--;
                            }
                            break;
                    }

                }

                if (input.Equals("recall"))
                {
                    //Give money back
                    Console.WriteLine("Returning " + money + " to customer");
                    money = 0;
                }

            }
        }

        private static void OrderSoda(string csoda, ISoda soda)
        {
            if (soda.Name == csoda && money >= soda.Price && soda.Nr > 0)
            {
                Console.WriteLine("Giving " + soda.Name + " out");
                money -= soda.Price;
                Console.WriteLine("Giving " + money + " out in change");
                money = 0;
                soda.Nr--;
            }
            else if (soda.Name == csoda && soda.Nr == 0)
            {
                Console.WriteLine("No " + soda.Name + " left");
            }
            else if (soda.Name == csoda)
            {
                Console.WriteLine("Need " + (soda.Price - money) + " more");
            }
        }
    }
}
