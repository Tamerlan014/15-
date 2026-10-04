using System.Numerics;

internal static class Program
{
    private static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Выберите задачу (1–15):");
        for (int i = 1; i <= 15; i++)
            Console.WriteLine($"{i}. {GetTaskName(i)}");

        Console.Write("Номер задачи: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 15)
        {
            Console.WriteLine("Введите номер задачи от 1 до 15.");
            return;
        }

        switch (choice)
        {
            case 1: Factorial(); break;
            case 2: CountDigits(); break;
            case 3: SumDigits(); break;
            case 4: ReverseNumber(); break;
            case 5: CheckPrime(); break;
            case 6: PrimesUpToN(); break;
            case 7: GreatestCommonDivisor(); break;
            case 8: AverageArray(); break;
            case 9: SecondLargest(); break;
            case 10: ReverseArray(); break;
            case 11: CountVowels(); break;
            case 12: CheckPalindrome(); break;
            case 13: RockPaperScissors(); break;
            case 14: GuessNumber(); break;
            case 15: StudentSystem(); break;
        }
    }

    private static string GetTaskName(int number) => number switch
    {
        1 => "Факториал числа",
        2 => "Количество цифр",
        3 => "Сумма цифр",
        4 => "Перевернуть число",
        5 => "Проверка на простое число",
        6 => "Простые числа до N",
        7 => "НОД двух чисел",
        8 => "Среднее значение массива",
        9 => "Второе максимальное число массива",
        10 => "Перевернуть массив",
        11 => "Подсчёт гласных",
        12 => "Проверка палиндрома",
        13 => "Камень, ножницы и бумага",
        14 => "Угадай число — 7 попыток",
        15 => "Мини-система студентов",
        _ => "Неизвестная задача"
    };

    private static void Factorial()
    {
        int n = ReadInt("Введите N: ");
        if (n < 0)
        {
            Console.WriteLine("Факториал отрицательного числа не определён.");
            return;
        }

        BigInteger result = 1;
        for (long i = 2; i <= n; i++)
            result *= i;

        Console.WriteLine($"Факториал: {result}");
    }

    private static void CountDigits()
    {
        int number = ReadInt("Введите число: ");
        long value = Math.Abs((long)number);
        int digits = 0;

        if (value == 0)
            digits = 1;
        else
            while (value > 0)
            {
                digits++;
                value /= 10;
            }

        Console.WriteLine($"Количество цифр: {digits}");
    }

    private static void SumDigits()
    {
        int number = ReadInt("Введите число: ");
        long value = Math.Abs((long)number);
        int sum = 0;

        while (value > 0)
        {
            sum += (int)(value % 10);
            value /= 10;
        }

        Console.WriteLine($"Сумма цифр: {sum}");
    }

    private static void ReverseNumber()
    {
        int number = ReadInt("Введите число: ");
        long value = Math.Abs((long)number);
        long reversed = 0;

        while (value > 0)
        {
            reversed = reversed * 10 + value % 10;
            value /= 10;
        }

        if (number < 0)
            reversed = -reversed;

        Console.WriteLine($"Перевернутое число: {reversed}");
    }

    private static void CheckPrime()
    {
        int number = ReadInt("Введите число: ");
        bool isPrime = number > 1;

        for (int divisor = 2; isPrime && divisor <= number / divisor; divisor++)
            if (number % divisor == 0)
                isPrime = false;

        Console.WriteLine(isPrime ? "Число простое" : "Число не простое");
    }

    private static void PrimesUpToN()
    {
        int n = ReadInt("Введите N: ");
        for (int number = 2; number <= n; number++)
        {
            bool isPrime = true;
            for (int divisor = 2; divisor <= number / divisor; divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
                Console.Write($"{number} ");
        }

        Console.WriteLine();
    }

    private static void GreatestCommonDivisor()
    {
        long a = Math.Abs((long)ReadInt("Первое число: "));
        long b = Math.Abs((long)ReadInt("Второе число: "));

        while (b != 0)
        {
            long remainder = a % b;
            a = b;
            b = remainder;
        }

        Console.WriteLine($"НОД: {a}");
    }

    private static void AverageArray()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        long sum = 0;
        foreach (int number in numbers)
            sum += number;

        Console.WriteLine($"Массив: {string.Join(" ", numbers)}");
        Console.WriteLine($"Среднее: {(double)sum / numbers.Length}");
    }

