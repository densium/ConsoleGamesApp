using ConsoleGamesApp.Games;

namespace ConsoleGamesApp.Main
{
    class MainMenu
    {
        static void Main(string[] args) // TODO: Coop
        {
            Console.WriteLine("Hello! Welcome to my first C# program");
            
            string[] availableGames = {
                "Capital cities - You will be given a country name, you should write down it's capital city",
                "Math problems - Simple math problems to solve",
                "Mad Libs - Random story with random words in it", // Work on scenarios
                "TicTacToe - Сlassic", // 4x4 field
                "Highscores - Get highscores of played games"
            };
            Highscores highscoreTable = new Highscores();
            Menu gamesList = new Menu(availableGames, false);

            while (true)
            {
                gamesList.PrintOptions("Here is a set of available games:");
                gamesList.GetOption("Choose the game you want to run: ");
                Console.Clear();
                
                IScorableGame game = null;
                switch (gamesList.ChosenOpt)
                {
                    case 1:
                        game = new CapitalCities();
                        break;
                    case 2:
                        game = new MathProblems();
                        break;
                    case 3:
                        game = new MadLibs();
                        break;
                    case 4:
                        game = new TicTacToe();
                        break;
                    case 5:
                        Menu highScores = new Menu(highscoreTable.GetTable(), false);
                        highScores.PrintOptionsList();
                        Helpers.WaitToQuit();
                        break;
                    default:
                        break;
                }
                Console.Clear();

                if (game != null)
                {
                    if (game.Result != string.Empty)
                    { 
                        highscoreTable.AddNewScore(game.Name, game.Result);
                    }
                    else if (game.Score > 0)
                    {
                        highscoreTable.AddNewScore(game.Name, game.Score);
                    }
                }
            }
        }
    }
}