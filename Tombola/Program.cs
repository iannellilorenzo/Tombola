using System;
using System.Numerics;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        // dichiarazione variabili
        int righeCart = 3, colonneCart = 9, righeTab = 9, colonneTab = 10;
        int min = 1, max = 90, numTab = 1;
        int xTab = 45, yTab = 1, xCart1 = 7, yCart1 = 12, xCart2 = 77, yCart2 = 12;
        int estraz = 0;

        // dichiarazione array
        bool[] array = new bool[90];

        // dichiarazione matrici
        int[,] tabellone = new int[righeTab, colonneTab];
        int[,] cartella1 = new int[righeCart, colonneCart];
        int[,] cartella2 = new int[righeCart, colonneCart];

        // coordinate del cursore + colore carattere rosso
        Console.SetCursorPosition(55, 0);
        Console.WriteLine("Tabellone");
        Console.ForegroundColor = ConsoleColor.Red;

        // invoco funzione di stampa del tabellone
        tab(tabellone, righeTab, colonneTab, xTab, yTab, numTab);

        // colore carrattere bianco (cartella1 e cartella2)
        Console.ForegroundColor = ConsoleColor.White;

        // invoco funzione di stampa della cartella giocatore 1
        cart1(cartella1, righeCart, colonneCart, xCart1, yCart1, min, max);

        // invoco funzione di stampa della cartella giocatore 2
        cart2(cartella2, righeCart, colonneCart, xCart2, yCart2, min, max);

        for (int i = 0; i < 90; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(estrazione(array, min, max) + " ");
        }



        //Console.WriteLine("\n\n" + estrazione(array, min, max)); // test per capire cosa stampa

        Console.ReadKey();
    }

    // funzione stampa tabellone
    static void tab(int[,] tabellone, int righeTab, int colonneTab, int xTab, int yTab, int numTab)
    {
        for (int i = 0; i < righeTab; i++)
        {
            Console.WriteLine();
            Console.SetCursorPosition(xTab, yTab);
            for (int j = 0; j < colonneTab; j++)
            {
                tabellone[i, j] = numTab++;
                Console.Write(tabellone[i, j].ToString("D2") + " ");
            }
            yTab++;
        }
    }

    // funzione di stampa cartella giocatore 1
    static void cart1(int[,] cartella1, int righeCart, int colonneCart, int xCart1, int yCart1, int min, int max)
    {
        Random random = new Random();
        Console.SetCursorPosition(14, 11);
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
    }

    // funzione di stampa cartella giocatore 2
    static void cart2(int[,] cartella2, int righeCart, int colonneCart, int xCart2, int yCart2, int min, int max)
    {
        Random random = new Random();
        Console.SetCursorPosition(84, 11);
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
    }

    // funzione estrazione dei numeri
    static int estrazione(bool[] array, int min, int max)
    {
        int numEstratto;
        Random random = new Random();

        do
        {
            numEstratto = random.Next(min, max + 1);
        } while (array[numEstratto - 1] == true);

        array[numEstratto - 1] = true;

        return numEstratto;
    }
}