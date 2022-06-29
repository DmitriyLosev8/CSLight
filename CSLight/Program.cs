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
            // Задание: UIElement:    

            string healthBar = "";
            int prosentsOfBar;
            string manaBar = "";
            string scaleOfBar = "";

            Console.WriteLine("Введите сколько процентов жизни вы хотите отобразить:");
            prosentsOfBar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 1 символ, которым будут отобрадаться жизни");
            scaleOfBar = Console.ReadLine();
            DrawBar(healthBar, prosentsOfBar, scaleOfBar);
            Console.WriteLine("Введите сколько процентов маны вы хотите отобразить:");
            prosentsOfBar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 1 символ, которым будет отображаться мана");
            scaleOfBar = Console.ReadLine();
            DrawBar(manaBar, prosentsOfBar, scaleOfBar);
        }

        static void DrawBar(string bar, int prosentsOfBar, string scaleOfBar)
        {
            string emptyScaleOfBar = " ";
            int multiplicity = 10;
            int fullBar = 100;

            if (prosentsOfBar < multiplicity || prosentsOfBar > fullBar)
            {
                Console.WriteLine("Введите корректное значение");
            }       
            else
            {
                Console.WriteLine("\nВот ваш Bar:\n");

                for (int i = 0; i < prosentsOfBar / multiplicity; i++)
                {
                    bar += scaleOfBar;
                }
                
                for (int i = prosentsOfBar / multiplicity; i < fullBar / multiplicity; i++)
                {
                    bar += emptyScaleOfBar;
                }
                Console.Write("[" + bar + "]\n");
            }  
        }
    }
}


