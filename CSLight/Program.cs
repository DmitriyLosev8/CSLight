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
            // домашнее задание конкатинация
            
            string name;
            Console.Write("Как Вас зовут?");
            name = Console.ReadLine();
            int age;
            Console.Write("Сколько вам лет?");
            age = Convert.ToInt32(Console.ReadLine());
            string zodiak;
            Console.Write("Какой у Вас знак зодиака?");
            zodiak = Console.ReadLine();
            string work;
            Console.Write("Где Вы работаете?");
            work = Console.ReadLine();
            Console.WriteLine("Вас зовут " + name + ", вам " + age + " год, вы " + zodiak + " и работаете " + work + ".");
        
        }
    }
}
