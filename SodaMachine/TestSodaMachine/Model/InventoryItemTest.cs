using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodaMachine.Model.Inventory;
using SodaMachine.Model.SodaTypes;
using System;

namespace TestSodaMachine.Model
{
    [TestClass]
    public class InventoryItemTest
    {
        readonly InventoryItem inventoryItem = new InventoryItem(new Coke(), 10);

        [TestMethod]
        public void ReduceQuantityByNumber_SubtractsGivenQuantity()
        {
            inventoryItem.ReduceQuantityByNumber(6);
            Assert.AreEqual(4, inventoryItem.Quantity);
        }
    }
}
