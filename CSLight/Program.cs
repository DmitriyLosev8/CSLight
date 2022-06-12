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
            // дамашнее задание: работа с конкретными строками,столбцами.

            int[,] array = { { 8, 5, 9 }, {6,3,4 }, {8,7,2 } };
            int sum = 0;
            int mult = 1;
            int line = 1;
            int column = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    
                    if ( i == line)
                    {
                        sum += array[i, j];
                    }
                     
                    if ( j == column)
                    {
                        mult *= array[i, j];
                    }
                    Console.Write(array[i, j] + " | ");   
                }
                Console.WriteLine("\n");
            } 
            Console.WriteLine("Сумма второй строки - " + sum);
            Console.WriteLine("Произведение первого столбца - " + mult + "\n");
        }
    }
}


