using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGamesApp.Main
{
    class Helpers
    {
        public static int[] RandomNumbers(int howMany, int maxValue, int minValue = 0)
        {
            Random rnd = new Random();
            int[] numsArr = new int[howMany];
            for (int i = 0; i < howMany; i++)
            {
                numsArr[i] = rnd.Next(minValue, maxValue);
            }
            return numsArr;
        }

        public static string[] Get1DFrom2D(string[,] inArr, int fieldIndex, int[] indexes)
        {
            string[] outArr = new string[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
            {
                outArr[i] = inArr[indexes[i], fieldIndex];
            }
            return outArr;
        }

        public static void WaitToQuit()
        {
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
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