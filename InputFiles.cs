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
                rawData = File.ReadAllLines(inputFileNames[fileNumber-1]).ToList();
            }
            catch (Exception e)
            {
                Console.Write("ReadFileToStringList Failed | "+e.Message);
            }
            
            return rawData;
        }

        /**
         * Returns input file as a int[] according to requested task number.
         */
        public static int[] ReadFiletoIntArray(int fileNumber)
        {
            List<string> rawData = ReadFileToStringList(fileNumber);

            int[] data = new int[rawData.Count];

            for (int i = 0; i < rawData.Count; i++)
            {
                data[i] = Int32.Parse(rawData[i]);
            }
            return data;
        }
    }
}
