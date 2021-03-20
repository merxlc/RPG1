using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Item
    {
        public Dictionary<string, string> attributes;

        public Item(Dictionary<string, string> attribs)
        {
            attributes = attribs;
        }
        public void info()
        {
            Console.WriteLine("====="+attributes["name"]+"=====");
            Console.WriteLine("Rarity: " + attributes["rarity"]);
        }
    }
}
