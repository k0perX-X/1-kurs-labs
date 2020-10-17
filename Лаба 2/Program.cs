using System;

namespace Лаба_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            main();
            Console.Write("Нажмите любую клавишу для выхода из программы");
            Console.ReadKey();
        }

        private static void main()
        {
            try
            {
                Console.Write("Выберете задание (1/2/3): ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        zadanie1();
                        break;

                    case 2:
                        zadanie2();
                        break;

                    case 3:
                        zadanie3();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат числа");
                        Console.ResetColor();
                        main();
                        break;
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа");
                Console.ResetColor();
                main();
            }
            ///zadanie1();
            ///zadanie2();
            ///zadanie3();
        }

        private static void zadanie1()
        {
            try
            {
                Console.Write("Введите число n: ");
                int n = int.Parse(Console.ReadLine());
                if (n < 0) throw new ArgumentNullException();
                else if (n == 0) Console.WriteLine("Введена пустая последовательность");
                else
                {
                    int x = int.Parse(Console.ReadLine());
                    int max = x;
                    int min = x;
                    for (int i = 1; i < n; i++)
                    {
                        x = int.Parse(Console.ReadLine());
                        if (x < min) min = x;
                        else if (x > max) max = x;
                    }
                    Console.WriteLine("Разность минимального и максимального: " + (min - max).ToString());
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа");
                Console.ResetColor();
            }
            ///zadanie1();
        }

        private static void zadanie2()
        {
            try
            {
                int x;
                int max = int.MinValue;
                int maxi = -1;
                for (int i = 1; (x = int.Parse(Console.ReadLine())) != 0; i++)
                {
                    if (x >= max)
                    {
                        max = x;
                        maxi = i;
                    }
                }
                if (maxi != -1) Console.WriteLine("Номер последнего максимального элемента в этой последовательности: " + maxi.ToString());
                else Console.WriteLine("Введена пустая последовательность");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа");
                Console.ResetColor();
            }
            ///zadanie2();
        }

        private static void zadanie3()
        {
            try
            {
                bool prost = true;
                Console.Write("Введите число k: ");
                int k = int.Parse(Console.ReadLine());
                if (k <= 1) throw new ArgumentNullException();
                for (int i = 2; i <= k / 2; i++)
                {
                    if (k % i == 0)
                    {
                        prost = false;
                        break;
                    }
                }
                if (prost)
                {
                    Console.WriteLine($"Число {k} простое");
                }
                else
                {
                    Console.WriteLine($"Число {k} не простое");
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа");
                Console.ResetColor();
            }
            ///zadanie3();
        }
    }
}