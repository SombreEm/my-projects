using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_08._02._24
{
    internal class Program
    {
        public static int MinIn2DArray(int[,] mas)
        {
            int minSum = 0;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                int minInRow = mas[i, 0];
                for (int j = 1; j < mas.GetLength(1); j++)
                {
                    minInRow = Math.Min(minInRow, mas[i, j]);
                }
                minSum += minInRow;
            }
            return minSum;
        }

        public static int MaxIn2DArray(int[,] mas)
        {
            int maxSum = 0;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                int maxInRow = mas[i, 0];
                for (int j = 1; j < mas.GetLength(1); j++)
                {
                    maxInRow = Math.Max(maxInRow, mas[i, j]);
                }
                maxSum += maxInRow;
            }
            return maxSum;
        }

        public static int DifferenceIn2DArray(int[,] mas)
        {
            return MaxIn2DArray(mas) - MinIn2DArray(mas);
        }

        public static void Main(string[] args)
        {
            int[,] number = {
                {5, 3, 2, 4, 1},
                {8, 10, 6, 9, 7},
                {13, 15, 11, 14, 15},
                {44, 55, 12, 10, 3}
            };

            Console.WriteLine($" {MinIn2DArray(number)} \n {MaxIn2DArray(number)} \n {DifferenceIn2DArray(number)}");
        }
    }
}

