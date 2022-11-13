using ConsoleApplication1.Model.Inventory;
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
            var inventory = new Inventory();

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
                    var sodaName = input.Split(' ')[1];

                    money = inventory.OrderSoda(sodaName, money);
                }
                if (input.StartsWith("sms order"))
                {
                    var sodaName = input.Split(' ')[2];

                    inventory.SmsOrderSoda(sodaName);
                }

                if (input.Equals("recall"))
                {
                    //Give money back
                    Console.WriteLine("Returning " + money + " to customer");
                    money = 0;
                }
            }
        }
    }
}
