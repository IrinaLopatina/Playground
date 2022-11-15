using SodaMachine.Model.Inventory;
using System;

namespace SodaMachine.Model
{
    public class MySodaMachine
    {
        private static int money;

        private readonly IInventory Inventory;


        public MySodaMachine(IInventory inventory)
        {
            Inventory = inventory;
        }

        /// <summary>
        /// This is the starter method for the machine
        /// </summary>
        public void Start()
        {
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

                    money = Inventory.OrderSoda(sodaName, money);
                }
                if (input.StartsWith("sms order"))
                {
                    var sodaName = input.Split(' ')[2];

                    Inventory.SmsOrderSoda(sodaName);
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
