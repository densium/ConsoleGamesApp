namespace ConsoleGamesApp.Main
{
    class Highscores
    {
        // private string[] highScoreTable = new string[100];
        List<string> highScoreTable = new List<string>();
        public int Count { get; set; }
        public int highScore = 0;
        public string gameResult = "";

        public Highscores()
        {
        }

        public List<string> GetTable()
        {
            return highScoreTable;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        }
        public void AddNewScore(string gameName, int newScore = 0)
        {
            Console.Write("Game ends, enter player name: ");
            string userText = Console.ReadLine();
            highScoreTable.Add($"{gameName} - {userText} - {newScore} points");
            Count++;
        }
        public void AddNewScore(string gameName, string gameResult = "unknown")
        {
            Console.Write("Enter player name: ");
            string userText = Console.ReadLine();
            highScoreTable.Add($"{gameName} - {userText} - {gameResult}");
            Count++;
        }
    }
}