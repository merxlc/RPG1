using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Runtime
    {
        public Generator stdGen = new Generator("Default", 0, 20);
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
        public Dictionary<string, Skill> Get_Skills()
        {
            return CombatDriver.Get_Skills();
        }
        public Skill Get_Skill(string name)
        {
            return CombatDriver.Get_Skill(name);
        }
        public float Get_Damage(Skill skill, int distance)
        {
            return CombatDriver.Get_Damage(skill, distance);
        }
        public List<float> Get_Damages(Skill skill, int start, int end)
        {
            List<float> damages = new List<float>();for (int i=start; i-1<end; i++){damages.Add(Get_Damage(skill, i));}return damages;
        }
        public Dictionary<string, CombatEncounter> Get_Encounters()
        {
            return CombatDriver.Get_Encounters();
        }
        public CombatEncounter Get_Encounter(string name)
        {
            return Get_Encounters()[name];
        }
    }
}
