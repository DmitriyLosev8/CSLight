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

            // домашнее задание: подмассив повторейний чисел:     

            int[] array = { 2, 6, 4, 8, 8, 8, 5, 6, 4, 8, 6, 4, 4, 4, 4, 4, 4, 3, 2, 8,2,4,12,67,4,87,12,5,6,6,};
            int count = 0;
            int element;
            int maximumCount = int.MinValue;

            Console.WriteLine("Весь массив - ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }

            for (int j = 1; j < array.Length; j++)
            {
                if (array[j] == array[j - 1])
                {
                    count++;
                    if (maximumCount < count)
                    {
                        maximumCount = count;
                    }
                }
                else if (array[j] != array[j - 1])
                {
                    count = 0;
                }
            }

            for (int j = 1; j < array.Length; j++)
            {
                if (array[j] == array[j - 1])
                {
                    count++;
                    if (count == maximumCount)
                    {
                        element = array[j];
                        Console.WriteLine("\n\nМаксимально часто повторяющийся элемент - " + element);
                        break;
                    }
                }
            }
            Console.WriteLine("\nМаксимальное колличество повторений  - " + maximumCount + "\n");
        }
    }
}


