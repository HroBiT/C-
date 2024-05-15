using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz co chcesz zrobić:");
            Console.WriteLine("1. Obliczenia arytmetyczne lub geometryczne");
            Console.WriteLine("2. Obliczenia logarytmiczne");
            Console.WriteLine("3. Wyjdź z programu");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CalculateSequence();
                    break;
                case 2:
                    CalculateLogarithms();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
                    break;
            }
        }
    }

    static void CalculateLogarithms()
    {
        Console.Clear();
        Console.WriteLine("Podaj działanie logarytmiczne do obliczenia (np. log_2(16)=4):");
        string input = Console.ReadLine().Trim();

        if (!TryParseLogarithm(input, out double result))
        {
            Console.WriteLine("Niepoprawne wyrażenie logarytmiczne. Spróbuj ponownie.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Wynik obliczeń: {result}");
        Console.ReadLine();
    }

    static bool TryParseLogarithm(string expression, out double result)
    {
        result = 0.0;
        string[] parts = expression.Split(new[] { '=', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 3)
            return false;

        if (parts[0].StartsWith("log_"))
        {
            if (double.TryParse(parts[1], out double baseNumber) && double.TryParse(parts[2], out double exponent))
            {
                result = Math.Pow(baseNumber, exponent);
                return true;
            }
        }

        return false;
    }

    static void CalculateSequence()
    {
        Console.Clear();
        Console.WriteLine("Wybierz typ ciągu do obliczeń:");
        Console.WriteLine("1. Arytmetyczny");
        Console.WriteLine("2. Geometryczny");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
            return;
        }

        switch (choice)
        {
            case 1:
                CalculateArithmeticSequence();
                break;
            case 2:
                CalculateGeometricSequence();
                break;
            default:
                Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
                break;
        }
    }

    static void CalculateArithmeticSequence()
    {
        Console.Clear();
        Console.WriteLine("Podaj długość ciągu:");

        if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
        {
            Console.WriteLine("Niepoprawna długość ciągu. Spróbuj ponownie.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Podaj elementy ciągu:");

        Dictionary<int, double> elements = new Dictionary<int, double>();

        for (int i = 1; i <= length; i++)
        {
            Console.Write($"{i} = ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Niepoprawna wartość. Spróbuj ponownie.");
                i--;
                continue;
            }
            elements.Add(i, value);
        }

        CalculateAndPrintSequence(elements, "arytmetyczny");
        Console.ReadLine();
    }

    static void CalculateGeometricSequence()
    {
        Console.Clear();
        Console.WriteLine("Podaj długość ciągu:");

        if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
        {
            Console.WriteLine("Niepoprawna długość ciągu. Spróbuj ponownie.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Podaj elementy ciągu:");

        Dictionary<int, double> elements = new Dictionary<int, double>();

        for (int i = 1; i <= length; i++)
        {
            Console.Write($"{i} = ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Niepoprawna wartość. Spróbuj ponownie.");
                i--;
                continue;
            }
            elements.Add(i, value);
        }

        CalculateAndPrintSequence(elements, "geometryczny");
        Console.ReadLine();
    }

    static void CalculateAndPrintSequence(Dictionary<int, double> elements, string sequenceType)
    {
        string monotonicity = GetMonotonicity(elements);

        Console.WriteLine($"Typ ciągu: {sequenceType}");
        Console.WriteLine($"Monotoniczność ciągu: {monotonicity}");

        Console.WriteLine("Podaj numer indeksu (n) elementu, którego wartość chcesz poznać:");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > elements.Count)
        {
            Console.WriteLine("Niepoprawny numer indeksu. Spróbuj ponownie.");
            return;
        }

        Console.WriteLine($"Wartość elementu o indeksie {index}: {elements[index]}");
    }

    static string GetMonotonicity(Dictionary<int, double> elements)
    {
        bool isIncreasing = true;
        bool isDecreasing = true;
        for (int i = 2; i <= elements.Count; i++)
        {
            if (elements[i] > elements[i - 1])
                isDecreasing = false;
            else if (elements[i] < elements[i - 1])
                isIncreasing = false;
        }

        if (isIncreasing)
            return "rosnący";
        else if (isDecreasing)
            return "malejący";
        else
            return "nierosnący/nemalejący";
    }
}
