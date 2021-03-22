using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class CombatEncounter
    {
        public string name;
        public string idName;
        public List<Player> enemies;

        public CombatEncounter(string encounterName, string encounterIdName, List<Player> encounterEnemies)
        {
            name = encounterName;
            idName = encounterIdName;
            enemies = encounterEnemies;
        }

        public void info()
        {
            Console.WriteLine(name);
            foreach (Player enemy in enemies)
            {
                enemy.info(true);
            }
        }

        public void info(bool isEnemy)
        {
            Console.WriteLine(name);
            foreach (Player enemy in enemies)
            {
                enemy.info(isEnemy);
            }
        }

        public void run(Player player)
        {
            int enemyHps = 1000;
            while (enemyHps > 0)
            {
                enemyHps = 0;
                foreach (Player enem in enemies)
                {
                    enemyHps += enem.health;
                }
                Dictionary<int, string> options = new Dictionary<int, string>();
                Console.WriteLine("What would you like to do? Options: ");
                options.Add(0, "View enemy info");
                options.Add(1, "Use a skill");
                foreach(int key in options.Keys)
                {
                    Console.WriteLine("["+key+"] "+options[key]);
                }
                string choice = options[Convert.ToInt32(Console.ReadLine())];
                switch (choice)
                {
                    case "View enemy info":
                        foreach(Player enem in enemies)
                        {
                            enem.info(true);
                        }
                        break;
                    case "Use a skill":
                        Dictionary<int, Skill> skilloptions = new Dictionary<int, Skill>();
                        int j = 0;
                        foreach(Skill skill in player.skills)
                        {
                            skilloptions.Add(j, skill);
                            j += 1;
                        }
                        foreach(int ind in skilloptions.Keys)
                        {
                            Console.WriteLine("[" + ind + "] " + "{"+skilloptions[ind].type+"} " + skilloptions[ind].name);
                        }
                        Skill chosen = skilloptions[Convert.ToInt32(Console.ReadLine())];
                         
                        break;
                }
            }
            
        }
    }
}
