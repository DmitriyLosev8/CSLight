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
        private int _health;
        private int _armor;
        private int _damage;
        private string _name;

        public Players(string name, int health, int armor, int damage)
        {
            _name = name;
            _health = health;
            _armor = armor;
            _damage = damage;
        }

        public void ShowСharacteristic()
        {
            Console.WriteLine($"Имя игрока - {_name}\nЗдоровье игрока - {_health}\nБроня игрока - {_armor}\nУрон игрока - {_damage}");
        }
    }
}
