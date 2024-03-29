﻿using ConsoleGamesApp.Main;

namespace ConsoleGamesApp.Games
{
    class MadLibs : GameData, IScorableGame
    {
        public MadLibs()
        {
            Name = "Mad libs";
            Score = 0;
            Result = string.Empty;
            InitializeLoop();
        }

        public void InitializeLoop()
        {
            string[] gameDesc = { "You chose Mad Libs! You will be given a set of scenarios ot chose from",
                "App will find all occurensies of such kind {{:NOUN}} and replace it with a proper word" };
            Helpers.PrintDesc(gameDesc);

            Menu libsList = new Menu(Directory.GetFiles("./", "*.txt"), false);
            if (libsList.Options.Length == 0)
            {
                Console.WriteLine("There is no files to play with");
                Helpers.WaitToQuit();
                return;
            }

            libsList.PrinOptionsCut("Here is the list of available scenarios:", 2, 6);
            libsList.GetOption();
            Console.WriteLine("");
            Console.WriteLine("Here is your generated scenario:");
            Thread.Sleep(250);

            try
            {
                StreamReader reader = new StreamReader(libsList.Options[libsList.AnswerToCheck]);
                
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = ReplaceTags(line);
                    Console.WriteLine(line);
                    Thread.Sleep(250);
                    line = reader.ReadLine();
                }
                reader.Close();
                Console.WriteLine("");
                Helpers.WaitToQuit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        private string ReplaceTags(string line)
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
        private string RandomWord(string[] wordsArray)
        {
            Random rnd = new Random();
            int arrayIndex = rnd.Next(wordsArray.Length);
            return wordsArray[arrayIndex];
        }
        private string[] GetWordsArray(string wordType)
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
