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

            // домашнее задание: сдвиг значений массива:

            int[] array = { 1, 2, 3, 4 };
            int userInput;
            int tempNumber;
            int count = 0;
            int lowerBorder = 0;
            int correctNumber = 1;

            Console.WriteLine("Исходный массив:");
            
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine("\n\nЧтобы сдвинуть значения элементов массива влево, введите число на сколько позиций будет сдвиг:");
            userInput = Convert.ToInt32(Console.ReadLine());

            while (count < userInput)
            {
                tempNumber = array[lowerBorder];
                
                for (int j = correctNumber; j < array.Length; j++)
                {
                    array[j - correctNumber] = array[j];
                }
                array[array.Length - correctNumber] = tempNumber;
                count++;
            }
            Console.WriteLine("Изменённый массив:");
            
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine();
        }
    }
}


