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
        {      // Задание: работа со свойствами:

            Player player = new Player(15, 15,'@');
            Renderer renderer = new Renderer();
            renderer.DrawPlayer(player.CoorditateX, player.CoorditateY,player.Character);
        }
    }

    class Player
    {
        public int CoorditateX { get; private set; }
        public int CoorditateY { get; private set; }
        public char Character { get; private set; }

        public Player(int coorditateX, int coorditateY, char character)
        {
            CoorditateX = coorditateX;
            CoorditateY = coorditateY;
            Character = character;
        }
    }

    class Renderer
    {
        public void DrawPlayer(int coorditateX, int coorditateY, char character)
        {
            Console.SetCursorPosition(coorditateX, coorditateY);
            Console.CursorVisible = false;
            Console.WriteLine(character);
        }
    }
}












