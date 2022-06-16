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

            // домашнее задание: подмассив повторейний чисел:     ДОДЕЛАТЬ, ЭТО ВРЕМЕННО

            int[] array = { 2, 6, 4, 8, 8, 8, 5, 6, 4, 8, 6, 4, 4, 4, 4, 4, 4, 3, 2, 8};
            int number1;
            int number2;
            int count1 = 0;
            int count2 = 0;
            int numberTostop = 0;
            int max = int.MinValue;
            int element1;
            int element2;


            for (int i = 1; i < array.Length - 1; i++)
            {

                if (array[i] == array[i - 1])
                {
                    element1 =  array[i];
                    count1 ++;
                    //Console.WriteLine("Элемент - " + element1);
                }
                

                if (array[i] != array[i - 1])
                {
                    number1 = count1;
                    count1 = 0;
                    for(int j = 0; j < number1; j++)
                {
                if (max < number1)
                {
                    max = number1;
                    Console.WriteLine(max);
                }
            }



            //if (number1 > 0) // && (number1 > number1))
            // {
            //     Console.WriteLine(", а вот количество повторений - " + number1);
            // }
        }
                
            }
            Console.WriteLine(count1 + "     ||       " + count2);    
        }
    }
}


