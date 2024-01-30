using SodaMachineNew.Model.Inventory;
using System;

namespace SodaMachineNew.Model.Command
{
    public class InsertCommand: ICommand
    {
        public int Id { get; private set; } = 1; 
        public string Name { get; private set; } = "insert";
        public string Description { get; set; } = "insert (money) - Money put into money slot";

        public double Execute(double money, string input, IInventory inventory)
        {
            //Add to credit
            money += int.Parse(input.Split(' ')[1]);
            Console.WriteLine("Adding " + int.Parse(input.Split(' ')[1]) + " to credit");
            return money;
        }
    }
}
