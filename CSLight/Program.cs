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
    }

    class CardDeck
    {
        private List<Card> _cards = new List<Card>();

        public void AddCard()
        {
            _cards.AddRange(new Card[] {new("6 пик"), new("7 пик"), new("8 пик"), new("9 пик"), new("10 пик"), new("валет пик"), new("дама пик"),new("король пик"),new("туз пик"),
            new("6 черва"), new("7 черва"), new("8 черва"), new("9 черва"), new("10 черва"), new("валет черва"), new("дама черва"),new("король черва"),new("туз черва"),
            new("6 трефа"), new("7 трефа"), new("8 трефа"), new("9 трефа"), new("10 трефа"), new("валет трефа"), new("дама трефа"),new("король трефа"),new("туз трефа"),
            new("6 бубна"), new("7 бубна"), new("8 бубна"), new("9 бубна"), new("10 бубна"), new("валет бубна"), new("дама бубна"),new("король бубна"),new("туз бубна"),});
        }

        public Card GiveAwayCard(int userNumber)
        {
            Card giveAwayCard = new Card("Отдаваемая карта");
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
            if (giveAvayCard.Title != "Отдаваемая карта")
            {
                _takenCards.Add(giveAvayCard);
            }
        }

        public void ShowTakenCards()
        {
            Console.WriteLine("Вот список взятых карт:");

            for (int i = 0; i < _takenCards.Count; i++)
            {
                Console.WriteLine(_takenCards[i].Title);
            }
        }
    }

    class Card
    {
        public string Title { get; private set; }

        public Card(string title)
        {
            Title = title;
        }
    }
}
















