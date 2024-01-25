using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGamesApp.Main
{
    class GameData
    {
        public int Score { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public string[] GameDesc { get; set; }
        
        public GameData()
        {
        }

        public static void PrintDesc(string[] gamedesc)
        {
            foreach (var line in gamedesc)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
