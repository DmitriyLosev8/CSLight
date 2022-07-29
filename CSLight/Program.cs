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
            //Задание: Конфигуратор пассажирских поездов:   

            ManagerOfRailwayStation managerOfRailwayStation = new ManagerOfRailwayStation();
            managerOfRailwayStation.ShowMenu();
        }
    }

    class ManagerOfRailwayStation
    {
        private bool isWorking = true;
        private List<RailwayStation> _stations = new List<RailwayStation>();
        private List<Direction> _directions = new List<Direction>();
        private List<Train> _trains = new List<Train>();
        private int _countOfRuns = 0;

        public void ShowMenu()
        {
            while (isWorking == true)
            {
                int userNumber;
                Console.SetCursorPosition(45, 0);
                Console.WriteLine("Добро пожаловать в программу управления ЖД вокзалом");
                Console.SetCursorPosition(60, 2);
                Console.WriteLine("Вот информация о текущем рейсе:");
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Чтобы создать направление, нажмите 1\nЧтобы продать билеты на это направление, нажмите 2\nЧобы сформировать поез, нажмите 3,\n" +
                    "Чтобы отправить поезд, нажмите 4\nЧтобы выйти, нажмите 5");
                string userInput = Console.ReadLine();
                bool isSuccessfull = int.TryParse(userInput, out userNumber);
                PickFunction(isSuccessfull, userNumber);
            }
        }

        private void PickFunction(bool isSuccessfull, int userNumber)
        {
            if (isSuccessfull == true)
            {
                switch (userNumber)
                {
                    case 1:
                        _countOfRuns++;
                        _stations.Add(new RailwayStation());
                        _directions.Add(_stations[_countOfRuns - 1].CreateADirection());
                        break;
                    case 2:
                        _stations[_countOfRuns - 1].SellTickets(_directions[0]);
                        break;
                    case 3:
                        _trains.Add(_stations[_countOfRuns - 1].FormATrain());
                        break;
                    case 4:
                        _stations[_countOfRuns - 1].SendTrain();
                        break;
                    case 5:
                        isWorking = false;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число.");
            }
            Console.ReadKey();
            Console.Clear();
            ShowAllInfo();
        }

        private void ShowAllInfo()
        {
            _directions[_countOfRuns - 1].ShowInfo();
            _stations[_countOfRuns - 1].ShowPassengers();

            if (_trains.Count != _countOfRuns - 1)
            {
                _trains[_countOfRuns - 1].ShowInfo();
            }
            else
            {
                Console.SetCursorPosition(60, 5);
                Console.WriteLine("Cформируйте поезд");
            }
        }
    }

    class RailwayStation
    {
        private int _minimalNumberOfPassengers = 10;
        private int _maximumNumberOfPassengers = 200;
        private int _minimalPriceOfTicket = 50;
        private int _maximumPriceOfTicket = 100;
        private int _money = 1000;
        private List<Passanger> _waitingHall = new List<Passanger>();
       
        public int CountOfPassengers { get; private set; }
        public bool isOnStation { get; private set; } = false;
        public bool IsCreated { get; private set; } = false;

        public void SendTrain()
        {
            if (_waitingHall.Count == 0 && isOnStation != false)
            {
                isOnStation = false;
                Console.WriteLine("Поезд отправлен");
                IsCreated = false;
            }
            else
            {
                Console.WriteLine("Поезд не сформирован");
            }
        }

        public Direction CreateADirection()
        {
            Direction direction = new Direction("Направление", 0);

            if (IsCreated == false)
            {
                Random random = new Random();
                Console.WriteLine("Введите направление в формате: Город - Город:");
                string userDirection = Console.ReadLine();
                direction = new Direction(userDirection, random.Next(_minimalPriceOfTicket, _maximumPriceOfTicket));
                IsCreated = true;
            }
            else
            {
                Console.WriteLine("Направление уже создано, сформируйте поезд и отправьте его.");
            }
            return direction;
        }

        public void SellTickets(Direction direction)
        {
            if (direction.Title != "Направление")
            {
                Random random = new Random();
                CountOfPassengers = random.Next(_minimalNumberOfPassengers, _maximumNumberOfPassengers);
                _waitingHall.Clear();

                while (CountOfPassengers > 0)
                {
                    Passanger passanger = new Passanger();
                    passanger.BuyATicket(direction.Ticket);
                    _money += direction.Ticket;
                    _waitingHall.Add(passanger);
                    CountOfPassengers--;
                }
            }
            else
            {
                Console.WriteLine("Создайте направление.");
            }
        }

        public void ShowPassengers()
        {
            Console.SetCursorPosition(60, 4);

            if (_waitingHall.Count > 0)
            {
                Console.WriteLine("В зале ожидания " + _waitingHall.Count + " пассажиров");
            }
            else if (CountOfPassengers > 0)
            {
                Console.WriteLine("В поезде " + CountOfPassengers + " пассажиров");
            }
            else if (IsCreated == true)
            {
                Console.WriteLine("Продайте билеты");
            }
        }

        public Train FormATrain()
        {
            Train train = new Train();

            if (_waitingHall.Count > 0)
            {
                CountOfPassengers = _waitingHall.Count;
                train.FillATrain(CountOfPassengers);
                isOnStation = true;
                _waitingHall.Clear();
            }
            else
            {
                Console.WriteLine("Продайте сначала билеты.");
            }
            return train;
        }
    }

    class Direction
    {
        public string Title { get; private set; }
        public int Ticket { get; private set; }

        public Direction(string title, int ticket)
        {
            Title = title;
            Ticket = ticket;
        }

        public void ShowInfo()
        {
            if (Title != "Направление")
            {
                Console.SetCursorPosition(60, 3);
                Console.WriteLine($"Направление - {Title}, стоимость билета - {Ticket}");
            }
            else
            {
                Console.SetCursorPosition(60, 3);
                Console.WriteLine("Создайте направление");
            }
        }
    }

    class Train
    {
        private static int _roominessOfCarriages = 20;
        private List<Passanger> _fullTrain = new List<Passanger>();
        private List<Passanger> _сarriages = new List<Passanger>(_roominessOfCarriages);

        public int CountOfCarriages { get; private set; } = 0;

        public void FillATrain(int countOfPassengers)
        {
            while (countOfPassengers > 0)
            {
                CountOfCarriages++;

                while (countOfPassengers > 0 && _сarriages.Count < _сarriages.Capacity)
                {
                    _сarriages.Add(new Passanger());
                }
                countOfPassengers -= _сarriages.Count;
                _fullTrain.AddRange(_сarriages);
            }
        }

        public void ShowInfo()
        {
            Console.SetCursorPosition(60, 5);

            if (_fullTrain.Count > 0)
            {
                Console.WriteLine($"Поезд состоит из {CountOfCarriages} вагонов");
            }
            else
            {
                Console.WriteLine("Cформируйте поезд");
            }
        }
    }

    class Passanger
    {
        private int Money = 500; // { get; private set; } ;

        public void BuyATicket(int ticket)
        {
            Money -= ticket;
        }
    }
}
















