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
            Generator MainGen = new Generator("Default", 0);
            Player test_player = MainGen.player();

            EventDriver.Run_Event("TEST_EVENT_1", test_player);
            test_player.info();

            Console.ReadLine();
        }
    }
}
