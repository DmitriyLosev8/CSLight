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
        {      //Задание: толковый словарь:    

            List<string> names = new List<string>();
            names.AddRange(new string[] { "Георгий", "Степан", "Фёдор", "Николай", "Сергей" });

            ShowingNumberOfWord(names);
        }

        static void ShowingNumberOfWord(List<string> names)
        {
            int correctUserInput = 1;
            string userInput;
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Напишите слово и мы покажем вам его номер");
                userInput = Console.ReadLine();

                if (names.Contains(userInput))
                {
                    Console.WriteLine("Вот номер вашего слова - " + (names.IndexOf(userInput) + correctUserInput));
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Такого слова нет, нажмите Enter, чтобы попробовать снова:");
                    Console.ReadKey();
                }
            }
        }
    }
}
