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
        public List<Skill> skills;
        public int health;

        public Player(string playerName, List<Item> playerInventory, int playerExp, int playerGold, List<Skill> playerSkills, int playerHealth)
        {
            name = playerName;
            inventory = playerInventory;
            exp = playerExp;
            gold = playerGold;
            skills = playerSkills;
            health = playerHealth;
        }

        public void Add_Skill(string skill)
        {
            skills.Add(CombatDriver.Get_Skill(skill));
        }

        public void info()
        {
            Console.WriteLine("====="+name+"=====");
            Console.WriteLine("EXP: " + exp);
            Console.WriteLine("Gold: " + gold);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("==INVENTORY==");
            foreach (Item ite in inventory)
            {
                ite.info();
            }
            Console.WriteLine("==SKILLS==");
            foreach (Skill skil in skills)
            {
                skil.info();
            }
        }

        public void info(bool isEnemy)
        {
            Console.WriteLine("=====" + name + "=====");
            if (isEnemy)
            {
                Console.WriteLine("Health: " + health);
                Console.WriteLine("==SKILLS==");
                foreach (Skill skil in skills)
                {
                    skil.info();
                }
            }
            else
            {
                Console.WriteLine("EXP: " + exp);
                Console.WriteLine("gold: " + gold);
                Console.WriteLine("Health: " + health);
                Console.WriteLine("==INVENTORY==");
                foreach (Item ite in inventory)
                {
                    ite.info();
                }
                Console.WriteLine("==SKILLS==");
                foreach (Skill skil in skills)
                {
                    skil.info();
                }
            }
        }

    }
}
