namespace SodaMachine.Model.Inventory
{
    public interface IInventory
    {
        /// <summary>
        /// Gets inventory item by name, returns null if no such item exists
        /// </summary>
        InventoryItem GetInventoryItemByName(string sodaName);

        /// <summary>
        /// Adds inventory item to inventory if no item with such name already exists and gives a message otherwise
        /// </summary>
        void AddInventoryItem(InventoryItem item);

        /// <summary>
        /// Gives out soda and change, reduces inventory quantity by 1  
        /// </summary>
        int OrderSoda(string sodaName, int money);

        /// <summary>
        /// Reserves soda, reduces inventory quantity by 1  
        /// </summary>
        void SmsOrderSoda(string sodaName);
    }
}
