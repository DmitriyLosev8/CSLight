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
            //Задание: Shuffle:

            int[] array = { 2, 6, 9, 4, 5, 6, 7, 3, 1, 9, 8, 5 };
            ShuffleElements(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine();
        }

        static void ShuffleElements(int[] array)
        {
            int randomElement;
            int elementNumber;
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                randomElement = random.Next(i);
                elementNumber = array[i];
                array[i] = array[randomElement];
                array[randomElement] = elementNumber;
            } 
        }
    }
}
