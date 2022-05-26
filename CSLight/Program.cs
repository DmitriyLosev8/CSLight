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
        {   // домашнее задание поликлиника:

            int minutesOfWaiting = 10;
            int amoutnOfGrandmothers;
            int timeToWait;

            Console.WriteLine("Здравствуйте, я помогу вам определить сколько Вам ждать в очереди. Сколько вы видите перед собой старушек?");
            amoutnOfGrandmothers = Convert.ToInt32(Console.ReadLine());

            timeToWait = amoutnOfGrandmothers * minutesOfWaiting;
            Console.WriteLine("Судя по моим подсчётам вам придётся ждать " + timeToWait + " минут, удачи!");
        }
    }
}
