using SodaMachineNew.Model.Inventory;

namespace SodaMachineNew.Model.Command
{
    public class OrderCommand : ICommand
    {
        public int Id { get; private set; } = 2;
        public string Name { get; private set; } = "order";
        public string Description { get; set; } = "order (coke, sprite, fanta) - Order from machines buttons";

        public double Execute(double money, string input, IInventory inventory)
        {
            var csoda = input.Split(' ')[1];
            money = inventory.OrderSoda(csoda, money);

            return money;
        }
    }
}
