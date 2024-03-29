﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SodaMachine.Model.Inventory
{
    /// <summary>
    /// Represents inventory of soda machine
    /// </summary>
    public class Inventory : IInventory
    {
        public IList<InventoryItem> Items { get;  private set; } = new List<InventoryItem>();

        //inheritdoc
        public InventoryItem GetInventoryItemByName(string sodaName)
        {
            return Items.ToList().FirstOrDefault(x => x.Soda.Name == sodaName);
        }

        //inheritdoc
        public void AddInventoryItem(InventoryItem item)
        {
            var existingItem = GetInventoryItemByName(item.Soda.Name);
            if (existingItem == null)
            {
                Items.Add(item);
            }
            else
            {
                Console.WriteLine($"Item {item.Soda.Name} exists");
            }
            return;
        }

        //inheritdoc
        public int OrderSoda(string sodaName, int money)
        {
            var item = GetInventoryItemByName(sodaName);
            if (item == null)
            {
                Console.WriteLine("No such soda");
                return money;
            }

            if (item.Soda.Name == sodaName && money >= item.Soda.Price && item.Quantity > 0)
            {
                Console.WriteLine("Giving " + item.Soda.Name + " out");
                money -= item.Soda.Price;
                Console.WriteLine("Giving " + money + " out in change");
                money = 0;
                item.ReduceQuantityByNumber(1);
            }
            else if (item.Soda.Name == sodaName && item.Quantity == 0)
            {
                Console.WriteLine("No " + item.Soda.Name + " left");
            }
            else if (item.Soda.Name == sodaName)
            {
                Console.WriteLine("Need " + (item.Soda.Price - money) + " more");
            }
            return money;
        }

        //inheritdoc
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
                Console.WriteLine("Giving " + item.Soda.Name + " out");
                item.ReduceQuantityByNumber(1);
            }
        }
    }
 }
