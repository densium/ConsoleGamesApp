namespace ConsoleGamesApp
{
    class Highscores : GameObject // Rewrite to List
    {
        private string[] highScoreTable = new string[100];
        private int n = 0;
        public int highScore = 0;
        public string gameResult = "";

        public Highscores()
        {
        }

        public string[] GetTable()
        {
            return highScoreTable;
        }
        public void SetNewScore(string gameName, int newScore = 0)
        {
            Console.Write("Enter player name: ");
            string userText = Console.ReadLine();
            highScoreTable[n] = $"{gameName} - {userText} - {newScore}";
            n++;
        }
        public void SetNewScore(string gameName, string gameResult = "unknown")
        {
            Console.Write("Enter player name: ");
            string userText = Console.ReadLine();
            highScoreTable[n] = $"{gameName} - {userText} - {gameResult}";
            n++;
        }
    }
}