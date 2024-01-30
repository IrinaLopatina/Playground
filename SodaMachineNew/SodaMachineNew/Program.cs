using SodaMachineNew.Model;
using SodaMachineNew.Model.Command;
using SodaMachineNew.Model.Inventory;
using System;

namespace SoodaMachineNew
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            inventory.Initialize();

            CommandList commandList = new CommandList();
            commandList.Initialize();

            MySodaMachineNew sodaMachine = new MySodaMachineNew(inventory, commandList);
            sodaMachine.Start();
        }
    }
}
