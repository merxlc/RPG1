using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Item
    {
        public Dictionary<string, ItemAttribute> attributes;

        public Item(Dictionary<string, ItemAttribute> attribs)
        {
            attributes = attribs;
        }

        public void info()
        {
            Console.WriteLine("====="+attributes["name"].value+"=====");
            foreach (string attr in attributes.Keys)
            {
                attributes[attr].info();
            }
        }
    }
}
