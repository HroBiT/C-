using System;
using System.Collections.Generic;
using System.Linq;

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
                    if (liczba > 0 && liczba <= 9)
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
                            Console.WriteLine("Dostępne magazyny:");
                            for (int i = 0; i < magazyny.Count; i++)
                            {
                                Console.WriteLine($"{i}: {magazyny[i].NazwaMagazynu}");
                            }


                            Console.WriteLine("Podaj indeks magazynu do edycji:");
                            int IMDE = Convert.ToInt32(Console.ReadLine()); //indeks Magazynu Do Edycji

                            if (IMDE >= 0 && IMDE < magazyny.Count)
                            {
                                Magazyn magazynDoEdycji = magazyny[IMDE];
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
                        Console.WriteLine("Dostępne magazyny:");
                        for (int i = 0; i < magazyny.Count; i++)
                        {
                            Console.WriteLine($"{i}: {magazyny[i].NazwaMagazynu}");
                        }

                        Console.WriteLine("Podaj indeks magazynu do usunięcia:");
                        int IMDU = Convert.ToInt32(Console.ReadLine());

                        if (IMDU >= 0 && IMDU < magazyny.Count) //indeks Magazynu Do Usuniecia
                        {
                            magazyny.RemoveAt(IMDU);
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
                            // Dodaj nowy produkt do składu produktów
                            magazyn.DodajProdukt(nowyProdukt);
                            Console.WriteLine("Produkt został dodany do składu produktów.");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowe dane produktu. Produkt nie został dodany.");
                        }
                        break;

                    case 5:
                        // Edycja produktu
                        try
                        {
                            Console.WriteLine("Dostępne produkty w ogólnym składzie:");
                            for (int i = 0; i < magazyn.PobierzProdukty().Count; i++)
                            {
                                Console.WriteLine($"{i}: {magazyn.PobierzProdukty()[i].NazwaProduktu}");
                            }
                            Console.WriteLine("Podaj indeks magazynu, w którym chcesz edytować produkt:");
                            int IMDEP = Convert.ToInt32(Console.ReadLine()); //indeks magazynu Do Edycji Produktu
                            if (IMDEP >= 0 && IMDEP < magazyny.Count) 
                            {
                                Magazyn magazynDoEdycjiProduktu = magazyny[IMDEP];
                                Console.WriteLine("Podaj nazwę produktu do edycji:");
                                string nazwaProduktuDoEdycji = Console.ReadLine();
                                Produkt produktDoEdycji = magazynDoEdycjiProduktu.WyszukajProdukt(nazwaProduktuDoEdycji);
                                if (produktDoEdycji != null)
                                {
                                    Console.WriteLine("Podaj nową nazwę produktu:");
                                    produktDoEdycji.NazwaProduktu = Console.ReadLine();
                                    Console.WriteLine("Produkt został edytowany.");
                                }
                                else
                                {
                                    Console.WriteLine("Produkt nie istnieje w wybranym magazynie.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidłowy indeks magazynu.");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.Write("Cos nie tak");
                        }
                        break;
                    case 6:
                        // Usuwanie produktu
                        try
                        {

                            Console.WriteLine("Dostępne produkty w ogólnym składzie:");
                            for (int i = 0; i < magazyn.PobierzProdukty().Count; i++)
                            {
                                Console.WriteLine($"{i}: {magazyn.PobierzProdukty()[i].NazwaProduktu}");
                            }


                            Console.WriteLine("Podaj nazwę produktu do usunięcia:");
                            string NPDU = Console.ReadLine(); //nazwaProduktuDoUsuniecia
                            Produkt PDU = null; //produktDoUsuniecia

                            foreach (var magazyn in magazyny)
                            {
                                PDU = magazyn.WyszukajProdukt(NPDU);
                                if (PDU != null)
                                {
                                    break;
                                }
                            }

                            if (PDU != null)
                            {
                                foreach (var magazyn in magazyny)
                                {
                                    magazyn.UsunProdukt(PDU);
                                }
                                Console.WriteLine("Produkt został usunięty.");
                            }
                            else
                            {
                                Console.WriteLine("Produkt nie istnieje.");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("cos nie tak");
                        }
                        break;
                    case 7:
                        // Dodawanie produktu do wybranego magazynu
                        try
                        {
                            if (magazyny.Count > 0 && magazyn.PobierzProdukty().Count > 0) // sprawdzanie czy sa podane produkty oraz magazyny
                            {
                                Console.WriteLine("Dostępne produkty w ogólnym składzie:");
                                for (int i = 0; i < magazyn.PobierzProdukty().Count; i++)
                                {
                                    Console.WriteLine($"{i}: {magazyn.PobierzProdukty()[i].NazwaProduktu}");
                                }

                                Console.WriteLine("Wybierz indeks produktu, który chcesz dodać do magazynu:");
                                int IPDD; // IndexProdDoDodania

                                // Probowanie do skutku podania odpowiedniej wartosci i odpowiedniego indexu
                                while (!int.TryParse(Console.ReadLine(), out IPDD) || IPDD < 0 || IPDD >= magazyn.PobierzProdukty().Count)
                                {
                                    Console.WriteLine("Nieprawidłowy indeks produktu. Wprowadź poprawną wartość:");
                                }

                                // Wybrany produkt z ogólnego składu
                                Produkt wybranyProdukt = magazyn.PobierzProdukty()[IPDD];

                                // Wybór magazynu, do którego chcemy dodać produkt
                                Console.WriteLine("Dostępne magazyny:");
                                for (int i = 0; i < magazyny.Count; i++)
                                {
                                    Console.WriteLine($"{i}: {magazyny[i].NazwaMagazynu}");
                                }

                                Console.WriteLine("Wybierz indeks magazynu, do którego chcesz dodać produkt:");
                                int IMDD; //indeksMagazynuDoDodania
                                while (!int.TryParse(Console.ReadLine(), out IMDD) || IMDD < 0 || IMDD >= magazyny.Count)
                                {
                                    Console.WriteLine("Nieprawidłowy indeks magazynu. Wprowadź poprawną wartość:");

                                }

                                // Wybrany magazyn, do którego chcemy dodać produkt
                                Magazyn wybranyMagazyn = magazyny[IMDD];

                                // Dodanie wybranego produktu do wybranego magazynu
                                wybranyMagazyn.DodajProdukt(wybranyProdukt);
                                Console.WriteLine($"Produkt {wybranyProdukt.NazwaProduktu} został dodany do magazynu {wybranyMagazyn.NazwaMagazynu}.");
                            }
                            else
                            {
                                Console.WriteLine("Nie posiadasz magazynow/produktow");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("cos nie tak");
                        }
                        break;

                    case 8:
                        // Usuwanie produktu z magazynu
                        if (magazyny.Count() > 0) // sparawdzanie czy sa magazyny
                        {
                            Console.WriteLine("Podaj indeks magazynu, z którego chcesz usunąć produkt:");
                            if (int.TryParse(Console.ReadLine(), out int IMDUP) &&
                                IMDUP >= 0 && IMDUP < magazyny.Count) // Indeks Magazynu Do Usuniecia Produktu
                            {
                                Magazyn MDUP = magazyny[IMDUP];  // Magazyn do usuniecia produktu
                                Console.WriteLine("Lista indeksów produktów w magazynie:");

                                // Uzyskanie listy produktów z magazynu
                                List<Produkt> PWM = MDUP.PobierzProdukty(); // Produkty W Magazynie

                                for (int i = 0; i < PWM.Count; i++)
                                {
                                    Console.WriteLine($"[{i}] {PWM[i].NazwaProduktu}");
                                }

                                Console.WriteLine("Podaj indeks produktu do usunięcia:");
                                if (int.TryParse(Console.ReadLine(), out int IPDU) &&
                                    IPDU >= 0 && IPDU < PWM.Count) // indeks Produktu Do Usuniecia
                                {
                                    Produkt PDUZMagazynu = PWM[IPDU];
                                    MDUP.UsunProdukt(PDUZMagazynu);
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
                        }
                        else
                        {
                            Console.WriteLine("Cos nie tak");
                        }
                        break;


                    case 9:
                        Environment.Exit(9);
                        break;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }


                System.Threading.Thread.Sleep(800);
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
