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

            string strToChek = "'(' и ')'";
            Console.WriteLine(strToChek);

            for (int i = 0; i <= strToChek.Length; i++)
            {

                while (i == 0)
                {

                    if (strToChek[i] != '"')
                    {
                        Console.WriteLine("Это скобочное выражение не корректное.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Пока что это кобочное выражение корректное.");
                        break;
                    }
                }
               
                while (i == 1)
                {

                    if (strToChek[i] == '(')
                    {
                        Console.WriteLine("Пока что это кобочное выражение корректное.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Это скобочное выражение не корректное.");
                        break;
                    }
                }
                
                while (i == 2)
                {

                    if (strToChek[i] == '(' || strToChek[i] == ' ' || strToChek[i] == ')')
                    {
                        Console.WriteLine("Пока что это кобочное выражение корректное.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Это скобочное выражение не корректное.");
                        break;
                    }
                }
                
                while (i == 3)
                {

                    if (strToChek[i] == '(' || strToChek[i] == ' ')
                    {
                        Console.WriteLine("Пока что это кобочное выражение корректное.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Это скобочное выражение не корректное.");
                        break;
                    }
                }
                
                while (i == 4)
                {

                    if (strToChek[i] == '(' || strToChek[i] == ' ' || strToChek[i] == 'и')
                    {
                        Console.WriteLine("Пока что это кобочное выражение корректное.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Это скобочное выражение не корректное.");
                        break;
                    }
                }
                
                while (i == 5)
                {

                    if (strToChek[i] == ')' || strToChek[i] == ' ')
                    {
                        Console.WriteLine("Пока что это кобочное выражение корректное.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Это скобочное выражение не корректное.");
                        break;
                    }
                }
                
                while (i == 6)
                {

                    if (strToChek[i] == '(' || strToChek[i] == ' ' || strToChek[i] == ')')
                    {
                        Console.WriteLine("Пока что это кобочное выражение корректное.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Это скобочное выражение не корректное.");
                        break;
                    }
                }
                
                while (i == 7)
                {

                    if (strToChek[i] == ')')
                    {
                        Console.WriteLine("Пока что это кобочное выражение корректное.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Это скобочное выражение не корректное.");
                        break;
                    }
                }
                
                while (i == 8)
                {

                    if (strToChek[i] != '"')
                    {
                        Console.WriteLine("Это скобочное выражение не корректное.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Пока что это кобочное выражение корректное.");
                        break;
                    }
                }
            }
        }
    }
}


