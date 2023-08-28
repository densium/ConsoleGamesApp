﻿namespace ConsoleApp
{
    class Menu
    {
        static void Main(string[] args)
        {
            string[] availableGames = {
                "1. Capital cities - You will be given a country name, you should write down it's capital city",
                "2. Math problems - Simple math problems to solve",
                "3. Mad Libs - Random story with random words in it"
            };

            Console.WriteLine("Hello! Welcome to my first C# program");
            while (true)
            {
                Console.WriteLine("Here is a set of available games");
                foreach (string gameDesc in availableGames)
                {
                    Console.WriteLine(gameDesc);
                }
                Console.Write("Choose the game you want to run: ");
                string userText = Console.ReadLine();

                switch (userText)
                {
                    case "1":
                        Console.WriteLine("---");
                        CapitalCitiesGame.InitializeLoop();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("---");
                        MathProblemsGame.InitializeLoop();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("---");
                        MadLibsGame.InitializeLoop();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Sorry, there is no such a game");
                        Console.WriteLine("---");
                        break;
                }
            }
        }
    }

    class CapitalCitiesGame
    {
        public static void InitializeLoop()
        {
            Console.WriteLine("Answer with the name of capital city of given country");
            Console.ReadLine();
        }
    }

    class MathProblemsGame
    {
        public static void InitializeLoop()
        {
            decimal firstInt;
            decimal secondInt;
            string userText;

            while (true)
            {
                try
                {
                    Console.Write("Enter first number: ");
                    userText = Console.ReadLine();
                    if (userText == "exit")
                    {
                        break;
                    }

                    firstInt = Convert.ToDecimal(userText);
                    Console.Write("Enter second number: ");
                    userText = Console.ReadLine();
                    secondInt = Convert.ToDecimal(userText);

                    Console.WriteLine("The largest number is: " + GetMax(firstInt, secondInt));
                    Console.WriteLine("---");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void InitializeGetSqrt()
        {
            double firstInt;
            string userText;

            while (true)
            {
                try
                {
                    Console.Write("Enter number: ");
                    userText = Console.ReadLine();
                    if (userText == "exit")
                    {
                        break;
                    }

                    firstInt = Convert.ToDouble(userText);
                    Console.WriteLine("The result is: " + Math.Sqrt(firstInt));
                    Console.WriteLine("---");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        static decimal GetMax(decimal firstInt, decimal secondInt)
        {
            if (firstInt > secondInt)
            {
                return firstInt;
            }
            else
            {
                return secondInt;
            }
        }
    }

    class MadLibsGame
    {
        public static void InitializeLoop()
        {
            string userText;
            StreamReader reader = null;
            string line;

            Console.Write("Tell me the path to file: ");
            userText = Console.ReadLine();

            try
            {
                reader = new StreamReader(userText);
                line = reader.ReadLine();

                while (line != null)
                {
                    //change variable by random value
                    line = ReplaceTags(line);
                    //write the line to console window
                    Console.WriteLine(line);
                    // Read the next line
                    line = reader.ReadLine();
                }
                //close the file
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static string ReplaceTags(string line)
        {
            int tagStartIndex = line.IndexOf("{{:");
            if (tagStartIndex != -1)
            {
                tagStartIndex += 3;
                int tagStopIndex = line.IndexOf("}}");
                string tagType = line.Substring(tagStartIndex, tagStopIndex - tagStartIndex);
                string resultString;
                switch (tagType)
                {
                    case "NOUN":
                        resultString = line.Replace("{{:NOUN}}", RandomWord(tagType));
                        return resultString;
                    default:
                        return line;
                }
            }
            else
            {
                return line;
            }
        }
        static string RandomWord(string wordType)
        {
            Random rnd = new Random();

            switch (wordType)
            {
                case "NOUN":
                    string[] nounArray = { "Rufus", "Bear", "Dakota", "Fido",
                          "Vanya", "Samuel", "Koani", "Volodya",
                          "Prince", "Yiska" };
                    int mIndex = rnd.Next(nounArray.Length);
                    return nounArray[mIndex];
                default:
                    return "place holder";
            }
        }
    }
}