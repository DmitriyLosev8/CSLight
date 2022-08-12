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

            CarService carService = new CarService();
            carService.StartToWork();
        }
    }

    class Storage
    {
        private List<Detail> _details = new List<Detail>();
       
        public int IndexOfDetail { get; private set; }

        public Storage()
        {
            int necessaryCount = 10;

            for (int i = 0; i < necessaryCount; i++)
            {
                _details.Add(new Detail());
                System.Threading.Thread.Sleep(150);
            }
        }

        public bool FindDetail(int clientsIdOfDetail)
        {
            bool isFound = false;

            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].Id == clientsIdOfDetail)
                {
                    isFound = true;
                    IndexOfDetail = i;
                }
            }
            return isFound;
        }

        public Detail GiveDetail(int indexOfDetail)
        {
            Detail tranferredDetail = _details[indexOfDetail];
            _details.RemoveAt(indexOfDetail);
            return tranferredDetail;
        }

        public void ShowInfo()
        {
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("Детали на скалде:");

            for (int i = 0; i < _details.Count; i++)
            {
                Console.WriteLine(_details[i].Id + " - " + _details[i].Name);
            }
            Console.SetCursorPosition(0, 5);
        }
    }

    class CarService
    {
        private Storage _storage = new Storage();
        private int _money = 20000;
        private int _priceOfService;
        private int _priceOfWork;
        private int _fine = 150;
        private List<Client> _clients = new List<Client>();
        private bool _isWorking = true;
        private Detail _detailForRepair;

        public int AccuracyOfWork { get; private set; } = 0;

        public void StartToWork()
        {
            AttractClients();

            while (_isWorking == true)
            {
                FormPrices(_clients[0]);
                ShowAllInfo(_clients[0], _priceOfService);
                PrepareToRepair(_clients[0]);
                _clients.RemoveAt(0);

                if (_clients.Count == 0)
                {
                    Console.WriteLine("Клиенты закончились");
                    _isWorking = false;
                }
            }
        }

        private void FormPrices(Client client)
        {
            int multiplierOfPrice = 3;

            switch (client.Сar.IdOfDefect)
            {
                case 1:
                    _priceOfWork = 150;
                    break;
                case 2:
                    _priceOfWork = 75;
                    break;
                case 3:
                    _priceOfWork = 250;
                    break;
            }
            _priceOfService = _priceOfWork * multiplierOfPrice;
        }

        private void ShowAllInfo(Client client, int priceOfService)
        {
            Console.WriteLine($"Денег в автосервисе - {_money}\nПоломка у текущего автомобиля - {client.Сar.Defect}\n" +
                $"Итоговая цена починки состоит из цены за деталь + цены за работу(в два раза меньше цены за деталь) - {priceOfService}");
            _storage.ShowInfo();
        }

        private void PrepareToRepair(Client client)
        {
            string userInput;
            Console.WriteLine("\n\nНажмите enter чтобы найти деталь на складе и произвести ремонт\nЧтобы выйти, нажмите 'в'");
            userInput = Console.ReadLine();

            if (userInput == "в")
            {
                _isWorking = false;
            }
            Console.ReadKey();
            TakeDetail(client);
        }

        private void TakeDetail(Client client)
        {
            bool isFound = _storage.FindDetail(client.Сar.IdOfDefect);

            if (isFound == true)
            {
                _detailForRepair = _storage.GiveDetail(_storage.IndexOfDetail);
                AccuracyOfWork = 1;
                Repair(client, _detailForRepair);
            }
            else
            {
                Console.WriteLine("Такой детали нет на складе.\nОтказать клиенту и заплатить штраф (нажмите любую клавишу)\n" +
                    "Установить ему первую неподходящую деталь и попытать счастья (введите слово 'рискнуть')");

                string userInput = Console.ReadLine();

                if (userInput == "рискнуть")
                {
                    int multiplierOfFinancialDamage = 5;
                    int indexOfDetail = 0;
                    _detailForRepair = _storage.GiveDetail(indexOfDetail);
                    Console.WriteLine("Вы установили ему неподходящую деталь. Надейтесь, что клиент не заметит");
                    AccuracyOfWork = 2;
                    Repair(client, _detailForRepair);
                    int financialDamage = _priceOfService * multiplierOfFinancialDamage;
                    bool isNoticed = client.CheckRepairedCar(AccuracyOfWork, financialDamage);
                    Pay(financialDamage, isNoticed);
                }
                else
                {
                    Console.WriteLine("Вы заплатили штраф");
                    Pay(_fine, true);
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void Repair(Client client, Detail detailForRepair)
        {
            client.Pay(_priceOfService);
            AcceptMoney(_priceOfService);
        }

        private void Pay(int fine, bool isNoticed)
        {
            if (_isWorking == true)
            {
                _money -= fine;
            }
        }

        private void AcceptMoney(int priceOfService)
        {
            _money += priceOfService;
        }

        private void AttractClients()
        {
            int countOfClients = 5;

            for (var i = 0; i < countOfClients; i++)
            {
                _clients.Add(new Client());
                System.Threading.Thread.Sleep(150);
            }
        }
    }

    class Client
    {
        private int _money = 5000;

        public Car Сar { get; private set; } = new Car();

        public void AcceptMoney(int financialDamage)
        {
            _money += financialDamage;
        }

        public void Pay(int priceOfService)
        {
            _money -= priceOfService;
        }

        public bool CheckRepairedCar(int accuracyOfWork, int financialDamage)
        {
            bool isNoticed = false;
            Random random = new Random();
            int chanceToNoticeFalse;
            int minimalBorder = 0;
            int maximalBorder = 3;
            chanceToNoticeFalse = random.Next(minimalBorder, maximalBorder);

            if (chanceToNoticeFalse == 0 || accuracyOfWork == 1)
            {
                Console.WriteLine("Клиент вам благодарен");
            }
            else
            {
                if (accuracyOfWork == 2)
                {
                    Console.WriteLine("Клиент заметил, что вы поставили ему не ту деталь. У вас спишется 5 стоимостей услуги из-за ущерба клиенту");
                    AcceptMoney(financialDamage);
                    isNoticed = true;
                }
            }
            return isNoticed;
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
                    Defect = "Разбилось зеркало заднего вида";
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
















