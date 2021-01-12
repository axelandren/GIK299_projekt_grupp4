using System;

namespace GIK299_projekt_grupp4
{
    public class Enemy
    {
        private string enemyMarker;
        public int[][] ColPosition = new int[10][];
        public int[][] RowPosition = new int[10][];
        public bool[][] AliveOrDead = new bool[10][];
        public int[,] RoomCol = new int[10, 2] {
            { 46, 62 }, { 19, 35 }, { 10, 26 }, { 55, 71 }, { 64, 89 }, { 28, 53 }, { 55, 71 }, { 46, 62 }, { 37, 53 }, { 73, 89 } };
        public int[,] RoomRow = new int[10, 2] {
            { 33, 35 }, { 29, 31 }, { 25, 27 }, { 25, 27 }, { 21, 23 }, { 17, 19 }, { 13, 15 }, { 9, 11 }, { 5, 7 }, { 1, 3 } };
        public Enemy()
        {
            enemyMarker = "E";
            GetEnemyPositions();
            LifeState();
        }
        private void GetEnemyPositions()
        {
            Random rand = new Random();
            int amountOfEnemiesInRoom;
            for (int k = 0; k < ColPosition.Length; k++)
            {
                amountOfEnemiesInRoom = rand.Next(1, 4);
                ColPosition[k] = new int[amountOfEnemiesInRoom];
                RowPosition[k] = new int[amountOfEnemiesInRoom];
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < ColPosition[i].Length; j++)
                {
                    ColPosition[i][j] = rand.Next(RoomCol[i, 0], RoomCol[i, 1] + 1);
                    RowPosition[i][j] = rand.Next(RoomRow[i, 0], RoomRow[i, 1] + 1);
                }
            }
        }
        public void DrawEnemies()
        {
            for (int i = 0; i < ColPosition.Length; i++)
            {
                for (int j = 0; j < ColPosition[i].Length; j++)
                {
                    if (AliveOrDead[i][j] == true)
                    {
                        Console.SetCursorPosition(ColPosition[i][j], RowPosition[i][j]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(enemyMarker);
                        Console.ResetColor();
                    }
                }
            }
        }
        public void LifeState()
        {
            for (int i = 0; i < AliveOrDead.Length; i++)
            {
                AliveOrDead[i] = new bool[ColPosition[i].Length];
                for (int j = 0; j < ColPosition[i].Length; j++)
                {
                    AliveOrDead[i][j] = true;
                }
            }
        }
    }
}