using System;
using System.Collections.Generic;
using System.Linq; //ПОДКЛЮЧАЕМ LINQ, ЧТОБЫ МОЖНО БЫЛО С НИМ РАБОТАТЬ
using System.Text;
using System.Threading.Tasks;
 


namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {      // Задание: Топ игроков:

            List<Player> players = new List<Player> { new Player("Бритва", 85, 40), new Player("Дымок", 70, 43), new Player("Терминатор", 15, 10), new Player("Гроза", 105, 54), new Player("Пуля", 67, 58),
            new Player("Девятка", 90, 87),new Player("Гараж", 74, 60),new Player("Буря", 10, 2),new Player("Страх", 150, 180),new Player("Нож", 11, 18),};

            var sorteredLevelPlayers = players.OrderByDescending(player => player.Level);
            var topThreeLevelPlayers = sorteredLevelPlayers.Take(3);

            Console.WriteLine("Вот топ 3 игроков по уровню:\n");

            foreach (var player in topThreeLevelPlayers)
            {
                Console.WriteLine(player.Name);
            }

            var sorteredPowerPlayers = players.OrderByDescending(player => player.Power);
            var topThreePowerPlayers = sorteredPowerPlayers.Take(3);

            Console.WriteLine("\n\nВот топ 3 игроков по силе:\n");

            foreach (var player in topThreePowerPlayers)
            {
                Console.WriteLine(player.Name);
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }
        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }
    }
}
















