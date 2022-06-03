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
            //домашнее задание: степень двойки: 

            int lowerNumber = 1;
            int upperNumber = 1000;
            int result = 1;
            int numberToMultiply = 2;


            Random random = new Random();
            int number = random.Next(lowerNumber, upperNumber);      

            Console.WriteLine("Стартовое число - " + number);

             while (result <+ number)
              {
                result *= numberToMultiply;
                Console.WriteLine(result);
              }
        }
    }
}

