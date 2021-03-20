using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class LocationDriver
    {
        public static Dictionary<string, Map> Get_Maps()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\C#\\RPG1\\RPG1\\data\\maps.xml");
            Dictionary<string, Map> mapDict = new Dictionary<string, Map>();

            foreach (XmlNode map in doc.DocumentElement.ChildNodes)
            {
                List<Location> mapLocations = new List<Location>();
                string mapIdName = map.Attributes["name"]?.InnerText;
                string mapName = "";
                foreach (XmlNode subNode in map)
                {
                    string nodeTag = subNode.Name;
                    switch (nodeTag)
                    {
                        case "name":
                            mapName = subNode.InnerText;
                            break;
                        case "locations":

                            foreach (XmlNode loc in subNode)
                            {
                                string locationIdName = loc.Attributes["name"]?.InnerText;
                                Dictionary<string, string> locationAttributes = new Dictionary<string, string>();

                                foreach (XmlNode locAttr in loc)
                                {
                                    locationAttributes.Add(locAttr.Name, locAttr.InnerText);
                                }

                                Location newLoc = new Location(locationIdName, locationAttributes);
                                mapLocations.Add(newLoc);
                            }

                            break;
                    }
                }
                Map mapObj = new Map(mapName, mapIdName, mapLocations);
                mapDict.Add(mapIdName, mapObj);
            }

            return mapDict;
        }
    }
}
