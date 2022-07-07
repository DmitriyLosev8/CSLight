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
        {      //Задание: объединение в одну коллекцию: 

            string[] chairs = { "1", "2", "3", "7", "10", "45" };
            string[] armchairs = { "4", "3", "5", "10", "18" };
            List<string> seats = new List<string>();
            seats.AddRange(chairs);
            seats.AddRange(armchairs);

            SearchAndDeleteRepeatingStrings(seats);
            ShowingAllUniqueSeats(seats);
        }

        static void SearchAndDeleteRepeatingStrings(List<string> seats)
        {
            List<string> tempSeats = seats;
            tempSeats.Sort();

            for (int i = 1; i < tempSeats.Count; i++)
            {
                if (tempSeats[i - 1] == tempSeats[i])
                {
                    seats.Remove(tempSeats[i]);
                }
            }
        }

        static void ShowingAllUniqueSeats(List<string> seats)
        {
            for (int i = 0; i < seats.Count; i++)
            {
                Console.WriteLine(seats[i]);

            }
        }
    }
}
