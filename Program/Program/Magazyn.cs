public class Magazyn
{
    private List<Produkt> produkty = new List<Produkt>();
    public Adres AdresMagazynu { get; set; }
    public string NazwaMagazynu { get; set; } // Publiczna właściwość NazwaMagazynu

    public Magazyn()
    {
        produkty = new List<Produkt>();
    }

    public void DodajProdukt(Produkt produkt)
    {
        produkty.Add(produkt);
    }

    public void UsunProdukt(Produkt produkt)
    {
        produkty.Remove(produkt);
    }

    public Produkt WyszukajProdukt(string nazwa)
    {
        return produkty.Find(p => p.NazwaProduktu.Equals(nazwa, StringComparison.OrdinalIgnoreCase));
    }

    public List<Produkt> PobierzProdukty()
    {
        return produkty;
    }
}
