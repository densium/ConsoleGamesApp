namespace ConsoleGamesApp
{
    class Highscores : GameObject // Save to file
    {
        // private string[] highScoreTable = new string[100];
        List<string> highScoreTable = new List<string>();
        private int n = 0;
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
            highScoreTable.Add($"{gameName} - {userText} - {newScore}");
            n++;
        }
        public void AddNewScore(string gameName, string gameResult = "unknown")
        {
            Console.Write("Enter player name: ");
            string userText = Console.ReadLine();
            highScoreTable.Add($"{gameName} - {userText} - {gameResult}");
            n++;
        }
    }
}