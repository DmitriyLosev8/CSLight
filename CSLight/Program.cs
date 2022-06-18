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

            int[] array = { 2, 6, 9, 0, 7, 3, 1, 5, 4, 8 };
            int biggerNumber;

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
                Console.Write(+array[i] + " | ");
            }
            Console.WriteLine();
        }
    }
}


