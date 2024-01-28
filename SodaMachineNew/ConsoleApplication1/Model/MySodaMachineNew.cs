using SodaMachineNew.Model.Command;
using SodaMachineNew.Model.Inventory;
using System;

namespace SodaMachineNew.Model
{
    internal class MySodaMachineNew
    {
        private static double money;
        public IInventory Inventory { get; private set; }    

        public MySodaMachineNew(IInventory inventory)
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
                PrintInstructions();

                var input = Console.ReadLine();

                var command = new CommandBuilder().Build(input);
                money = command.Execute(money, input, Inventory);
            }
        }

        private void PrintInstructions()
        {
            Console.WriteLine("\n\nAvailable commands:");
            Console.WriteLine("insert (money) - Money put into money slot");
            Console.WriteLine("order (coke, sprite, fanta) - Order from machines buttons");
            Console.WriteLine("sms order (coke, sprite, fanta) - Order sent by sms");
            Console.WriteLine("recall - gives money back");
            Console.WriteLine("-------");
            Console.WriteLine("Inserted money: " + money);
            Console.WriteLine("-------\n\n");
        }
    }
}
