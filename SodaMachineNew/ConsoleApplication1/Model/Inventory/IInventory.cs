using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineNew.Model.Inventory
{ 
    /// <summary>
    /// Contains inventory functions
    /// </summary>
    public interface IInventory
    {
        /// <summary>
        /// Gets inventory item by name, returns null if no such item exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        InventoryItem GetInventoryItemByName(string name);
        
        /// <summary>
        /// Gives out soda and change, reduces inventory quantity by 1
        /// </summary>
        /// <param name="sodaName">Soda name</param>
        /// <param name="money">Money</param>
        /// <returns></returns>
        double OrderSoda(string sodaName, double money);
        
        /// <summary>
        /// Reserves soda, reduces inventory quantity by 1
        /// </summary>
        /// <param name="sodaName">Soda name</param>
        void SmsOrderSoda(string sodaName);
    }   
}
