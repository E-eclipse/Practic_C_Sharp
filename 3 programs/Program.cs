using System;

Console.WriteLine("Выберете программу:\n" +
    "1. Угадай число\n" +
    "2. Таблица умножения\n" +
    "3. Делители числа\n" +
    "4. Выход");
string? number = "0";


static void randnum()
{
    Random rnd = new Random();
    int? value = rnd.Next(100);


    int? num = 0;
    while (num != value)
    {
        Console.WriteLine("Введите число");
        num = int.Parse(Console.ReadLine());
        if (num > value)
        {
            Console.WriteLine("Введенное число больше загаданного\n");
        }
        else if (num < value)
        {
            Console.WriteLine("Введенное число меньше загаданного\n");
        }
        else
        {
            Console.WriteLine("Поздравляю, вы угадали число!!!\n");
            break;
        }
    }

    Console.WriteLine("\n\n");


}

static void num_num()
{

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


    Console.WriteLine("\n\n");
    }

}

static void dels()
{
    Console.Write("Введите число, для которого надо найти делители: ");
    int? num = int.Parse(Console.ReadLine());
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
}






do
{
    number = Console.ReadLine();
    switch (number)
    {
        case "1":

            randnum();

            break;

        case "2":

            num_num();

            break;


        case "3":
            
            dels();

            break;

        case "4":
            Console.WriteLine("Всего доброго!!!");
            break;









    }
}
while (number != "4");


