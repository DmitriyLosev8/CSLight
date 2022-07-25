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
            //Задание: Гладиаторские бои:       

            Arena arena = new Arena();
            arena.PickWarrior();
        }
    }

    class Arena
    {
        private static bool _readyToFight = true;
        private Warrior[] _warriors = { new Giant("Гигант", 10, 300, 50, _readyToFight), new Knight("Рыцарь", 5, 200, 30, _readyToFight), new Wizard("Волшебник", 5, 150, 30, _readyToFight),
            new Recruit("Рекрут",3,150,25,_readyToFight), new Officer("Офицер", 7,300,50,_readyToFight) };

        public void ShowAllWarriors()
        {
            Console.WriteLine("Вот список всех бойцов:\n");

            for (int i = 0; i < _warriors.Length; i++)
            {
                Console.Write(i + 1 + " ");
                _warriors[i].ShowIndicators();
            }
        }

        public void PickWarrior()
        {
            int leftWarriorIndex;
            int rightWarriorIndex;
            string userInput;
            bool isSuccessfull;

            Console.SetCursorPosition(45, 0);
            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ НА АРЕНУ:");
            Console.SetCursorPosition(0, 2);
            ShowAllWarriors();
            Console.WriteLine("\nВыберете левого бойца:");
            userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out leftWarriorIndex);

            if (isSuccessfull == true && leftWarriorIndex <= _warriors.Length)
            {
                Console.WriteLine("\nВыберете правого бойца:");
                userInput = Console.ReadLine();
                isSuccessfull = int.TryParse(userInput, out rightWarriorIndex);
                Fight(isSuccessfull, leftWarriorIndex, rightWarriorIndex);
            }
            else
            {
                Console.WriteLine("Вы ввели не число или бойца под таким номером нет");
            }
        }

        public void ShowFigth(int leftWarriorIndex, int rightWarriorIndex)
        {
            Console.SetCursorPosition(35, 0);
            Console.WriteLine("Сначала выберете способность для левого бойца, потом для правого");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Боец слева:");
            Console.SetCursorPosition(55, 2);
            Console.WriteLine("Боец справа:");
            Console.SetCursorPosition(0, 5);
            _warriors[leftWarriorIndex - 1].ShowIndicators();
            Console.SetCursorPosition(55, 5);
            _warriors[rightWarriorIndex - 1].ShowIndicators();
        }

        public void ApplySkill(int warriorIndex, int stepOfFight)
        {
            Console.SetCursorPosition(25, 7);
            Console.WriteLine("Применить способность у бойца?");
            Console.SetCursorPosition(35, 8);
            Console.WriteLine("д - Да, н - нет");
            string userInput = Console.ReadLine();

            if (userInput == "д")
            {
                _warriors[warriorIndex - 1].UniqueSkill(stepOfFight);
            }
        }

        public void Fight(bool isSuccessfull, int leftWarriorIndex, int rightWarriorIndex)
        {
            int stepOfFight = 0;
           
            if (isSuccessfull == true && rightWarriorIndex <= _warriors.Length && leftWarriorIndex != rightWarriorIndex)
            {
                Console.Clear();
                while (_warriors[leftWarriorIndex - 1].Health > 0 && _warriors[rightWarriorIndex - 1].Health > 0 && _warriors[leftWarriorIndex - 1].ReadyToFight == true && _warriors[rightWarriorIndex - 1].ReadyToFight == true)
                {
                    stepOfFight++;
                    ShowFigth(leftWarriorIndex, rightWarriorIndex);
                    ApplySkill(leftWarriorIndex, stepOfFight);
                    _warriors[rightWarriorIndex - 1].TakeDamage(_warriors[leftWarriorIndex - 1].Damage);
                    ApplySkill(rightWarriorIndex, stepOfFight);
                    _warriors[leftWarriorIndex - 1].TakeDamage(_warriors[rightWarriorIndex - 1].Damage);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число или бойца под таким номером нет/его уже выбрали");
            }
        }
    }

    class Warrior
    {
        protected string Name;
        protected int Armor;

        public bool ReadyToFight { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int UniqueFeature { get; protected set; }

        public void ShowIndicators()
        {
            Console.WriteLine($"{Name}, {Damage} - урона. Жизней - {Health}, брони - {Armor}");
        }

        public virtual void UniqueSkill(int uniqueInfo) { }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }
    }

    class Giant : Warrior
    {
        private int _coolDown = 6;

        public Giant(string name, int armor, int health, int damage, bool readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            Console.WriteLine("SuperHit + 30 к урону");

            if (stepOfFight % _coolDown == 0)
            {
                Damage += 30;
            }
        }
    }

    class Knight : Warrior
    {
        private int _possibilityToSkill = 1;
        private int _lowerBorder = 0;
        private int _upperBorder = 5;
        private int _chance;

        public Knight(string name, int armor, int health, int damage, bool readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            Console.WriteLine("ExtraDamage - 20% вероятность увеличить урон на 15");
            Random random = new Random();
            _chance = random.Next(_lowerBorder, _upperBorder);

            if (_chance == _possibilityToSkill)
            {
                Damage += 15;
            }
        }
    }

    class Wizard : Warrior
    {
        private int _priceOfAplly = 25;

        public Wizard(string name, int armor, int health, int damage, bool readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
            UniqueFeature = 100;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            if (UniqueFeature >= _priceOfAplly)
            {
                Console.WriteLine("GetExtraHealth - жизни + 20");
                UniqueFeature -= _priceOfAplly;
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
        public Recruit(string name, int armor, int health, int damage, bool readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            Console.WriteLine("GiveUp - боец сдался");
            ReadyToFight = false;
        }
    }

    class Officer : Warrior
    {
        private int _coolDown = 8;

        public Officer(string name, int armor, int health, int damage, bool readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            if (stepOfFight % _coolDown == 0)
            {
                Console.WriteLine("DoubleDamage - двойной урон");
                Damage *= 2;
            }
        }
    }
}













