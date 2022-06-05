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
            char deepOfBracket;
            Console.WriteLine(stringToChek);

            for (int i = 0; i <= stringToChek.Length; i++)
            {
                deepOfBracket = stringToChek[i];

                if (i == '(')
                {
                    i += 1;
                }

                if (i == ')')
                {
                    i -= 1;
                }
               
                if (deepOfBracket < 0)
                {
                    break;
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
}


