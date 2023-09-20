Console.WriteLine("Выберете действие, которое хотите выполнить:\n1. Сложить 2 числа\n2. Вычесть первое число из второго\n3. Перемножить 2 числа\n4. Разделить первое число на второе\n5. Возвести число в степень N\n6. Найти квадратный корень числа\n7. Найти 1 процент из числа\n8. Найти факториал числа\n9. Выйти из программы\n\n\n\n");
string? number = "0";

do
{
    Console.Write("Bыберете oперацию: ");
    number  = Console.ReadLine();
	switch (number)
	{
		case "1":
			Console.WriteLine("Введите 2 слагаемых:");
			double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine(a + b);
            Console.WriteLine("\n\n");
            break;
		case "2":
            Console.WriteLine("Введите сначала уменьшаемое, а потом вычитаемое:");
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            Console.WriteLine(a - b);
            Console.WriteLine("\n\n");
            break;
		case "3":
            Console.WriteLine("Введите 2 множителя");
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            Console.WriteLine(a * b);
            Console.WriteLine("\n\n");
            break;
		case "4":
            Console.WriteLine("Введите сначала числитель, а потом знаменатель");
            a = double.Parse(Console.ReadLine());
			b = double.Parse(Console.ReadLine());
            Console.WriteLine(a / b);
            Console.WriteLine("\n\n");
            break;
		case "5":
            Console.WriteLine("Введите сначала число, а потом его степень");
            a = double.Parse(Console.ReadLine());
			double N = double.Parse(Console.ReadLine());
            Console.WriteLine(Math.Pow(a, N));
            Console.WriteLine("\n\n");
			break;
		case "6":
            Console.WriteLine("Введите число для извлечения корня");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Корень: " + Math.Sqrt(a));
            Console.WriteLine("\n\n");
            break;
		case "7":
            Console.WriteLine("Введите число для извлечения 1-го процента:");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("1 процент: " + a / 100);
            Console.WriteLine("\n\n");
            break;
		case "8":
            Console.WriteLine("Введите число для вычисления его факториала");
            a = double.Parse(Console.ReadLine());
            int? num = 1;
            int? i = 1;
            while(i <= a)
            {
                num *= i;
                i++;
            }
            Console.WriteLine("Факториал: " + num);
            Console.WriteLine("\n\n");
            break;
		case "9":
            Console.WriteLine("Спасибо за использование нашего калькулятора...");
            break;
	}
}
while (number != "9");