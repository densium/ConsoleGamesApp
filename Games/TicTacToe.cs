using ConsoleGamesApp.Main;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleGamesApp.Games
{
    class TicTacToe : GameData, IScorableGame
    {
        public TicTacToe()
        {
            Name = "Tic Tac Toe";
            InitializeLoop();
        }

        public void InitializeLoop()
        {
            bool runGameLoop = true;
            string userText;
            string[,] simpleBoard = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

            Board mainBoard = new Board(simpleBoard);
            mainBoard.Draw();

            while (runGameLoop)
            {
                bool checkLoop = true;
                int option = 0;
                do
                {
                    Console.Write("Chose cell to put {0}: ", mainBoard.Turn);
                    userText = Console.ReadLine();
                    if (userText == "Exit" || userText == "exit")
                    {
                        Result = "Player exits";
                    }

                    try
                    {
                        option = Convert.ToInt32(userText);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    if (option <= mainBoard.BoardLength || option > 0)
                    {
                        checkLoop = !mainBoard.CheckCell(option);
                    }

                } while (checkLoop);

                mainBoard.SetCell(option);
                Console.Clear();
                mainBoard.Draw();
                if (mainBoard.CheckWin())
                {
                    break;
                }
                mainBoard.SwitchPlayer();
            }

            Console.WriteLine("Player {0} win!", mainBoard.PlayerTurn);
            Result = "Player " + mainBoard.PlayerTurn + " win";
            // Console.Write("Press any key to return to main menu...");
            // Console.ReadKey();
        }
    }
    class Board
    {
        private byte _playerTurn;
        private char _turn;
        private int _boardLength;
        private string[,] _boardArr = new string[3, 3];
        public byte PlayerTurn { get { return _playerTurn; } }
        public char Turn { get { return _turn; } }
        public int BoardLength { get { return _boardLength; } }

        public Board(string[,] boardArr)
        {
            _playerTurn = 1;
            _turn = 'X';
            _boardArr = boardArr;
            _boardLength = _boardArr.GetLength(0) * _boardArr.GetLength(1);
        }

        public void Draw() // TODO: Rewrite to expendable function 
        {
            for (int i = 0; i < _boardArr.GetLength(0); i++)
            {
                Console.WriteLine(BuildRow(false));
                string boardRow = _boardArr[i, 0] + _boardArr[i, 1] + _boardArr[i, 2];
                Console.WriteLine(BuildRow(boardRow));
                if (i < _boardArr.GetLength(0) - 1)
                {
                    Console.WriteLine(BuildRow(true));
                }
                else
                {
                    Console.WriteLine(BuildRow(false));
                }
            }
        }
        private string BuildRow(string cellFill)
        {
            return "  " + cellFill[0] + "  |  " + cellFill[1] + "  |  " + cellFill[2] + "  ";
        }

        private string BuildRow(bool bottom = false)
        {
            string cell = "     ";
            string wall = "|";
            if (bottom)
            {
                cell = "_____";
            }
            return cell + wall + cell + wall + cell;
        }

        public bool CheckWin()
        {
            string sumString;

            for (int i = 0; i < _boardArr.GetLength(0); i++)
            {
                sumString = _boardArr[i, 0] + _boardArr[i, 1] + _boardArr[i, 2]; // Check horizontal
                if (sumString == "XXX" || sumString == "OOO")
                {
                    return true;
                }

                sumString = _boardArr[0, i] + _boardArr[1, i] + _boardArr[2, i]; // Check vertical
                if (sumString == "XXX" || sumString == "OOO")
                {
                    return true;
                }
            }

            sumString = _boardArr[0, 0] + _boardArr[1, 1] + _boardArr[2, 2]; // Check diagonal1
            if (sumString == "XXX" || sumString == "OOO")
            {
                return true;
            }

            sumString = _boardArr[0, 2] + _boardArr[1, 1] + _boardArr[2, 0]; // Check diagonal2
            if (sumString == "XXX" || sumString == "OOO")
            {
                return true;
            }

            return false;
        }

        public void SwitchPlayer()
        {
            if (_playerTurn == 1)
            {
                _playerTurn = 2;
                _turn = 'O';
            }
            else
            {
                _playerTurn = 1;
                _turn = 'X';
            }
        }

        public bool CheckCell(int cellNum)
        {
            string cellStr = cellNum.ToString();
            foreach (string numToChar in _boardArr)
            {
                if (numToChar == cellStr)
                {
                    return true;
                }
            }

            return false;
        }

        public void SetCell(int cellNum)
        {
            cellNum -= 1;
            int x = 0;
            int y = 0;

            if (cellNum > 0)
            {
                int width = _boardArr.GetLength(0);
                x = cellNum / width;
                y = cellNum % width;
            }

            _boardArr[x, y] = _turn.ToString();
        }
    }
}
