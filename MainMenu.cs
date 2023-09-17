namespace ConsoleGamesApp
{
    class MainMenu
    {
        static void Main(string[] args) // TODO: Coop
        {
            string[] availableGames = {
                "Capital cities - You will be given a country name, you should write down it's capital city",
                "Math problems - Simple math problems to solve",
                "Mad Libs - Random story with random words in it", // Work on scenarios
                "TicTacToe - Сlassic", // 4x4 field
                "Highscores - Get highscores of played games"
            };
            Highscores mainTable = new Highscores();

            Console.WriteLine("Hello! Welcome to my first C# program");
            while (true)
            {
                Console.WriteLine("Here is a set of available games");
                int n = 1;
                foreach (string gameDesc in availableGames)
                {
                    Console.WriteLine($"{n}. {gameDesc}");
                    n++;
                }
                Console.Write("Choose the game you want to run: ");
                string userText = Console.ReadLine();
                Console.Clear();
                switch (userText)
                {
                    case "1":
                        CapitalCities.InitializeLoop();
                        mainTable.SetNewScore("Capital Cities", mainTable.gameResult);
                        break;
                    case "2":
                        MathProblems.InitializeLoop();
                        mainTable.SetNewScore("Math Problems", mainTable.gameResult);
                        break;
                    case "3":
                        MadLibs.InitializeLoop();
                        break;
                    case "4":
                        mainTable.gameResult = TicTacToe.InitializeLoop();
                        mainTable.SetNewScore("Tic Tac Toe", mainTable.gameResult);
                        break;
                    case "5":
                        mainTable.OptionsMenu(mainTable.GetTable());
                        Console.WriteLine("Press any key to return to main menu...");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}