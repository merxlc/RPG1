using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Generator
    {

        public string defaultName;
        public int defaultSmall;
        public int defaultLarge;

        public Generator(string name, int small, int large)
        {
            defaultName = name;
            defaultSmall = small;
            defaultLarge = large;
        }

        public Player player()
        {
            string name = defaultName;
            List<Item> inventory = new List<Item>();
            List<Skill> skills = new List<Skill>();
            int exp = defaultSmall;
            int gold = defaultSmall;
            int health = defaultLarge;
            return new Player(name, inventory, exp, gold, skills, health);
        }
    }
}
