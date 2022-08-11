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

    class CarService
    {
        private int _money = 20000;
        private int _priceOfService;
        private int _priceOfWork;
        private int _fine = 150;
        private List<Detail> _storage = new List<Detail>();
        public List<Client> _clients = new List<Client>();
        private bool _isWorking = true;

        public int _accuracyOfWork { get; private set; } = 0;

        public void StartToWork()
        {
            AddDetail();
            AddClients();

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
            switch (client._car.IdOfDefect)
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
            _priceOfService = _priceOfWork + (_priceOfWork * 2);
        }

        private void ShowAllInfo(Client client, int priceOfService)
        {
            Console.WriteLine($"Денег в автосервисе - {_money}\nПоломка у текущего автомобиля - {client._car.Defect}\n" +
                $"Итоговая цена починки состоит из цены за деталь + цены за работу(в два раза меньше цены за деталь) - {priceOfService}");
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("Склад автосервиса:");

            for (int i = 0; i < _storage.Count; i++)
            {
                Console.WriteLine(_storage[i].Id + " - " + _storage[i].Name);
            }
            Console.SetCursorPosition(0, 7);
        }

        private void PrepareToRepair(Client client)
        {
            string userInput;
            bool isSuccessfull;
            int userNumber;

            Console.WriteLine("Введите id детали, которую надо заменить, чтобы найти её на складе произвести ремонт\nЧтобы выйти, нажмите 9");
            userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out userNumber);
            FindADetail(client, isSuccessfull, userNumber);
        }

        private void FindADetail(Client client, bool isSuccessfull, int userNumber)
        {
            if (isSuccessfull == true)
            {
                int indexOfDetail;
                int firstFoundDetail = 0;

                if (userNumber == 9)
                {
                    _isWorking = false;
                }
                else
                {
                    for (int i = 0; i < _storage.Count; i++)
                    {
                        if (_storage[i].Id == userNumber && client._car.IdOfDefect == userNumber)
                        {
                            firstFoundDetail++;

                            if (firstFoundDetail == 1)
                            {
                                indexOfDetail = i;
                                _accuracyOfWork = 1;
                                Repair(client, indexOfDetail);
                            }
                        }
                    }

                    if (firstFoundDetail == 0)
                    {
                        Console.WriteLine("Такой детали нет на складе. Или вы ввели не тот id.\nОтказать клиенту и заплатить штраф (нажмите 1)\n" +
                            "Установить ему первую неподходящую деталь (нажмите 2)");
                        string userInput = Console.ReadLine();
                        isSuccessfull = int.TryParse(userInput, out userNumber);

                        if (isSuccessfull == true)
                        {
                            if (userNumber == 1)
                            {
                                Console.WriteLine("Вы заплатили штраф");
                                GiveAwayMoney(_fine, true);
                            }
                            else if (userNumber == 2)
                            {
                                indexOfDetail = 0;
                                Console.WriteLine("Вы установили ему неподходящую деталь. Надейтесь, что клиент не заметит");
                                _accuracyOfWork = 2;
                                Repair(client, indexOfDetail);
                                int financialDamage = _priceOfService * 5;
                                bool isNoticed = client.CheckRepairedCar(_accuracyOfWork, financialDamage);
                                GiveAwayMoney(financialDamage, isNoticed);
                            }
                        }
                    }
                }
            }
            else if (isSuccessfull == false)
            {
                Console.WriteLine("Вы ввели не число");
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void Repair(Client client, int indexOfDetail)
        {
            client.GiveAwayMoney(_priceOfService);
            GetMoney(_priceOfService);
            _storage.RemoveAt(indexOfDetail);
        }

        private void GiveAwayMoney(int fine, bool isNoticed)
        {
            if (_isWorking == true)
            {
                _money -= fine;
            }
        }

        private void GetMoney(int priceOfService)
        {
            _money += priceOfService;
        }

        private void AddDetail()
        {
            int necessaryCount = 10;

            for (int i = 0; i < necessaryCount; i++)
            {
                _storage.Add(new Detail());
                System.Threading.Thread.Sleep(150);
            }
        }

        private void AddClients()
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

        public Car _car { get; private set; } = new Car();

        public void GetMoney(int financialDamage)
        {
            _money += financialDamage;
        }

        public void GiveAwayMoney(int priceOfService)
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
                    GetMoney(financialDamage);
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
















