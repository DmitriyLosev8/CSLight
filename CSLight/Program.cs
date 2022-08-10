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
            //Задание: автосервис:   

            Client client = new Client();
            Console.WriteLine(client._car.IdOfDefect);

        }
    }

    class CarService
    {
        private int _money;
        private int _priceOfWork;
        private string _service;
        private int _idOfService;
        private List<Detail> _storage = new List<Detail>();
        private Queue<Client> _clients = new Queue<Client>();

        public void AddDetail()
        {
            int necessaryCount = 10;

            for (int i = 0; i < necessaryCount; i++)
            {
                _storage.Add(new Detail());        
            }
        }

        public void AddClients()
        {
            int countOfClients = 5;

            for (var i = 0; i < countOfClients; i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        public void StartToWork()
        {
            AddDetail();
            AddClients();


        }

        public void Repair()
        {

        }
    }

    class Client 
    {
        private int _money = 5000;

        public Car _car { get; private set; } = new Car();
        
        public void GetMoney(int financialDamage)
        {
            _money += financialDamage;
        }
        
        public void GiveAwayMoney(int priceOfDetail, int priceOfWork)
        {
            _money -= priceOfDetail + priceOfWork;
        }
    }



    class Car
    {
        public string Defect { get; private set; }
        public int IdOfDefect { get; private set; }

        public Car()
        {
            int minimalIdOfDefect = 1;
            int maximalIdOfDefect = 4;
            Random random = new Random();
            IdOfDefect = random.Next(minimalIdOfDefect, maximalIdOfDefect);

            switch (IdOfDefect)
            {
                case 1:
                    Defect = "Прокол шины";
                    break;
                case 2:
                    Defect = "Закончилось масло";
                    break;
                case 3:
                    Defect = "Разбилось левое зеркало";
                    break;
            }
        }
    }

    class Detail
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public int Price { get; private set; }

        public Detail()
        {
            int minimalId = 1;
            int maximalId = 4;

            Random random = new Random();
            Id = random.Next(minimalId, maximalId);

            switch (Id)
            {
                case 1:
                    Name = "Шина";
                    Price = 300;
                    break;
                case 2:
                    Name = "Масло";
                    Price = 150;
                    break;
                case 3:
                    Name = "Зеркало";
                    Price = 500;
                    break;
            }
        }
    }
}
















