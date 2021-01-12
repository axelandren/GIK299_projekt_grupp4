using System;

namespace GIK299_projekt_grupp4
{
    public class World
    {
        private static string[,] map;
        private int rows;
        private int cols;
        private string keyMarker;
        public World()
        {
            map = WorldParser.ParseFileToArray("WorldDrawing.txt");
            rows = map.GetLength(0);
            cols = map.GetLength(1);
            keyMarker = "K";
            GenerateAndPlaceKeys();
        }
        public void DrawWorld()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (map[i, j] == "K")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("{0}", map[i, j]);
                        Console.ResetColor();
                    }
                    else if (map[i, j] == "E")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0}", map[i, j]);
                        Console.ResetColor();
                    }
                    else if (map[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0}", map[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0}", map[i, j]);
                    }
                }
                Console.Write("\n");
            }
        }
        public void GenerateAndPlaceKeys()
        {
            Random rand = new Random();
            for (int i = 0; i < 10;)
            {
                int row = rand.Next(1, rows - 4);
                int col = rand.Next(1, cols - 1);
                if (map[row, col] == " ")
                {
                    map[row, col] = keyMarker;
                    i++;
                }
            }
        }
        public string GetStringAt(int x, int y)
        {
            return map[y, x];
        }
        public static void ChangeStringToEmpty(int x, int y)
        {
            map[y, x] = " ";
        }
        public static void ChangeStringToHero(int x, int y)
        {
            map[y, x] = Hero.HeroMarker;
        }
        public static void ChangeStringToEnemy(int x, int y)
        {
            map[y, x] = Enemy.EnemyMarker;
        }
        public bool IsWalkable(int col, int row)
        {
            if (col < 0 || row < 0 || col >= cols || row >= rows)
            {
                return false;
            }
            return map[row, col] == " " || map[row, col] == "F" || map[row, col] == "K";
        }
    }
}