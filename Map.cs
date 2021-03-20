using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Map
    {

        public string name;
        public string idname;
        public List<Location> locations;

        public Map(string mapName, string mapIdName, List<Location> mapLocations)
        {
            name = mapName;
            idname = mapIdName;
            locations = mapLocations;
        }

        public void info()
        {
            Console.WriteLine(name);
            foreach (Location loc in locations)
            {
                loc.info();
            }
        }

    }
}
