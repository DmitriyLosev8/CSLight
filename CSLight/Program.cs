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

            string day;
            string toExit = "exit";

            Console.WriteLine("Какое сегодня число?");
            Console.WriteLine("Чтобы прекратить поздравления, напишите слово: " + toExit);
            day = (Console.ReadLine());

            while (day != toExit)
            {
                Console.WriteLine("Поздравляю Вас, вы прекрасны!");
                Console.WriteLine("Какое сегодня число?"); 
            }
        }
    }
}
