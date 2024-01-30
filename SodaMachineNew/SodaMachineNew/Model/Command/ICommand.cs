using SodaMachineNew.Model.Inventory;

namespace SodaMachineNew.Model.Command
{
    public interface ICommand
    {
        double Execute(double money, string input, IInventory inventory);

        int Id { get; }
        string Name { get; }
        string Description { get; }
    }
}
