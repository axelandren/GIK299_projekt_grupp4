using System.IO;

namespace GIK299_projekt_grupp4
{
    class WorldParser
    {
        public static string[,] ParseFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath); // skapar en array där varje rad i txt motsvarar ett index i arrayen
            string firstLine = lines[0]; // skapar en sträng av första raden i textdokumentet
            int rows = lines.Length;
            int cols = firstLine.Length;
            string[,] worldArray = new string[rows, cols]; // skapar en 2d array med bestämt antal rader och kolumner
            for (int row = 0; row < rows; row++) // loopar igenom alla rader och kolumner
            {
                string line = lines[row];
                for (int col = 0; col < cols; col++) // tar characters var o en för sig, en rad i taget från textdokumentet
                {
                    char currentChar = line[col];
                    worldArray[row, col] = currentChar.ToString(); // konverterar till string så att den kan användas i arrayen
                }
            }
            return worldArray;
        }
    }
}