namespace ConsoleGamesApp
{
    class GameObject
    {
        public void PrintOptions(string[] options)
        {
            byte n = 1;
            foreach (string option in options)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
        }
        public void PrintOptions(int[] options)
        {
            byte n = 1;
            foreach (int option in options)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
        }
        public void PrintOptions(List<string> options)
        {
            byte n = 1;
            foreach (string option in options)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
        }
        public static void PrintOptionsS(string[] options)
        {
            byte n = 1;
            foreach (string option in options)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
        }
        public static int[] RandomNumbers(int howMany, int maxValue, int minValue = 0)
        {
            Random rnd = new Random();
            int[] numsArr = new int[howMany];
            for (int i = 0; i < howMany; i++)
            {
                numsArr[i] = rnd.Next(minValue, maxValue);
            }
            return numsArr;
        }
        public int ChoseOption(int[] optionsNums)
        {
            string userText = "";
            bool menuLoop = true;
            int optionNumber = 0;
            while (menuLoop)
            {
                Console.Write("Chose option: ");
                userText = Console.ReadLine();

                if (userText == null)
                {
                    Console.WriteLine("No options chosen");
                    break;
                }

                optionNumber = CheckOptionByte(userText, optionsNums.Length);
                if (optionNumber == 0)
                {
                    Console.WriteLine("There is no such an option");
                    break;
                }
                else
                {
                    menuLoop = false;
                }
            }
            return optionsNums[optionNumber - 1];
        }
        public byte CheckOptionByte(string userText, int maxOption)
        {
            try
            {
                byte optionNumber = Convert.ToByte(userText);
                if (optionNumber > maxOption)
                {
                    return 0;
                }
                else
                {
                    return optionNumber;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        public static string[] Get1DFrom2D(string[,] inArr, int fieldIndex, int[] indexes)
        {
            string[] outArr = new string[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
            {
                outArr[i] = inArr[indexes[i], fieldIndex];
            }
            return outArr;
        }
    }
}
