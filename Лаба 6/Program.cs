using System;
using System.Collections.Generic;

namespace Лаба_6
{
    internal class Program
    {
        public static Random rnd = new Random();

        public const int max =
            //0;
            int.MaxValue;

        public const int min =
            //0;
            int.MinValue;

        public static double DoubleVvod(string predlojenie_vvoda, double bolshe = int.MinValue, double menshe = int.MaxValue)
        {
            double n;
            bool vihod = false;
            do
            {
                Console.Write(predlojenie_vvoda);
                if (!double.TryParse(Console.ReadLine(), out n))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
                else if (n > menshe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Число больше разрешенного");
                    Console.ResetColor();
                }
                else if (n < bolshe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Число меньше разрешенного");
                    Console.ResetColor();
                }
                else
                {
                    vihod = true;
                }
            } while (!vihod);
            return n;
        }

        public static int IntVvod(string predlojenie_vvoda, int bolshe = int.MinValue, int menshe = int.MaxValue)
        {
            int n;
            bool vihod = false;
            do
            {
                Console.Write(predlojenie_vvoda);
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
                else if (n > menshe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Число больше разрешенного");
                    Console.ResetColor();
                }
                else if (n < bolshe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Число меньше разрешенного");
                    Console.ResetColor();
                }
                else
                {
                    vihod = true;
                }
            } while (!vihod);
            return n;
        }

        public static string StringVvod(string predlojenie_vvoda)
        {
            bool vihod = false;
            string s;
            do
            {
                Console.Write(predlojenie_vvoda);
                s = Console.ReadLine();
                if (s.IndexOfAny(new char[] { '.', '!', '?' }) == s.LastIndexOfAny(new char[] { '.', '!', '?' }))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Меньше двух предложений");
                    Console.ResetColor();
                }
                else
                    vihod = true;
            } while (!vihod);
            return s;
        }

        public static double[,] DoRandMas(int n, int m)
        {
            double[,] mas = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = rnd.Next(min, max) * rnd.NextDouble();
                }
            }
            return mas;
        }

        public static double[,] DoVvodMas(int n, int m)
        {
            double[,] mas = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = DoubleVvod($"Пожалуйста, введите число на позиции {i + 1} строка {j + 1} столбец: ");
                }
            }
            return mas;
        }

        public static void VivodDvumerMas(double[,] mas, bool skobka = true)
        {
            if (mas.Length > 0)
            {
                if (skobka) Console.Write("[");
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    if (skobka) Console.Write("[");
                    for (int j = 0; j < mas.GetLength(1) - 1; j++)
                        Console.Write($"{mas[i, j]}, ");
                    Console.Write(mas[i, mas.GetLength(1) - 1]);
                    if (skobka)
                        if (i != mas.GetLength(0) - 1) Console.Write("],");
                        else Console.Write("]");
                    if (i != mas.GetLength(0) - 1) Console.WriteLine();
                }
                if (skobka) Console.WriteLine("]");
            }
            else
                if (skobka) Console.WriteLine("Массив пустой");
        }

        public static void Otdelit()
        {
            string str;
            str = "=";
            str = str.PadRight(Console.WindowWidth, '=');
            Console.WriteLine(str);
            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
        }

        public static void OsnMenu()
        {
            try
            {
                int u;
                bool vihod = false;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nМЕНЮ\n");
                    Console.ResetColor();
                    Console.Write("   1. Задача 1\n" +
                        "   2. Задача 2\n" +
                        "   3. Выход из программы\n" +
                        "\nВыберите задание: ");
                    if (!int.TryParse(Console.ReadLine(), out u))
                    {
                        Otdelit();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат числа");
                        Console.ResetColor();
                    }
                    else
                        switch (u)
                        {
                            case 1:
                                Otdelit();
                                Zadacha1();
                                break;

                            case 2:
                                Otdelit();
                                Zadacha2();
                                break;

                            case 3:
                                Otdelit();
                                Console.Write("Нажмите любую клавишу для выхода...");
                                Console.ReadKey();
                                vihod = true;
                                break;

                            default:
                                Otdelit();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неверный формат числа");
                                Console.ResetColor();
                                break;
                        }
                } while (!vihod);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Непредвиденная ошибка. Перезапуск программы.");
                Console.ResetColor();
                OsnMenu();
            }
        }

        public static double[,] MenuViborVvoda()
        {
            int u;
            int n = IntVvod("Введите количество строк в массиве: ", 0);
            int m = IntVvod("Введите количество столбцов в массиве: ", 0);
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nВЫБЕРИТЕ ТИП ВВОДА\n");
                Console.ResetColor();
                Console.Write("   1. Ручной\n" +
                    "   2. С помощью ДСЧ\n" +
                    "\nВыберите задание: ");
                if (!int.TryParse(Console.ReadLine(), out u))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
                else
                    switch (u)
                    {
                        case 1:
                            return DoVvodMas(n, m);

                        case 2:
                            return DoRandMas(n, m);

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неверный формат числа");
                            Console.ResetColor();
                            continue;
                    }
            } while (true);
        }

        public static double[,] DelStrokiWith(double chislo, double[,] mas)
        {
            List<int> del = new List<int>();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] == chislo)
                    {
                        del.Add(i);
                        break;
                    }
                }
            }
            if (del.Count != 0)
            {
                double[,] newmas = new double[mas.GetLength(0) - del.Count, mas.GetLength(1)];
                int g;
                int m = 0;
                bool tf;
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    tf = true;
                    for (g = 0; (del[g] <= i) && (g < del.Count); g++)
                        if (del[g] == i)
                        {
                            tf = false;
                            break;
                        }
                    if (tf)
                    {
                        for (int j = 0; j < mas.GetLength(1); j++)
                        {
                            newmas[m, j] = mas[i, j];
                        }
                        m++;
                    }
                }
                return newmas;
            }
            else
                return mas;
        }

        public static string DelLastAndFirst(string s)
        {
            s = s.Substring(s.IndexOfAny(new char[] { '.', '!', '?' }) + 1);
            return s.Remove(s.LastIndexOfAny(new char[] { '.', '!', '?' }, s.LastIndexOfAny(new char[] { '.', '!', '?' }) - 1) + 1);
        }

        public static void Zadacha1()
        {
            double[,] mas = MenuViborVvoda();
            VivodDvumerMas(mas);
            mas = DelStrokiWith(DoubleVvod("Введите число для поиска: "), mas);
            VivodDvumerMas(mas);
        }

        public static void Zadacha2()
        {
            string s = StringVvod("Введите строку из двух или более предложений:\n");
            Console.WriteLine($"Строка после удаления первого и последнего предложения:\n{DelLastAndFirst(s)}");
        }

        private static void Main(string[] args)
        {
            OsnMenu();
        }
    }
}