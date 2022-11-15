using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodaMachine.Model.Inventory;
using System;
using System.IO;

namespace TestSodaMachine.Model
{
    [TestClass]
    public class InventoryTest
    {

        readonly Inventory inventory;

        public InventoryTest() 
        {
            inventory = new Inventory();
            inventory.AddInventoryItem(new InventoryItem(new Soda("coke", 20), 5));
            inventory.AddInventoryItem(new InventoryItem(new Soda("sprite", 15), 3));
        }

        [TestMethod]
        public void GetInventoryItemByName_WhenExistingItem_ReturnsItem()
        {
            //act
            var item = inventory.GetInventoryItemByName("coke");

            //assert
            Assert.IsNotNull(item);
            Assert.AreEqual(item.Quantity, 5);
            Assert.AreEqual(item.Soda.Name, "coke");
            Assert.AreEqual(item.Soda.Price, 20);
        }

        [TestMethod]
        public void GetInventoryItemByName_WhenNonExistingItem_ReturnsNull()
        {
            //act
            var item = inventory.GetInventoryItemByName("fanta");

            //assert
            Assert.IsNull(item);
        }

        [TestMethod]
        public void AddInventoryItem_WhenNotExistingItem_AddsItem()
        {
            //act
            inventory.AddInventoryItem(new InventoryItem(new Soda("fanta", 15), 1));

            //assert
            Assert.AreEqual(inventory.Items.Count, 3);
            var item = inventory.GetInventoryItemByName("fanta");
            Assert.IsNotNull(item);
            Assert.AreEqual(item.Quantity, 1);
            Assert.AreEqual(item.Soda.Name, "fanta");
            Assert.AreEqual(item.Soda.Price, 15);
        }

        [TestMethod]
        public void AddInventoryItem_WhenExistingItem_GivesErrorMessage()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            inventory.AddInventoryItem(new InventoryItem(new Soda("coke", 20), 3));

            //assert
            Assert.AreEqual(inventory.Items.Count, 2);

            var output = stringWriter.ToString();
            Assert.AreEqual("Item coke exists\r\n", output);
        }

        [TestMethod]
        public void OrderSoda_WhenUnknownSodaType_GivesMessageAndDoesNotReduceMoney()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            var money = inventory.OrderSoda("pepsi", 100);

            //assert
            Assert.AreEqual(100, money);
            var output = stringWriter.ToString();
            Assert.AreEqual("No such soda\r\n", output);
        }

        [TestMethod]
        public void OrderSoda_WhenKnownSodaTypeAndEnoughMoney_GivesMessageAndReducesMoneyToZero()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            var money = inventory.OrderSoda("coke", 100);

            //assert
            Assert.AreEqual(0, money);
            var output = stringWriter.ToString();
            Assert.AreEqual("Giving coke out\r\nGiving 80 out in change\r\n", output);
        }

        [TestMethod]
        public void OrderSoda_WhenKnownSodaTypeAndNotEnoughMoney_GivesMessageAndDoesNotReduceMoney()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            var money = inventory.OrderSoda("coke", 15);

            //assert
            Assert.AreEqual(15, money);
            var output = stringWriter.ToString();
            Assert.AreEqual("Need 5 more\r\n", output);
        }

        [TestMethod]
        public void OrderSoda_WhenKnownSodaTypeAndEnoughMoneyAndEmptyInventory_GivesMessageAndDoesNotReduceMoney()
        {
            //arrange
            for(int i = 0; i < 3; i++)
                inventory.OrderSoda("sprite", 20);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            var money = inventory.OrderSoda("sprite", 20);

            //assert
            Assert.AreEqual(20, money);
            var output = stringWriter.ToString();
            Assert.AreEqual("No sprite left\r\n", output);
        }
    }
}
