using System;
using System.Data;
using System.Linq.Expressions;

List<string> zlotemysli = new List<string>();

while (true)
{
   Console.WriteLine("1. Dodaj a zlote mysli");
  Console.WriteLine("2. Edytuj a zlote mysli");
   Console.WriteLine("3. Usun a zlote mysli");
   Console.WriteLine("4. Randomowe zlote mysli");
   Console.WriteLine("5. Wyjdz");
    Console.Write("Wybierz liczbe od 1-5: ");

    string Op = Console.ReadLine();
    int liczba;

    if (int.TryParse(Op, out liczba)) 
    {
        if (liczba > 0 && liczba <= 5)
        {
            liczba = Convert.ToInt32(Op);
        }
        else {
            Console.WriteLine("Wypisz dobrze");
        }
    }else 
    { 
        Console.WriteLine("Cos jest nie tak"); 
    }

   switch (liczba)
   {
        case 1:
            Console.Write("Dodaj nowa mysl: ");
            string mysli = Console.ReadLine();
            zlotemysli.Add(mysli);
            break;
        case 2:
            Console.Write("Wybierz numer mysli ktora chcesz edytowac (pierwsza pozycja = 0, druga = 1, idt.)");
            int i;
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
                if (i >= 0 && i < zlotemysli.Count)
                 {
                     Console.Write("Edytuj nowe mysli:");
                     string nowemysli = Console.ReadLine();
                     zlotemysli[i] = nowemysli;
                 }
                else
                {
                    Console.WriteLine("Nie ma takiego numeru");
                }
            }
            catch (Exception a) {
                Console.WriteLine("cos jest nie tak");
            }

            break;
        case 3:
            try
            {
                Console.Write("Wybierz numer mysli ktora usunac (pierwsza pozycja = 0, druga = 1, idt.)");
                i = Convert.ToInt32(Console.ReadLine());
                if (i >= 0 && i < zlotemysli.Count)
                {
                    zlotemysli.RemoveAt(i);
                }
                else
                {
                    Console.WriteLine("Nie ma takiego numeru");
                }
            }
            catch (Exception a)
            { 
                Console.WriteLine("cos jest nie tak");
            }
            break;
        case 4:
            Random random = new Random();
            string randommysli = zlotemysli[random.Next(zlotemysli.Count)];
            Console.WriteLine(randommysli);
            break;
        case 5:
            return;
        default:
            if (zlotemysli.Count > 0)
            {
                random = new Random();
                randommysli = zlotemysli[random.Next(zlotemysli.Count)];
                Console.WriteLine(randommysli);
            }
            break;
    }
    System.Threading.Thread.Sleep(2000);
    Console.Clear();
}
