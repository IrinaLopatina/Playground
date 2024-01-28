using SodaMachineNew.Model.Inventory;
using System;

namespace SodaMachineNew.Model.Command
{
    public class InsertCommand: ICommand
    {
        public double Execute(double money, string input, IInventory inventory)
        {
            //Add to credit
            money += int.Parse(input.Split(' ')[1]);
            Console.WriteLine("Adding " + int.Parse(input.Split(' ')[1]) + " to credit");
            return money;
        }
    }
}
