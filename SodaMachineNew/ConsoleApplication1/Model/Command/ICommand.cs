using SodaMachineNew.Model.Inventory;

namespace SodaMachineNew.Model.Command
{
    public interface ICommand
    {
        double Execute(double money, string input, IInventory inventory);
    }
}
