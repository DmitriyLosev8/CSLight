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
            // домашнее задание перестановка местами значений:
            
            string name = "Волочкова";
            string lastName = "Алёна";
            Console.WriteLine("Имя - " + name);
            Console.WriteLine("Фамилия - " + lastName);
            string changes = "Данные были не верны, данные исправлены:";
            string changedName = "Алёна";
            string changedLastName = "Волочкова";
            Console.WriteLine(changes);
            Console.WriteLine("Имя - " + changedName);
            Console.WriteLine("Фамилия - " + changedLastName);

        }
    }
}
