namespace ConsoleGamesApp
{
    class MainMenu
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
}