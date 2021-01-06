using System;

namespace GIK299_projekt_grupp4
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeConsoleFeatures();
            Game newGame = new Game();
            newGame.Menu();
        }
        private static void ChangeConsoleFeatures()
        {
            Console.Title = "Best Game In The World";
            Console.SetWindowSize(180, 60);
        }
    }
}