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


        [Fact]
        public void GetInventoryItemByName_WhenNonExistingItem_ReturnsNull()
        {
            //act
            var item = inventory.GetInventoryItemByName("tull");

            //assert
            Assert.Null(item);
        }

        [Fact]
        public void AddInventoryItem_WhenNotExistingItem_AddsItem()
        {
            //act
            inventory.AddInventoryItem(new InventoryItem(new Soda("fanta", 17), 6));

            //assert
            Assert.Equal(3, inventory.InventoryItems.Count);

            var item = inventory.GetInventoryItemByName("fanta");

            Assert.NotNull(item);
            Assert.Equal(6, item.Quantity);
            Assert.Equal("fanta", item.Soda.Name);
            Assert.Equal(17, item.Soda.Price);
        }

        [Fact]
        public void AddInventoryItem_WhenExistingItem_GivesErrorMessage()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            inventory.AddInventoryItem(new InventoryItem(new Soda("coke", 20), 3));

            //assert
            Assert.Equal(2, inventory.InventoryItems.Count);

            var output = stringWriter.ToString();
            Assert.Equal("Item with name coke already exists\r\n", output);
        }

        [Fact]
        public void OrderSoda_WhenUnknownSodaType_GivesMessageAndDoesNotReduceMoney()
        {
            //arrange
            var money = 50;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            var restMoney = inventory.OrderSoda("fanta", money);

            //assert
            var output = stringWriter.ToString();
            Assert.Equal("No such soda\r\n", output);
            Assert.Equal(money, restMoney);
        }

        [Fact]
        public void OrderSoda_WhenKnownSodaTypeAndEnoughMoney_GivesMessageAndReduceMoneyToZero()
        {
            //arrange
            var money = 50;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            var restMoney = inventory.OrderSoda("coke", money);

            //assert
            Assert.Equal(0, restMoney);

            var output = stringWriter.ToString();
            Assert.Equal($"Giving coke out\r\nGiving {money - 20} out in change\r\n", output);
        }

        [Fact]
        public void OrderSoda_WhenKnownSodaTypeAndNotEnoughMoney_GivesMessageAndDoesNotReduceMoney()
        {
            //arrange
            var money = 17;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            var restmoney = inventory.OrderSoda("coke", money);

            //assert
            Assert.Equal(money, restmoney);
            var output = stringWriter.ToString();
            Assert.Equal($"Need {20 - money} more\r\n", output);
        }

        [Fact]
        public void OrderSoda_WhenKnownSodaTypeAndEnoughMoneyAndEmptyInventory_GivesMessageAndDoesNotReduceMoney()
        {
            //arrange
            var money = 20;
            for (int i = 0; i < 3; i++)
                inventory.OrderSoda("sprite", money);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            var restmoney = inventory.OrderSoda("sprite", money);

            //assert
            Assert.Equal(money, restmoney);
            var output = stringWriter.ToString();
            Assert.Equal("No sprite left\r\n", output);
        }
    }
}