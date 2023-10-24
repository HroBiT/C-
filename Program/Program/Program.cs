using System;
using System.Collections.Generic;

namespace Program
{
    public class Program
    {
        private static Magazyn magazyn = new Magazyn();
        private static List<Produkt> produkty = new List<Produkt>();

        static void Main(string[] args)
        {
            List<Magazyn> magazyny = new List<Magazyn>();

            while (true)
            {
                Console.WriteLine("Wybierz operację:");
                Console.WriteLine("1. Dodaj magazyn");
                Console.WriteLine("2. Edytuj magazyn");
                Console.WriteLine("3. Usuń magazyn");
                Console.WriteLine("4. Dodaj produkt");
                Console.WriteLine("5. Edytuj produkt");
                Console.WriteLine("6. Usuń produkt");
                Console.WriteLine("7. Dodaj produkt do magazynu");
                Console.WriteLine("8. Usuń produkt z magazynu");
                Console.WriteLine("9. Zakończ");

                string wybor = Console.ReadLine();
                int liczba;

                if (int.TryParse(wybor, out liczba))
                {
                    if (liczba > 0 && liczba <= 5)
                    {
                        liczba = Convert.ToInt32(wybor);
                    }
                    else
                    {
                        Console.WriteLine("Wpisz poprawną wartość.");
                    }
                }
                else
                {
                    Console.WriteLine("Wpisz poprawną wartość.");
                }
                switch (liczba)
                {
                    case 1:
                        // Dodawanie magazynu
                        try
                        {
                            Magazyn nowyMagazyn = new Magazyn();
                            Console.WriteLine("Podaj adres magazynu \n");
                            Console.WriteLine("Podaj nazwe Magazynu: ");
                            nowyMagazyn.NazwaMagazynu = Console.ReadLine();
                            Adres adres = WprowadzAdres();
                            nowyMagazyn.AdresMagazynu = adres;
                            magazyny.Add(nowyMagazyn);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Wprowadź prawidłowe dane.");
                        }
                        Console.WriteLine("Magazyn został dodany.");
                        break;
                    case 2:
                        // Edycja magazynu
                        try
                        {
                            Console.WriteLine("Podaj indeks magazynu do edycji:");
                            int indeksMagazynuDoEdycji = Convert.ToInt32(Console.ReadLine());

                            if (indeksMagazynuDoEdycji >= 0 && indeksMagazynuDoEdycji < magazyny.Count)
                            {
                                Magazyn magazynDoEdycji = magazyny[indeksMagazynuDoEdycji];
                                Console.WriteLine("Podaj nowy adres magazynu \n");
                                Adres nowyAdres = WprowadzAdres();
                                magazynDoEdycji.AdresMagazynu = nowyAdres;
                                Console.WriteLine("Magazyn został zedytowany.");
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidłowy indeks magazynu.");
                            }
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine("Cos nie tak");

                        }
                        break;
                    case 3:
                        // Usuwanie magazynu
                        Console.WriteLine("Podaj indeks magazynu do usunięcia:");
                        int indeksMagazynuDoUsuniecia = Convert.ToInt32(Console.ReadLine());

                        if (indeksMagazynuDoUsuniecia >= 0 && indeksMagazynuDoUsuniecia < magazyny.Count)
                        {
                            magazyny.RemoveAt(indeksMagazynuDoUsuniecia);
                            Console.WriteLine("Magazyn został usunięty.");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy indeks magazynu.");
                        }
                        break;
                    case 4:
                        // Dodawanie produktu do ogólnego składu produktów
                        Produkt nowyProdukt = new Produkt();

                        Console.WriteLine("Podaj nazwę producenta:");
                        nowyProdukt.NazwaProducenta = Console.ReadLine();

                        Console.WriteLine("Podaj nazwę produktu:");
                        nowyProdukt.NazwaProduktu = Console.ReadLine();

                        Console.WriteLine("Podaj kategorię:");
                        nowyProdukt.Kategoria = Console.ReadLine();

                        Console.WriteLine("Podaj kod produktu:");
                        nowyProdukt.KodProduktu = Console.ReadLine();

                        // Sprawdzenie poprawności wprowadzonej ceny
                        double wprowadzonaCena;
                        Console.WriteLine("Podaj cenę:");
                        while (!double.TryParse(Console.ReadLine(), out wprowadzonaCena) || wprowadzonaCena < 0)
                        {
                            Console.WriteLine("Nieprawidłowa cena. Wprowadź poprawną wartość:");
                        }
                        nowyProdukt.Cena = wprowadzonaCena;

                        Console.WriteLine("Podaj opis:");
                        nowyProdukt.Opis = Console.ReadLine();

                        // Dodanie produktu tylko jeśli wszystkie dane są prawidłowe
                        if (!string.IsNullOrWhiteSpace(nowyProdukt.NazwaProducenta) &&
                            !string.IsNullOrWhiteSpace(nowyProdukt.NazwaProduktu) &&
                            !string.IsNullOrWhiteSpace(nowyProdukt.Kategoria) &&
                            !string.IsNullOrWhiteSpace(nowyProdukt.KodProduktu) &&
                            wprowadzonaCena >= 0 &&
                            !string.IsNullOrWhiteSpace(nowyProdukt.Opis))
                        {
                            // Dodaj nowy produkt do ogólnego składu produktów
                            magazyn.DodajProdukt(nowyProdukt);
                            Console.WriteLine("Produkt został dodany do ogólnego składu produktów.");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowe dane produktu. Produkt nie został dodany.");
                        }
                        break;

                    case 5:
                    
    // Edycja produktu
    Console.WriteLine("Dostępne magazyny:");
    for (int i = 0; i < magazyny.Count; i++)
    {
        Console.WriteLine($"{i}: {magazyny[i].NazwaMagazynu}");
    }

    Console.WriteLine("Wybierz indeks magazynu, w którym chcesz edytować produkt:");
    int indeksMagazynuDoEdycjiProduktu;
    while (!int.TryParse(Console.ReadLine(), out indeksMagazynuDoEdycjiProduktu) || indeksMagazynuDoEdycjiProduktu < 0 || indeksMagazynuDoEdycjiProduktu >= magazyny.Count)
    {
        Console.WriteLine("Nieprawidłowy indeks magazynu. Wprowadź poprawną wartość:");
    }

    Magazyn magazynDoEdycjiProduktu = magazyny[indeksMagazynuDoEdycjiProduktu];

    Console.WriteLine("Dostępne produkty w wybranym magazynie:");
    for (int i = 0; i < magazynDoEdycjiProduktu.PobierzProdukty().Count; i++)
    {
        Console.WriteLine($"{i}: {magazynDoEdycjiProduktu.PobierzProdukty()[i].NazwaProduktu}");
    }

    Console.WriteLine("Wybierz indeks produktu do edycji:");
    int indeksProduktuDoEdycji;
    while (!int.TryParse(Console.ReadLine(), out indeksProduktuDoEdycji) || indeksProduktuDoEdycji < 0 || indeksProduktuDoEdycji >= magazynDoEdycjiProduktu.PobierzProdukty().Count)
    {
        Console.WriteLine("Nieprawidłowy indeks produktu. Wprowadź poprawną wartość:");
    }

    Produkt produktDoEdycji = magazynDoEdycjiProduktu.PobierzProdukty()[indeksProduktuDoEdycji];

    Console.WriteLine("Podaj nową nazwę produktu:");
    produktDoEdycji.NazwaProduktu = Console.ReadLine();
    Console.WriteLine("Produkt został edytowany.");
    break;

                    case 6:
                        // Usuwanie produktu
                        Console.WriteLine("Podaj nazwę produktu do usunięcia:");
                        string nazwaProduktuDoUsuniecia = Console.ReadLine();
                        Produkt produktDoUsuniecia = null;

                        foreach (var magazyn in magazyny)
                        {
                            produktDoUsuniecia = magazyn.WyszukajProdukt(nazwaProduktuDoUsuniecia);
                            if (produktDoUsuniecia != null)
                            {
                                break;
                            }
                        }

                        if (produktDoUsuniecia != null)
                        {
                            foreach (var magazyn in magazyny)
                            {
                                magazyn.UsunProdukt(produktDoUsuniecia);
                            }
                            Console.WriteLine("Produkt został usunięty.");
                        }
                        else
                        {
                            Console.WriteLine("Produkt nie istnieje.");
                        }
                        break;
                    case 7:
                        // Dodawanie produktu do wybranego magazynu
                        Console.WriteLine("Dostępne produkty w ogólnym składzie:");
                        for (int i = 0; i < magazyn.PobierzProdukty().Count; i++)
                        {
                            Console.WriteLine($"{i}: {magazyn.PobierzProdukty()[i].NazwaProduktu}");
                        }

                        Console.WriteLine("Wybierz indeks produktu, który chcesz dodać do magazynu:");
                        int indeksProduktuDoDodania;
                        
                        // Probowanie do skutku podania odpowiedniej wartosci i odpowiedniego indexu
                        while (!int.TryParse(Console.ReadLine(), out indeksProduktuDoDodania) || indeksProduktuDoDodania < 0 || indeksProduktuDoDodania >= magazyn.PobierzProdukty().Count)
                        {
                            Console.WriteLine("Nieprawidłowy indeks produktu. Wprowadź poprawną wartość:");
                        }

                        // Wybrany produkt z ogólnego składu
                        Produkt wybranyProdukt = magazyn.PobierzProdukty()[indeksProduktuDoDodania];

                        // Wybór magazynu, do którego chcemy dodać produkt
                        Console.WriteLine("Dostępne magazyny:");
                        for (int i = 0; i < magazyny.Count; i++)
                        {
                            Console.WriteLine($"{i}: {magazyny[i].NazwaMagazynu}");
                        }

                        Console.WriteLine("Wybierz indeks magazynu, do którego chcesz dodać produkt:");
                        int indeksMagazynuDoDodania;
                        while (!int.TryParse(Console.ReadLine(), out indeksMagazynuDoDodania) || indeksMagazynuDoDodania < 0 || indeksMagazynuDoDodania >= magazyny.Count)
                        {
                            Console.WriteLine("Nieprawidłowy indeks magazynu. Wprowadź poprawną wartość:");
                        }

                        // Wybrany magazyn, do którego chcemy dodać produkt
                        Magazyn wybranyMagazyn = magazyny[indeksMagazynuDoDodania];

                        // Dodanie wybranego produktu do wybranego magazynu
                        wybranyMagazyn.DodajProdukt(wybranyProdukt);
                        Console.WriteLine($"Produkt {wybranyProdukt.NazwaProduktu} został dodany do magazynu {wybranyMagazyn.NazwaMagazynu}.");
                        break;
                    case 8:
                        // Usuwanie produktu z magazynu
                        Console.WriteLine("Podaj indeks magazynu, z którego chcesz usunąć produkt:");
                        if (int.TryParse(Console.ReadLine(), out int IndexMagazynDUP) &&
                            IndexMagazynDUP >= 0 && IndexMagazynDUP < magazyny.Count)
                        {
                            Magazyn MagazynDUP = magazyny[IndexMagazynDUP];
                            Console.WriteLine("Lista indeksów produktów w magazynie:");

                            // Uzyskanie listy produktów z magazynu
                            List<Produkt> produktyWMagazynie = MagazynDUP.PobierzProdukty();

                            for (int i = 0; i < produktyWMagazynie.Count; i++)
                            {
                                Console.WriteLine($"[{i}] {produktyWMagazynie[i].NazwaProduktu}");
                            }

                            Console.WriteLine("Podaj indeks produktu do usunięcia:");
                            if (int.TryParse(Console.ReadLine(), out int indeksProduktuDoUsuniecia) &&
                                indeksProduktuDoUsuniecia >= 0 && indeksProduktuDoUsuniecia < produktyWMagazynie.Count)
                            {
                                Produkt produktDoUsunieciaZMagazynu = produktyWMagazynie[indeksProduktuDoUsuniecia];
                                MagazynDUP.UsunProdukt(produktDoUsunieciaZMagazynu);
                                Console.WriteLine("Produkt został usunięty z magazynu.");
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidłowy indeks produktu.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy indeks magazynu.");
                        }
                        break;


                    case 9:
                        Environment.Exit(9);
                        break;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }

                System.Threading.Thread.Sleep(500);
                Console.Clear();

                // Metoda do wprowadzania danych adresu
                static Adres WprowadzAdres()
                {

                    Adres adres = new Adres();
                    Console.WriteLine("Podaj ulicę:");
                    adres.Ulica = Console.ReadLine();
                    Console.WriteLine("Podaj kod pocztowy:");
                    adres.KodPocztowy = Console.ReadLine();
                    Console.WriteLine("Podaj miejscowość:");
                    adres.Miejscowosc = Console.ReadLine();
                    Console.WriteLine("Podaj numer posesji:");
                    adres.NumerPosesji = Console.ReadLine();
                    Console.WriteLine("Podaj numer lokalu:");
                    adres.NumerLokalu = Console.ReadLine();
                    return adres;
                }
            }
        }
    }
}
