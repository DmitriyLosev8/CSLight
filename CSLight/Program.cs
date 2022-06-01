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
            // домашнее задание: сумма чисел

            int multipleTo3 = 3;
            int multipleTo5 = 5;
            int sum = 0;

            Random rand = new Random();
            int number = rand.Next(0, 101);
            Console.WriteLine(number);

            for (int i = 0; i <= number; i ++)

            {
                if (i % multipleTo3 == 0 || i % multipleTo5 == 0)
                {
                    sum += i;
                    Console.WriteLine(sum);
                }      
            }
        }   
    }
}
