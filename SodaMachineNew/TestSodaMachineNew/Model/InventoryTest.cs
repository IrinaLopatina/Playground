using SodaMachineNew.Model.Inventory;

namespace TestSodaMachineNew.Model
{
    public class InventoryTest
    {
        readonly Inventory inventory;

        public InventoryTest()
        {
            inventory = new Inventory();
            inventory.AddInventoryItem(new InventoryItem(new Soda("coke", 20), 5));
            inventory.AddInventoryItem(new InventoryItem(new Soda("sprite", 15), 3));
        }

        [Fact]
        public void GetInventoryItemByName_WhenExistingItem_ReturnsItem()
        {
            //act
            var item = inventory.GetInventoryItemByName("coke");

            //assert
            Assert.NotNull(item);
            Assert.Equal(5, item.Quantity);
            Assert.Equal("coke", item.Soda.Name);
            Assert.Equal(20, item.Soda.Price);
        }

    }
}