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

            int[] array = new int[30];
            int count = 0;
            int element;
            int maximumCount = int.MinValue;
            Random random = new Random();
            int lowerNumner = 0;
            int upperNumber = 10;

            Console.WriteLine("Весь массив - ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(lowerNumner, upperNumber);
                Console.Write(array[i] + " | ");
            }

            for (int j = 1; j < array.Length; j++)
            {
                if (array[j] == array[j - 1])
                {
                    count++;
                    if (maximumCount < count)
                    {
                        element = array[j];
                        maximumCount = count;
                        Console.WriteLine("\n\nПервый максимально часто повторяющийся элемент - " + element);
                    }
                }
                else if (array[j] != array[j - 1])
                {
                    count = 0;
                }
            }
            Console.WriteLine("\nМаксимальное колличество повторений  - " + maximumCount + "\n");
        }
    }
}


