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
            Runtime main = new Runtime();
            Player test_player = main.stdGen.player();
            main.defaultPlayer = test_player;

            //main.Run_Event("TEST_EVENT_1");
            //test_player.info();

            Dictionary<string, Map> maps = main.Get_Maps();
            foreach (string mapkey in maps.Keys)
            {
                Map map = maps[mapkey];
                map.info();
                foreach (Location loc in map.locations)
                {
                    main.Run(loc, test_player);
                }
            }

            Console.ReadLine();
        }
    }
}
