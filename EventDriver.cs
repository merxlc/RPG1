using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RPG1
{
    class EventDriver
    {

        public static List<string> options = new List<string>();
        public static Dictionary<string, XmlNode> results = new Dictionary<string, XmlNode>();

        public static Dictionary<string, Event> Get_Events()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\C#\\RPG1\\RPG1\\data\\events.xml");
            List<Event> eventList = new List<Event>();
            Dictionary<string, Event> eventDict = new Dictionary<string, Event>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                XmlNode driver = null;
                string eventName = null;
                string idName = node.Attributes["name"]?.InnerText;
                foreach (XmlNode subNode in node)
                {
                    string tag = subNode.Name;
                    switch (tag)
                    {
                        case "eventDriver":
                            driver = subNode;
                            break;
                        case "name":
                            eventName = subNode.InnerText;
                            break;
                    }
                }
                Event eventItem = new Event(idName, eventName, driver);
                eventList.Add(eventItem);
                eventDict.Add(idName, eventItem);
            }
            return eventDict;
        }

        public static Event Get_Event(string eventName)
        {
            Dictionary<string, Event> events = Get_Events();
            Event target = events[eventName];
            return target;
        }

        static string Make_Choice(List<string> options)
        {
            foreach (string option in options)
            {
                int ind = options.IndexOf(option);
                Console.WriteLine(String.Format("[{0}] {1}", ind, option));
            }
            string chosen = options[Convert.ToInt32(Console.ReadLine())];
            return chosen;
        }

        static void Run_RuntimeNode(XmlNode runtimeNode, Player player)
        {
            string nodeTag = runtimeNode.Name;
            switch (nodeTag)
            {
                case "text":
                    Console.WriteLine(runtimeNode.InnerText);
                    break;
                case "dialogueBox":
                    Console.WriteLine("=======================");
                    foreach (XmlNode dialogueNode in runtimeNode)
                    {
                        Run_RuntimeNode(dialogueNode, player);
                    }
                    Console.WriteLine("=======================");
                    break;
                case "choice":
                    options.Clear();
                    results.Clear();
                    foreach (XmlNode choiceNode in runtimeNode)
                    {
                        Run_RuntimeNode(choiceNode, player);
                    }
                    string chosen = Make_Choice(options);
                    XmlNode resultMatch = results[chosen];
                    foreach (XmlNode resultNode in resultMatch)
                    {
                        Run_RuntimeNode(resultNode, player);
                    }
                    break;
                case "option":
                    options.Add(runtimeNode.InnerText);
                    break;
                case "result":
                    Console.WriteLine(runtimeNode.Attributes["id"]?.InnerText);
                    results.Add(runtimeNode.Attributes["id"]?.InnerText, runtimeNode);
                    break;
                case "exp":
                    player.exp += Convert.ToInt32(runtimeNode.InnerText);
                    Console.WriteLine("You gained [" + runtimeNode.InnerText + "] exp. You now have ["+player.exp+"].");
                    break;
                case "gold":
                    player.gold += Convert.ToInt32(runtimeNode.InnerText);
                    Console.WriteLine("You gained [" + runtimeNode.InnerText + "] gold. You now have [" + player.gold + "].");
                    break;
                case "item":
                    Item gained_item = ItemDriver.Get_Item(runtimeNode.InnerText);
                    player.inventory.Add(gained_item);
                    break;
            }
        }

        public static void Run_Event_Obj(Event eventToRun, Player player)
        {
            XmlNode driver = eventToRun.eventDriver;
            foreach (XmlNode runtimeNode in driver)
            {
                Run_RuntimeNode(runtimeNode, player);
            }
        }

        public static void Run_Event(string eventName, Player player)
        {
            Run_Event_Obj(Get_Event(eventName), player);
        }
    }
}
