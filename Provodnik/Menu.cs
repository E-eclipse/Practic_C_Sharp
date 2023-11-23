using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolearrow
{
    public class Menu
    {
        public static int strelka(int min, int max)
        {
            int pos = 3;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine(">");

                key = Console.ReadKey();
                Console.SetCursorPosition(0, pos);
                Console.WriteLine(" ");

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (pos != min)
                        {
                            pos--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (pos != max)
                        {
                            pos++;
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            pos = -1;
                        }
                        return pos;

                }


            } while (key.Key != ConsoleKey.Enter);
            return pos;
        }
    }
}