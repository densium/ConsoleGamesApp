using System;
using System.IO;

namespace ConsoleGamesApp
{
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
            // Check for files, check if there is any
            string[] madLibsfiles = Directory.GetFiles("./", "*.txt");
            if (madLibsfiles.Length == 0)
            {
                Console.WriteLine("There is no files to play with");
                Console.Write("Press any key to return to main menu...");
                Console.ReadKey();
                return;
            }

            // Show the list of available files
            Console.WriteLine("Here is the list of available scenarios");
            byte n = 0;
            string fileText;
            int endPos;
            foreach (string file in madLibsfiles)
            {
                n++;
                endPos = file.Length - 6; // minus .txt
                fileText = file.Substring(2, endPos); // minus ./
                Console.WriteLine("{0}. {1}", n, fileText);
            }

            // Choose one file
            string userText;
            byte option;
            bool menuLoop = true;
            string pathToFile = "./Some_file.txt"; // placeholder for compiler
            while (menuLoop)
            {
                Console.Write("Choose one: ");
                userText = Console.ReadLine();
                try
                {
                    option = Convert.ToByte(userText);
                    if (option > madLibsfiles.Length)
                    {
                        Console.WriteLine("There is no such an option");
                    } 
                    else
                    {
                        pathToFile = madLibsfiles[option - 1];
                        menuLoop = false;
                        Console.WriteLine("Here is your generated scenario:");
                        Thread.Sleep(300);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // Read file and replace tags
            StreamReader reader = null;
            string line;
            try
            {
                reader = new StreamReader(pathToFile);
                line = reader.ReadLine();

                while (line != null)
                {
                    line = ReplaceTags(line);
                    Console.WriteLine(line);
                    Thread.Sleep(300);
                    line = reader.ReadLine();
                }
                reader.Close();
                Console.WriteLine("---");
                Console.Write("Press any key to return to main menu...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        static string ReplaceTags(string line)
        {
            int tagStartIndex = line.IndexOf("{{:");
            if (tagStartIndex != -1) //Check if there is any value of that type
            {
                tagStartIndex += 3;
                int tagStopIndex = line.IndexOf("}}");
                string tagType = line.Substring(tagStartIndex, tagStopIndex - tagStartIndex);
                string resultString;
                string randomWord;

                switch (tagType)
                {
                    case "NOUN":
                        randomWord = RandomWord(GetNounArray());
                        resultString = line.Replace("{{:NOUN}}", randomWord);
                        return resultString;
                    case "ADJECTIVE":
                        randomWord = RandomWord(GetAdjectiveArray());
                        resultString = line.Replace("{{:ADJECTIVE}}", randomWord);
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
        static string RandomWord(string[] wordsArray)
        {
            Random rnd = new Random();
            int arrayIndex = rnd.Next(wordsArray.Length);
            return wordsArray[arrayIndex];
        }
        static string[] GetNounArray()
        {
            string[] nounArray = { "Tentacle","Bagpipes","Whammy","Vandyke Beard","Stink Bomb","Black Magic","Loose Cannon","Teddy Bear","Meatwagon",            "Swampland","Skin And Bones","Godmother","Evil Eye","Chicanery","Tail Feather","Gizmo","Pandemonium","Great Power",            "Creepy-Crawly","Boogeyman","Mission from God","Elixir Of Life","Billy Goat","Wacko","Tabby Cat","Goblet","Gooseberry Bush",            "Enchantment","Dance of Death","Law Of The Land","Road-Kill","Controlled Substance","Rainbow Trout","Tribute","Houses Of Parliament",
            "Peer Of The Realm","Holy Terror","Private Security Force","Wastepaper Basket","Eternal Damnation","Unnoticed Mango",
            "Rocket Launcher","Personal Doodad","Barnacle","Thunderbird","Snake Pit","Superstructure","Smoked Salmon","Murderess",
            "Werewolf" };
            return nounArray;
        }
        static string[] GetAdjectiveArray()
        {
            string[] adjectiveArray = { "Tactical","No - Show","Troublemaking","Hydraulic","Lambskin","Wild - Eyed","Cranky","Woolly - Haired","Glowering",
            "Tiger - Striped","Babbling","Bombshell","Nutcase","Departmental","Thrashing","Spiraling","Hotheaded",
            "Over - The - Counter","Droopy","Lizard - like","Earthbound","Exterminating","Forensic","Overstuffed","Sidekick",
            "Iron - Clad","Sleuthing","Well - Informed","Freaky","State of the Art","Bloodsucking","Provoking",
            "Predatory","Self - Serving","Rumbling","Muddled","Creaky","Deadbeat","Taunting","Four - Poster",
            "Smoking","Ultraviolet","Wannabe","Sheepish","Murderous","Flat - Footed","Ransacking","Cold - Blooded",
            "Bad - Tempered","Turn Of The Century" };
            return adjectiveArray;
        }
    }
}
