using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    class InputFiles
    {
        public static string dir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        public static string[] inputFileNames = System.IO.Directory.GetFiles(dir);

        /**
         * Returns input file as a List<string> according to requested task number.
         */
        public static List<string> ReadFileToStringList(int fileNumber)
        {

            List<string> rawData = null;

            try
            {
                //Console.WriteLine("Testipath: "+dir);
                rawData = File.ReadAllLines(inputFileNames[fileNumber - 1]).ToList();
            }
            catch (Exception e)
            {
                Console.Write("ReadFileToStringList Failed | " + e.Message);
            }

            return rawData;
        }

        /**
         * Returns input file as a int[] according to requested task number.
         */
        public static int[] ReadFileToIntArray(int fileNumber)
        {
            List<string> rawData = ReadFileToStringList(fileNumber);

            int[] data = new int[rawData.Count];

            for (int i = 0; i < rawData.Count; i++)
            {
                data[i] = Int32.Parse(rawData[i]);
            }
            return data;
        }

        /**
         * Returns input file as a tuple with bingo numbers and bingogrids as separate data structures.
         */
        public static (int[], List<int[,]>) ReadFileToBingo(int fileNumber)
        {
            string[] rawData = File.ReadAllLines(inputFileNames[fileNumber - 1]);

            string[] order = rawData[0].Split(",");

            int[] orderInt = Array.ConvertAll(order, int.Parse);


            List<int[,]> listOfBingoGrids = new();

            int[,] bingoGrid = new int[5, 5];

            int index = 0;

            for (int i = 1; i < rawData.Length; i++)
            {

                if (rawData[i].Length > 0)
                {
                    string[] temp = rawData[i].Split(" ",StringSplitOptions.RemoveEmptyEntries);

                    for (int x = 0; x < temp.Length; x++)
                    {
                        bingoGrid[index, x] = Int32.Parse(temp[x]);
                    }

                    index++;
                } else
                {
                    bingoGrid = new int[5, 5];
                }

                if (index == 5)
                {
                    listOfBingoGrids.Add(bingoGrid);
                    index = 0;
                } 
            }

            return (orderInt, listOfBingoGrids);
        }
    }
}        