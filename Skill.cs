using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class Skill
    {
        public string name;
        public string type;
        public Dictionary<string, int> attributes;

        public Skill(string skillName, string skillType, Dictionary<string, int> attribs)
        {
            name = skillName;
            type = skillType;
            attributes = attribs;
        }

        public void wrt(string text, string val)
        {
            Console.WriteLine(text + ": " + attributes[val]);
        }

        public void info()
        {
            Console.WriteLine("[" + type + "] Skill: " + name);
            switch (this.type){

                case "damaging":
                    wrt("Damage", "damage");
                    wrt("Damage Dropoff", "rangemod");
                    wrt("Base Damage", "base");
                    wrt("Max Damage", "max");
                    break;
                case "healing":
                    wrt("Heal Amount", "healAmount");
                    wrt("Range", "range");
                    break;

            }
        }
        
    }
}
