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
            //домашнее задание "программа под паролем":

            string password = "123456";
            string userInput;
            int tryCount = 3;

            for (int i = 0; i < tryCount; i++)
            {
                Console.WriteLine("Введите пароль, чтобы узнать страшную тайну:");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine("Вы открыли страшную тайну: Бабы Яги не существует!");
                    break;
                }
                else if (userInput != password)
                {
                    Console.WriteLine("Неа, пароль не верный, введите ещё раз");
                }
            }
        }
    }
}