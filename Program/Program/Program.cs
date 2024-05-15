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
            Console.WriteLine("Wybierz co chcesz zrobic:");
            Console.WriteLine("1. Obliczenia logarytmiczne");
            Console.WriteLine("2. Operacje na ciagach");
            Console.WriteLine("3. Wyjdź z programu");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Niepoprawny wybor, sprobuj ponownie.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CalculateLogarithms();
                    break;
                case 2:
                    CalculateSequence();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybor, sprobuj ponownie.");
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

    static bool TryParseLogarithm(string expression, out double result)
    {
        result = 0.0;
        string[] parts = expression.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 2)
            return false;

        if (double.TryParse(parts[1], out double number))
        {
            if (parts[0].StartsWith("log_"))
            {
                if (double.TryParse(parts[0].Substring(4), out double baseNumber))
                {
                    result = Math.Log(number, baseNumber);
                    return true;
                }
            }
            else if (parts[0].Equals("log", StringComparison.OrdinalIgnoreCase))
            {
                result = Math.Log(number);
                return true;
            }
        }

        return false;
    }

    static void CalculateSequence()
    {
        Console.Clear();
        Console.WriteLine("Podaj długosc ciagu:");

        if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
        {
            Console.WriteLine("Niepoprawna długosc ciagu. Sprobuj ponownie.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Podaj elementy ciagu:");

        Dictionary<int, double> elements = new Dictionary<int, double>();

        for (int i = 1; i <= length; i++)
        {
            Console.Write($"{i} = ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Niepoprawna wartosc. Sprobuj ponownie.");
                i--;
                continue;
            }
            elements.Add(i, value);
        }

        CalculateAndPrintSequence(elements);
        Console.ReadLine();
    }

    static void CalculateAndPrintSequence(Dictionary<int, double> elements)
    {
        string sequenceType = GetSequenceType(elements);
        string monotonicity = GetMonotonicity(elements);

        Console.WriteLine($"Typ ciagu: {sequenceType}");
        Console.WriteLine($"Monotonicznosc ciagu: {monotonicity}");




        Console.WriteLine("Podaj numer indeksu (n) elementu ktorego wartosc chcesz poznac:");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > elements.Count)
        {
            Console.WriteLine("Niepoprawny numer indeksu. Sprobuj ponownie.");
            return;
        }

        Console.WriteLine($"Wartosc elementu indexu {index} ' go  jest rowna {elements[index]}");
    }

    static double CalculateCommonDifference(Dictionary<int, double> elements)
    {
        if (elements.Count < 2)
            return 0.0;

        double commonDifference = 0.0;
        int index = 1;

        foreach (var kvp in elements.OrderBy(kvp => kvp.Key))
        {
            if (index == 1)
            {
                index++;
                continue;
            }

            commonDifference += (kvp.Value - elements.ElementAt(index - 1).Value);
            index++;
        }

        return commonDifference / (elements.Count - 1);
    }

    static string GetSequenceType(Dictionary<int, double> elements)
    {
        bool isArithmetic = CheckArithmeticSequence(elements);
        bool isGeometric = CheckGeometricSequence(elements);

        if (isArithmetic)
            return "arytmetyczny";
        else if (isGeometric)
            return "geometryczny";
        else
            return "inny";
    }



    static double CalculateGeometric(double firstTerm, double commonRatio, int n)
    {
        return firstTerm * Math.Pow(commonRatio, n - 1);
    }

    static double CalculateArithmetic(double firstTerm, double commonDifference, int n)
    {
        return firstTerm + (n - 1) * commonDifference;
    }

    static bool CheckArithmeticSequence(Dictionary<int, double> elements)
    {
        double commonDifference = CalculateCommonDifference(elements);
        double firstTerm = elements[1];

        for (int i = 3; i <= elements.Count; i++)
        {
            if (elements[i] != CalculateArithmetic(firstTerm, commonDifference, i))
                return false;
        }

        return true;
    }


    static bool CheckGeometricSequence(Dictionary<int, double> elements)
    {
        double firstTerm = elements[1];
        double commonRatio = elements[2] / elements[1];

        for (int i = 3; i <= elements.Count; i++)
        {
            if (elements[i] != CalculateGeometric(firstTerm, commonRatio, i))
                return false;
        }

        return true;
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
            return "rosnacy";
        else if (isDecreasing)
            return "malejacy";
        else
            return "nierosnacy/nemlejacy";
    }
}
