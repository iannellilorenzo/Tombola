using System;
using System.Numerics;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        // Dichiarazione variabili
        int righeCart = 9, colonneCart = 3, righeTab = 9, colonneTab = 10;
        int min = 1, max = 90, numTab = 1;
        int xTab = 45, yTab = 1, xCart1 = 11, yCart1 = 12, xCart2 = 77, yCart2 = 12, xEstraz = 0, yEstraz = 0;
        int estraz = 0, xT = 0, yT = 0, lamp = 0;
        int contEstraz = 0;

        // Dichiarazione matrici
        int[,] tabellone = new int[righeTab, colonneTab];
        int[,] cartella1 = new int[righeCart, colonneCart];
        int[,] cartella2 = new int[righeCart, colonneCart];

        // Coordinate del cursore + colore carattere rosso
        Console.SetCursorPosition(55, 0);
        Console.WriteLine("Tabellone");
        Console.ForegroundColor = ConsoleColor.Red;

        // Invoco funzione di stampa del tabellone
        Tab(tabellone, righeTab, colonneTab, xTab, yTab, numTab);

        // Invoco funzione di generazione della cartella giocatore 1
        GenCart1(cartella1, min, max);

        // Invoco funzione di stampa della cartella giocatore 1
        Cart1(cartella1, xCart1, yCart1, min, max);

        // Invoco funzione di generazione della cartella giocatore 2
        GenCart2(cartella1, min, max);

        // Invoco funzione di stampa della cartella giocatore 2
        Cart2(cartella2, xCart2, yCart2, min, max);

        // Invoco funzione di stampa di numeri estratti
        StampaEstraz(estraz, lamp, xT, yT, xTab, yTab, min, max);

        Console.ReadKey();
    }

    // Funzione stampa tabellone
    static void Tab(int[,] tabellone, int righeTab, int colonneTab, int xTab, int yTab, int numTab)
    {
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

    // Funzione generazione della cartella giocatore 1
    static void GenCart1(int[,] cartella1, int min, int max)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Random random = new Random();
        bool[] array = new bool[90];
        int salva1;

        for (int i = 0; i < 3; i++)
        {
            bool[] array2 = new bool[10];
            for (int j = 0; j < 5; j++)
            {
                do
                {
                    salva1 = random.Next(min, max + 1);
                    if (salva1 == 90)
                    {
                        j--;
                    }
                } while (array[salva1 - 1] == true || array2[salva1 / 10] == true);

                array[salva1 - 1] = true;
                array2[salva1 / 10] = true;

                if (salva1 == 90)
                {
                    cartella1[8, i] = 90;
                }
                else
                {
                    cartella1[salva1 / 10, i] = salva1;
                }
            }
            for (int j = 0; j < 9; j++)
            {
                array2[j] = false;
            }
        }
    }

    // Funzione di stampa cartella giocatore 1
    static void Cart1(int[,] cartella1, int xCart1, int yCart1, int min, int max)
    {
        Console.SetCursorPosition(14, 11);
        Console.WriteLine("Cartella giocatore 1");
        for (int i = 0; i < 5; i++)
        {
            xCart1 = 11;
            yCart1++;
            Console.WriteLine();
            if (i % 2 == 1)
            {
                Console.SetCursorPosition(xCart1 - 1, yCart1);
                Console.WriteLine("----------------------------");
            }
            else
            {
                Console.SetCursorPosition(xCart1, yCart1);
                for (int j = 0; j < 9; j++)
                {
                    if (cartella1[j, i / 2 + i % 2] != 0)
                    {
                        Console.Write(cartella1[j, i / 2 + i % 2].ToString("D2") + " ");
                    }
                    else
                    {
                        if (j == 0)
                        {
                            Console.Write("   ");
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
    static void GenCart2(int[,] cartella2, int min, int max)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Random random = new Random();
        bool[] array = new bool[90];
        int salva2;

        for (int i = 0; i < 3; i++)
        {
            bool[] array2 = new bool[10];
            for (int j = 0; j < 5; j++)
            {
                do
                {
                    salva2 = random.Next(min, max + 1);
                    if (salva2 == 90)
                    {
                        j--;
                    }
                } while (array[salva2 - 1] == true || array2[salva2 / 10] == true);

                array[salva2 - 1] = true;
                array2[salva2 / 10] = true;

                if (salva2 == 90)
                {
                    cartella2[8, i] = 90;
                }
                else
                {
                    cartella2[salva2 / 10, i] = salva2;
                }
            }
            for (int j = 0; j < 9; j++)
            {
                array2[j] = false;
            }
        }
    }

    // Funzione di stampa cartella giocatore 2
    static void Cart2(int[,] cartella2, int xCart2, int yCart2, int min, int max)
    {
        Console.SetCursorPosition(84, 11);
        Console.WriteLine("Cartella giocatore 2");
        for (int i = 0; i < 5; i++)
        {
            xCart2 = 77;
            yCart2++;
            Console.WriteLine();
            if (i % 2 == 1)
            {
                Console.SetCursorPosition(xCart2 - 1, yCart2);
                Console.WriteLine("----------------------------");
            }
            else
            {
                Console.SetCursorPosition(xCart2, yCart2);
                for (int j = 0; j < 9; j++)
                {
                    if (cartella2[j, i / 2 + i % 2] != 0)
                    {
                        Console.Write(cartella2[j, i / 2 + i % 2].ToString("D2") + " ");
                    }
                    else
                    {
                        if (j == 0)
                        {
                            Console.Write("   ");
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

    // Funzione estrazione dei numeri
    static int Estrazione(int min, int max)
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
    static int Xtabellone (int estraz, int xTab)
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
    static int Ytabellone(int estraz, int yTab)
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
    static void StampaEstraz (int estraz, int lamp, int xT, int yT, int xTab, int yTab,int min, int max)
    {
        for (int i = 0; i < 90; i++)
        {
            // Invoco funzione di estrazione dei numeri
            estraz = Estrazione(min, max);

            // Invoco funzione per conoscere le coordinate x del tabellone
            xT = Xtabellone(estraz, xTab);

            // Invoco funzione per conoscere le coordinate y del tabellone
            yT = Ytabellone(estraz, yTab);

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

    // Funzione di visualizzazione dei numeri estratti per la cartella 1
    static int VisEstraz (int xCart1, int yCart1, int estraz, int contEstraz, int[,] cartella1)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (cartella1[j, i] == estraz)
                {
                    if (j == 0)
                    {
                        xCart1 = 0;
                    }
                    else
                    {
                        xCart1 += j * 3 - 1;
                    }

                    yCart1 += j * 2;
                    contEstraz++;
                    Console.SetCursorPosition(xCart1, yCart1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(estraz);
                    
                    if (contEstraz == 15)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(40, 12);
                        Console.WriteLine("Il giocatore 1 ha fatto tombola!");
                    }
                }
            }
        }
        return 0;
    }
}