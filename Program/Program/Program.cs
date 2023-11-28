using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

class Program
{
    static char[,] labirynt;
    static int iloscWierszy, iloscKolumn;
static void Main()
{
        while (true)
        {
            try {
                Console.WriteLine("Podaj ilość wierszy:");
                iloscWierszy = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Podaj ilość kolumn:");
                iloscKolumn = Convert.ToInt32(Console.ReadLine());


                ZrobLabirynt();

                while (true)
                {

                    WyswietlLabirynt();

                    Console.WriteLine("wybierz numer od 1-4");
                    Console.WriteLine("1) Modyfikuj element");
                    Console.WriteLine("2) Zapisz labirynt");
                    Console.WriteLine("3) Wczytaj labirynt");
                    Console.WriteLine("4) Wyjście");

                    int wybor = Convert.ToInt32(Console.ReadLine());

                    switch (wybor)
                    {
                        case 1:
                            ModyfikujElement();
                            break;
                        case 2:
                            ZapiszLabirynt();
                            break;
                        case 3:
                            OdczytajLabirynt();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("cos nie tak");
                            break;
                    }
                }
            }catch(FormatException) { Console.WriteLine("cos nie tak"); }
           }
}

    static void ZrobLabirynt()
    {
        labirynt = new char[iloscWierszy, iloscKolumn];

        for (int i = 0; i < iloscWierszy; i++)
        {
            for (int j = 0; j < iloscKolumn; j++)
            {
                labirynt[i, j] = '?';
            }
        }
    }

    static void WyswietlLabirynt()
    {
        System.Threading.Thread.Sleep(500);
        Console.Clear();

        for (int i = 0; i < iloscWierszy; i++)
        {
            for (int j = 0; j < iloscKolumn; j++)
            {
                Console.Write(labirynt[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void ModyfikujElement()
    {
        Console.WriteLine("1) edytacja \n");
        Console.WriteLine("podaj wiersz:");
        int wiersz = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("podaj kolumnę:");
        int kolumna = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("wybierz stan:");
            Console.WriteLine("1. brak (znak '?')");
            Console.WriteLine("2. sciana (znak '#')");
            Console.WriteLine("3. sciezka (znak '.')");
        int stan = Convert.ToInt32(Console.ReadLine());

        switch (stan)
        {
            case 1:
                labirynt[wiersz, kolumna] = '?';
                break;
            case 2:
                labirynt[wiersz, kolumna] = '#';
                break;
            case 3:
                labirynt[wiersz, kolumna] = '.';
                break;
            default:
                Console.WriteLine("wpisujesz cos zle");
                break;
        }
    }

    static void ZapiszLabirynt()
    {
        
        using (StreamWriter dokument = new StreamWriter("labirynt.txt"))
        {
            dokument.WriteLine(iloscWierszy);
            dokument.WriteLine(iloscKolumn);

            for (int i = 0; i < iloscWierszy; i++)
            {
                for (int j = 0; j < iloscKolumn; j++)
                {
                    dokument.Write(labirynt[i, j]);
                }
                dokument.WriteLine();
            }
        }

        Console.WriteLine("Labirynt zostal zapisany do pliku");
        System.Threading.Thread.Sleep(500);
        Console.Clear();
    }

    static void OdczytajLabirynt()
    {
        try
        {
            using (StreamReader dokument = new StreamReader("labirynt.txt"))
            {
                iloscWierszy = Convert.ToInt32(dokument.ReadLine());
                iloscKolumn = Convert.ToInt32(dokument.ReadLine());

                ZrobLabirynt();

                for (int i = 0; i < iloscWierszy; i++)
                {
                    string linia = dokument.ReadLine();
                    for (int j = 0; j < iloscKolumn; j++)
                    {
                        labirynt[i, j] = linia[j];
                    }
                }
            }

            Console.WriteLine("Labirynt zostal wczytany z pliku");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik z labiryntem nie istnieje");
        }
    }
}
