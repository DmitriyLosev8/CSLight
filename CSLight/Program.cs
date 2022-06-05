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
            //домашнее задание: скобочное выражение: 

            string stringToChek = "'(' и ')'";
            int deepOfBracket = 0;
            Console.WriteLine(stringToChek);

            for (int i = 0; i < stringToChek.Length; i++)
            {

                if (stringToChek[i] == '(')
                {
                    deepOfBracket += 1;
                }

                if (stringToChek[i] == ')')
                {
                    deepOfBracket -= 1;
                }

                if (deepOfBracket < 0)
                {
                    break;
                }
            }

            if (deepOfBracket == 0)
            {
                Console.WriteLine("Строка корректна");
            }

            else
            {
                Console.WriteLine("Строка не корректна");
            }
        }
    }
}


