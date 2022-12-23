using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        // dichiarazione
        int righe = 3, colonne = 5, min = 1, max = 90, xT = 20, yT = 10, xC1 = 20, yC1 = 20;
        int[,] tabellone = new int[10, 10];
        int[,] cartella1 = new int[righe, colonne];
        int[,] cartella2 = new int[righe, colonne];
        Random random = new Random();

        // set del cursore tabellone

        for (int i = 0; i < 10; i++)
        {
            Console.SetCursorPosition(xT, yT);
            Console.WriteLine();
            for (int j = 0; j < 8; j++)
            {
                Console.Write(tabellone[i, j]);
            }
            xT++;
            yT++;
        }

        // generazione cartella1
        for (int i = 0; i < righe; i++)
        {
            Console.SetCursorPosition(xC1, yC1);
            Console.WriteLine();
            for (int j = 0; j < colonne; j++)
            {
                cartella1[i, j] = random.Next(min, max + 1);
                Console.Write(cartella1[i, j].ToString("D2") + "  ");
            }
            xC1++; yC1++;
        }

        Console.ReadKey();
    }
}