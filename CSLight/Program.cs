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
            // домашнее задание освоение циклов:

            string userInput;
            string notice;
            int times;

            Console.WriteLine("Вы хотите поставить напоминание, чтобы вы поздравили бабушку через 5 дней?");
            Console.WriteLine("1 - да, 2 - нет");
            userInput = Console.ReadLine();
            Console.WriteLine("Сколько раз повторить это напоминание?");
            times = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите текст напоминания:");
            notice = Console.ReadLine();

            while (-- times > 0 )
            {
                Console.WriteLine(notice);
            }
        }
    }
}
