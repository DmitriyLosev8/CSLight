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
            // домашнее задание: конвертер валют

            int eurToRub = 70;
            int usdToRub = 60;
            float rubToEur = 0.014f;
            float rubToUsd = 0.016f;
            float eurToUsd = 1.166f;
            float usdToEur = 0.857f;

            float rub;
            float eur;
            float usd;
            float currencyCount;
            string userInput;

            Console.WriteLine("Это конвертер валют, вы можете обменять между собой рубли, доллары и евро!");
            Console.WriteLine("Сколько у вас рублей?");
            rub = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Сколько у вас евро?");
            eur = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Сколько у вас долларов?");
            usd = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Чтобы обменять рубли на евро, нажмите 1:\nЧтобы обменять рубли на доллары, нажмите 2:");
            Console.WriteLine("Чтобы обменять евро на рубли, нажмите 3:\nЧтобы обменять евро на доллары, нажмите 4:");
            Console.WriteLine("Чтобы обменять доллары на рубли, нажмите 5:\nЧтобы обменять доллары на евро, нажмите 6:");
            Console.WriteLine("Чтобы завершить программу, нажмите 8");
            userInput = Console.ReadLine();

            while (userInput != "8")
           
            {
               
                switch (userInput)
                {
                    case "1":

                        Console.WriteLine("Обмен рублей на евро.\nСколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            eur += currencyCount * rubToEur;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое колличество денег");
                        }
                        break;
                    case "2":

                        Console.WriteLine("Обмен рублей на доллары.\nСколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            usd += currencyCount * rubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое колличество денег");
                        }
                        break;
                    case "3":

                        Console.WriteLine("Обмен евро на рубли.\nСколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (eur >= currencyCount)
                        {
                            eur -= currencyCount;
                            rub += currencyCount * eurToRub;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое колличество денег");
                        }
                        break;
                    case "4":

                        Console.WriteLine("Обмен евро на доллары.\nСколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (eur >= currencyCount)
                        {
                            eur -= currencyCount;
                            usd += currencyCount * eurToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое колличество денег");
                        }

                        break;
                    case "5":

                        Console.WriteLine("Обмен доллары на рубли.\nСколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            rub += currencyCount * usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое колличество денег");
                        }

                        break;
                    case "6":

                        Console.WriteLine("Обмен доллары на евро.\nСколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            eur += currencyCount * usdToEur;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое колличество денег");
                        }
                        break;
                }
            }
        }
    }
}
