using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodaMachine.Model.Inventory;
using System;
using System.IO;

namespace TestSodaMachine.Model
{
    [TestClass]
    public class InventoryTest
    {
        readonly Inventory inventory = new Inventory();

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
