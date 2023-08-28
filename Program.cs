namespace ConsoleAppInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to my first C# program");
            while (true)
            {
                Console.WriteLine("Choose the program you want to run");
                Console.WriteLine("max_number | mad_libs | guess_game | sqrt");
                string userText = Console.ReadLine();

                switch (userText)
                {
                    case "max_number":
                        InitializeGetMax();
                        Console.WriteLine("---");
                        break;
                    case "mad_libs":
                        InitializeMadLibs();
                        Console.WriteLine("---");
                        break;
                    case "guess_game":
                        // code block
                        break;
                    case "sqrt":
                        InitializeGetSqrt();
                        Console.WriteLine("---");
                        break;
                    default:
                        Console.WriteLine("There is no such a program");
                        break;
                }
            }
        }
        static void InitializeGetMax()
        {
            decimal firstInt;
            decimal secondInt;
            string userText;

            while (true)
            {
                try
                {
                    Console.Write("Enter first number: ");
                    userText = Console.ReadLine();
                    if (userText == "exit")
                    {
                        break;
                    }

                    firstInt = Convert.ToDecimal(userText);
                    Console.Write("Enter second number: ");
                    userText = Console.ReadLine();
                    secondInt = Convert.ToDecimal(userText);

                    Console.WriteLine("The largest number is: " + GetMax(firstInt, secondInt));
                    Console.WriteLine("---");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void InitializeMadLibs()
        {
            string userText;
            StreamReader reader = null;
            string line;

            Console.Write("Tell me the path to file: ");
            userText = Console.ReadLine();

            try
            {
                reader = new StreamReader(userText);
                line = reader.ReadLine();

                while (line != null)
                {
                    //change variable by random value
                    line = ReplaceTags(line);
                    //write the line to console window
                    Console.WriteLine(line);
                    // Read the next line
                    line = reader.ReadLine();
                }
                //close the file
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static string ReplaceTags(string line)
        {
            int tagStartIndex = line.IndexOf("{{:");
            if (tagStartIndex != -1)
            {
                tagStartIndex += 3;
                int tagStopIndex = line.IndexOf("}}");
                string tagType = line.Substring(tagStartIndex, tagStopIndex - tagStartIndex);
                string resultString;
                switch (tagType)
                {
                    case "NOUN":
                        resultString = line.Replace("{{:NOUN}}", RandomWord(tagType));
                        return resultString;
                    default:
                        return line;
                }
            }
            else
            {
                return line;
            }
        }
        static string RandomWord(string wordType)
        {
            Random rnd = new Random();

            switch (wordType)
            {
                case "NOUN":
                    string[] nounArray = { "Rufus", "Bear", "Dakota", "Fido",
                          "Vanya", "Samuel", "Koani", "Volodya",
                          "Prince", "Yiska" };
                    int mIndex = rnd.Next(nounArray.Length);
                    return nounArray[mIndex];
                default:
                    return "place holder";
            }
        }
        static void InitializeGetSqrt()
        {
            double firstInt;
            string userText;

            while (true)
            {
                try
                {
                    Console.Write("Enter number: ");
                    userText = Console.ReadLine();
                    if (userText == "exit")
                    {
                        break;
                    }

                    firstInt = Convert.ToDouble(userText);
                    Console.WriteLine("The result is: " + Math.Sqrt(firstInt));
                    Console.WriteLine("---");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        static decimal GetMax(decimal firstInt, decimal secondInt)
        {
            if (firstInt > secondInt)
            {
                return firstInt;
            }
            else
            {
                return secondInt;
            }
        }
    }
}