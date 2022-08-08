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
            //Задание: зоопарк:   

            Zoo zoo = new Zoo();
            zoo.ShowMenu();
        }
    }

    class Zoo
    {
        private Dogs _dogs = new Dogs("В этом вольере живут собаки", 20, "Мужской", "Гав", "Собаки");
        private Ducks _ducks = new Ducks("В этом вольере живут утки", 30, "Женский", "Кря", "Утки");
        private Goats _goats = new Goats("В этом вольере живут козлы", 15, "Мужской", "Бее", "Козлы");
        private Rabbits _rabbits = new Rabbits("В этом вольере живут кролики", 50, "Женский", "Фырк", "Кролики");
        private bool _isWorking = true;

        public void ShowMenu()
        {
            while (_isWorking == true)
            {
                string userInput;
                bool isSuccessfull;
                int userNumber;
                Console.WriteLine($"Добро пожаловать в зоопарк\nЧтобы подойти к вольеру {_dogs.Name}, нажмите 1\nЧтобы подойти к вольеру {_ducks.Name}, нажмите 2\n" +
                    $"Чтобы подойти к вольеру {_goats.Name}, нажмите 3\nЧтобы подойти к вольеру {_rabbits.Name}, нажмите 4\nЧтобы выйти, нажмите 5");
                userInput = Console.ReadLine();
                isSuccessfull = int.TryParse(userInput, out userNumber);
                PickAnAviary(isSuccessfull, userNumber);
            }
        }

        private void PickAnAviary(bool isSuccessfull, int userNumber)
        {
            if (isSuccessfull == true)
            {
                switch (userNumber)
                {
                    case 1:
                        _dogs.ShowInfo();
                        break;
                    case 2:
                        _ducks.ShowInfo();
                        break;
                    case 3:
                        _goats.ShowInfo();
                        break;
                    case 4:
                        _rabbits.ShowInfo();
                        break;
                    case 5:
                        _isWorking = false;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }

    abstract class Aviary
    {
        protected string Description;
        protected int CountOfAmimals;
        protected string GenderOfAmimals;
        protected string SoundOfAmimals;

        public string Name { get; protected set; }

        public Aviary(string description, int countOfAmimals, string genderOfAmimals, string soundOfAmimals, string name)
        {
            Description = description;
            CountOfAmimals = countOfAmimals;
            GenderOfAmimals = genderOfAmimals;
            SoundOfAmimals = soundOfAmimals;
            Name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Вот вся информация по этому вольеру:");
            Console.WriteLine($"{Description} в колличестве {CountOfAmimals} штук, у всех {GenderOfAmimals} пол, а их издаваемый звук - {SoundOfAmimals}");
        }
    }

    class Dogs : Aviary
    {
        public Dogs(string description, int countOfAmimals, string genderOfAmimals, string soundOfAmimals, string name) : base(description, countOfAmimals, genderOfAmimals, soundOfAmimals, name)
        {
            Description = description;
            CountOfAmimals = countOfAmimals;
            GenderOfAmimals = genderOfAmimals;
            SoundOfAmimals = soundOfAmimals;
            Name = name;
        }
    }

    class Ducks : Aviary
    {
        public Ducks(string description, int countOfAmimals, string genderOfAmimals, string soundOfAmimals, string name) : base(description, countOfAmimals, genderOfAmimals, soundOfAmimals, name)
        {
            Description = description;
            CountOfAmimals = countOfAmimals;
            GenderOfAmimals = genderOfAmimals;
            SoundOfAmimals = soundOfAmimals;
            Name = name;
        }
    }

    class Goats : Aviary
    {
        public Goats(string description, int countOfAmimals, string genderOfAmimals, string soundOfAmimals, string name) : base(description, countOfAmimals, genderOfAmimals, soundOfAmimals, name)
        {
            Description = description;
            CountOfAmimals = countOfAmimals;
            GenderOfAmimals = genderOfAmimals;
            SoundOfAmimals = soundOfAmimals;
            Name = name;
        }
    }

    class Rabbits : Aviary
    {
        public Rabbits(string description, int countOfAmimals, string genderOfAmimals, string soundOfAmimals, string name) : base(description, countOfAmimals, genderOfAmimals, soundOfAmimals, name)
        {
            Description = description;
            CountOfAmimals = countOfAmimals;
            GenderOfAmimals = genderOfAmimals;
            SoundOfAmimals = soundOfAmimals;
            Name = name;
        }
    }
}
















