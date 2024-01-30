using SodaMachineNew.Model.Command;
using SodaMachineNew.Model.Inventory;
using System;

namespace SodaMachineNew.Model
{
    internal class MySodaMachineNew
    {
        private static double money;
        public IInventory Inventory { get; private set; }
        public ICommandList CommandList {  get; private set; }


        public MySodaMachineNew(IInventory inventory, ICommandList commandList)
        {
            Inventory = inventory;
            CommandList = commandList;
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

                var command = CommandList.GetCommandByName(input);
                if (command != null)
                    money = command.Execute(money, input, Inventory);
                else
                    Console.WriteLine("Nonexistent command. Try again.");
            }
        }

        private void PrintInstructions()
        {
            Console.WriteLine("\n\nAvailable commands:");

            CommandList.GetOrderedCommandList().ForEach(x => Console.WriteLine(x.Description));
            Console.WriteLine("-------");
            Console.WriteLine("Inserted money: " + money);
            Console.WriteLine("-------\n\n");
        }
    }
}
