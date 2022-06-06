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
            //домашнее задание: консольное меню:

            string name;
            string password;
            int daysInYear = 365;
            int daysBeforeNewYear;
            int minimumDays = 1;
            Random random = new Random();
            int daysToRun = random.Next(minimumDays, daysInYear);
            int userInput;
            int color = 1;
            int anotherColor = 3;
            Random randomOfColor = new Random();
            int colorOfFuture = randomOfColor.Next(color, anotherColor);

            Console.WriteLine("                                     ДОБРО ПОЖАЛОВАТЬ В КОНСОЛЬНОЕ МЕНЮ");
            Console.WriteLine("Чтобы задать имя, нажмите - 1\nЧтобы задать пароль, нажмите - 2\nЧтобы узнать сколько дней подряд вам надо бегать (непредсказуемо), нажмите - 3" +
                "\n" + "Чтобы узнать сколько дней осталось до Нового Года, нажмите - 4\nЕсли вы хотите знать, какой цвет будет популярным через 10 лет, нажмите - 5" +
                "\nЧтобы выйти, нажмите - 6");
            userInput = Convert.ToInt32(Console.ReadLine());

            while (userInput != 6)
            {  
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Введите Ваше имя:");
                        name = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Введите пароль:");
                        password = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("По нашим подсчётам, чтобы Вы были в тонусе, Вам надо бегать - " + daysToRun + " дней подряд. Удачи!");
                        break;
                    case 4:
                        Console.WriteLine("Какой по счёту сегодня день в году?");
                        userInput = Convert.ToInt32(Console.ReadLine());
                        daysBeforeNewYear = daysInYear - userInput;
                        Console.WriteLine(daysBeforeNewYear + " - столько дней осталось до Нового Года.");
                        break;
                    case 5:

                        if (colorOfFuture == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Предполагаемый нами популярный цвет через десять лет - зелёный");
                        }
                        if (colorOfFuture == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Предполагаемый нами популярный цвет через десять лет - красный");
                        }
                        if (colorOfFuture == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Предполагаемый нами популярный цвет через десять лет - синий");
                        }
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                userInput = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}


