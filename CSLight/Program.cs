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
            // домашнее задание поменять местами значения переменных:

            string name = "Волочкова";
            string lastName = "Алёна";   
            Console.WriteLine("Ваше имя - " + name);
            Console.WriteLine("Ваша фамилия - " + lastName);
            string changedName = lastName;
            string changedLastName = name;
            name = changedName;
            lastName = changedLastName;
            Console.WriteLine("Данные были не верны, вот верные данные:");
            Console.WriteLine("Ваше имя - " + name);
            Console.WriteLine("Ваша фамилия - " + lastName);
        }
    }
}
