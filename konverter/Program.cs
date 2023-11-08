using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

public class Figure
{
    public string Text { get; set; }

    public Figure() { }

    public Figure(string text)
    {
        Text = text;
    }
}

public class FileManager
{
    public static Figure LoadFile(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
        {
            Console.WriteLine("Указан некорректный путь");
            return null;
        }

        string extension = Path.GetExtension(path);
        Figure figure = null;

        try
        {
            switch (extension)
            {
                case ".txt":
                    string text = File.ReadAllText(path);
                    figure = new Figure(text);
                    Console.WriteLine("Файл успешно сохранен");
                    break;

                case ".json":
                    string json = File.ReadAllText(path);
                    figure = JsonSerializer.Deserialize<Figure>(json);
                    Console.WriteLine("Файл успешно сохранен");
                    break;

                case ".xml":
                    using (StreamReader reader = new StreamReader(path))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Figure));
                        figure = (Figure)serializer.Deserialize(reader);
                        Console.WriteLine("Файл успешно сохранен");
                    }
                    break;

                default:
                    Console.WriteLine("Неподдерживаемый формат файла");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Произошла ошибка при загрузке файла: " + e.Message);
        }

        return figure;
    }

    public static void SaveFile(string path, Figure figure)
    {
        if (string.IsNullOrWhiteSpace(path) || figure == null)
        {
            Console.WriteLine("Путь для сохранения не указан");
            return;
        }

        string directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        string extension = Path.GetExtension(path);

        try
        {
            switch (extension)
            {
                case ".txt":
                    File.WriteAllText(path, figure.Text);
                    break;

                case ".json":
                    string json = JsonSerializer.Serialize(figure);
                    File.WriteAllText(path, json);
                    break;

                case ".xml":
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Figure));
                        serializer.Serialize(writer, figure);
                    }
                    break;

                default:
                    Console.WriteLine("Неподдерживаемый формат файла");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Произошла ошибка при сохранении файла: " + e.Message);
        }
    }
}

public class TextEditor
{
    private Figure figure;
    private string filePath;

    public TextEditor(string filePath)
    {
        this.filePath = filePath;
        this.figure = FileManager.LoadFile(filePath);

        if (this.figure == null)
        {
            this.figure = new Figure("");
        }
    }

    public void PrintFigure()
    {
        Console.WriteLine($"Текст: {figure.Text}");
    }

    public void SaveFile()
    {
        Console.Write("Введите путь для сохранения файла: ");
        string newPath = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newPath))
        {
            FileManager.SaveFile(newPath, figure);
        }
        else
        {
            Console.WriteLine("Указан некорректный путь для сохранения файла. Повторите попытку.");
        }
    }


    public void ModifyFigureRealTime()
    {
        Console.WriteLine("Введите новый текст:");
        string input = Console.ReadLine();
        figure.Text += "\n" + input;
        Console.WriteLine("Текст успешно изменен.");
    }

    public void Run()
    {
        ConsoleKeyInfo keyInfo;

        do
        {
            PrintFigure();
            Console.WriteLine("Нажмите F1 чтобы сохранить, F2 чтобы редактировать, ESC чтобы выйти.");
            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.F1:
                    SaveFile();
                    break;

                case ConsoleKey.F2:
                    ModifyFigureRealTime();
                    break;

                case ConsoleKey.Escape:
                    Console.WriteLine("Вы вышли из режима редактирования. Возвращаемся в меню выбора файла.");
                    return;

                default:
                    Console.WriteLine("Неподдерживаемая операция");
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();

            TextEditor editor = new TextEditor(filePath);
            editor.Run();

            Console.WriteLine("Нажмите ESC для выхода из программы или любую другую клавишу, чтобы продолжить.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
