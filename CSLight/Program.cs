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
            //Задание: Магазин:       

            Shop shop = new Shop();
            shop.ShowMenu();
        }
    }

    class Shop
    {
        private bool _isWorking = true;
        private Seller _seller = new Seller();
        private Client _client = new Client();

        public void ShowMenu()
        {
            _seller.AddProducts();

            while (_isWorking)
            {
                int inputedNumber;
                Console.SetCursorPosition(45, 0);
                Console.WriteLine("Добро пожаловать в магазин");
                _seller.ShowProducts();
                Console.SetCursorPosition(45, 10);
                Console.WriteLine("Чтобы купить товар, нажмите 1");
                Console.SetCursorPosition(45, 11);
                Console.WriteLine("Чтобы посмотреть купленные товары, нажмите 2");
                Console.SetCursorPosition(45, 12);
                Console.WriteLine("Чтобы выйти, нажмите любую другую цифру");
                string userTitle = Console.ReadLine();
                bool isSuccessfull = int.TryParse(userTitle, out inputedNumber);
                PickAProduct(isSuccessfull, inputedNumber);
            }
        }

        private void PickAProduct(bool isSuccessfull, int inputedNumber)
        {
            if (isSuccessfull == true)
            {
                if (inputedNumber == 1)
                {
                    Console.WriteLine("Введите название товара, который вы хотите купить");
                    string userTitle = Console.ReadLine();
                    MakeADeal(userTitle);
                }
                else if (inputedNumber == 2)
                {
                    _client.ShowProducts();
                }
                else
                {
                    _isWorking = false;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void MakeADeal(string userTitle)
        {
            Product ProductToSale = _seller.Sale(userTitle);
            _client.Purchase(ProductToSale);
        }
    }

    class ParticipantOFDeal
    {
        protected List<Product> Products = new List<Product>();
        protected int Money = 1000;

        public virtual void ShowProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.Write(i + 1 + " ");
                Console.WriteLine(Products[i].Title + " стоит - " + Products[i].Price);
            }
        }
    }

    class Client : ParticipantOFDeal
    {
        public void Purchase(Product ProductToSale)
        {
            if (ProductToSale.Title != "Товар на продажу")
            {
                Money -= ProductToSale.Price;
                Products.Add(new Product(ProductToSale.Title, ProductToSale.Price));
            }
            else
            {
                Console.WriteLine("Такого товара нет.");
            }
        }

        public override void ShowProducts()
        {
            Console.WriteLine("Денег у клиента - " + Money + "\n\n");
            Console.WriteLine("Вот список всех купленных товаров:\n");
            base.ShowProducts();
        }
    }

    class Seller : ParticipantOFDeal
    {
        public Product Sale(string userTitle)
        {
            Product ProductToSale = new Product("Товар на продажу", 0);

            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Title == userTitle)
                {
                    Money += Products[i].Price;
                    ProductToSale = Products[i];
                    Products.RemoveAt(i);
                }
            }
            return ProductToSale;
        }

        public override void ShowProducts()
        {
            Console.WriteLine("Денег у продавца - " + Money + "\n\n");
            Console.WriteLine("Вот список всех товаров продавца:\n");
            base.ShowProducts();
        }

        public void AddProducts()
        {
            Products.Add(new Product("Сахар", 50));
            Products.Add(new Product("Масло", 70));
            Products.Add(new Product("Мука", 40));
            Products.Add(new Product("Соль", 20));
            Products.Add(new Product("Греча", 75));
        }
    }

    class Product
    {
        public string Title { get; private set; }
        public int Price { get; private set; }

        public Product(string title, int price)
        {
            Title = title;
            Price = price;
        }
    }
}
















