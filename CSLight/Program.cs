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
            // домашнее задание: наибольший элемент:

            int[,] array = { {7,9,5,6,47,4,8,9,2,3 }, {4,2,1,6,36,7,4,3,9,1 }, {7,9,8,15,2,6,4,1,9,5 },{1,3,2,5,7,89,4,6,5,8 }, {2,6,98,8,9,12,6,5,1,7 },
                {2,15,36,2,4,15,23,8,9,4 }, {1,5,8,6,2,4,6,4,14,98 },{1,8,96,47,51,12,1,5,6,14 }, };
            int maximumNumber = int.MinValue;
            int newValueOfElement = 0;

            Console.WriteLine("Исходная матрица: \n");
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    
                    if (maximumNumber < array[i, j])
                    {
                        maximumNumber = array[i, j];                    
                    }
                    Console.Write(array[i, j] + " | ");                   
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Наибольший элемент матрицы - " + maximumNumber + "\n");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                
                for (int j = 0; j < array.GetLength(1); j++)
                {
                      
                    if (array[i, j] == maximumNumber)
                    {
                        array[i, j] = newValueOfElement;
                    }
                    Console.Write(array[i, j] + " | ");
                }
                Console.WriteLine("\n");
            }                   
            Console.WriteLine("Новая матрица \n");
        }
    }
}


