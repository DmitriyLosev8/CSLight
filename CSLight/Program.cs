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
            ShowingAmauntOfNumbers(numbers);
        }

        static void ShowingAmauntOfNumbers(List<int> numbers)
        {
            bool isWorking = true;
            int userInput;
            int amauntOfNumbers = 0;

            while (isWorking)
            {
                Console.WriteLine("Введите число и программа его запомнит:");
                userInput = Convert.ToInt32(Console.ReadLine());
                numbers.Add(userInput);
                Console.WriteLine("Нажмите  1, чтобы посмотреть сумму всех введённых вами чисел.\nНажмите 2 чтобы ввести ещё одно число.\nНажмитие 3,чтобы выйти.");
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        foreach (int number in numbers)
                        {
                            amauntOfNumbers += number;
                        }
                        Console.WriteLine(amauntOfNumbers);
                        break;
                    case 2:
                        break;
                    case 3:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}
