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
            //Задание: Гладиаторские бои:       ДОДЕЛАТЬ


            bool readyToFight = true;
            Arena arena = new Arena();
            arena.ShowAllWarriors();

            // ВОТ ТУТ. Я создаю массив с типом Warrior, внутри него создаю уже классы, но по-факту они всё теже Warrior.





        }
    }


    class Arena
    {
        static bool readyToFight = true;
        Warrior[] warriors = { new Giant("Гигант", 100, 500, 50, readyToFight), new Knight("Рыцарь", 50, 200, 30, readyToFight), new Wizard("Волшебник", 50, 150, 30, readyToFight) };

        public void ShowAllWarriors()
        {
            Console.WriteLine("Вот список всех бойцов:");
            
            for(int i = 0; i < warriors.Length; i++)
            {
                Console.Write(i + 1 + " ");
                warriors[i].ShowIndicators();

            }
        }

        public void Fight()
        {
            ShowAllWarriors();
            while
        }






    }
    class Warrior 
    {
        protected string Name;
        protected int Armor;
        protected bool ReadyToFight;

        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        //public Warrior(string name, int armor, int health, int damage, bool readyToFight)
        //{
        //    Name = name;
        //    Armor = armor;
        //    Health = health;
        //    Damage = damage;
        //    ReadyToFight = true;
        //}

        public void ShowIndicators()
        {
            Console.WriteLine($"{Name} иммет {Damage} урона. Жизней - {Health}, брони - {Armor}");
        }

        public virtual void UniqueSkill(int unqueInfo)
        {

        }

        public virtual void SecondUniqueSkill()
        {

        }


        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }

        public void LosePartOfDamage(int manaHit)
        {
            Damage -= manaHit;
        }
    }

    class Giant : Warrior
    {
        public Giant(string name, int armor, int health, int damage, bool readyToFight) //: base(name, armor, health, damage, readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            int coolDown = 5;
            Console.WriteLine("SuperHit + 30 к урону");

            if (stepOfFight % coolDown == 0)
            {
                Damage += 30;
            }
        }


        //public void SuperHit(int stepOfFight)
        //{
        //    int coolDown = 5;

        //    if (stepOfFight % coolDown == 0)
        //    {
        //        Damage += 30;
        //    }
        //}
    }

    class Knight : Warrior
    {
        public Knight(string name, int armor, int health, int damage, bool readyToFight) //: base(name, armor, health, damage, readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int damage)
        {
            Console.WriteLine("RepairTakenDamage - 20% вероятность восстановления полученного урона");
            int lowerBorder = 0;
            int upperBorder = 5;
            int possibility = 1;
            Random random = new Random();
            int chance = random.Next(lowerBorder, upperBorder);

            if (chance == possibility)
            {
                Health += damage - Armor;
            }
        }
    }

    class Wizard : Warrior
    {
        public int _mana;
        public Wizard(string name, int armor, int health, int damage, bool readyToFight) //: base(name, armor, health, damage, readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
            _mana = 100;

        }

        //public override void SecondUniqueSkill()
        //{
        //    Console.WriteLine("GetExtraDamage - урон + 10");
        //    int priceOfAplly = 25;
        //    int manaHit = 10;

        //    if (_mana >= priceOfAplly)
        //    {
        //        Damage += manaHit;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Недостаточно маны");
        //    }
        //}

        public override void SecondUniqueSkill()
        {
            Console.WriteLine("GetExtraHealth - жизни + 20");
            int priceOfAplly = 25;

            if (_mana >= priceOfAplly)
            {
                Health += 20;
            }
            else
            {
                Console.WriteLine("Недостаточно маны");
            }
        }
    }

    class Recruit : Warrior
    {
        public Recruit(string name, int armor, int health, int damage, bool readyToFight) //: base(name, armor, health, damage, readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void SecondUniqueSkill()
        {
            Console.WriteLine("GiveUp - боец сдался");
            ReadyToFight = false;
        }
    }

    class Officer : Warrior
    {
        public Officer(string name, int armor, int health, int damage, bool readyToFight) //: base(name, armor, health, damage, readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public void DoubleDamage(int stepOfFight)
        {
            int coolDown = 8;

            if (stepOfFight % coolDown == 0)
            {
                Damage *= 2;
            }
        }
    }

}












