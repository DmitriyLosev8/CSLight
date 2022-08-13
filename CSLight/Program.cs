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
            aquarium.Observe();
        }
    }

    class Aquarium
    {
        static private int _maximumCounfOfFishes = 20;
        private List<Fish> _fishes = new List<Fish>(_maximumCounfOfFishes);
        private string[] _names = { "Егор", "Маша", "Киря", "Стёпа", "Саша", "Боря", "Жана", "Лена", "Женя", "Толя", "Настя", "Олег" };
        private string _nameForFish;
        private bool _isWorking = true;
        private int _countOfFishes;
        private int _correctNumber = 1;
        private int _emptyPlases = 20;

        public void Observe()
        {
            bool isSuccessfull;
            string userInput;
            int userNumber;

            while (_isWorking == true)
            {
                ShowAllInfo();
                Console.WriteLine("Перед вами аквариум\n\nНажмите 1, чтобы добавить рыб\nНажмите 2, чтобы вытащить рыбу\nНажмите любую другую цифру, чтобы выйти");
                userInput = Console.ReadLine();
                isSuccessfull = int.TryParse(userInput, out userNumber);

                if (isSuccessfull == true)
                {
                    if (userNumber == 1)
                    {
                        AddFishes();
                    }
                    else if (userNumber == 2)
                    {
                        TakeFish();
                    }
                    else
                    {
                        _isWorking = false;
                    }
                }
                GrowOldOfFishes();
                DieingFishes();
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void GrowOldOfFishes()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                _fishes[i].GrowOld();
                _fishes[i].Die();
            }
        }

        private void DieingFishes()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].IsAlive == false)
                {
                    _fishes.RemoveAt(i);
                    _emptyPlases++;
                }
            }
        }
       
        private void ShowAllInfo()
        {
            Console.SetCursorPosition(65, 0);
            Console.WriteLine("Колличество свободных мест в аквариуме - " + _emptyPlases);
            Console.SetCursorPosition(0, 10);

            for (int i = 0; i < _fishes.Count; i++)
            {
                Console.Write((i + _correctNumber) + " - ");
                _fishes[i].ShowInfo();
            }
            Console.SetCursorPosition(0, 0);
        }

        private void AddFishes()
        {
            bool isSuccessfull;
            string userInput;
            Console.WriteLine("Сколько рыб вы хотите добавить?");
            userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out _countOfFishes);

            if (isSuccessfull == true)
            {
                if (_countOfFishes <= _maximumCounfOfFishes && _countOfFishes <= _emptyPlases)
                {
                    for (int i = 0; i < _countOfFishes; i++)
                    {
                        GiveName();
                        _fishes.Add(new Fish(_nameForFish));
                        _emptyPlases = _maximumCounfOfFishes - _fishes.Count;
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

        private void TakeFish()
        {
            bool isSuccessfull;
            string userInput;
            int userNumber;
            Console.WriteLine("Введите номер рыбы, которую вы хотите забрать:");
            userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out userNumber);

            if (isSuccessfull == true)
            {
                _fishes.RemoveAt(userNumber - _correctNumber);
                _emptyPlases++;
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
        }

        private void GiveName()
        {
            Random random = new Random();
            int indexOfName;
            for (int i = 0; i < _names.Length; i++)
            {
                indexOfName = random.Next(_names.Length);
                _nameForFish = _names[indexOfName];
            }
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
        }

        public void ShowInfo()
        {
            Console.WriteLine(_name + " " + _years + " лет. ");
        }

        public void Die()
        {
            if (_years == _maximumAge)
            {
                IsAlive = false;
            }
        }
    }
}
















