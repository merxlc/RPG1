using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class ItemDriver
    {
        public static Dictionary<string, Item> Get_Items()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\C#\\RPG1\\RPG1\\data\\items.xml");
            Dictionary<string, Item> itemDict = new Dictionary<string, Item>();

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                Dictionary<string, string> attribs = new Dictionary<string, string>();
                string itemName = node.Attributes["name"]?.InnerText;
                foreach (XmlNode itemNode in node)
                {
                    attribs.Add(itemNode.Name, itemNode.InnerText);
                }

                Item addedItem = new Item(attribs);
                itemDict.Add(itemName, addedItem);
            }
            return itemDict;
        }

        public static Item Get_Item(string itemname)
        {
            Dictionary<string, Item> items = Get_Items();
            return items[itemname];
        }
    }
}
