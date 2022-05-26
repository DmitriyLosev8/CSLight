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
        {   // домашнее задание магазин:

            int goldCoins;
            int cristal;
            int priseOfCristal = 10;

            Console.WriteLine("Вы в магазине кристаллов. Цена одного кристалла - " + priseOfCristal + " золотых монет.");
            Console.Write("Сколько у вас золотых монет?");
            goldCoins = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько кристаллов вы хотите купить?");
            cristal = Convert.ToInt32(Console.ReadLine());

            goldCoins -= cristal * priseOfCristal;
            Console.WriteLine("Спасибо за покупку, вы купили " + cristal + " кристалов, у вас осталось " + goldCoins + " золотых монет.");
        }
    }
}
