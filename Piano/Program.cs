ConsoleKeyInfo txt = Console.ReadKey(true);


while (true)
{
    txt = Console.ReadKey(true);
    if (txt.Key == ConsoleKey.F1)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Для переключения между октавами нажмите один раз F2/дважды нажмите F1\n\n\n");
        Console.WriteLine("1 октава");
        while (txt.Key != ConsoleKey.F2)
        {
            if (txt.Key == ConsoleKey.D1)
            {
                Console.Beep(523, 100);
            }

            if (txt.Key == ConsoleKey.Q)
            {
                Console.Beep(554, 100);
            }
            if (txt.Key == ConsoleKey.D2)
            {
                Console.Beep(587, 100);
            }
            if (txt.Key == ConsoleKey.W)
            {
                Console.Beep(622, 100);
            }
            if (txt.Key == ConsoleKey.D3)
            {
                Console.Beep(659, 100);
            }
            else if (txt.Key == ConsoleKey.E)
            {
                Console.Beep(698, 100);
            }
            else if (txt.Key == ConsoleKey.D4)
            {
                Console.Beep(740, 100);
            }
            else if (txt.Key == ConsoleKey.R)
            {
                Console.Beep(784, 100);
            }
            else if (txt.Key == ConsoleKey.D5)
            {
                Console.Beep(831, 100);
            }
            txt = Console.ReadKey(true);
        }
    }

    if (txt.Key == ConsoleKey.F2)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("\n\n\n\n2 октава");
        while (txt.Key != ConsoleKey.F1)
        {
            if (txt.Key == ConsoleKey.D1)
            {
                Console.Beep(2100, 100);
            }
            else if (txt.Key == ConsoleKey.Q)
            {
                Console.Beep(2200, 100);
            }
            else if (txt.Key == ConsoleKey.D2)
            {
                Console.Beep(2300, 100);
            }
            else if (txt.Key == ConsoleKey.W)
            {
                Console.Beep(2400, 100);
            }
            else if (txt.Key == ConsoleKey.D3)
            {
                Console.Beep(2500, 100);
            }
            else if (txt.Key == ConsoleKey.E)
            {
                Console.Beep(2600, 100);
            }
            else if (txt.Key == ConsoleKey.D4)
            {
                Console.Beep(2700, 100);
            }
            else if (txt.Key == ConsoleKey.R)
            {
                Console.Beep(2800, 100);
            }
            else if (txt.Key == ConsoleKey.D5)
            {
                Console.Beep(2900, 100);
            }
            txt = Console.ReadKey(true);
        }
    }

}

if (txt.Modifiers.HasFlag(ConsoleModifiers.Alt))
{
    Console.WriteLine();    
}