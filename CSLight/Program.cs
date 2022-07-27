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
            //Задание: Колода карт:       

            PlayingTable playingTable = new PlayingTable();
            playingTable.ShowMenu();
        }
    }

    class PlayingTable
    {
        private bool _isPlaying = true;
        private Player _player = new Player();
        private CardDeck _cardDeck = new CardDeck();

        public void ShowMenu()
        {
            _cardDeck.AddCard();

            while (_isPlaying)
            {
                int userNumber;
                Console.SetCursorPosition(45, 0);
                Console.WriteLine("Добро пожаловать за игральный стол");
                Console.WriteLine("Чтобы взять карты, нажмите 1\nЧтобы посмотреть взятые карты, нажмите 2\nЧтобы выйти, нажмите любую другую цифру");
                string userInput = Console.ReadLine();
                bool isSuccessfull = int.TryParse(userInput, out userNumber);
                Play(isSuccessfull, userNumber);
            }
        }

        private void Play(bool isSuccessfull, int userNumber)
        {
            if (_isPlaying == true)
            {
                if (userNumber == 1)
                {
                    TakeCards(isSuccessfull, userNumber);
                }
                else if (userNumber == 2)
                {
                    _player.ShowTakenCards();
                }
                else
                {
                    _isPlaying = false;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void TakeCards(bool isSuccessfull, int userNumber)
        {
            Console.WriteLine("Сколько карт вы хотите взять?");
            string userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out userNumber);

            if (isSuccessfull == true)
            {
                while (userNumber > 0)
                {
                    Card giveAwayCard = _cardDeck.GiveAwayCard(userNumber);
                    _player.TakeCard(giveAwayCard);
                    userNumber--;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
        }
    }

    class CardDeck
    {
        private List<Card> _cards = new List<Card>();
        private string[] _suits = { "Пик", "Черва", "Бубна", "Трефа" };
        private int[] _values = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public void AddCard()
        {
            for (int i = 0; i < _suits.Length; i++)
            {
                for (int j = 0; j < _values.Length; j++)
                {
                    _cards.Add(new Card(_suits[i], _values[j]));
                }
            }
        }

        public Card GiveAwayCard(int userNumber)
        {
            Card giveAwayCard = new Card("Отдаваемая карта", 0);
            if (userNumber <= _cards.Count)
            {
                giveAwayCard = _cards[0];
                _cards.RemoveAt(0);
            }
            return giveAwayCard;
        }
    }

    class Player
    {
        private List<Card> _takenCards = new List<Card>();

        public void TakeCard(Card giveAvayCard)
        {
            if (giveAvayCard.Suit != "Отдаваемая карта")
            {
                _takenCards.Add(giveAvayCard);
            }
        }

        public void ShowTakenCards()
        {
            Console.WriteLine("Вот список взятых карт:");

            for (int i = 0; i < _takenCards.Count; i++)
            {
                Console.WriteLine(_takenCards[i].Value + " " + _takenCards[i].Suit);
            }
        }
    }

    class Card
    {
        public string Suit { get; private set; }

        public int Value { get; private set; }

        public Card(string suit, int value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
















