using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;
 


namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {      // Задание: Объединение войск:
            
            List<Warrior> leftWarriors = new List<Warrior> { (new Warrior("Гена", "Борисов")), (new Warrior("Дима", "Аникеев")), (new Warrior("Саша", "Бондаренко")), 
                (new Warrior("Саша", "Степанов")),(new Warrior("Боря", "Андропов")),(new Warrior("Семён", "Бонько")),(new Warrior("Никита", "Опа")),(new Warrior("Степан", "Борислав")), };

            List<Warrior> rigthWarriors = new List<Warrior> { (new Warrior("Саша", "Задорожный")), (new Warrior("Дима", "Лосев")), (new Warrior("Сергей", "Бодров")),
                (new Warrior("Сергей", "Шнуров")),(new Warrior("Незами", "Мамедов")),(new Warrior("Ксения", "Задорожная")),(new Warrior("Любовь", "Двойнина")),(new Warrior("Владимир", "Двойнин")), };

            var unitedSqaud = rigthWarriors.Union(leftWarriors.Where(warrior => warrior.LastName.StartsWith("Б")));

            foreach (var warrior in unitedSqaud)
            {
                Console.WriteLine(warrior.Name);
            }
        }
    }

    class Warrior
    {
       public string Name { get; private set; } 
       public string LastName { get; private set; }

      public Warrior(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}
















