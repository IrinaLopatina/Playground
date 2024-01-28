using SodaMachineNew.Model.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSodaMachineNew.Model
{
    public class InventoryItemTest
    {
        readonly InventoryItem inventoryItem;

        public InventoryItemTest()
        {
            inventoryItem = new InventoryItem(new Soda("fanta", 17), 7);
        }

        [Fact]
        public void GetInventoryItemByName_WhenExistingItem_ReturnsItem()
        {
            //act
            inventoryItem.ReduceQuantityByNumber(2);

            //assert
            Assert.Equal(5, inventoryItem.Quantity);
        }
    }
}
