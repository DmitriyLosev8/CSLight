using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // дамашнее задание: локальные максимумы: 

            int[] array = new int[30];
            Random random = new Random();
            int minimalNumber = 0;
            int maximalNumber = 100;
            int minimalBorder = 0;
            int maximalBorder = 29;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimalNumber, maximalNumber);

                if (i == minimalBorder)
                {
                    if (array[i] > array[i + 1])
                    {
                        Console.WriteLine("\nЛокальный максимум:");
                        Console.Write(array[i] + "\n");
                    }
                }

                if (i == maximalBorder)
                {
                    if (array[i] > array[i - 1])
                    {
                        Console.WriteLine("\nЛокальный максимум:");
                        Console.Write(array[i] + "\n");
                    }
                }

                if (i > minimalBorder && i < maximalBorder)
                {

                    if (array[i] > array[i - 1] && array[i] > array[i + 1])
                    {
                        Console.WriteLine("\nЛокальный максимум:");
                        Console.WriteLine(array[i]);
                    }
                }
            }
        }
    }
}


