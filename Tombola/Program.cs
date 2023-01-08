using System;
using System.Numerics;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {

        // Dichiarazione variabili
        int righeCart = 3, colonneCart = 9, righeTab = 9, colonneTab = 10;
        int min = 1, max = 90, numTab = 1;
        int xTab = 45, yTab = 1, xCart1 = 7, yCart1 = 12, xCart2 = 77, yCart2 = 12, xEstraz = 0, yEstraz = 0;
        int estraz = 0, xT = 0, yT = 0, lamp = 50;

        // Dichiarazione matrici
        int[,] tabellone = new int[righeTab, colonneTab];
        int[,] cartella1 = new int[righeCart, colonneCart];
        int[,] cartella2 = new int[righeCart, colonneCart];

        // Coordinate del cursore + colore carattere rosso
        Console.SetCursorPosition(55, 0);
        Console.WriteLine("Tabellone");
        Console.ForegroundColor = ConsoleColor.Red;

        // Invoco funzione di stampa del tabellone
        tab(tabellone, righeTab, colonneTab, xTab, yTab, numTab);

        // Colore carrattere bianco (cartella1 e cartella2)
        Console.ForegroundColor = ConsoleColor.White;

        // Invoco funzione di generazione della cartella giocatore 1
        genCart1(cartella1, min, max);

        // Invoco funzione di stampa della cartella giocatore 1
        cart1(cartella1, righeCart, colonneCart, xCart1, yCart1, min, max);

        // Invoco funzione di stampa della cartella giocatore 2
        cart2(cartella2, righeCart, colonneCart, xCart2, yCart2, min, max);

        // Invoco funzione di stampa di numeri estratti
        stampaEstraz(estraz, lamp, xT, yT, xTab, yTab, min, max);

        Console.ReadKey();
    }

    // Funzione stampa tabellone
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

    // Funzione generazione della cartella giocatore 1
    static void genCart1(int[,] cartella1, int min, int max)
    {
        Random random = new Random();
        bool[] array = new bool[90];
        int salva;

        for (int i = 0; i < 3; i++)
        {
            bool[] array2 = new bool[10];
            for (int j = 0; j < 5; j++)
            {
                do
                {
                    salva = random.Next(min, max + 1);
                    if (salva == 90)
                    {
                        j--;
                    }
                } while (array[salva - 1] == true || array2[salva / 10] == true);

                array[salva - 1] = true;
                array2[salva / 10] = true;

                if (salva == 90)
                {
                    cartella1[i, 8] = 90;
                }
                else
                {
                    cartella1[i, salva / 10] = salva;
                }
            }
            for (int k = 0; k < 9; k++)
            {
                array2[k] = false;
            }
        }
    }

    // Funzione di stampa cartella giocatore 1
    static void cart1(int[,] cartella1, int righeCart, int colonneCart, int xCart1, int yCart1, int min, int max)
    {
        Console.SetCursorPosition(14, 11);
        Console.WriteLine("Cartella giocatore 1");
        for (int i = 0; i < 5; i++)
        {
            xCart1 = 7;
            yCart1++;
            Console.WriteLine();
            if (i % 2 == 1)
            {
                Console.SetCursorPosition(xCart1, yCart1);
                Console.WriteLine("----------------------");
            }
            else
            {
                Console.SetCursorPosition(xCart1, yCart1);
                for (int j = 0; j < 9; j++)
                {
                    if (cartella1[j, i] != 0)
                    {
                        Console.Write(cartella1[i, j].ToString("D2") + " ");
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                    }
                }
            }
        }
    }

    // Funzione generazione della cartella giocatore 2
    static void genCart2(int[,] cartella2, int min, int max)
    {
        Random random = new Random();
        bool[] array = new bool[90];
        int salva;
        for (int i = 0; i < 3; i++)
        {
            bool[] array2 = new bool[10];
            for (int j = 0; j < 5; j++)
            {
                do
                {
                    salva = random.Next(min, max + 1);
                    if (salva == 90)
                    {
                        j--;
                    }
                } while (array[salva - 1] == true || array2[salva / 10] == true);

                array[salva - 1] = true;
                array2[salva / 10] = true;

                if (salva == 90)
                {
                    cartella2[i, 8] = 90;
                }
                else
                {
                    cartella2[i, salva / 10] = salva;
                }
            }
            for (int k = 0; k < 9; k++)
            {
                array2[k] = false;
            }
        }
    }

    // Funzione di stampa cartella giocatore 2
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

    // Funzione estrazione dei numeri
    static int estrazione(int min, int max)
    {
        int numEstratto;
        Random random = new Random();
        bool[] array = new bool[90];
        do
        {
            numEstratto = random.Next(min, max + 1);
        } while (array[numEstratto - 1] == true);

        array[numEstratto - 1] = true;

        return numEstratto;
    }

    // Funzione coordinata x del tabellone
    static int xTabellone (int estraz, int xTab)
    {
        int x;

        if (estraz / 10 == 0)
        {
            x = (xTab + (estraz % 10 * 3)) - 3;
        }
        else
        {
            if (estraz % 10 != 0)
            {
                x = (xTab + (1 + (estraz % 10 * 3 - 1))) - 3;
            }
            else
            {
                x = (xTab + (1 + estraz / (estraz / 10) * 3 - 1)) - 3;
            }
        }

        return x;
    }

    // Funzione coordinata y del tabellone
    static int yTabellone(int estraz, int yTab)
    {
        int y;

        if (estraz / 10 == 0)
        {
            y = yTab;
        }
        else
        {
            if (estraz % 10 == 0)
            {
                y = (estraz / 10);
            }
            else
            {
                y = yTab + (estraz / 10);
            }
        }

        return y;
    }

    // Funzione stampa dei numeri estratti
    static void stampaEstraz (int estraz, int lamp, int xT, int yT, int xTab, int yTab,int min, int max)
    {
        for (int i = 0; i < 90; i++)
        {
            // Invoco funzione di estrazione dei numeri
            estraz = estrazione(min, max);

            // Invoco funzione per conoscere le coordinate x del tabellone
            xT = xTabellone(estraz, xTab);

            // Invoco funzione per conoscere le coordinate y del tabellone
            yT = yTabellone(estraz, yTab);

            for (int j = 0; j < 2; j++)
            {
                // Prima iterazione: Sleep per evitare che il tabellone parta immediatamente
                // Dalla seconda iterazione in poi: Sleep di attesa tra un numero e l'altro
                Thread.Sleep(1000);

                // Set del cursore + selezione del colore carattere verde + stampa del numero estratto
                Console.SetCursorPosition(xT, yT);            // Set del cursore
                Console.ForegroundColor = ConsoleColor.Green; // Selezione del colore carattere verde
                Console.Write(estraz.ToString("D2"));         // Stampa del numero estratto

                // Intervallo regolare per lampeggiare
                Thread.Sleep(lamp);

                // Set del cursore + selezione del colore carattere bianco + stampa del numero estratto
                Console.SetCursorPosition(xT, yT);            // Set del cursore
                Console.ForegroundColor = ConsoleColor.White; // Selezione del colore carattere bianco
                Console.Write(estraz.ToString("D2"));         // Stampa del numero estratto

                // Intervallo regolare per lampeggiare
                Thread.Sleep(lamp);

                // Set del cursore + selezione del colore carattere verde + stampa del numero estratto
                Console.SetCursorPosition(xT, yT);            // Set del cursore
                Console.ForegroundColor = ConsoleColor.Green; // Selezione del colore carattere verde
                Console.Write(estraz.ToString("D2"));         // Stampa del numero estratto
            }
        }
    }
}