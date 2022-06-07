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
            //домашнее задание: бой с боссом:

            int healthOfHero = 400;
            int healthOfBoss = 600;
            int bossDamage = 20;
            int minimumHeroDamage = 7;
            int maximumHeroDamage = 15;
            Random random = new Random();
            int powerOfAirDamage = random.Next(minimumHeroDamage, maximumHeroDamage);
            int powerOfEarthHealth = 100;
            int powerOfEarthDamage = 20;
            int powerOfWaterHealth = 150;
            int powerOfWaterDamage = 10;
            int ultimatePowerHealth = 50;
            int ultimatePowerDamage = 100;
            int healthForUltimatePower = 60;
            int healthForPowerOfEarth = 300;
            int healthForPowerOfWater = 150;
            string userInput;

            Console.WriteLine("                                  Впереди Вас ждёт финальное сражение! Босс - очень силён, но у Вас есть шансы!");
            Console.WriteLine("Для этого Вам нужно чётко расчитать стратегию ведения боя. У Босса " + healthOfBoss + " хп и " + bossDamage + " урона.");
            Console.WriteLine("У Вас же " + healthOfHero + " хп и четыре заклинания:\n\nСила Воздуха - Ваш урон будет от " + minimumHeroDamage + " до " + maximumHeroDamage +
                ", нажмите 1, чтобы применить\n\nСила Земли - Ваш урон будет - " + powerOfEarthDamage + ", но отнимется - " + powerOfEarthHealth + " хп," + "\n" +
                "(МОЖНО ПРИМЕНИТЬ, ТОЛЬКО ЕСЛИ У ВАС БОЛЬШЕ ХП ЧЕМ - " + healthForPowerOfEarth + ", нажмите 2, чтобы применить\n\n" +
                "Сила Воды - Вам прибавится - " + powerOfWaterHealth + " хп, но урон будет - " + powerOfWaterDamage + ",\n" +
                "(МОЖНО ПРИМЕНИТЬ, ТОЛЬКО ЕСЛИ У ВАС ХП НИЖЕ ЧЕМ - " + healthForPowerOfWater + ", нажмите 3, чтобы применить\n\n" +
                "Абсолютная Сила  - Ваш урон будет - " + ultimatePowerDamage + ", а хп увеличится на - " + ultimatePowerHealth + "\n" +
                "(МОЖНО ПРИМЕНИТЬ, ТОЛЬКО КОГДА У ВАС - " + healthForUltimatePower + " ХП ИЛИ НИЖЕ). Нажмите 4, чтобы применить\n\n" +
                "                                                        ДА НАЧНЁТСЯ БИТВА!");

            while (healthOfHero > 0 && healthOfBoss > 0)
            {
                userInput = Console.ReadLine();
                Console.WriteLine("Герой - " + healthOfHero + " хп                                  Босс - " + healthOfBoss + " хп");

                switch (userInput)
                {
                    case "1":
                        healthOfBoss -= powerOfAirDamage;
                        healthOfHero -= bossDamage;
                        break;
                    case "2":

                        if (healthOfHero > healthForPowerOfEarth)
                        {
                            healthOfHero -= powerOfEarthHealth;
                            healthOfBoss -= powerOfEarthDamage;
                            healthOfHero -= bossDamage;
                        }

                        else
                        {
                            Console.WriteLine("Сейчас невозможно применить Силу Земли, у Вас хп меньше чем - " + healthForPowerOfEarth);
                        }
                        break;
                    case "3":

                        if (healthOfHero < healthForPowerOfWater)
                        {
                            healthOfHero += powerOfWaterHealth;
                            healthOfBoss -= powerOfWaterDamage;
                            healthOfHero -= bossDamage;
                        }

                        else
                        {
                            Console.WriteLine("Сейчас невозможно применить Силу Воды, у Вас хп больше чем - " + healthForPowerOfWater);
                        }
                        break;
                    case "4":

                        if (healthOfHero <= healthForUltimatePower)
                        {
                            healthOfHero += ultimatePowerHealth;
                            healthOfBoss -= ultimatePowerDamage;
                            healthOfHero -= bossDamage;
                        }
                        
                        else
                        {
                            Console.WriteLine("Сейчас невозможно применить Абсолютную Силу, у Вас хп больше чем - " + healthForUltimatePower);
                        } 
                        break;
                }
                
                if (healthOfHero <= 0 && healthOfBoss <= 0)
                {
                    Console.WriteLine("Так бывает. Ничья!");
                }

                else if (healthOfHero <= 0)
                {
                    Console.WriteLine("Не в этот раз. Победил Босс!");
                }

                else if (healthOfBoss <= 0)
                {
                    Console.WriteLine("Босс повержен! Победил Герой!");
                } 
            }
        }
    }
}


