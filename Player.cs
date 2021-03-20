using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Player
    {
        public string name;
        public List<Item> inventory;
        public int exp;
        public int gold;

        public Player(string playerName, List<Item> playerInventory, int playerExp, int playerGold)
        {
            name = playerName;
            inventory = playerInventory;
            exp = playerExp;
            gold = playerGold;
        }

        public void info()
        {
            Console.WriteLine("====="+name+"=====");
            Console.WriteLine("EXP: " + exp);
            Console.WriteLine("gold: " + gold);
        }

    }
}
