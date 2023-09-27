Console.WriteLine("Выберете программу:\n" +
    "1. Угадай число\n" +
    "2. Таблица умножения\n" +
    "3. Делители числа\n" +
    "4. Выход");
string? number = "0";


do
{
    number = Console.ReadLine();
    switch (number)
    {
        case "1":
            Random rnd = new Random();
            int? value = rnd.Next(100);


            int? num = 0;
            while (num != value)
            {
                Console.WriteLine("Введите число");
                num = int.Parse(Console.ReadLine());
                if (num > value)
                {
                    Console.WriteLine("Введенное число больше загаданного");
                }
                else if (num < value)
                {
                    Console.WriteLine("Введенное число меньше загаданного");
                }
                else
                {
                    Console.WriteLine("Поздравляю, вы угадали число!!!");
                    break;
                }
            }

            Console.WriteLine("\n\n");

            break;

        case "2":
            int[,] table = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    table[i, j] = (i + 1) * (j + 1);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(table[i, j] + "\t");
                }
                Console.WriteLine();
            }


            break;


        case "3":
            Console.WriteLine("Введите число, для которого надо найти делители");
            num = int.Parse(Console.ReadLine());
            int? a = num;
            while (a != 1)
            {
                if (num % a == 0)
                {
                    Console.Write(a + " ");
                }
                a -= 1;

            }
            Console.WriteLine("\n\n");

            break;

        case "4":
            Console.WriteLine("Всего доброго!!!");
            break;









    }
}
while (number != "4");