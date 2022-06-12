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
            // домашнее задание: работа с конкретными строками,столбцами.

            int[,] array = { { 8, 5, 9 },{ 6, 3, 4 },{ 8, 7, 2 } };
            int sum = 0;
            int mult = 1;
            int line = 1;
            int column = 0;

           for (int i = 0; i < array.GetLength(1); i++)
            {
             sum += array[line, i];   
            }
            Console.WriteLine("Сумма второй строки - " + sum);

            for (int j = 0; j < array.GetLength(0); j++)
            {
                mult *= array[column, j];
            }
            Console.WriteLine("Произведение первого столбца - " + mult + "\n");

            for (int k = 0; k < array.GetLength(0); k++)
            {
                for (int l = 0; l < array.GetLength(1); l++)
                {
                    Console.Write(array[k, l] + " | ");
                } Console.WriteLine("\n");
            } 
        }
    }
}


