using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {      // Задание: Отчёт о вооружении:

            List<Soldier> soldiers = new List<Soldier> {new Soldier("Борис", "Автомат","Лейтенант",56), new Soldier("Никита", "Пистолет", "Сержанn", 15),
          new Soldier("Коля", "Нож","Курсант",3),new Soldier("Саша", "Пистолет","Майор",158),new Soldier("Толя", "Граната","Курсант",6),};

            var soldiersList = soldiers.Select(soldier => new { Name = soldier.Name, Rank = soldier.Rank }).ToList();

            Console.WriteLine("Список солдат, состоящий из имен и званий:\n");
            
            foreach (var soldier in soldiersList)
            {
                Console.WriteLine(soldier.Name + " " + soldier.Rank);
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Rank { get; private set; }
        public int YearsOfService { get; private set; }

        public Soldier(string name, string armament, string rank, int yearsOfService)
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            YearsOfService = yearsOfService;
        }
    }
}
















