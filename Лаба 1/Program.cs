using System;

namespace ConsoleApp1
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
            /*try
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
            }*/
            ///zadanie1();
            zadanie2();
        }

        private static void zadanie1()
        {
            try
            {
                Console.Write("Введите число n: ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Введите число m: ");
                int m = int.Parse(Console.ReadLine());
                Console.Write("Введите число x: ");
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine("Результат вычисления n++ + m--: " + (n++ + m--).ToString());
                Console.WriteLine("Результат вычисления n * m < n++: " + (n * m < n++).ToString());
                Console.WriteLine("Результат вычисления n++ + m--: " + (n-- > ++m).ToString());
                Console.WriteLine("Результат вычисления 2^x * x * cos(x) + 1: " + (Math.Pow(2, x) * x * Math.Cos(x) + 1).ToString());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа");
                Console.ResetColor();
                zadanie1();
            }
            ///zadanie1();
        }

        private static void zadanie2()
        {
            try
            {
                Console.Write("Введите число x: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("Введите число y: ");
                double y = double.Parse(Console.ReadLine());
                Console.WriteLine((((x >= 0) || (y >= 0)) && (Math.Sqrt(x * x + y * y) <= 1)).ToString());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа");
                Console.ResetColor();
                zadanie2();
            }
            zadanie2();
        }

        private static void zadanie3()
        {
            {
                float a = 10;
                float b = 0.01f;
                Console.WriteLine("float: " + ((Math.Pow(a + b, 4) - (Math.Pow(a, 4) + 4 * Math.Pow(a, 3) * b)) / (6 * Math.Pow(a, 2) * Math.Pow(b, 2) + 4 * a * Math.Pow(b, 3) + Math.Pow(b, 4))).ToString());
            }
            {
                double a = 10;
                double b = 0.01;
                Console.WriteLine("double: " + ((Math.Pow(a + b, 4) - (Math.Pow(a, 4) + 4 * Math.Pow(a, 3) * b)) / (6 * Math.Pow(a, 2) * Math.Pow(b, 2) + 4 * a * Math.Pow(b, 3) + Math.Pow(b, 4))).ToString());
            }
        }
    }
}