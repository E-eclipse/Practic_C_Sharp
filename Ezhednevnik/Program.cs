using System;
using System.Collections.Generic;
using System.Globalization;

public class Program
{
    public const int MinPos = 1;
    public static int pos = MinPos;
    public static DateTime date = DateTime.Now;
    public static Dictionary<DateTime, List<Note>> notes = new Dictionary<DateTime, List<Note>>();

    public static void Main()
    {
        InitializeNotes();

        while (true)
        {
            DrawMenu();

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (pos != MinPos)
                        {
                            pos--;
                            ClearLine();
                            DrawMenu();
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (notes.ContainsKey(date) && pos != notes[date].Count)
                        {
                            pos++;
                            ClearLine();
                            DrawMenu();
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        date = date.AddDays(-1);
                        pos = MinPos;
                        ClearLine();
                        DrawMenu();
                        break;

                    case ConsoleKey.RightArrow:
                        date = date.AddDays(1);
                        pos = MinPos;
                        ClearLine();
                        DrawMenu();
                        break;

                    case ConsoleKey.E:
                        AddNote();
                        break;

                    case ConsoleKey.D:
                        AddDescriptionToNote();
                        break;

                    case ConsoleKey.Enter:
                        ShowEventDescription();
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }

    static void AddNote()
    {
        Console.Clear();
        Console.WriteLine("Введите название заметки: ");
        string title = Console.ReadLine();

        if (!notes.ContainsKey(date))
            notes[date] = new List<Note>();

        notes[date].Add(new Note(title, "", "", ""));

        Console.Clear();
    }

    static void DrawMenu()
    {
        Console.Clear();
        Console.WriteLine("Дата: " + date.ToString("d", CultureInfo.CreateSpecificCulture("ru-RU")));

        if (!notes.ContainsKey(date) || notes[date].Count == 0)
        {
            Console.WriteLine("Не найдено заметок на эту дату");
            return;
        }

        for (int i = 0; i < notes[date].Count; i++)
        {
            if (i + 1 == pos)
                Console.WriteLine("-> " + notes[date][i].Title);
            else
                Console.WriteLine("    " + notes[date][i].Title);
        }
    }

    static void AddDescriptionToNote()
    {
        if (notes.ContainsKey(date) && notes[date].Count > 0)
        {
            Console.Clear();
            Console.WriteLine("Введите описание для заметки '" + notes[date][pos - 1].Title + "':");
            notes[date][pos - 1].Description = Console.ReadLine();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Нет заметок для добавления описания.");
        }
    }

    static void ShowEventDescription()
    {
        if (!notes.ContainsKey(date) || notes[date].Count == 0)
        {
            Console.WriteLine("Нет заметок для просмотра");
            return;
        }

        Console.Clear();
        Console.WriteLine(notes[date][pos - 1]);
    }

    static void InitializeNotes()
    {
        notes[date] = new List<Note> { new Note("Заметки добавляются через кнопку E", "", "", "") };
    }

    static void ClearLine()
    {
        int cursor = Console.CursorTop;
        Console.SetCursorPosition(0, cursor);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursor);
    }
}

public class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Time { get; set; }

    public Note(string title, string description, string location, string time)
    {
        Title = title;
        Description = description;
        Location = location;
        Time = time;
    }

    public override string ToString()
    {
        return $"{Title}\n{Description}\n{Location}\n{Time}";
    }
}