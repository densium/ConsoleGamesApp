using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleGamesApp
{
    class CapitalCitiesGame
    {
        public static void InitializeLoop()
        {
            Console.WriteLine("Answer with the name of capital city of given country");
            Console.ReadLine();
        }
    }

    class MathProblemsGame
    {
        public static void InitializeLoop()
        {
            // Game desc
            Console.WriteLine("You chose Math questions! You will be given a set of options to define question:");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            
            // Generate 2 random operation
            string[] initOperationsArr = { "Substract", "Add", "Multiple", "Divide" };
            string[] execOperationsArr = new string[2];
            Random rnd = new Random();
            execOperationsArr[0] = initOperationsArr[rnd.Next(initOperationsArr.Length)];
            do
            {
                execOperationsArr[1] = initOperationsArr[rnd.Next(initOperationsArr.Length)];
            }
            while (execOperationsArr[0] == execOperationsArr[1]);

            // Write menu and wait for option
            string chosenOperation = execOperationsArr[OptionsMenu(execOperationsArr) - 1];

            // Generate 2 random numbers based on preferable option
            int numberSize = 50;
            int[] firstNumber = new int[2];
            firstNumber[0]= rnd.Next(numberSize);
            do
            {
                firstNumber[1] = rnd.Next(numberSize);
            }
            while (firstNumber[0] == firstNumber[1]);

            // Chose from 2 numbers
            // TODO: Write overload for OptionsMenu

        }
        public static byte OptionsMenu(string[] options)
        {
            // Write down a set of options
            byte n = 1;
            foreach (string option in options)
            {
                Console.WriteLine($"{n}. {option}");
                n++;
            }

            // Check chosen option
            string userText = String.Empty;
            bool menuLoop = true;
            byte optionNumber = 0;
            while (menuLoop)
            {
                Console.Write("Chose operation: ");
                userText = Console.ReadLine();
                
                // Check for empty string
                if (userText == null)
                {
                    Console.WriteLine("No options chosen");
                    break;
                }

                // Check for byte option
                optionNumber = CheckOption(userText, options.Length);
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
            return optionNumber;
        }
        public static byte CheckOption(string userText, int maxOption)
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
        public static void GetMax()
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