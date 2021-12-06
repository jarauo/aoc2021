using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    class Day1
    {
        public static int[] data = InputFiles.ReadFileToIntArray(1);

        public static int Task1()
        {
            return Counter(data);
        }

        public static int Task2()
        {
            return CounterSums(data);
        }

        /**
         * For Day1: Counts the amount of values that are larger than the previous value in the array.
         */
        public static int Counter(int[] A)
        {
            int counter = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (((i + 1) < A.Length) && (A[i + 1] > A[i]))
                {
                    counter++;
                }
            }
            return counter;
        }

        /**
         * For Day1: Counts sums of 3 consecutive values and stores them into an array int[] A.
         * Calls Counter(int[] A) to calculate the the amount of values that are larger than the previous value in the array.
         */
        public static int CounterSums(int[] A)
        {
            int[] sum = new int[A.Length - 2];

            for (int i = 0; i < A.Length; i++)
            {
                if (i + 2 < A.Length)
                {
                    sum[i] = (A[i] + A[i + 1] + A[i + 2]);
                }
            }

            return Counter(sum);
        }
    }
}
