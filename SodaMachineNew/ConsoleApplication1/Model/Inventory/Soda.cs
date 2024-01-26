using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineNew.Model.Inventory
{
    public class Soda
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Soda(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
