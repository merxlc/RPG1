using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RPG1
{
    class Event
    {
        public string idName;
        public string eventName;
        public XmlNode eventDriver;

        public Event(string id, string name, XmlNode driver)
        {
            idName = id;
            eventName = name;
            eventDriver = driver;
        }

        public void info()
        {
            Console.WriteLine(String.Format("====={0}=====", eventName));
            Console.WriteLine("ID: "+idName);
            Console.WriteLine(eventDriver);
        }
    }
}
