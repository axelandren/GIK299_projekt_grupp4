using System;

namespace GIK299_projekt_grupp4
{
    public class Hero
    {
        private static string name;
        public int Col;
        public int Row;
        private string heroMarker;
        public int NumberOfKeys;
        public int Health;
        public Hero(int initialX, int initialY)
        {
            Col = initialX;
            Row = initialY;
            NumberOfKeys = 0;
            Health = 100;
            heroMarker = "O";
        }
        public static void SetHeroName()
        {
            Console.Write("\n\n\t\tName your hero: ");
            name = Console.ReadLine();
        }
        public string GetName()
        {
            return name;
        }
        public void DrawHero()
        {
            Console.SetCursorPosition(Col, Row);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(heroMarker);
            Console.ResetColor();
        }
    }
}