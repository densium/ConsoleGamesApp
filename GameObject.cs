namespace ConsoleGamesApp
{
    class GameObject
    {
        public void OptionsMenu(string[] options)
        {
            byte n = 1;
            foreach (string option in options)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
        }
        public void OptionsMenu(int[] options)
        {
            byte n = 1;
            foreach (int option in options)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }
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
    }
}
