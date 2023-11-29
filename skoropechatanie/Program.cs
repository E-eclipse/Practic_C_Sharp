using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

class TypeSpeedTest
{
    static void Main()
    {
        string text = "Здесь нужно что-то другое написать)";
        int currentCharIndex = 0;
        int correctCount = 0;
        int mistakeCount = 0;
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Добро пожаловать в тест на скоропечатание!");
        Console.WriteLine("Наберите этот текст:");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();

        Console.WriteLine("Нажмите клавишу Enter, чтобы начать...");
        Console.ReadLine();
        Console.Clear();
        Console.CursorVisible = false;

        stopwatch.Start();

        Console.WriteLine(text);

        while (currentCharIndex < text.Length)
        {
            Console.SetCursorPosition(currentCharIndex, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text[currentCharIndex]);

            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.KeyChar == text[currentCharIndex])
            {
                Console.SetCursorPosition(currentCharIndex, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(text[currentCharIndex]);

                currentCharIndex++;
                correctCount++;
            }
            else
            {
                Console.SetCursorPosition(currentCharIndex, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(text[currentCharIndex]);

                mistakeCount++;
            }
        }

        stopwatch.Stop();

        Console.Clear();
        Console.CursorVisible = true;

        Console.WriteLine("Тест выполнен!");
        Console.WriteLine($"Затраченное время: {stopwatch.Elapsed}");
        Console.WriteLine($"Символов набрано: {correctCount}");
        Console.WriteLine($"Ошибок сделано: {mistakeCount}");

        Console.WriteLine("Нажмите любую(почти) клавишу, чтобы выйти из программы...");
        Console.ReadLine();
    }
}