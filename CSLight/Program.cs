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

            int[] array = { 2, 6, 4, 8, 8, 8, 5, 6, 4, 8, 6, 4, 4, 4, 4, 4, 4, 3, 2, 8};
            int count = 0;
            int repeatNumber;
            int element;

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
                    element = array[j];
                    Console.WriteLine("\nПовторяющийся элемент - " +  element);
                }
              
                if (array[j] != array[j - 1])
                  {
                    repeatNumber = count;
                    count = 0;
                     
                    if (repeatNumber > 0)
                      {
                        Console.WriteLine("Количество повторений - " + repeatNumber);
                      }
                }
            }
        }
    }
}


