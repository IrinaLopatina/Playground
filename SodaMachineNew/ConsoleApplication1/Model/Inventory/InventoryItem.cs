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
        public int Nr { get; private set; }
        public InventoryItem(Soda soda, int nr) 
        {
            Soda = soda;
            Nr = nr;
        }

        public void ReduceQuantityByNumber(int number)
        {  
            Nr = -- number; 
        }
    }
}
