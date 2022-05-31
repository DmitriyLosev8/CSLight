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
            // домашнее задание: Контроль выхода:

            int day;
            string userInput;

            Console.WriteLine("Какое сегодня число?");
            day = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Поздравляю Вас, вы прекрасны!");
                Console.WriteLine("Какое сегодня число?");
                Console.WriteLine("                                                       Чтобы прекратить поздравления, напишите слово exit");
                
                userInput = Console.ReadLine();

                if (userInput == "exit")
                {
                    break;
                }
            }
        }
    }
}