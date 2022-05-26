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
            // домашнее задание картинки: у нас есть 52 картинке в альбоме, выводятся по 3 ряда, надо понять сколько полностью заполненных рядов можно будет вывести,
            // и сколько картинок будет сверх меры.

            int albumOfPictures = 52;
            int seriaOfPictures = 3;
            int fullSeriesOfPictures = albumOfPictures / seriaOfPictures;
            int extraPictures = albumOfPictures % seriaOfPictures;
            Console.WriteLine(fullSeriesOfPictures);
            Console.WriteLine(extraPictures);
            
        }
    }
}
