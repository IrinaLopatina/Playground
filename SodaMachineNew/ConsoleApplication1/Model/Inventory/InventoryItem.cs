using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineNew.Model.Inventory
{
    public class InventoryItem
    {
        public Soda Soda { get; private set; }
        public int Quantity { get; private set; }
        public InventoryItem(Soda soda, int quantity) 
        {
            Soda = soda;
            Quantity = quantity;
        }

        public void ReduceQuantityByNumber(int quantity)
        {  
            Quantity -= quantity; 
        }
    }
}
