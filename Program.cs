using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Program
    {
        static void Main(string[] args)
        {
            Runtime main = new Runtime(); Player test_player = main.stdGen.player(); main.defaultPlayer = test_player; test_player.Add_Skill("SLASH"); test_player.Add_Skill("HEAL");

            //EVENT RUNNING
            //main.Run_Event("TEST_EVENT_1");test_player.info();

            //LOCATION EVENT RUNNING
            //Dictionary<string, Map> maps = main.Get_Maps();foreach (string mapkey in maps.Keys){Map map = maps[mapkey];map.info();foreach (Location loc in map.locations){main.Run(loc, test_player);}}

            //SKILL GATHERING
            //Dictionary<string, Skill> skills = main.Get_Skills();foreach (string skillname in skills.Keys){Skill skill = skills[skillname];skill.info();}

            //SKILL DAMAGE TESTING
            //foreach (float dmg in main.Get_Damages(main.Get_Skill("SLASH"), 0, 5)) {Console.WriteLine(dmg);}

            //COMBAT ENCOUNTER READING
            //Dictionary<string, CombatEncounter> encounters = main.Get_Encounters();foreach (string key in encounters.Keys){encounters[key].info(true);}

            //COMBAT ENCOUNTER RUNNING
            CombatEncounter encounter = main.Get_Encounter("ENCOUNTER_1");encounter.run(test_player);

            Console.ReadLine();
        }
    }
}
