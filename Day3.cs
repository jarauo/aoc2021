using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    class Day3
    {

        public static List<string> data = InputFiles.ReadFileToStringList(3);

        public static int Task1()
        {
            return ProductOfMostAndLeastCommonBinary(MostAndLeastCommonBinary(data));
        }

        public static int Task2()
        {
            return ProductOfMostAndLeastCommonBinary(FilterBinaries(data));
        }

        /**
         * Day 3 Task 1 and 2. Filters binary values bit by bit according to most and least common bit values.
         */
        public static string[] FilterBinaries(List<string> data)
        {
            List<string> startData = new List<string>();
            startData.AddRange(data);
            List<string> apulista = new List<string>();

            string oxygen;
            string co2;


            for (int i = 0; i < startData[0].Length; i++)
            {
                string mostCommon = MostAndLeastCommonBinary(startData)[0];
                char filter1 = mostCommon[i];

                for (int j = 0; j < startData.Count; j++)
                {
                    if (startData[j][i] == filter1)
                    {
                        apulista.Add(startData[j]);
                    }
                }
                startData.Clear();
                startData.AddRange(apulista);
                apulista.Clear();
            }

            oxygen = startData[0];
            startData.Clear();
            startData.AddRange(data);

            for (int i = 0; i < startData[0].Length; i++)
            {
                string leastCommon = MostAndLeastCommonBinary(startData)[1];
                char filter2 = leastCommon[i];

                if (startData.Count == 1)
                {
                    break;
                }

                for (int j = 0; j < startData.Count; j++)
                {
                    if (startData[j][i] == filter2)
                    {
                        apulista.Add(startData[j]);
                    }
                }

                startData.Clear();
                startData.AddRange(apulista);
                apulista.Clear();

            }

            co2 = startData[0];

            string[] task2result = { oxygen, co2 };

            return task2result;
        }

        /**
         * Day 3 Task 1 and 2. Finds the most and least common bits from a given data set and forms binary values out of them
         */
        public static string[] MostAndLeastCommonBinary(List<string> data)
        {
            int binaryCount = data.Count;
            string commonBinary = "";
            string rareBinary = "";
            string[] result = new string[2];

            int[] binarySums = new int[data[0].Length];

            for (int i = 0; i < binaryCount; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    binarySums[j] += (int)char.GetNumericValue(data[i][j]);
                }

            }

            foreach (int bitSum in binarySums)
            {
                if ((binaryCount / 2.0) > bitSum)
                {
                    commonBinary = commonBinary + "0";
                    rareBinary = rareBinary + "1";
                }
                else if ((binaryCount / 2.0) == bitSum)
                {
                    commonBinary = commonBinary + "1";
                    rareBinary = rareBinary + "0";
                }
                else
                {
                    commonBinary = commonBinary + "1";
                    rareBinary = rareBinary + "0";
                }


            }

            result[0] = commonBinary;
            result[1] = rareBinary;
            return result;
        }

        /**
         * Day 3 Task 1 and 2. Returns the decimal product of two given binary values.
         */
        public static int ProductOfMostAndLeastCommonBinary(string[] commonresult)
        {
            //Console.WriteLine("common: " + Convert.ToInt32(commonresult[0], 2)+" binary: "+commonresult[0]);
            //Console.WriteLine("rare: " + Convert.ToInt32(commonresult[1], 2) + " binary: " + commonresult[1]);
            return (Convert.ToInt32(commonresult[0], 2) * Convert.ToInt32(commonresult[1], 2));
        }
    }
}
