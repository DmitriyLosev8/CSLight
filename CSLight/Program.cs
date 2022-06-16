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

            int[] array = { 2, 6, 4, 8, 8, 8, 5, 6, 4, 8, 6, 4, 4, 4, 4, 4, 4, 3, 2, 8, };
            int count1 = 0;
            int count2 = 0;
            int numberTostop = 0;


            for (int i = 1; i < array.Length - 1; i++)
            {
                numberTostop++;

                if (array[i] == array[i + 1])
                {
                    count1++;
                }

                else if (array[i] != array[i + 1] && array[i] == array[i - 1])
                {
                   // Console.WriteLine("Вот тот индекс, на котоорм тормазнуть - " + numberTostop);
                    break;
                }

                for (int j = numberTostop; j < array.Length - 1; j++)
                {
                    if (array[j] == array[j + 1])
                    {
                        count2++;
                    }

                    else if (array[j] != array[j + 1] && array[j] == array[j - 1])
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(count1 + "     ||       " + count2);     // доделать. их нужно ещё сравнить
        }
    }
}


