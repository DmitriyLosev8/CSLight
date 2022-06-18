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

            // домашнее задание: сортировка чисел:

            int[] array = new int[10];
            int lowerNumber = 0;
            int UpperNumber = 9;
            Random random = new Random();
            int biggerNumber;
            Console.Write("Не отсортированный массив - ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(lowerNumber, UpperNumber);
                Console.Write(array[i] + " | ");

            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        biggerNumber = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = biggerNumber;
                    }
                }
            }
            Console.Write("\nОтсортированный массив - ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine();
        }
    }
}


