using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("input.txt");
            bool[,] even = new bool[text.Length, text.Length];
            int[,] data = new int[text.Length, text.Length];

            int posSolutions = (int)Math.Pow(2, data.GetLength(0) - 1);
            int largestSum = 0;
            int tempSum;
            int index;
            bool lastNumber;
            string path = "";
            string tempPath;

            for (int i = 0; i < text.Length; i++)
            {
                string[] row = text[i].Split(null);
                for (int j = 0; j < row.Length; j++)
                {
                    data[i, j] = int.Parse(row[j]);
                    even[i, j] = data[i, j] % 2 == 0;
                }
            }

            for (int i = 0; i <= posSolutions; i++)
            {
                tempSum = data[0, 0];
                tempPath = data[0, 0].ToString();
                index = 0;
                lastNumber = data[0, 0] % 2 == 0;
                for (int j = 0; j < data.GetLength(0) - 1; j++)
                {
                    index = index + (i >> j & 1);
                    if (lastNumber != (data[j + 1, index] % 2 == 0))
                    {
                        tempSum += data[j + 1, index];
                        lastNumber = !lastNumber;
                        tempPath += "-" + data[j + 1, index];
                    }
                    else
                    {
                        j = data.GetLength(0);
                        tempSum = 0;
                    }
                }
                if (tempSum > largestSum)
                {
                    largestSum = tempSum;
                    path = tempPath;
                }
            }
            Console.WriteLine(largestSum);
            Console.WriteLine("Path: " + path);
        }
    }
}
