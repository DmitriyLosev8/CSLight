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

            int lowerNumber = 0;
            int upperNumber = 101;
            int lowerMultipleNumber = 3;
            int upperMultipleNumber = 5;
            int sum = 0;

            Random random = new Random();
            int number = random.Next(lowerNumber, upperNumber);
            Console.WriteLine(number);

            for (int i = 0; i <= number; i ++)
            {
                if (i % lowerMultipleNumber == 0 || i % upperMultipleNumber == 0)
                {
                    sum += i;
                    Console.WriteLine(sum);
                }      
            }
        }   
    }
}
