namespace SodaMachine.Model.Inventory
{
    public interface IInventory
    {
        InventoryItem GetInventoryItemByName(string sodaName);
        void AddInventoryItem(InventoryItem item);
        int OrderSoda(string sodaName, int money);
        void SmsOrderSoda(string sodaName);
    }
}
