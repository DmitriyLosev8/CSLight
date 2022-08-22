using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {      // Задание: Определение просрочки:

            int nowYear = 2022;

            List<Stew> stews = new List<Stew> {new Stew("Добрыня",2015,8), new Stew("Степан", 2012, 8), new Stew("Мясовник", 2019, 2), new Stew("СуперТушёнка", 2013, 15),
            new Stew("СъешьМеня",2014,7),new Stew("ПочтиТушёнка",2003,8),new Stew("Вкусняшка",2021,4),new Stew("КускиМяса",2017,3),new Stew("НеТушёнка",2015,6)};

            var overdueStew = stews.Where(stew => stew.ProductionYear + stew.ExpirationDate < nowYear).ToList();

            Console.WriteLine("Тушёнка с истёкшим сроком годности:\n");

            foreach (var stew in overdueStew)
            {
                Console.WriteLine(stew.Title);
            }
        }
    }

    class Stew
    {
        public string Title { get; private set; }
        public int ProductionYear { get; private set; }
        public int ExpirationDate { get; private set; }

        public Stew(string title, int productionYear, int expirationDate)
        {
            Title = title;
            ProductionYear = productionYear;
            ExpirationDate = expirationDate;
        }
    }
}
