    private static void SecondLargest()
    {
        int[] numbers = { 15, 8, 27, 10, 21 };
        int max = int.MinValue;
        int secondMax = int.MinValue;
        bool hasMax = false;
        bool hasSecondMax = false;

        foreach (int number in numbers)
        {
            if (!hasMax || number > max)
            {
                if (hasMax)
                {
                    secondMax = max;
                    hasSecondMax = true;
                }

                max = number;
                hasMax = true;
            }
            else if (number != max && (!hasSecondMax || number > secondMax))
            {
                secondMax = number;
                hasSecondMax = true;
            }
        }

        Console.WriteLine($"Массив: {string.Join(" ", numbers)}");
        if (hasSecondMax)
            Console.WriteLine($"Второе максимальное: {secondMax}");
        else
            Console.WriteLine("В массиве нет второго различного числа.");
    }

    private static void ReverseArray()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Было: {string.Join(" ", numbers)}");

        for (int left = 0, right = numbers.Length - 1; left < right; left++, right--)
        {
            int temp = numbers[left];
            numbers[left] = numbers[right];
            numbers[right] = temp;
        }

        Console.WriteLine($"Стало: {string.Join(" ", numbers)}");
    }

    private static void CountVowels()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine() ?? "";
        const string vowels = "аеёиоуыэюя";
        int count = 0;

        foreach (char character in text.ToLowerInvariant())
            if (vowels.Contains(character))
                count++;

        Console.WriteLine($"Количество гласных: {count}");
    }

    private static void CheckPalindrome()
    {
        Console.Write("Введите слово: ");
        string text = (Console.ReadLine() ?? "").ToLowerInvariant();
        bool isPalindrome = true;

        for (int i = 0; i < text.Length / 2; i++)
            if (text[i] != text[text.Length - 1 - i])
            {
                isPalindrome = false;
                break;
            }

        Console.WriteLine(isPalindrome ? "Палиндром" : "Не палиндром");
    }

    private static void RockPaperScissors()
    {
        string[] choices = { "камень", "ножницы", "бумага" };
        Console.Write("Ваш выбор (камень, ножницы, бумага): ");
        string userChoice = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

        if (Array.IndexOf(choices, userChoice) == -1)
        {
            Console.WriteLine("Неизвестный выбор.");
            return;
        }

        string computerChoice = choices[Random.Shared.Next(choices.Length)];
        Console.WriteLine($"Компьютер: {computerChoice}");

        if (userChoice == computerChoice)
            Console.WriteLine("Ничья!");
        else if (
            (userChoice == "камень" && computerChoice == "ножницы") ||
            (userChoice == "ножницы" && computerChoice == "бумага") ||
            (userChoice == "бумага" && computerChoice == "камень"))
            Console.WriteLine("Вы победили!");
        else
            Console.WriteLine("Вы проиграли!");
    }

    private static void GuessNumber()
    {
        int secretNumber = Random.Shared.Next(1, 101);
        bool guessed = false;

        for (int attempt = 1; attempt <= 7; attempt++)
        {
            int guess = ReadInt($"Попытка {attempt}/7: ");
            if (guess == secretNumber)
            {
                Console.WriteLine($"Вы угадали за {attempt} попыток!");
                guessed = true;
                break;
            }

            Console.WriteLine(guess < secretNumber
                ? "Загаданное число больше."
                : "Загаданное число меньше.");
        }

        if (!guessed)
            Console.WriteLine($"Попытки закончились. Было загадано число {secretNumber}.");
    }

    private static void StudentSystem()
    {
        int count = ReadInt("Количество студентов: ");
        if (count <= 0)
        {
            Console.WriteLine("Количество студентов должно быть больше нуля.");
            return;
        }

        string[] names = new string[count];
        double[] grades = new double[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Имя студента {i + 1}: ");
            names[i] = Console.ReadLine() ?? "";
            grades[i] = ReadDouble($"Оценка студента {i + 1}: ");
        }

        double sum = 0;
        int bestIndex = 0;
        for (int i = 0; i < count; i++)
        {
            sum += grades[i];
            if (grades[i] > grades[bestIndex])
                bestIndex = i;
        }

        double average = sum / count;
        int aboveAverage = 0;
        Console.WriteLine("\nСтуденты:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{names[i]} — {grades[i]}");
            if (grades[i] > average)
                aboveAverage++;
        }

        Console.WriteLine($"Средняя оценка: {average:F1}");
        Console.WriteLine($"Лучший студент: {names[bestIndex]} — {grades[bestIndex]}");
        Console.WriteLine($"Выше среднего: {aboveAverage}");
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int value))
            return value;

        throw new FormatException("Ожидалось целое число.");
    }

    private static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        if (double.TryParse(Console.ReadLine(), out double value))
            return value;

        throw new FormatException("Ожидалось число.");
    }
}
