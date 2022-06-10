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

            int[] array = {8,6,15,12,18,3,7,6,4,15,6,19,84,65,14,35,1,9,14,45,14,69,48,25,67,1,9,15,12,36};
            int minimalNumber = 0;
            int maximalNumber = 100;
            int minimalBorder = 0;
            int maximalBorder = 29;

            for (int i = 0; i < array.Length; i++)
            {
               
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


