using System;

namespace GIK299_projekt_grupp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Best Game In The World";
            Game newGame = new Game();
            newGame.Menu();
        }
    }
}