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
            // домашнее задание: Вывод имени:

            string name;
            string symbol;
            int amountOfSymbolsInName;

            Console.WriteLine("Напишите Ваше имя:");
            name = Console.ReadLine();
            Console.WriteLine(name.Length);
            amountOfSymbolsInName = name.Length;

            Console.WriteLine("Введите любой один символ и ваше имя окажется внутри прямоугольника, состоящего из этого символа:");
            symbol = Console.ReadLine();

            for (int i = 0; i <= amountOfSymbolsInName + 1; i++)
            {
                Console.Write(symbol);
            }

            Console.WriteLine("\n" + symbol + name + symbol);

            for (int i = 0; i <= amountOfSymbolsInName + 1; i++)
            {
                Console.Write(symbol);
            }
        }
    }
}