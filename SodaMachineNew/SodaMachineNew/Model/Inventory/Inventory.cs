﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineNew.Model.Inventory
{
    public class Inventory: IInventory
    {
        public List<InventoryItem> InventoryItems { get; private set; } = new List<InventoryItem> { };

        private static readonly string cokeName = "coke";
        private static readonly double cokePrice = 20;
        private static readonly int cokeNr = 5;
        
        private static readonly string fantaName = "fanta";
        private static readonly double fantaPrice = 15;
        private static readonly int fantaNr = 3;

        private static readonly string spriteName = "sprite";
        private static readonly double spritePrice = 15;
        private static readonly int spriteNr = 3;

        /// <inheritdoc />
        public Inventory(){}

        public void Initialize()
        {
            AddInventoryItem(new InventoryItem(new Soda(cokeName, cokePrice), cokeNr));
            AddInventoryItem(new InventoryItem(new Soda(fantaName, fantaPrice), fantaNr));
            AddInventoryItem(new InventoryItem(new Soda(spriteName, spritePrice), spriteNr));
        }

        /// <inheritdoc />
        public InventoryItem GetInventoryItemByName(string sodaName)
        { 
            return InventoryItems.FirstOrDefault(x => x.Soda.Name == sodaName);
        }

        /// <inheritdoc />
        public void AddInventoryItem(InventoryItem item) 
        {
            var existingItem = GetInventoryItemByName(item.Soda.Name);
            if (existingItem == null)
            {
                InventoryItems.Add(item);
            }
            else
            {
                Console.WriteLine($"Item with name {item.Soda.Name} already exists");
            }
            return;
        }

        /// <inheritdoc />
        public double OrderSoda(string sodaName, double money)
        {
            var item = GetInventoryItemByName(sodaName);

            if (item == null)
            {
                Console.WriteLine("No such soda");
                return money;
            }
            
            if (money >= item.Soda.Price && item.Quantity > 0)
            {
                Console.WriteLine("Giving " + item.Soda.Name + " out");
                money -= item.Soda.Price;
                Console.WriteLine("Giving " + money + " out in change");
                money = 0;
                item.ReduceQuantityByNumber(1);
            }
            else if (item.Quantity == 0)
            {
                Console.WriteLine($"No {item.Soda.Name} left");
            }
            else
            {
                Console.WriteLine($"Need {item.Soda.Price - money} more");
            }
            return money;
        }

        /// <inheritdoc />
        public void SmsOrderSoda(string sodaName)
        {
            var item = GetInventoryItemByName(sodaName);

            if (item == null)
            {
                Console.WriteLine("No such soda");
                return;
            }

            if (item.Quantity > 0)
            {
                Console.WriteLine($"Giving {item.Soda.Name} out");
                item.ReduceQuantityByNumber(1);
            }
        } 
    }
}