using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    class Day2
    {
        public static List<string> data = InputFiles.ReadFileToStringList(2);

        public static int Task1()
        {
            return SubmarinePosition(data, 1);
        }

        public static int Task2()
        {
            return SubmarinePosition(data, 2);
        }

        /**
         * Day 2 Tasks 1 and 2. Switches logic based on value given as a method parameter taskParam (1 || 2).
         * Calculates the submarine position.
         */
        public static int SubmarinePosition(List<string> data, int taskParam)
        {
            string task = taskParam.ToString();
            int horizontal = 0;
            int vertical = 0;
            int aim = 0;

            foreach (string line in data)
            {
                string command = line.Split(" ")[0];
                int number = Int32.Parse(line.Split(" ")[1]);

                switch (command + task)
                {
                    case "forward1":
                        horizontal += number;
                        break;
                    case "down1":
                        vertical += number;
                        break;
                    case "up1":
                        vertical -= number;
                        break;
                    case "forward2":
                        horizontal += number;
                        vertical += aim * number;
                        break;
                    case "down2":
                        aim += number;
                        break;
                    case "up2":
                        aim -= number;
                        break;
                }

            }
            return horizontal * vertical;
        }
    }
}
