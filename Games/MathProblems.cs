using ConsoleGamesApp.Main;
using System.Security.Cryptography;

namespace ConsoleGamesApp.Games
{
    class MathProblems : GameData, IScorableGame
    {
        public MathProblems()
        {
            Name = "Math problems";
            Score = 0;
            Result = string.Empty;
            InitializeLoop();
        }

        public void InitializeLoop()
        {
            string[] gameDesc = { "You chose Math questions!", "You will be given a set of options to define question" };
            Helpers.PrintDesc(gameDesc);

            while (true)
            {
                NumsForGame mathObj = new NumsForGame();

                // Выбрать операцию из 2 ух случайных - 2 случайных 1 выбранное
                Menu mathMenu = new Menu(mathObj.execOperArr, true);
                mathMenu.PrintOptions("Chose operation: ");
                mathMenu.GetOption();
                if (mathMenu.ChosenOpt == mathObj.execOperArr.Length + 1)
                {
                    break;
                }
                mathObj.chosenOperIndex = mathMenu.ChosenOpt;
                Console.WriteLine("");


                // 2 раза выбрать число из 2 ух случайных - 2 случайных, 1 выбранное
                for (int i = 0; i < 2; i++)
                {
                    mathMenu.OptionsNums = mathObj.numbersArr[i];
                    mathMenu.PrintOptionsNums("Chose number: ");
                    mathMenu.GetOption();
                    if (mathMenu.ChosenOpt == mathObj.numbersArr[i].Length + 1)
                    {
                        break;
                    }
                    mathObj.numIndex[i] = mathMenu.AnswerToCheck;
                    Console.WriteLine("");
                }

                // Напечатать пример 
                Console.Clear();
                Console.WriteLine("Here is your math problem:");
                mathObj.WriteProblem(); // В меню убрать

                // Забрать ответ
                mathMenu.AnswerToCheck = Convert.ToInt32(Console.ReadLine()); // В меню убрать ReadInt

                // Проверить ответ
                mathMenu.Answer = mathObj.FormAnswer();
                Score += mathMenu.CheckAnswer(1);

                Console.Write("Press any key to continue...\n");
                Console.ReadKey();
            }
        }
    }

    class NumsForGame
    {
        private static int optionsSize = 2;

        public string[,] initOperArr = { { "Substract", "-" }, { "Add", "+" }, { "Multiple", "*" }, { "Divide", "/" } };
        public string[] execOperArr = new string[optionsSize];
        
        public int[] rndOperOption = Helpers.RandomNumbers(optionsSize, 4);
        public int chosenOperIndex;

        public int[][] numbersArr = { Helpers.RandomNumbers(optionsSize, 100, 15), Helpers.RandomNumbers(optionsSize, 15) };
        public int[] numIndex = new int[optionsSize];

        public NumsForGame()
        {
            for (int i = 0; i < optionsSize; i++)
            {
                execOperArr[i] = initOperArr[rndOperOption[i], 0];
            }
        }
        public void WriteProblem()
        {
            Console.Write("{0} {1} {2} = ? ", numbersArr[0][numIndex[0]], initOperArr[chosenOperIndex, 1], numbersArr[1][numIndex[1]]);
        }
        public int FormAnswer()
        {
            int answer = 0;
            int x = numbersArr[0][numIndex[0]];
            int y = numbersArr[1][numIndex[1]];
            switch (initOperArr[chosenOperIndex, 0])
            {
                case "Add":
                    answer = x + y;
                    break;
                case "Multiple":
                    answer = x * y;
                    break;
                case "Substract":
                    answer = x - y;
                    break;
                case "Divide":
                    answer = x / y;
                    break;
                default:
                    break;
            }
            return answer;
        }
    }
}
