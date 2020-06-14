using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Functions
{
    class Inventory
    {
        public void addInventory(int itemId, int quantity)
        {
            //Insert Database Command with itemId - Query Line - Search for Match
            //Insert Database Command with itemId and quantity - Update Line
        }

        public void registerItem(int itemId, string itemName, double price) {
            //Insert Database Command with itemId - Query Line - Search for match
            //Insert Database Command with itemId, itemName, and price - Insert to Table
        }
    }
}
