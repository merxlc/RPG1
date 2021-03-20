using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Generator
    {

        public static string defaultName = "Default";
        public static int defaultNum = 0;

        public Generator(string name, int num)
        {
            defaultName = name;
            defaultNum = num;
        }

        public Player player()
        {
            string name = defaultName;
            List<Item> inventory = new List<Item>();
            int exp = defaultNum;
            int gold = defaultNum;
            return new Player(name, inventory, exp, gold);
        }
    }
}
