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
            //Задание: аквариум:        
            Aquarium aquarium = new Aquarium();
            aquarium.Work();
        }
    }

    class Aquarium
    {
        private int _maximumCounfOfFishes = 20;
        private List<Fish> _fishes = new List<Fish>();
        private bool _isWorking = true;

        public void Work()
        {  
            string userInput;
            string comandToAddFishes = "1";
            string comandToTakeOutFish = "2";
            string comandToExit = "3";

            while (_isWorking == true)
            {      
                ShowAllInfo();
                Console.WriteLine("Перед вами аквариум\n\nНажмите 1, чтобы добавить рыб\nНажмите 2, чтобы вытащить рыбу\nНажмите 3 , чтобы выйти");
                userInput = Console.ReadLine();

                if (userInput == comandToAddFishes)
                {
                    AddFishes();
                }
                else if (userInput == comandToTakeOutFish)
                {
                    TakeOutFish();
                }
                else if (userInput == comandToExit)
                {
                    _isWorking = false;
                }
                GrowOldOfFishes();
                DieFishes();
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void GrowOldOfFishes()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                _fishes[i].GrowOld();
            }
        }

        private void DieFishes()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].IsAlive == false)
                {
                    _fishes.RemoveAt(i);
                    i--;
                }
            }
        }

        private void ShowAllInfo()
        {
            Console.SetCursorPosition(0, 10);
            int correctNumber = 1;
            
            for (int i = 0; i < _fishes.Count; i++)
            {
                Console.Write((i + correctNumber) + " - ");
                _fishes[i].ShowInfo();
            }
            Console.SetCursorPosition(0, 0);
        }

        private void AddFishes()
        {
            int emptyPlases = _maximumCounfOfFishes - _fishes.Count;
            int countOfFishes;
            bool isSuccessfull;
            string userInput;
            Console.WriteLine("Сколько рыб вы хотите добавить?");
            userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out countOfFishes);

            if (isSuccessfull == true)
            {
                if (countOfFishes <= emptyPlases) 
                {
                    for (int i = 0; i < countOfFishes; i++)
                    {
                        string nameForFish = GiveName();
                        _fishes.Add(new Fish(nameForFish));
                        System.Threading.Thread.Sleep(150);
                    }
                }
                else
                {
                    Console.WriteLine("В аквариуме не хватает места, добавьте меньше рыб");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
        }

        private void TakeOutFish()
        {
            int correctNumber = 1;
            bool isSuccessfull;
            string userInput;
            int userNumber;
            Console.WriteLine("Введите номер рыбы, которую вы хотите забрать:");
            userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out userNumber);

            if (isSuccessfull == true)
            {
                _fishes.RemoveAt(userNumber - correctNumber);
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
        }

        private string GiveName()
        {
            string[] names = { "Егор", "Маша", "Киря", "Стёпа", "Саша", "Боря", "Жана", "Лена", "Женя", "Толя", "Настя", "Олег" };
            string nameForFish = "";
            Random random = new Random();
            int indexOfName;
            for (int i = 0; i < names.Length; i++)
            {
                indexOfName = random.Next(names.Length);
                nameForFish = names[indexOfName];
            }
            return nameForFish;
        }
    }

    class Fish
    {
        private string _name;
        private int _maximumAge;
        private int _years;

        public bool IsAlive { get; private set; }

        public Fish(string name)
        {
            int minimumYears = 14;
            int maximumYears = 21;
            _years = 0;
            IsAlive = true;
            _name = name;

            Random random = new Random();
            _maximumAge = random.Next(minimumYears, maximumYears);
        }

        public void GrowOld()
        {
            _years++;

            if (_years == _maximumAge)
            {
                Die();
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine(_name + " " + _years + " лет. ");
        }

        public void Die()
        {
            IsAlive = false;
        }
    }
}
















