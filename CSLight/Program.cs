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
            bool isWorking = true;
            bool success;

            while (isWorking)
            {
                RequestOfNumber(out inputedNumber, out success);

                if (success == true)
                {
                    Console.WriteLine("Число преобразованно");
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Введите корректное значение:");
                }
            }

        }

        static void RequestOfNumber(out int inputedNumber, out bool success)
        {
            string userInput;
            Console.WriteLine("Введите число:");
            userInput = Console.ReadLine();
            success = int.TryParse(userInput, out inputedNumber);
        }
    }
}
