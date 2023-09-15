namespace ConsoleGamesApp
{
    class MainMenu
    {
        static void Main(string[] args) // TODO: Coop
        {
            string[] availableGames = {
                "1. Capital cities - You will be given a country name, you should write down it's capital city",
                "2. Math problems - Simple math problems to solve",
                "3. Mad Libs - Random story with random words in it", // Work on scenarios
                "4. TicTacToe - Сlassic", // 4x4 field
                "5. Highscores - Get highscores of played games"
            };

            Console.WriteLine("Hello! Welcome to my first C# program");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Here is a set of available games");
                foreach (string gameDesc in availableGames)
                {
                    Console.WriteLine(gameDesc);
                }
                Console.Write("Choose the game you want to run: ");
                string userText = Console.ReadLine();
                Console.Clear();
                switch (userText)
                {
                    case "1":
                        CapitalCitiesGame.InitializeLoop();
                        break;
                    case "2":
                        MathProblemsGame.InitializeLoop();
                        break;
                    case "3":
                        MadLibsGame.InitializeLoop();
                        break;
                    case "4":
                        TicTacToe.InitializeLoop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}