using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    class Day4
    {
        public static (int[], List<int[,]>) data = InputFiles.ReadFileToBingo(4);
        public static (int, int, List<int[,]>) bingoResult = BingoPlay();
        public static int Task1()
        {
            return (bingoResult.Item1 * SumOfExtraNumbers(bingoResult.Item3[0]));
        }

        public static int Task2()
        {
            return (bingoResult.Item2 * SumOfExtraNumbers(bingoResult.Item3.Last()));
        }

        /**
         * A method to play bingo with given input. Returns all winning bingogrids and the 
         * last called number for first and last winning bingogrid.
         */
        public static (int, int, List<int[,]>) BingoPlay()
        {
            bool winner = true;
            List<int[,]> winningBoards = new();
            int lastNumber = 0;
            int firstNumber = -1;
            List<int> winningBoardIndexList = new();

            for (int i = 0; i < data.Item1.Length; i++)
            {
                for (int a = 0; a < data.Item2.Count; a++)
                {
                    winner = true;

                    if (!winningBoardIndexList.Contains(a))
                    {
                        for (int x = 0; x < data.Item2[1].GetLength(0) && winner; x++)
                        {
                            for (int y = 0; y < data.Item2[1].GetLength(0) && winner; y++)
                            {
                                if (data.Item2[a][x, y] == data.Item1[i])
                                {
                                    data.Item2[a][x, y] = -1;
                                }

                                if (CheckIfBingo(data.Item2[a]))
                                {
                                    winningBoards.Add(data.Item2[a]);

                                    if (firstNumber == -1)
                                    {
                                        firstNumber = data.Item1[i];
                                    }

                                    lastNumber = data.Item1[i];

                                    winner = false;

                                    winningBoardIndexList.Add(a);
                                }
                            }
                        }
                    }
                }
            }

            return (firstNumber, lastNumber, winningBoards);
        }

        /**
         * Calculates the sum of the left over numbers in a bingogrid.
         */
        public static int SumOfExtraNumbers(int[,] A)
        {
            int sum = 0;

            for (int x = 0; x < A.GetLength(0); x++)
            {
                for (int y = 0; y < A.GetLength(0); y++)
                {
                    if (A[x, y] != -1)
                    {
                        sum += A[x, y];
                    }
                }
            }
            return sum;
        }

        /**
         * Checks if a given bingogrid has a bingo in it.
         */
        public static Boolean CheckIfBingo(int[,] A)
        {
            bool win = false;

            int counter = 0;

            for (int x = 0; x < data.Item2[1].GetLength(0); x++)
            {
                for (int y = 0; y < data.Item2[1].GetLength(0); y++)
                {
                    if (A[y, x] == -1)
                    {
                        counter++;
                    }
                }

                if (counter == 5)
                {
                    win = true;
                    break;
                }
                counter = 0;
            }

            for (int x = 0; x < data.Item2[1].GetLength(0); x++)
            {
                for (int y = 0; y < data.Item2[1].GetLength(0); y++)
                {
                    if (A[x, y] == -1)
                    {
                        counter++;
                    }
                }

                if (counter == 5)
                {
                    win = true;
                    break;
                }
                counter = 0;
            }

            return win;
        }

        /**
         * Prints a 2D array
         */
        static void printArray(int[,] A)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(string.Format(" {0} ", A[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        /**
         * Another print method
         */
        public static void printTest((int[], List<int[,]>) A)
        {

            foreach (int[,] bingoGrid in A.Item2)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(string.Format(" {0} ", bingoGrid[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
            }
        }
    }
}
