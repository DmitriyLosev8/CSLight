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
            //Задание: ReadInt:

            int inputedNumber;
            RequestOfNumber(out inputedNumber);
            Console.WriteLine("Вот оно -  " + inputedNumber);
        }

        static void RequestOfNumber(out int inputedNumber)
        {
            bool isWorking = true;
            string userInput;
            inputedNumber = 0;
            bool isSuccessful;

            while (isWorking)
            {
                Console.WriteLine("Введите число:");
                userInput = Console.ReadLine();
                isSuccessful = int.TryParse(userInput, out inputedNumber);
                if (isSuccessful == false)
                {
                    Console.WriteLine("Введите корректное значение:");
                }
                else
                {
                    Console.WriteLine("Число преобразованно");
                    isWorking = false;
                }
            }
        }
    }
}
