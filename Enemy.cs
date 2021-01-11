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
            { 46, 63 }, { 19, 36 }, { 10, 27 }, { 55, 72 }, { 64, 90 }, { 28, 54 }, { 55, 72 }, { 46, 63 }, { 37, 54 }, { 73, 90 } };
        public int[,] RoomRowIndex = new int[10, 2] {
            { 41, 45 }, { 36, 40 }, { 31, 35 }, { 31, 35 }, { 26, 30 }, { 21, 25 }, { 16, 20 }, { 11, 15 }, { 6, 10 }, { 1, 5 } };
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
                    ColPosition[i][j] = rand.Next(RoomColIndex[i, 0], RoomColIndex[i, 1]);
                    RowPosition[i][j] = rand.Next(RoomRowIndex[i, 0], RoomRowIndex[i, 1]);
                    // if (i == 0)
                    // {
                    //     ColPosition[i][j] = rand.Next(enemyRoomColIndex[j, 0], enemyRoomColIndex[j, 1]);
                    //     RowPosition[i][j] = rand.Next(enemyRoomRowIndex[j, 0], enemyRoomRowIndex[j, 1]);
                    // }
                    // else if (i == 1)
                    // {

                    //     ColPosition[i][j] = rand.Next(19, 36);
                    //     RowPosition[i][j] = rand.Next(36, 40);
                    // }
                    // else if (i == 2)
                    // {
                    //     ColPosition[i][j] = rand.Next(10, 27);
                    //     RowPosition[i][j] = rand.Next(31, 35);
                    // }
                    // else if (i == 3)
                    // {
                    //     ColPosition[i][j] = rand.Next(55, 72);
                    //     RowPosition[i][j] = rand.Next(31, 35);
                    // }
                    // else if (i == 4)
                    // {
                    //     ColPosition[i][j] = rand.Next(64, 90);
                    //     RowPosition[i][j] = rand.Next(26, 30);
                    // }
                    // else if (i == 5)
                    // {
                    //     ColPosition[i][j] = rand.Next(28, 54);
                    //     RowPosition[i][j] = rand.Next(21, 25);
                    // }
                    // else if (i == 6)
                    // {
                    //     ColPosition[i][j] = rand.Next(55, 72);
                    //     RowPosition[i][j] = rand.Next(16, 20);
                    // }
                    // else if (i == 7)
                    // {
                    //     ColPosition[i][j] = rand.Next(46, 63);
                    //     RowPosition[i][j] = rand.Next(11, 15);
                    // }
                    // else if (i == 8)
                    // {
                    //     ColPosition[i][j] = rand.Next(37, 54);
                    //     RowPosition[i][j] = rand.Next(6, 10);
                    // }
                    // else if (i == 9)
                    // {
                    //     ColPosition[i][j] = rand.Next(73, 90);
                    //     RowPosition[i][j] = rand.Next(1, 5);
                    // }
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