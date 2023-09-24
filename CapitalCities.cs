using Microsoft.VisualBasic.FileIO;

namespace ConsoleGamesApp
{
    class CapitalCities
    {
        public static void InitializeLoop()
        {
            Console.WriteLine("Welcome to Capital Cities!");
            Console.WriteLine("You will be given a series of country names \n" +
                 "Answer with the name of capital city ");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Questions mainArr = new Questions("./country-list.csv");
            GameObject obj = new GameObject();

            // TODO: Set it to new instance of Questions inherited from GameObject
            int countryNameIndex = 0;
            int cityNameIndex = 1;
            int optionsAmount = 4;

            int[] setOfIndexes = GameObject.RandomNumbers(optionsAmount, mainArr.QListLen);
            string[] countryNames = GameObject.Get1DFrom2D(mainArr.QList, countryNameIndex, setOfIndexes);

            // Print options
            Console.Clear();
            obj.PrintOptions(countryNames);
            Console.ReadLine();

            // Read file    
            // Go to random row
            // Store number of row
            // Get question from it
            // Wait for answer toLow
            // Decode answer from the same row of file
            // Check answer
            // Levels easy, medium, hard
            // 3 lives
            // Win game if you answered all
            // Highscore for Answers_Count * 200 / (Lost_Lives * 2) - Played_Seconds * 10  
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
