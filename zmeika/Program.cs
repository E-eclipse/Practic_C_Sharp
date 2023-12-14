using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class SnakeGame
{
    private static readonly int Width = 30;
    private static readonly int Height = 10;
    private static readonly int Delay = 200;

    private static int score;
    private static int direction;
    private static bool isGameOver;

    private static Point snakeHead;
    private static List<Point> snakeBody;
    private static Point food;

    static void Main()
    {
        Console.WindowHeight = Height + 3;
        Console.WindowWidth = Width;

        Initialize();

        while (!isGameOver)
        {
            if (Console.KeyAvailable)
                ProcessInput();

            MoveSnake();
            CheckCollision();

            if (isGameOver)
                ShowGameOver();
            else
                Draw();

            Thread.Sleep(Delay);
        }

        Console.ReadLine();
    }

    static void Initialize()
    {
        score = 0;
        direction = 2;
        isGameOver = false;

        snakeHead = new Point(Width / 2, Height / 2);
        snakeBody = new List<Point>
    {
        snakeHead,
        new Point(snakeHead.X - 1, snakeHead.Y), 
        new Point(snakeHead.X - 2, snakeHead.Y)  
    };

        PlaceFood();
    }

    static void ProcessInput()
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.LeftArrow:
                if (direction != 2)
                    direction = 0;
                break;
            case ConsoleKey.UpArrow:
                if (direction != 3)
                    direction = 1;
                break;
            case ConsoleKey.RightArrow:
                if (direction != 0)
                    direction = 2;
                break;
            case ConsoleKey.DownArrow:
                if (direction != 1)
                    direction = 3;
                break;
            case ConsoleKey.Escape:
                isGameOver = true;
                break;
        }
    }

    static void MoveSnake()
    {
        Point newHead = new Point(snakeHead.X, snakeHead.Y);

        switch (direction)
        {
            case 0:
                newHead.X--;
                break;
            case 1:
                newHead.Y--;
                break;
            case 2:
                newHead.X++;
                break;
            case 3:
                newHead.Y++;
                break;
        }

        snakeHead = newHead;
        snakeBody.Insert(0, snakeHead);

        if (snakeHead.X == food.X && snakeHead.Y == food.Y)
        {
            score++;
            PlaceFood();
        }
        else
        {
            snakeBody.RemoveAt(snakeBody.Count - 1);
        }
    }

    static void CheckCollision()
    {
        if (snakeHead.X < 0 || snakeHead.X >= Width || snakeHead.Y < 0 || snakeHead.Y >= Height)
            isGameOver = true;

        for (int i = 1; i < snakeBody.Count; i++)
        {
            if (snakeHead.X == snakeBody[i].X && snakeHead.Y == snakeBody[i].Y)
                isGameOver = true;
        }
    }

    static void PlaceFood()
    {
        Random random = new Random();
        food = new Point(random.Next(0, Width), random.Next(0, Height));

        if (snakeBody.Any(segment => segment.X == food.X && segment.Y == food.Y))
            PlaceFood();
    }
    static void Draw()
    {
        Console.Clear();

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (x == snakeHead.X && y == snakeHead.Y)
                {
                    Console.Write("O");
                }
                else if (snakeBody.Any(segment => segment.X == x && segment.Y == y))
                {
                    Console.Write("o");
                }
                else if (x == food.X && y == food.Y)
                {
                    Console.Write("X");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine("Счет: " + score);
    }



    static void ShowGameOver()
    {
        Console.Clear();
        Console.WriteLine("Игра окончена!");
        Console.WriteLine("Счет: " + score);
        Console.WriteLine("Нажмите Enter.");
    }
}

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
