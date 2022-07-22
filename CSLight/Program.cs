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
            //Задание: Гладиаторские бои:    ДОДЕЛАТЬ

            //Database figthers = new Database();

            bool readyToFight = true;           
            Warrior[] warriors = { new Giant("Гигант", 100, 500, 50, readyToFight), new Knight("Рыцарь",50,200,30, readyToFight),new Wizard("Волшебник",50,150,30, readyToFight) };
           
        }
    }


    //class Database
    //{
    //    bool readyToFight = true;
    //    private List<Warrior> _warriors = {new Giant() };
        

    //}
    class Warrior // abstract
    {
        protected string Name;
        protected int Armor;
        //protected int Health;
       // protected int Damage;
        protected bool ReadyToFight;


        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public Warrior(string name, int armor, int health, int damage, bool readyToFight) 
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        //public int Damage
        //{
        //    get { return Damage; }
        //}


        public void ShowIndicators()
        {
            Console.WriteLine($"{Name} иммет {Damage} урона. Жизней - {Health}, брони - {Armor}");
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
        public Giant(string name, int armor, int health, int damage, bool readyToFight) : base(name, armor, health, damage, readyToFight) 
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public void SuperHit(int stepOfFight)
        {
            int coolDown = 5;

            if (stepOfFight % coolDown == 0)
            {
                Damage += 30;
            }
        }
    }

    class Knight : Warrior
    {
        public Knight(string name, int armor, int health, int damage, bool readyToFight) : base(name, armor, health, damage, readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public void RepairTakenDamage(int damage)
        {
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
        private int _mana;
        public Wizard(string name, int armor, int health, int damage, bool readyToFight) : base(name, armor, health, damage, readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
            _mana = 100;

        }

        public void GetExtraDamage()
        {
            int priceOfAplly = 25;
            int manaHit = 10;

            if (_mana >= priceOfAplly)
            {
                Damage += manaHit;
            }
            else
            {
                Console.WriteLine("Недостаточно маны");
            }
        }

        public void GetExtraHealth()
        {
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
        public Recruit(string name, int armor, int health, int damage, bool readyToFight) : base(name, armor, health, damage, readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public void GiveUp()
        {
            ReadyToFight = false;
        }
    }

    class Officer : Warrior
    {
        public Officer(string name, int armor, int health, int damage, bool readyToFight) : base(name, armor, health, damage, readyToFight)
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












