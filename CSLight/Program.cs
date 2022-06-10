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

            int[] array = { 8, 6, 15, 12, 18, 3, 7, 6, 4, 15, 6, 19, 84, 65, 14, 35, 1, 9, 14, 45, 14, 69, 48, 25, 67, 1, 9, 15, 12, 36 };
            int minimalNumber = 0;
            int maximalNumber = 100;
            int minimalBorder = 0;
            int maximalBorder = 29;
            int nearbyNumber = 1;

            if (array[minimalBorder] > array[minimalBorder + nearbyNumber])
            {
                Console.WriteLine("\nЛокальный максимум:");
                Console.Write(array[minimalBorder] + "\n");
            }

            if (array[maximalBorder] > array[maximalBorder - nearbyNumber])
            {

                Console.WriteLine("\nЛокальный максимум:");
                Console.Write(array[maximalBorder] + "\n");
            }

            for (int i = 1; i < (array.Length - nearbyNumber); i++)
            {

                if (array[i] > array[i - nearbyNumber] && array[i] > array[i + nearbyNumber])
                {
                    Console.WriteLine("\nЛокальный максимум:");
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}


