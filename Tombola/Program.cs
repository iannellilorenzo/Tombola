using System;
using System.Numerics;
using System.Security.Cryptography;

namespace Tombola
{
    class Program
    {
        static void Main()
        {
            // Selezione del cursore visibile a falso (cursore invisibile) per una migliore interfaccia grafica
            Console.CursorVisible = false;

            // Dichiarazione variabili
            int min = 1, max = 90, numTab = 1;                                           // Variabili: min = 1 corrisponde al minimo che può estrarre il random; max = 90 corrisponde al massimo che può estrarre il random; numTab = 1 corrisponde alla variabile che riempe il tabellone
            int xTab = 45, yTab = 1, xCart1 = 11, yCart1 = 12, xCart2 = 84, yCart2 = 12; // Variabili: tutte le coordinate necessarie, *Tab = Tabellone; *Cart1 = Cartella 1; *Cart2 = Cartella 2
            int estraz = 0, xT = 0, yT = 0, lamp = 250;                                  // Variabili: estraz = 0 corrisponde al valore della variabile ritornata dalla funzione Estrazione; xT corrisponde al valore della variabile ritornata dalla funzione Xtabellone; yT corrisponde al valore della variabile ritornata dalla funzione Ytabellone; lamp corrisponde allo sleep per far lampeggiare i numeri estratti sul tabellone.
            int contEstraz1 = 0, contEstraz2 = 0, contEstraz10 = 0, contEstraz20 = 0;    // Variabili: contEstraz* corrispondono alle variabili per determinare la vittoria; contEstraz*0 corrispondono al valore della variabile ritornata dalle funzioni VisEstraz*

            // Dichiarazione matrici
            int[,] tabellone = new int[9, 10]; // Tabellone
            int[,] cartella1 = new int[9, 3];  // Cartella del primo giocatore
            int[,] cartella2 = new int[9, 3];  // Cartella del secondo giocatore

            // Dichiarazione array
            bool[] array = new bool[90];       // Array per salvare tutti i valori estratti

            // Invoco funzione di stampa del tabellone
            Tab(tabellone, xTab, yTab, numTab);

            // Invoco funzione di stampa della cartella giocatore 1
            Cart1(cartella1, xCart1, yCart1, min, max);

            // Invoco funzione di stampa della cartella giocatore 2
            Cart2(cartella2, xCart2, yCart2, min, max);

            // Invoco funzione di stampa di numeri estratti
            StampaEstraz(estraz, xT, yT, xTab, yTab, min, max, lamp, contEstraz1, contEstraz2, xCart1, yCart1, xCart2, yCart2, contEstraz10, contEstraz20, cartella1, cartella2, array);

            Console.ReadKey();
        }
        #region Funzioni

        /// <summary>
        /// Funzione stampa tabellone
        /// </summary>
        /// <param name="tabellone"> Matrice usata come tabellone della tombola </param>
        /// <param name="xTab"> Coordinata x del tabellone </param>
        /// <param name="yTab"> Coordinata y del tabellone </param>
        /// <param name="numTab"> Variabile usata per riempire il tabellone </param>
        static void Tab(int[,] tabellone, int xTab, int yTab, int numTab)
        {
            // Set del cursore + stampa di "Tabellone" + selezione del colore carattere rosso
            Console.SetCursorPosition(55, 0);           // Set del cursore
            Console.WriteLine("Tabellone");             // Stampa di "Tabellone"
            Console.ForegroundColor = ConsoleColor.Red; // Selezione del colore carattere rosso

            for (int i = 0; i < 9; i++) 
            {
                Console.WriteLine();                                     // A capo per staccare ogni riga del tabellone
                Console.SetCursorPosition(xTab, yTab);                   // Set delle coordinate per stampare il tabellone nelle coordinate giuste
                for (int j = 0; j < 10; j++)
                {
                    tabellone[i, j] = numTab++;                          // Incremento di numTab, che riempirà la matrice tabellone per essere stampata
                    Console.Write(tabellone[i, j].ToString("D2") + " "); // Stampa del tabellone, ToString("D2") per stampare i numeri con 2 cifre (2 = 02)
                }
                yTab++;                                                  // Incremento di yTab per settare nuovamente le coordinate nella zona giusta
            }
        }

