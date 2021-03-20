using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Runtime
    {
        public Generator stdGen = new Generator("Default", 0);
        public Player defaultPlayer;

        public Runtime(Player player, Generator gen)
        {
            defaultPlayer = player;
            stdGen = gen;
        }

        public Runtime()
        {
            defaultPlayer = this.stdGen.player();
        }

        public Dictionary<string, Event> Get_Events()
        {
            return EventDriver.Get_Events();
        }
        public Event Get_Event(string name)
        {
            return EventDriver.Get_Event(name);
        }
        public Dictionary<string, Item> Get_Items()
        {
            return ItemDriver.Get_Items();
        }
        public Item Get_Item(string name)
        {
            return ItemDriver.Get_Item(name);
        }
        public void Run_Event(string name)
        {
            EventDriver.Run_Event(name, this.defaultPlayer);
        }
        public void Run_Event(string name, Player player)
        {
            EventDriver.Run_Event(name, player);
        }
        public Dictionary<string, Map> Get_Maps()
        {
            return LocationDriver.Get_Maps();
        }
        public void Run(Location location)
        {
            location.run(this.defaultPlayer);
        }
        public void Run(Location location, Player player)
        {
            location.run(player);
        }
    }
}
