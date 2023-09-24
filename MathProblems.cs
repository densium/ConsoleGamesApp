namespace ConsoleGamesApp
{
    class NumsForGame : GameObject
    {
        private static int optSize = 2;

        public string[,] initOperArr = { { "Substract", "-" }, { "Add", "+" }, { "Multiple", "*" }, { "Divide", "/" } };
        public int[] rndOperOption = RandomNumbers(optSize, 4);
        public string[] execOperArr = new string[optSize];
        public int chosenOperIndex;

        public int[][] numbersArr = { RandomNumbers(optSize, 100, 15) , RandomNumbers(optSize, 15) };
        public int[] numIndex = new int[optSize];

        public NumsForGame()
        {
            for (int i = 0; i < optSize; i++)
            {
                execOperArr[i] = initOperArr[rndOperOption[i], 0];
            }
        }
        public void WriteProblem ()
        {
            Console.Write("{0} {1} {2} = ? ", numbersArr[0][numIndex[0]], initOperArr[chosenOperIndex, 1], numbersArr[1][numIndex[1]]);
        }
        public bool CheckAnswer(int check)
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

            if (answer == check)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class MathProblems
    {
        public static void InitializeLoop()
        {
            Console.WriteLine("You chose Math questions! You will be given a set of options to define question");
            Console.Write("Press any key to continue...\n");
            Console.ReadKey();
            
            while (true)
            {
                NumsForGame obj = new NumsForGame();
            
                obj.PrintOptions(obj.execOperArr);
                obj.chosenOperIndex = obj.ChoseOption(obj.rndOperOption);
            
                obj.PrintOptions(obj.numbersArr[0]);
                obj.numIndex[0] = obj.ChoseOption(new int[] {0, 1});
            
                obj.PrintOptions(obj.numbersArr[1]);
                obj.numIndex[1] = obj.ChoseOption(new int[] {0, 1});

                Console.Clear();
                Console.WriteLine("Here is your math problem:");
                obj.WriteProblem();
                string userText = Console.ReadLine();
                if (obj.CheckAnswer(Convert.ToInt32(userText)))
                {
                    Console.WriteLine("Right answer!");
                }
                else
                {
                    Console.WriteLine("Wrong answer!");
                }
                Console.Write("Press any key to continue...\n");
                Console.ReadKey();
            }
        }
    }
}