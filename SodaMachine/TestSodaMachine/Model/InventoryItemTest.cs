using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodaMachine.Model.Inventory;

namespace TestSodaMachine.Model
{
    [TestClass]
    public class InventoryItemTest
    {
        readonly InventoryItem inventoryItem = new InventoryItem(new Soda("coke", 15), 10);

        [TestMethod]
        public void ReduceQuantityByNumber_SubtractsGivenQuantity()
        {
            inventoryItem.ReduceQuantityByNumber(6);
            Assert.AreEqual(4, inventoryItem.Quantity);
        }
    }
}
