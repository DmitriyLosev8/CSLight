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
            // домашнее задание поликлиника:

            int minutesOfWaiting = 10;
            int amountOfGrandmothers;
            int timeToWaitHours;
            int timeToWaitMinutes;
            int minutesPerHour = 60;
            string timeToWait;

            Console.WriteLine("Здравствуйте, я помогу вам определить сколько Вам ждать в очереди. Сколько вы видите перед собой старушек?");
            amountOfGrandmothers = Convert.ToInt32(Console.ReadLine());

            timeToWait = Convert.ToString((amountOfGrandmothers * minutesOfWaiting / minutesPerHour) + " часов " +  
                (amountOfGrandmothers * minutesOfWaiting % minutesPerHour) + " минут");
            Console.WriteLine("По моим подсчётам вам ждать: " + timeToWait + ", удачи!");
        }
    }
}