        /// <summary>
        /// Funzione di stampa cartella giocatore 1
        /// </summary>
        /// <param name="cartella1"> Cartella del primo giocatore </param>
        /// <param name="xCart1"> Coordinata x della cartella del primo giocatore </param>
        /// <param name="yCart1"> Coordinata y della cartella del primo giocatore </param>
        static void Cart1(int[,] cartella1, int xCart1, int yCart1, int min, int max)
        {
            // Selezione colore carattere bianco + random + array + dichiarazione di salva1
            Console.ForegroundColor = ConsoleColor.White; // Selezione del colore carattere bianco
            Random random = new();                        // Dichiarazione random
            bool[] array11 = new bool[90];                // Dichiarazione array
            int salva1;                                   // Dichiarazione di salva1, variabile usata per salvare il valore randomizzato

            for (int i = 0; i < 3; i++)
            {
                bool[] array21 = new bool[10];            // Dichiarazione array21, usato per controllare il numero generato
                for (int j = 0; j < 5; j++)
                {
                    do                                                                     // Fai...
                    {
                        salva1 = random.Next(min, max + 1);       // Salvataggio del numero randomizzato nella variabile salva1
                    } while (array11[salva1 - 1] == true || array21[salva1 / 10] == true); // ...Mentre o un array o l'altro array hanno valore true

                    array11[salva1 - 1] = true;  // Riporto del valore true della cella [salva1 - 1] dell'array11
                    array21[salva1 / 10] = true; // Riporto del valore true della cella [salva1 / 10] dell'array21

                    if (salva1 == 90)                       // Se il numero randomizzato è 90...
                    {
                        cartella1[8, i] = 90;               // ...Viene inserito nella cella [8, i] della cartella 1
                    }
                    else                                    // Altrimenti...
                    {
                        cartella1[salva1 / 10, i] = salva1; // ...Il numero randomizzato viene inserito nella cella [salva1 / 10, i] della cartella 1
                    }
                }
                for (int j = 0; j < 9; j++)
                {
                    array21[j] = false; // Riporto dell'array21 a false
                }
            }

            // Set del cursore + stampa "Cartella giocatore 1"
            Console.SetCursorPosition(14, 11);         // Set del cursore
            Console.WriteLine("Cartella giocatore 1"); // Stampa "Cartella giocatore 1"
            for (int i = 0; i < 5; i++)
            {
                // Set del cursore in x + set del cursore in y + stampa di una riga vuota per staccare
                xCart1 = 11;         // Set del cursore in x
                yCart1++;            // Set del cursore in y
                Console.WriteLine(); // Stampa di una riga vuota per staccare

                if (i % 2 == 1) // Se il modulo tra i e 2 è uguale a 1...
                {
                    // ...Set del cursore + stampa dei trattini
                    Console.SetCursorPosition(xCart1 - 1, yCart1);     // Set del cursore
                    Console.WriteLine("----------------------------"); // Stampa dei trattini
                }
                else            // Altrimenti...
                {
                    // ...Set del cursore + for e if di controllo
                    Console.SetCursorPosition(xCart1, yCart1);         // Set del cursore
                    for (int j = 0; j < 9; j++)
                    {
                        if (cartella1[j, i / 2 + i % 2] != 0)                                // Se la cella [j, i / 2 + i % 2] della cartella 1 è diversa da 0...
                        {
                            Console.Write(cartella1[j, i / 2 + i % 2].ToString("D2") + " "); // Stampa della cella [j, i / 2 + i % 2] della cartella 1
                        }
                        else if (j == 0)                                                     // Altrimenti Se j = 0...
                        {
                            Console.Write("   ");                                            // ...Stampa 3 spazi
                        }
                        else                                                                 // Altrimenti...
                        { 
                            Console.Write("   ");                                            // ...Stampa di 3 spazi
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Funzione di generazione e stampa cartella giocatore 2
        /// </summary>
        /// <param name="cartella2"> Cartella del secondo giocatore </param>
        /// <param name="xCart2"> Coordinata x della cartella del secondo giocatore </param>
        /// <param name="yCart2"> Coordinata y dalla cartella del secondo giocatore </param>
        static void Cart2(int[,] cartella2, int xCart2, int yCart2, int min, int max)
        {
            // Selezione colore carattere bianco + random + array + dichiarazione di salva2
            Console.ForegroundColor = ConsoleColor.White; // Selezione del colore carattere bianco
            Random random = new();                        // Dichiarazione random
            bool[] array21 = new bool[90];                // Dichiarazione Array
            int salva2;                                   // Dichiarazione di salva2, variabile usata per salvare il valore randomizzato

            for (int i = 0; i < 3; i++)
            {
                bool[] array22 = new bool[10];            // Dichiarazione di array22, usato per controllare il numero generato
                for (int j = 0; j < 5; j++)
                {
                    do                                                                    // Fai...
                    {
                        salva2 = random.Next(min, max + 1);       // Salvataggio del numero randomizzato nella variabile salva2
                    } while (array21[salva2 - 1] == true || array22[salva2 / 10] == true); // ...Mentre o un array o l'altro array hanno valore true

                    array21[salva2 - 1] = true;  // Riporto del valore true della cella [salva2 - 1] dell'array21
                    array22[salva2 / 10] = true; // Riporto del valore true della cella [salva2 / 10] dell'array22

                    if (salva2 == 90)                       // Se il numero randomizzato è 90...
                    {
                        cartella2[8, i] = 90;               // ...Viene inserito nella cella [8, i] della cartella 2
                    }
                    else                                    // Altrimenti...
                    {
                        cartella2[salva2 / 10, i] = salva2; // ...Il numero randomizzato viene inserito nella cella [salva1 / 10, i] della cartella 2
                    }
                }
                for (int j = 0; j < 9; j++)
                {
                    array22[j] = false; // Riporto dell'array22 a false
                }
            }

            // Set del cursore + stampa "Cartella giocatore 2"
            Console.SetCursorPosition(85, 11);         // Set del cursore
            Console.WriteLine("Cartella giocatore 2"); // Stampa "Cartella giocatore 2"
            for (int i = 0; i < 5; i++)
            {
                // Set del cursore in x + set del cursore in y + stampa di una riga vuota per staccare
                xCart2 = 82;         // Set del cursore in x
                yCart2++;            // Set del cursore in y
                Console.WriteLine(); // Stampa di una riga vuota per staccare

                if (i % 2 == 1) // Se il modulo tra i e 2 è uguale a 0...
                {
                    Console.SetCursorPosition(xCart2 - 1, yCart2);
                    Console.WriteLine("----------------------------");
                }
                else            // Altrimenti...
                {
                    // Set del cursore + for e if di controllo
                    Console.SetCursorPosition(xCart2, yCart2); // Set del cursore
                    for (int j = 0; j < 9; j++)
                    {
                        if (cartella2[j, i / 2 + i % 2] != 0)                                // Se la cella [j, i / 2 + i % 2] della cartella 2 è diversa da 0...
                        {
                            Console.Write(cartella2[j, i / 2 + i % 2].ToString("D2") + " "); // Stampa della cella [j, i / 2 + i % 2] della cartella 2
                        }
                        else if (j == 0)                                                     // Altrimenti Se j = 0...
                        {
                            Console.Write("   ");                                            // ...Stampa 3 spazi
                        }
                        else                                                                 // Altrimenti...
                        {
                            Console.Write("   ");                                            // ...Stampa di 3 spazi
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Funzione estrazione dei numeri
        /// </summary>
        /// <param name="min"> Determina il minimo numero estraibile </param>
        /// <param name="max"> Determina il massimo numero estraibile </param>
        /// <param name="array"> Array di appoggio per controllare che un numero venga estratto più di una volta </param>
        /// <returns> numEstratto </returns>
        static int Estrazione(int min, int max, bool[] array)
        {
            // Dichiarazione numEstratto + random
            int numEstratto;       // Dichiarazione numEstratto, usato per salvare il numero randomizzato
            Random random = new(); // Dichiarazione random
            do                                           // Fai...
            {
                numEstratto = random.Next(min, max + 1); // Salvataggio del numero randomizzato in numEstratto
            } while (array[numEstratto - 1] == true);    // ...Mentre l'array ha valore true

            array[numEstratto - 1] = true; // Riporto dell'array al valore true

            return numEstratto; // Ritorno di numEstratto
        }

        /// <summary>
        /// Funzione coordinata x del tabellone
        /// </summary>
        /// <param name="estraz"> Numero estratto dalla funzione Estrazione </param>
        /// <param name="xTab"> Coordinata x del tabellone </param>
        /// <returns> x </returns>
        static int Xtabellone(int estraz, int xTab)
        {
            // Dichiarazione di x
            int x;

            if (estraz / 10 == 0)                                      // Se la divisione tra estraz e 10 è uguale a 0...
            {
                x = (xTab + (estraz % 10 * 3)) - 3;                    // ...x è uguale a (xTab + (estraz % 10 * 3)) - 3; calcolo delle x
            }
            else if (estraz % 10 != 0)                                 // Altrimenti Se...
            {
                x = (xTab + (1 + (estraz % 10 * 3 - 1))) - 3;          // ...x è uguale a (xTab + (1 + (estraz % 10 * 3 - 1))) - 3; calcolo delle x
            }
            else                                                       // Altrimenti
            {
                x = (xTab + (1 + estraz / (estraz / 10) * 3 - 1)) - 3; // ...x è uguale a (xTab + (1 + estraz / (estraz / 10) * 3 - 1)) - 3; calcolo delle x
            }

            return x; // Ritorno di x
        }

        /// <summary>
        /// Funzione per trovare la coordinata y del tabellone
        /// </summary>
        /// <param name="estraz"> Numero estratto dalla funzione Estrazione </param>
        /// <param name="yTab"> Coordinata y del tabellone </param>
        /// <returns> y </returns>
        static int Ytabellone(int estraz, int yTab)
        {
            // Dichiarazione di y
            int y;

            if (estraz / 10 == 0)         // Se la divisione tra estrza e 10 è uguale a 0...
            {
                y = yTab;                 // ...y è uguale a yTab; calcolo delle y
            }
            else if (estraz % 10 == 0)    // Altrimenti Se il modulo tra estraz e 10 è uguale a 0...
            {
                y = (estraz / 10);        // ...y è uguale a estraz / 10; calcolo delle y
            }
            else                          // Altrimenti...
            {
                y = yTab + (estraz / 10); // ...y è uguale a yTab + (estraz / 10); calcolo delle y
            }

            return y; // Ritorno di y
        }

        /// <summary>
        /// Funzione di visualizzazione dei numeri estratti per la cartella 1
        /// </summary>
        /// <param name="xCart1"> Coordinata x della cartella 1 </param>
        /// <param name="yCart1"> Coordinata y della cartella 1 </param>
        /// <param name="estraz"> Numero estratto che verrà ristampato verde </param>
        /// <param name="contEstraz1"> Contatore per determinare la vittoria del primo giocatore </param>
        /// <param name="cartella1"> Cartella del primo giocatore </param>
        /// <returns> contEstraz1 </returns>
        static int VisEstraz1(int xCart1, int yCart1, int estraz, int contEstraz1, int[,] cartella1)
        {
            for (int i = 0; i < 3; i++)
            {
                // Dichiarazione di xCart1 + yCart1
                xCart1 = 12; // Dichiarazione xCart1
                yCart1 = 13; // Dichiarazione yCart1

                for (int j = 0; j < 9; j++)
                {
                    if (cartella1[j, i] == estraz) // Se la cella [j, i]  è uguale al numero estratto...
                    {
                        if (j != 0)                // Se j è diverso da 0...
                        {
                            xCart1 += j * 3 - 1;   // ...xCart1 è uguale a xCart1 += j * 3 - 1; calcolo delle x
                        }
                        else                       // Altrimenti...
                        {
                            xCart1 -= 1;           // ...xCart1 è uguale a xCart1 -= 1; calcolo delle x
                        }

                        yCart1 += i * 2;                              // yCart1 è uguale a yCart1 += i * 2; calcolo delle y
                        contEstraz1++;                                // Contatore che indica la vittoria
                        Console.SetCursorPosition(xCart1, yCart1);    // Set del cursore
                        Console.ForegroundColor = ConsoleColor.Green; // Selezione del colore carattere verde
                        Console.WriteLine(estraz.ToString("D2"));     // Stampa del numera estratto per sovrascrivere il tabellone
                    }
                }
            }
            return contEstraz1; // Ritorno del contatore che indica la vittoria
        }

        /// <summary>
        /// Funzione di visualizzazione dei numeri estratti per la cartella 2
        /// </summary>
        /// <param name="xCart2"> Coordinata x della cartella 2 </param>
        /// <param name="yCart2"> Coordinata y della cartella 2 </param>
        /// <param name="estraz"> Numero estratto che verrà ristampato verde </param>
        /// <param name="contEstraz2"> Contatore per determinare la vittoria del secondo giocatore </param>
        /// <param name="cartella2"> Cartella del secondo giocatore </param>
        /// <returns> contEstraz2 </returns>
        static int VisEstraz2(int xCart2, int yCart2, int estraz, int contEstraz2, int[,] cartella2)
        {
            for (int i = 0; i < 3; i++)
            {
                // Dichiarazione di xCart2 + yCart2 
                xCart2 = 83; // Dichiarazione xCart2
                yCart2 = 13; // Dichiarazione yCart2

                for (int j = 0; j < 9; j++)
                {
                    if (cartella2[j, i] == estraz) // Se la cella [j, i]  è uguale al numero estratto...
                    {
                        if (j != 0)                // Se j è diverso da 0...
                        {
                            xCart2 += j * 3 - 1;   // ...xCart1 è uguale a xCart1 += j * 3 - 1; calcolo delle x
                        }
                        else                       // Altrimenti...
                        {
                            xCart2 -= 1;           // ...xCart1 è uguale a xCart1 -= 1; calcolo delle x
                        }

                        yCart2 += i * 2;                              // yCart1 è uguale a yCart2 += i * 2; calcolo delle y
                        contEstraz2++;                                // Contatore che indica la vittoria
                        Console.SetCursorPosition(xCart2, yCart2);    // Set del cursore
                        Console.ForegroundColor = ConsoleColor.Green; // Selezione del colore carattere verde
                        Console.WriteLine(estraz.ToString("D2"));     // Stampa del numera estratto per sovrascrivere il tabellone
                    }
                }
            }
            return contEstraz2; // Ritorno del contatore che indica la vittoria
        }

        /// <summary>
        /// Funzione stampa dei numeri estratti
        /// </summary>
        /// <param name="estraz"> Variabile usata per salvare il valore della funzione Estrazione </param>
        /// <param name="xT"> Variabile usata per salvare il valore della funzione Xtabellone </param>
        /// <param name="yT"> Variabile usata per salvare il valore della funzione Ytabellone </param>
        /// <param name="xTab"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="yTab"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="min"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="max"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="lamp"> Variabile per far lampeggiare i numeri estratti ad uno stesso intervallo  </param>
        /// <param name="contEstraz1"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="contEstraz2"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="xCart1"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="yCart1"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="xCart2"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="yCart2"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="contEstraz10"> Variabile usata per salvare il valore della funzione VisEstraz1 </param>
        /// <param name="contEstraz20"> Variabile usata per salvare il valore della funzione VisEstraz2 </param>
        /// <param name="cartella1"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="cartella2"> Parametro passato per sostenere le altre funzioni </param>
        /// <param name="array"> Parametro passato per sostenere le altre funzioni </param>
        static void StampaEstraz(int estraz, int xT, int yT, int xTab, int yTab, int min, int max, int lamp, int contEstraz1, int contEstraz2, int xCart1, int yCart1, int xCart2, int yCart2, int contEstraz10, int contEstraz20, int[,] cartella1, int[,] cartella2, bool[] array)
        {
            for (int i = 0; i < 90; i++)
            {
                // Invoco funzione di estrazione dei numeri
                estraz = Estrazione(min, max, array);

                // Invoco funzione per conoscere le coordinate x del tabellone
                xT = Xtabellone(estraz, xTab);

                // Invoco funzione per conoscere le coordinate y del tabellone
                yT = Ytabellone(estraz, yTab);

                for (int j = 0; j < 2; j++)
                {
                    // Prima iterazione: Sleep per evitare che il tabellone parta immediatamente
                    // Dalla seconda iterazione in poi: Sleep di attesa tra un numero e l'altro
                    Thread.Sleep(100);

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

                // Invoco funzione per visualizzare i numeri estratti per la cartella 1
                contEstraz10 = VisEstraz1(xCart1, yCart1, estraz, contEstraz1, cartella1); // contEstraz10 prende il valore ritornato dalla funzione

                // Invoco funzione per visualizzare i numeri estratti per la cartella 2
                contEstraz20 = VisEstraz2(xCart2, yCart2, estraz, contEstraz2, cartella2); // contEstraz20 prende il valore ritornato dalla funzione

                Console.ForegroundColor = ConsoleColor.White;

                // Controlli per determinare la vittoria
                if (contEstraz10 == 15 && contEstraz20 == 15)           // Se contEstraz è uguale a 15 e contEstraz20 è uguale a 15...
                {
                    Console.SetCursorPosition(40, 20);                  // ...Set del cursore
                    Console.WriteLine("Avete fatto entrambi tombola!"); // ...Stampa di "Avete fatto entrambi tombola!"
                    break;                                              // ...Break per non far continuare l'estrazione dei numeri
                }
                else if (contEstraz10 == 15)                            // Altrimenti Se contEstraz10 è uguale a 15...
                {
                    Console.SetCursorPosition(12, 20);                  // ...Set del cursore
                    Console.WriteLine("Tombola!");                      // ...Stampa di "Tombola!"
                    break;                                              // ...Break per non far continuare l'estrazione dei numeri
                }
                else if (contEstraz20 == 15)                            // Altrimenti Se contEstraz20 è uguale a 15...
                {
                    Console.SetCursorPosition(80, 20);                  // ...Set del cursore
                    Console.WriteLine("Tombola!");                      // ...Stampa di "Tombola!"
                    break;                                              // ...Break per non far continuare l'estrazione dei numeri
                }
            }
        }

        #endregion funzioni
    }
}