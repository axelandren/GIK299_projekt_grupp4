using System;

namespace GIK299_projekt_grupp4
{
    public class Hero
    {
        private static string name;
        public static string HeroMarker;
        public int Col;
        public int Row;
        public int NumberOfKeys;
        public int Health;
        public Hero(int initialX, int initialY)
        {
            Col = initialX;
            Row = initialY;
            NumberOfKeys = 0;
            Health = 100;
            HeroMarker = "O";
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
    }
}