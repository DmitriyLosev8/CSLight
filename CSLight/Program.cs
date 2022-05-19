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

            string request = "Как Вас зовут? Сколько Вам лет? Какой Ваш знак зодиака? Где Вы работаете?";
            Console.WriteLine(request);
            string name = "Алексей";
            int age = 21;
            string zodiak = "водолей";
            string work = "на заводе";
            Console.WriteLine("Вас зовут " + name + ", вам " + age + " год, вы " + zodiak + " и работаете " + work + ".");
        }
    }
}
