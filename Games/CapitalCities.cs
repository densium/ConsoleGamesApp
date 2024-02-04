using ConsoleGamesApp.Main;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleGamesApp.Games
{
    class CapitalCities : GameData, IScorableGame
    {
        public CapitalCities()
        {
            Name = "Capital cities";
            Score = 0;
            Result = string.Empty;
            InitializeLoop();
        }

        private void InitializeLoop()
        {
            Questions mainArr = new Questions("./country-list.csv");
            int countryIndex = 0;
            int cityIndex = 1;
            int pointsValue = 4;
            Random rnd = new Random();
            string[] gameDesc = { "Welcome to Capital Cities!", "You will be given a series of country names", "Answer with the name of capital city" };
            Helpers.PrintDesc(gameDesc);

            while (true)
            {
                int[] setOfIndexes = Helpers.RandomNumbers(4, mainArr.QListLen);
                string[] citiesNames = Helpers.Get1DFrom2D(mainArr.QList, cityIndex, setOfIndexes);
                string[] countryNames = Helpers.Get1DFrom2D(mainArr.QList, countryIndex, setOfIndexes);

                Menu citiesMenu = new Menu(citiesNames, rnd.Next(pointsValue));
                citiesMenu.PrintOptions("Country: " + countryNames[citiesMenu.Answer] + ", find out capital");
                citiesMenu.GetOption();
                if (citiesMenu.ChosenOpt == citiesNames.Length + 1)
                {
                    break;
                }
                Score += citiesMenu.CheckAnswer(1); 
            }
        }
    }

    class Questions
    {
        public string[,] QList { get; }
        public int QListLen { get; }
        public Questions(string pathToFile)
        {
            string[] lines = File.ReadAllLines(pathToFile);
            QListLen = lines.Length;
            QList = new string[lines.Length, 3];

            TextFieldParser parser = new TextFieldParser(pathToFile);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            parser.ReadLine(); // Skip first line

            int x = 0;
            int y = 0;
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                for (y = 0; y < fields.Length; y++)
                {
                    QList[x, y] = fields[y];
                }
                x++;
            }
        }
    }
}
