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
        {      //Задание: Динамический массив продвинутый:    

            List<int> numbers = new List<int>();
            PerformOperationsWithNumbers(numbers);
        }

        static void PerformOperationsWithNumbers(List<int> numbers)
        {
            bool isWorking = true;
            string userInput;

            while (isWorking)
            {
                Console.WriteLine("Нажмите  английскую букву s, чтобы посмотреть сумму всех введённых вами чисел.\nНажмите английскую букву c чтобы ввести  число." +
                    "\nНажмитие английскую букву e,чтобы выйти.");
                userInput = (Console.ReadLine());

                switch (userInput)
                {
                    case "s":
                        ShowSumNumbers(numbers);
                        break;
                    case "c":
                        AddNumbers(numbers, out userInput);
                        break;
                    case "e":
                        isWorking = false;
                        break;
                }
            }
        }

        static void AddNumbers(List<int> numbers, out string userInput)
        {
            bool isSuccessfull;
            int inputedNumber;
            Console.WriteLine("Введите число и программа его запомнит:");
            userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out inputedNumber);

            if (isSuccessfull == false)
            {
                Console.WriteLine("Вы ввели не число:");
            }

            numbers.Add(inputedNumber);
        }

        static void ShowSumNumbers(List<int> numbers)
        {
            int amauntOfNumbers = 0;
            foreach (int number in numbers)
            {
                amauntOfNumbers += number;
            }
            Console.WriteLine(amauntOfNumbers);
        }
    }
}
