using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt7
{
    public class CustomMenu
    {
        public static int SelectDirectory(int min, int max)
        {
            int position = 3;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, position);
                Console.WriteLine(">");

                key = Console.ReadKey();
                Console.SetCursorPosition(0, position);
                Console.WriteLine(" ");

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (position != min)
                        {
                            position--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (position != max)
                        {
                            position++;
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            position = -1;
                        }
                        return position;

                }


            } while (key.Key != ConsoleKey.Enter);
            return position;
        }
    }
    public static class AdditionalUtils
    {
        public static void ShowDirectoryInfo(string path)
        {
            while (true)
            {
                Console.Clear();
                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                List<string> allFiles = new List<string>();

                for (int i = 0; i < directories.Length; i++)
                {
                    allFiles.Add(directories[i]);
                }
                for (int i = 0; i < files.Length; i++)
                {
                    allFiles.Add(files[i]);
                }

                Console.WriteLine("        Имя   " + "                                          Дата изменения");
                Console.WriteLine("========================================================================================================================");
                foreach (string directory in directories)
                {
                    var createDate = Directory.GetCreationTime(directory);

                    Console.Write(" " + directory);

                    Console.SetCursorPosition(40, Console.CursorTop);
                    Console.WriteLine("            |" + createDate + "|");
                }
                foreach (string file in files)
                {
                    var createDate = Directory.GetCreationTime(file);
                    Console.Write(" " + file);
                    Console.SetCursorPosition(40, Console.CursorTop);
                    Console.Write("            |" + createDate + "|\n");
                }
                Console.WriteLine("========================================================================================================================");

                int position = CustomMenu.SelectDirectory(2, directories.Length + files.Length + 1);
                if (position == -1)
                {
                    return;
                }
                else
                {
                    try
                    {
                        ShowDirectoryInfo(allFiles[position-2]);

                    }
                    catch (IOException)
                    {
                        Process.Start(new ProcessStartInfo { FileName = allFiles[position], UseShellExecute = true });
                    }
                }
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            do
            {
                DriveInfo[] drivesInfo = DriveInfo.GetDrives();

                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("Этот компьютер\n");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("========================================================================================================================");
                Console.SetCursorPosition(1, 2);
                Console.WriteLine("Устройства и диски: ");

                foreach (var drive in drivesInfo)
                {
                    Console.WriteLine
                    (" " + drive.Name + " " + drive.AvailableFreeSpace / 1073741824 + " ГБ" + " свободно из " + drive.TotalSize / 1073741824 + " ГБ");
                }

                int position = CustomMenu.SelectDirectory(3, drivesInfo.Length + 2);
                if (position == -1)
                {
                    return;
                }
                else
                {
                    AdditionalUtils.ShowDirectoryInfo(drivesInfo[position - 3].RootDirectory.FullName);
                }
            } while (true);
        }
    }
}