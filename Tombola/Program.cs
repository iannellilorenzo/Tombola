using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        // dichiarazione variabili
        int righeCart = 3, colonneCart = 5, righeTab = 8, colonneTab = 10;
        int min = 1, max = 90;
        int xTab = 50, yTab = 1, xCart1 = 15, yCart1 = 11, xCart2 = 85, yCart2 = 11;

        // dichiarazione matrici
        int[,] tabellone = new int[righeTab, colonneTab];
        int[,] cartella1 = new int[righeCart, colonneCart];
        int[,] cartella2 = new int[righeCart, colonneCart];

        // random
        Random random = new Random();

        // stampa tabellone
        Console.SetCursorPosition(55, 0);
        Console.WriteLine("Tabellone");
        for (int i = 0; i < righeTab; i++)
        {
            Console.WriteLine();
            Console.SetCursorPosition(xTab, yTab);
            for (int j = 0; j < colonneTab; j++)
            {
                Console.Write(tabellone[i, j].ToString() + " ");
            }
            yTab++;
        }

        // stampa cartella1
        Console.SetCursorPosition(14, 10);
        Console.WriteLine("Cartella giocatore 1");
        for (int i = 0; i < righeCart; i++)
        {
            Console.WriteLine();
            Console.SetCursorPosition(xCart1, yCart1);
            for (int j = 0; j < colonneCart; j++)
            {
                cartella1[i, j] = random.Next(min, max + 1);
                Console.Write(cartella1[i, j].ToString("D2") + "  ");
            }
            yCart1++;
        }

        // stampa cartella2
        Console.SetCursorPosition(84, 10);
        Console.WriteLine("Cartella giocatore 2");
        for (int i = 0; i < righeCart; i++)
        {
            Console.WriteLine();
            Console.SetCursorPosition(xCart2, yCart2);
            for (int j = 0; j < colonneCart; j++)
            {
                cartella2[i, j] = random.Next(min, max + 1);
                Console.Write(cartella2[i, j].ToString("D2") + "  ");
            }
            yCart2++;
        }

        Console.ReadKey();
    }
}