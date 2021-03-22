using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG1
{
    class CombatDriver
    {
        public static Dictionary<string, Skill> Get_Skills()
        {
            Dictionary<string, Skill> skillDict = new Dictionary<string, Skill>();
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\C#\\RPG1\\RPG1\\data\\skills.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string skillIdName = node.Attributes["name"]?.InnerText;
                string skilltype = node.Attributes["type"]?.InnerText;
                string skillName = "";
                Dictionary<string, int> skillAttributes = new Dictionary<string, int>();

                foreach (XmlNode skillNode in node)
                {
                    string nodeName = skillNode.Name;
                    switch (nodeName)
                    {
                        case "name":
                            skillName = skillNode.InnerText;
                            break;
                        default:
                            skillAttributes.Add(nodeName, Convert.ToInt32(skillNode.InnerText));
                            break;
                    }
                }

                Skill newSkill = new Skill(skillName, skilltype, skillAttributes);
                skillDict.Add(skillIdName, newSkill);
            }

            return skillDict;
        }

        public static Skill Get_Skill(string name)
        {
            return Get_Skills()[name];
        }

        public static float Get_Damage(Skill skill, int distance) //1
        {
            float damage = skill.attributes["damage"]; //100
            float dropoff = skill.attributes["rangemod"]; //-10
            float dmgChange = ((100+dropoff)/100); //0.9
            float newDamage = (float) (damage * Math.Pow(dmgChange, distance));
            return newDamage;
        }

        public static Dictionary<string, CombatEncounter> Get_Encounters()
        {
            Generator gen = new Generator("default", 0, 20);
            Dictionary<string, CombatEncounter> encounterDict = new Dictionary<string, CombatEncounter>();
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\C#\\RPG1\\RPG1\\data\\encounters.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string encIdName = node.Attributes["id"]?.InnerText;
                string encName = "";
                List<Player> encEnemies = new List<Player>();

                foreach (XmlNode subnode in node)
                {
                    switch (subnode.Name)
                    {
                        case "name":
                            encName = subnode.InnerText;
                            break;
                        case "enemy":
                            Player newEn = gen.player();
                            foreach (XmlNode enAttr in subnode)
                            {
                                switch (enAttr.Name)
                                {
                                    case "skill":
                                        newEn.skills.Add(Get_Skill(enAttr.InnerText));
                                        break;
                                    case "name":
                                        newEn.name = enAttr.InnerText;
                                        break;
                                }
                            }
                            encEnemies.Add(newEn);
                            break;
                    }
                }

                CombatEncounter newEnc = new CombatEncounter(encName, encIdName, encEnemies);
                encounterDict.Add(encIdName, newEnc);
            }
            return encounterDict;
        }

    }
}
