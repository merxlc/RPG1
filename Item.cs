using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Item
    {
        public string name;
        public string rarity;

        public Item(string itemName, string itemRarity)
        {
            name = itemName;
            rarity = itemRarity;
        }
    }
}
