namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Minesweeper
    {
        public class Ranking
        {
            private string name;

            private int points;

            public string Name
            {
                get
                { 
                    return name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }

                set
                {
                    this.points = value;
                }
            }

            public Ranking()
            {
            }

            public Ranking(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] mines = SetMines();
            int counter = 0;
            bool isFired = false;
            List<Ranking> winners = new List<Ranking>(6);
            int row = 0;
            int col = 0;
            bool isNewGame = true;
            const int MaxTurns = 35;
            bool areTurnsMaxed = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine(
                        "Let's go! Play the Minesweeper game. The command 'top' show the ranking," +
                        "'restart' - reset the game and command 'exit' - left the game");
                    SetGameBoard(gameField);
                    isNewGame = false;
                }

                Console.Write("Enter row and col : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && 
                        int.TryParse(command[2].ToString(), out col) && 
                        row <= gameField.GetLength(0) && 
                        col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        GetRanking(winners);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        mines = SetMines();
                        SetGameBoard(gameField);
                        isFired = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                ChangeTurn(gameField, mines, row, col);
                                counter++;
                            }

                            if (MaxTurns == counter)
                            {
                                areTurnsMaxed = true;
                            }
                            else
                            {
                                SetGameBoard(gameField);
                            }
                        }
                        else
                        {
                            isFired = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }

                if (isFired)
                {
                    SetGameBoard(mines);
                    Console.WriteLine("\n Game over! You died a hero with : {0} points. Enter your nickname : ", counter);
                    string nickname = Console.ReadLine();
                    Ranking winner = new Ranking(nickname, counter);
                    int winnersLimit = 5;
                    if (winners.Count < winnersLimit)
                    {
                        winners.Add(winner);
                    }
                    else
                    {
                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < winner.Points)
                            {
                                winners.Insert(i, winner);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((Ranking ranking1, Ranking ranking2) => ranking2.Name.CompareTo(ranking1.Name));
                    winners.Sort((Ranking ranking1, Ranking ranking2) => ranking2.Points.CompareTo(ranking1.Points));
                    GetRanking(winners);

                    gameField = CreateGameField();
                    mines = SetMines();
                    counter = 0;
                    isFired = false;
                    isNewGame = true;
                }

                if (areTurnsMaxed)
                {
                    Console.WriteLine("\ncongratulations! You find 35 cells without hurt yourself!");
                    SetGameBoard(mines);
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Ranking points = new Ranking(name, counter);
                    winners.Add(points);
                    GetRanking(winners);
                    gameField = CreateGameField();
                    mines = SetMines();
                    counter = 0;
                    areTurnsMaxed = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.Read();
        }

        private static void GetRanking(List<Ranking> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty rating list!\n");
            }
        }

        private static void ChangeTurn(char[,] field, char[,] mines, int row, int col)
        {
            char numberOfMines = CountMines(mines, row, col);
            mines[row, col] = numberOfMines;
            field[row, col] = numberOfMines;
        }

        private static void SetGameBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] SetMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] fieldForPlay = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    fieldForPlay[i, j] = '-';
                }
            }

            int numberOfMines = 15;
            List<int> mines = new List<int>();
            while (mines.Count < numberOfMines)
            {
                Random random = new Random();
                int newMine = random.Next(50);
                if (!mines.Contains(newMine))
                {
                    mines.Add(newMine);
                }
            }

            foreach (int mine in mines)
            {
                int col = mine / cols;
                int row = mine % cols;
                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                fieldForPlay[col, row - 1] = '*';
            }

            return fieldForPlay;
        }

        private static char CountMines(char[,] field, int currentRow, int currentCol)
        {
            int mineCounter = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (field[currentRow - 1, currentCol] == '*')
                {
                    mineCounter++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (field[currentRow + 1, currentCol] == '*')
                {
                    mineCounter++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (field[currentRow, currentCol - 1] == '*')
                {
                    mineCounter++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (field[currentRow, currentCol + 1] == '*')
                {
                    mineCounter++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (field[currentRow - 1, currentCol - 1] == '*')
                {
                    mineCounter++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (field[currentRow - 1, currentCol + 1] == '*')
                {
                    mineCounter++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (field[currentRow + 1, currentCol - 1] == '*')
                {
                    mineCounter++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (field[currentRow + 1, currentCol + 1] == '*')
                {
                    mineCounter++;
                }
            }

            return char.Parse(mineCounter.ToString());
        }
    }
}