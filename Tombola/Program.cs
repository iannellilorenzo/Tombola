using System;
using System.Numerics;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        // dichiarazione variabili
        int righeCart = 3, colonneCart = 9, righeTab = 9, colonneTab = 10;
        int min = 1, max = 9, numTab = 1, index = 0;
        int xTab = 45, yTab = 1, xCart1 = 7, yCart1 = 12, xCart2 = 77, yCart2 = 12;
        int colonneIndex = 0;
        char dec = '0';

        // dichiarazione matrici
        int[,] tabellone = new int[righeTab, colonneTab];
        int[,] cartella1 = new int[righeCart, colonneCart];
        int[,] cartella2 = new int[righeCart, colonneCart];

        // invoco funzione di stampa del tabellone
        tab(tabellone, righeTab, colonneTab, xTab, yTab, numTab);

        // invoco funzione di stampa della cartella giocatore 1
        cart1(cartella1, righeCart, colonneCart, xCart1, yCart1, min, max, index, colonneIndex, dec);

        // invoco funzione di stampa della cartella giocatore 2
        cart2(cartella2, righeCart, colonneCart, xCart2, yCart2, min, max);

        Console.ReadKey();
    }

    // funzione stampa tabellone
    static void tab(int[,] tabellone, int righeTab, int colonneTab, int xTab, int yTab, int numTab)
    {
        Console.SetCursorPosition(55, 0);
        Console.WriteLine("Tabellone");
        for (int i = 0; i < righeTab; i++)
        {
            Console.WriteLine();
            Console.SetCursorPosition(xTab, yTab);
            for (int j = 0; j < colonneTab; j++)
            {
                tabellone[i, j] = numTab;
                Console.Write(tabellone[i, j].ToString("D2") + " ");
                numTab++;
            }
            yTab++;
        }
    }

    // funzione di stampa cartella giocatore 1
    static void cart1(int[,] cartella1, int righeCart, int colonneCart, int xCart1, int yCart1, int min, int max, int index, int colonneIndex, char dec)
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
                cartella1[i, colonneIndex] = random.Next(min, max + 1);
                index++;
                if (cartella1[i, colonneIndex].ToString("D2")[0] == dec || index < 3)
                {
                    Console.SetCursorPosition(xCart1, yCart1++);
                    Console.WriteLine(cartella1[i, colonneIndex].ToString("D2"));
                }
                dec++;
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
}