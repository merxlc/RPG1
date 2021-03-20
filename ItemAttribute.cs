using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{


    class ItemAttribute
    {
        public string name;
        public string value;
        public XmlAttributeCollection attrs;
        private string attrsString;

        public ItemAttribute(string attrName, string attrValue, XmlAttributeCollection attrAttrs)
        {
            name = attrName;
            value = attrValue;
            attrs = attrAttrs;
            attrsString = "";
            foreach(XmlAttribute entry in attrs)
            {
                attrsString += entry.Name + ": "+entry.InnerText+", ";
            }
        }

        public void info()
        {
            string final = "[" + name + "] " + value;
            if (attrsString.Length > 1)
            {
                final += " {" + attrsString.Remove(attrsString.Length - 2) + "}";
            }
            Console.WriteLine(final);
        }

    }
}
