using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Location
    {

        public string idname;
        public Dictionary<string, string> attrs;

        public Location(string locationName, Dictionary<string, string> attributes)
        {
            idname = locationName;
            attrs = attributes;
        }

        public void info()
        {
            Console.WriteLine(attrs["name"]+" at ["+attrs["x"]+", "+attrs["y"]+"]");
        }

        public void run(Player player)
        {
            EventDriver.Run_Event(attrs["event"], player);
        }
    }
}
