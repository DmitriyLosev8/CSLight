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
        {      // Задание: Работа с классами:

            Players redPlayer = new Players("Красный игрок", 100, 85, 12);
            redPlayer.ShowСharacteristic();
        }
    }

    class Players
    {
        public int Health;
        public int Armor;
        public int Damage;
        public string Name;

        public Players(string name, int health, int armor, int damage)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public void ShowСharacteristic()
        {
            Console.WriteLine($"Имя игрока - {Name}\nЗдоровье игрока - {Health}\nБроня игрока - {Armor}\nУрон игрока - {Damage}");
        }
    }
}
