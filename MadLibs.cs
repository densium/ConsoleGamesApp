namespace ConsoleGamesApp
{
    class MadLibs
    {
        public static void InitializeLoop()
        {
            // Games desc
            Console.WriteLine("You chose Mad Libs! You will be given a set of scenarios ot chose from");
            Console.WriteLine("App will find all occurensies of such kind {{:NOUN}} and replace it with a proper word");
            Console.Write("Press any key to continue...");
            Console.ReadKey();

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
            Console.WriteLine("Here is the list of available scenarios:");
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
            int tagStartIndex;
            int tagStopIndex;
            string tagType;
            string randomWord;
            while (true)
            {
                tagStartIndex = line.IndexOf("{{:");
                if (tagStartIndex == -1)
                {
                    return line;
                }
                else
                {
                    tagStopIndex = line.IndexOf("}}") + 2;
                    tagType = line.Substring(tagStartIndex, tagStopIndex - tagStartIndex);
                    randomWord = RandomWord(GetWordsArray(tagType));
                    line = line.Replace(tagType, randomWord);
                }
            }
        }
        static string RandomWord(string[] wordsArray)
        {
            Random rnd = new Random();
            int arrayIndex = rnd.Next(wordsArray.Length);
            return wordsArray[arrayIndex];
        }
        static string[] GetWordsArray(string wordType)
        {
            string[] wordsArray = new string[200];
            switch (wordType)
            {
                case "{{:NOUN}}":
                    string[] nounsArray = {
                        "Tentacle","Bagpipes","Whammy","Vandyke Beard","Stink Bomb","Black Magic","Loose Cannon","Teddy Bear","Meatwagon",
            "Swampland","Skin And Bones","Godmother","Evil Eye","Chicanery","Tail Feather","Gizmo","Pandemonium","Great Power",
            "Creepy-Crawly","Boogeyman","Mission from God","Elixir Of Life","Billy Goat","Wacko","Tabby Cat","Goblet","Gooseberry Bush",
            "Enchantment","Dance of Death","Law Of The Land","Road-Kill","Controlled Substance","Rainbow Trout","Tribute","Houses Of Parliament",
            "Peer Of The Realm","Holy Terror","Private Security Force","Wastepaper Basket","Eternal Damnation","Unnoticed Mango",
            "Rocket Launcher","Personal Doodad","Barnacle","Thunderbird","Snake Pit","Superstructure","Smoked Salmon","Murderess",
            "Werewolf" };
                    wordsArray = nounsArray;
                    break;
                case "{{:ADJECTIVE}}":
                    string[] adjectiveArray = { "Tactical","No - Show","Troublemaking","Hydraulic","Lambskin","Wild - Eyed","Cranky","Woolly - Haired","Glowering",
            "Tiger - Striped","Babbling","Bombshell","Nutcase","Departmental","Thrashing","Spiraling","Hotheaded",
            "Over - The - Counter","Droopy","Lizard - like","Earthbound","Exterminating","Forensic","Overstuffed","Sidekick",
            "Iron - Clad","Sleuthing","Well - Informed","Freaky","State of the Art","Bloodsucking","Provoking",
            "Predatory","Self - Serving","Rumbling","Muddled","Creaky","Deadbeat","Taunting","Four - Poster",
            "Smoking","Ultraviolet","Wannabe","Sheepish","Murderous","Flat - Footed","Ransacking","Cold - Blooded",
            "Bad - Tempered","Turn Of The Century" };
                    wordsArray = adjectiveArray;
                    break;
                case "{{:ADVERB}}":
                    string[] adverbArray = { "really","very","well","badly","today","yesterday","everyday","sometimes","often",
            "rarely","early","late","soon","here","there","everywhere" };
                    wordsArray = adverbArray;
                    break;
                case "{{:BODY_PART}}":
                    string[] bodyPartArray = { "Head","Face","Hair","Ear","Neck","Forehead","Beard","Eye","Nose","Mouth","Chin",
            "Shoulder","Elbow","Arm","Chest","Armpit","Forearm","Wrist","Back","Navel","Toes",
            "Ankle","Instep","Toenail","Waist","Abdomen","Buttock","Hip","Leg","Thigh","Knee","Foot","Hand","Thumb" };
                    wordsArray = bodyPartArray;
                    break;
                case "{{:NOUN_PL}}":
                    string[] nounPlArray = { "addenda","addendums","aircraft","alumnae","alumni","analyses","antennas","antitheses",
            "apexes","appendixes","axes","bacilli","bacteria","bases","beaus","bison","bureaus",
            "cactuses","children","codices","crises","women","men" };
                    wordsArray = nounPlArray;
                    break;
                case "{{:VERB}}":
                    string[] verbArray = { "be","have","do","say","go","can","get","would","make","know","will","think","take",
            "see","come","could","want","look","use","find","give","tell","work","may","should",
            "call","try","ask","need","feel","become","leave","put","mean","keep","let","begin",
            "seem","help","talk","turn","start","might","show","hear","play","run","move","like",
            "live in","believe","hold","bring","happen","must","write","provide","sit","stand",
            "lose","pay","meet","include","continue","set","learn","change","lead","understand",
            "watch","follow","stop","create","speak","read","allow","add","spend","grow","open",
            "walk","win","offer","remember","love","consider","appear","buy","wait","serve","die",
            "send","expect","build","stay","fall","cut","reach","kill","remain" };
                    wordsArray = verbArray;
                    break;
                default:
                    break;
            }
            return wordsArray;
        }
    }
}
