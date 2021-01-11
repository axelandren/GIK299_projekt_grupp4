using System;

namespace GIK299_projekt_grupp4
{
    public class Enemy
    {
        private string enemyMarker;
        public int[][] ColPosition = new int[10][];
        public int[][] RowPosition = new int[10][];
        public bool[][] AliveOrDead = new bool[10][];
        public int[,] RoomColIndex = new int[10, 2] {
            { 46, 62 }, { 19, 35 }, { 10, 26 }, { 55, 71 }, { 64, 89 }, { 28, 53 }, { 55, 71 }, { 46, 62 }, { 37, 53 }, { 73, 89 } };
        public int[,] RoomRowIndex = new int[10, 2] {
            { 41, 44 }, { 36, 39 }, { 31, 34 }, { 31, 34 }, { 26, 29 }, { 21, 24 }, { 16, 19 }, { 11, 14 }, { 6, 9 }, { 1, 4 } };
        public Enemy()
        {
            enemyMarker = "E";
            GetEnemyPositions();
            LifeState();
        }
        // Fienderums index: 1(41, 45-46, 62) 2(36, 39-19, 35) 3(31, 34-10, 26) 4(31, 34-55, 71) 5(26, 29-64, 89)
        // 6(21, 24-28, 53) 7(16, 19-55, 71) 8(11, 14-46, 62) 9(6, 9-37, 53) 10(1, 4-73, 89)
        // rum(minRow, maxRow-minCol, maxCol)
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
                    ColPosition[i][j] = rand.Next(RoomColIndex[i, 0], RoomColIndex[i, 1] + 1);
                    RowPosition[i][j] = rand.Next(RoomRowIndex[i, 0], RoomRowIndex[i, 1] + 1);
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