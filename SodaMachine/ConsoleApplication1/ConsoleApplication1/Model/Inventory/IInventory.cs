﻿namespace ConsoleApplication1.Model.Inventory
{
    public interface IInventory
    {
        int OrderSoda(string sodaType, int money);
        void SmsOrderSoda(string sodaType);
    }
}