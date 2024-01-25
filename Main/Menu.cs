using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGamesApp.Main
{
    class Menu
    {
        public int ChosenOpt { get; set; }
        public int OptToArr { get; set; }
        public int LastOpt { get; set; }
        public int Answer { get; set; }
        public string[] Options { get; set; }
        public int[] OptionsNums { get; set; }
        public List<string> OptionsList { get; set; }
        public string UserText { get; set; }
        public int[] Answers { get; set; }
        public bool QuitOpt { get; set; }

        public Menu(string[] options, bool quitOpt)
        {
            UserText = string.Empty;
            Options = options;
            OptionsList = new List<string>();
            Answers = new int[1];
            OptionsNums = new int[1];
            QuitOpt = quitOpt;
        }

        public Menu(string[] options, int answer)
        {
            UserText = string.Empty;
            Answer = answer;
            Options = options;
            OptionsList = new List<string>();
            Answers = new int[1];
            OptionsNums = new int[1];
            QuitOpt = true;
        }

        public Menu(int[] options, int answer)
        {
            UserText = string.Empty;
            Answer = answer;
            OptionsNums = options;
            OptionsList = new List<string>();
            Answers = new int[1];
            Options = new string[1];
            QuitOpt = true;
        }

        public void PrintOptions()
        {
            byte n = 1;
            foreach (string option in Options)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
            if (QuitOpt)
            { 
                Console.WriteLine($"{n}. -- Quit --");
            }
        }
        public void PrintOptions(string firstLine)
        {
            Console.WriteLine(firstLine);
            byte n = 1;
            foreach (string option in Options)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
            if (QuitOpt)
            {
                Console.WriteLine($"{n}. -- Quit --");
            }
        }
        
        public void PrintOptionsNums()
        {
            byte n = 1;
            foreach (int option in OptionsNums)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
            if (QuitOpt)
            {
                Console.WriteLine($"{n}. -- Quit --");
            }
        }

        public void PrintOptionsNums(string firstLine)
        {
            Console.WriteLine(firstLine);
            byte n = 1;
            foreach (int option in OptionsNums)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
            Console.WriteLine($"{n}. -- Quit --");
        }
        
        public void PrintOptionsList()
        {
            byte n = 1;
            foreach (string option in OptionsList)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
        }

        public void GetOption(string choseLine = "Chose option: ")
        {
            bool menuLoop = true;
            while (menuLoop)
            {
                Console.Write(choseLine);
                UserText = Console.ReadLine();

                if (UserText == null)
                {
                    Console.WriteLine("No options chosen");
                    break;
                }

                try
                {
                    ChosenOpt = Convert.ToByte(UserText);
                    OptToArr = ChosenOpt - 1; // To array index
                }
                catch (Exception e)
                {
                    Console.WriteLine("There is no such an option");
                    break;
                }

                if (ChosenOpt == 0 || ChosenOpt > Options.Length + 1) // + quit option
                {
                    Console.WriteLine("There is no such an option");
                    break;
                } 
                else
                {
                    menuLoop = false;
                }
            }
        }

        public int CheckAnswer(int rate)
        {
            LastOpt = ChosenOpt;
            int score = 0;

            if (OptToArr == Answer)
            {
                score = 10 * rate;
                // Console.WriteLine($"You chose: {ChosenOpt}");
                // Console.WriteLine($"Answer is: {Answer}");
                Console.WriteLine($"Right answer! + {score} points");
                Console.WriteLine("");
            }
            else
            {
                // Console.WriteLine($"You chose: {ChosenOpt}");
                // Console.WriteLine($"Answer is: {Answer}");
                Console.WriteLine("Wrong answer!");
                Console.WriteLine("");
            }

            return score;
        }
    }
}
