﻿using System;
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

            Console.WriteLine("Здравствуйте, я помогу вам определить сколько Вам ждать в очереди. Сколько вы видите перед собой старушек?");
            amountOfGrandmothers = Convert.ToInt32(Console.ReadLine());

            timeToWaitHours = amountOfGrandmothers * minutesOfWaiting / 60;
            timeToWaitMinutes = amountOfGrandmothers * minutesOfWaiting % 60;
            Console.WriteLine("Судя по моим подсчётам вам придётся ждать " + timeToWaitHours + " часов " + timeToWaitMinutes + " минут, удачи!");
        }
    }
}
