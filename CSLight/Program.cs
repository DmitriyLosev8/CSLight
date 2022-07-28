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
            //Задание: Конфигуратор пассажирских поездов:   ДОРАБОТАТЬ

            //ManagerOfRailwayStation managerOfRailwayStation = new ManagerOfRailwayStation();
            //managerOfRailwayStation.ShowMenu();

            Carriage carriage = new Carriage();
            carriage.AddPassangers(123);

        }
    }

    class ManagerOfRailwayStation
    {
        private bool isWorking = true;
        private RailwayStation _railwayStation = new RailwayStation();
        private Train _train = new Train();
        private Direction _direction = new Direction("Направление",0);

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
                        _direction = _railwayStation.CreateADirection();
                        //ShowAllInfo();
                        break;
                    case 2:
                        _railwayStation.SellTickets(_direction);
                        //ShowAllInfo();
                        break;
                    case 3:
                        _railwayStation.FormATrain();
                        break;
                    case 4:
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

        public void ShowAllInfo()
        {
            _direction.ShowInfo();
            _railwayStation.ShowPassengers();
            _train.ShowInfo();
        }
    }

    class RailwayStation
    {
        public int CountOfPassengers { get; private set; }
        public bool isOnStation { get; private set; } = true;

        private int _minimalNumberOfPassengers = 10;
        private int _maximumNumberOfPassengers = 200;
        private int _minimalPriceOfTicket = 50;
        private int _maximumPriceOfTicket = 100;
        private int _money = 1000;
        private List<Passanger> _waitingHall = new List<Passanger>();

        public void SendTrain()
        {
            isOnStation = false;
        }

        public void GetReadyToSendAnotherTrain()
        {
            isOnStation = true;
        }


        public Direction CreateADirection()
        {
            Direction direction = new Direction("Направление", 0);

            if (isOnStation == true)
            {
                Random random = new Random();
                Console.WriteLine("Введите направление в формате: Город - Город:");
                string userDirection = Console.ReadLine();
                direction = new Direction(userDirection, random.Next(_minimalPriceOfTicket, _maximumPriceOfTicket));
            }
            else
            {
                Console.WriteLine("Направление уже создано, сформируйте поезд и отправьте его.");
            }
            return direction;
        }

        public void SellTickets(Direction direction)
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

        public void ShowPassengers()
        {
            Console.SetCursorPosition(60, 4);
            if (_waitingHall.Count > 0)
            {   
                Console.WriteLine("По этому направлению поедут " + _waitingHall.Count + " пассажиров");
            }
            else
            {
                Console.WriteLine("Продайте билеты");
            }  
        }
       
        public void FormATrain()
        {
            if(_waitingHall.Count > 0)
            {
                CountOfPassengers = _waitingHall.Count; 
                Train train = new Train();
                train.FillATrain(CountOfPassengers);
            }
            else
            {
                Console.WriteLine("Продайте сначала билеты.");
            }
           
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
            Console.SetCursorPosition(60, 3);
            Console.WriteLine($"Направление - {Title}, стоимость билета - {Ticket}");
            //Console.SetCursorPosition(0, 3);
        }
    }

    class Train
    {
        private List<Passanger> _fullTrain = new List<Passanger>();
        //private List<Passanger> _сarriages = new List<Passanger>(_roominessOfCarriages);
        private static int _roominessOfCarriages  = 20;

        public int CountOfCarriages { get; private set; } = 0; 

        private List<Passanger> AddPassangers(int countOfPassengers)
        {
            List<Passanger> _сarriages = new List<Passanger>(_roominessOfCarriages);
            while (countOfPassengers > 0)
            {
                _сarriages.Add(new Passanger());
                countOfPassengers--;
            }
            return _сarriages;
        }


        public void FillATrain(int countOfPassengers)
        {
            while (countOfPassengers > 0)
            {
                CountOfCarriages++;
                List<Passanger> _сarriages = new List<Passanger>(_roominessOfCarriages);
                _сarriages = AddPassangers(countOfPassengers);
                _fullTrain.AddRange(_сarriages);

                //Carriage carriage = new Carriage();
                //carriage.AddPassangers(countOfPassengers);
                //_fullTrain.Add(carriage);
                //countOfPassengers-= carriage.Roominess;
            }
        }

        public void ShowInfo()
        {
            Console.SetCursorPosition(60, 5);
            
            if (_fullTrain.Count > 0)
            {
                Console.WriteLine($"Поезд состоит из {_fullTrain.Count % _roominessOfCarriages} вагонов");
            }
            else
            {
                Console.WriteLine("Cформируйте поезд");
            }      
        }
    }

    //class Carriage
    //{
    //    public static int Roominess { get; private set; } = 20;
    //    private List<Passanger> _passangers = new List<Passanger>(Roominess);

    //public void AddPassangers(int countOfPassengers)
    //{
    //    while (countOfPassengers > 0)
    //    {
    //        _passangers.Add(new Passanger());
    //        //countOfPassengers--;
    //    }
    //}



    //}

    class Passanger
    {
        public int Money { get; private set; } = 500;

        public void BuyATicket(int ticket)
        {
            Money -= ticket;
        }
    }


}
















