using System;

namespace Лаба_7
{
    public class Program
    {
        private static DiapasonArray arr = new DiapasonArray();
        private static bool prisv = false;

        public static bool Intersection(Diapason dp1, Diapason dp2)
        {
            {
                double x1, x2, y1, y2;
                if (dp1.X > dp1.Y)
                {
                    x2 = dp1.Y;
                    y2 = dp1.X;
                }
                else
                {
                    y2 = dp1.Y;
                    x2 = dp1.X;
                }
                if (dp2.X > dp2.Y)
                {
                    x1 = dp2.Y;
                    y1 = dp2.X;
                }
                else
                {
                    y1 = dp2.Y;
                    x1 = dp2.X;
                }
                if (x1 >= x2 & x1 <= y2)
                    return true;
                if (y1 >= x2 & y1 <= y2)
                    return true;
                if (x2 >= x1 & x2 <= y1)
                    return true;
                if (y2 >= x1 & y2 <= y1)
                    return true;
                return false;
            }
        }

        private static double DoubleVvod(string predlojenie_vvoda, double bolshe = int.MinValue, double menshe = int.MaxValue)
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

        private static int IntVvod(string predlojenie_vvoda, int bolshe = int.MinValue, int menshe = int.MaxValue)
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

        private static bool Menu()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nМЕНЮ\n");
                Console.ResetColor();
                Console.Write("   1. Задание 1\n" +
                    "   2. Задание 3\n" +
                    "   3. Показать каунтеры\n" +
                    "   4. Выход из программы\n" +
                    "\nВыберите задание: ");
                string str;
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Diapason dp1 = new Diapason(DoubleVvod("Введите первую границу первого диапазона: "), DoubleVvod("Введите вторую границу первого диапазона: "));
                            Diapason dp2 = new Diapason(DoubleVvod("Введите первую границу второго диапазона: "), DoubleVvod("Введите вторую границу второго диапазона: "));
                            Console.WriteLine($"Пересекается ли первый Diapason и второй Diapason: {dp1.Intersection(dp2)}\n" +
                                $"Пересекается ли второй Diapason и первый Diapason: {dp2.Intersection(dp1)}\n" +
                                $"Пересекается ли второй Diapason и второй Diapason: {dp2.Intersection(dp2)}\n" +
                                $"Пересекается ли первый Diapason и второй Diapason (статическая внешняя функция): {Intersection(dp1, dp2)}\n" +
                                $"Пересекается ли второй Diapason и первый Diapason (статическая внешняя функция): {Intersection(dp2, dp1)}\n");
                        }
                        Console.WriteLine();
                        return true;

                    case 2:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            while (MenuZadacha3()) { }
                        }
                        Console.WriteLine();
                        return true;

                    case 3:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.WriteLine($"Количество экземпляров Diapason: {Diapason.count}\n" +
                                $"Количество экземпляров DiapasonArray: {DiapasonArray.count}");
                        }
                        return true;

                    case 4:
                        Console.Write("Нажмите любую клавишу для выхода...");
                        Console.ReadKey();
                        return false;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат числа\n");
                        Console.ResetColor();
                        Console.WriteLine();
                        return true;
                }
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа\n");
                Console.ResetColor();
                return true;
            }
        }

        private static bool MenuZadacha3()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nМЕНЮ ЗАДАЧИ 3\n");
                Console.ResetColor();
                Console.Write("   1. Без ввода\n" +
                    "   2. Рандомное заполнение\n" +
                    "   3. Ручное заполнение\n" +
                    "   4. Вывести массив\n" +
                    "   5. Показать каунтеры\n" +
                    "   6. Вернуться в основное меню\n" +
                    "\nВыберите задание: ");
                string str;
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            arr = new DiapasonArray();
                            Console.WriteLine("Массив создан");
                            prisv = true;
                        }
                        Console.WriteLine();
                        return true;

                    case 2:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            int n = IntVvod("Введите количество элементов массива: ", 0);
                            double min = 0, max = 0;
                            while (true)
                            {
                                min = DoubleVvod("Введите минимальное значение массива: ");
                                max = DoubleVvod("Введите максимальное значение массива: ");
                                if (min > max)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Минимальное значение больше максимального значения");
                                    Console.ResetColor();
                                    continue;
                                }
                                if (double.IsInfinity(max - min))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Использованы недопустимые значения");
                                    Console.ResetColor();
                                    continue;
                                }
                                break;
                            }
                            arr = new DiapasonArray(n, min, max);
                            Console.WriteLine("Массив создан");
                            prisv = true;
                        }
                        Console.WriteLine();
                        return true;

                    case 3:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            arr = new DiapasonArray(double.MinValue, double.MaxValue);
                            Console.WriteLine("Массив создан");
                            prisv = true;
                        }
                        Console.WriteLine();
                        return true;

                    case 4:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            if (prisv)
                                arr.Vivod();
                            else
                                Console.WriteLine("Сначала требуется присвоить значение");
                        }
                        Console.WriteLine();
                        return true;

                    case 5:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.WriteLine($"Количество экземпляров Diapason: {Diapason.count}\n" +
                                $"Количество экземпляров DiapasonArray: {DiapasonArray.count}");
                        }
                        return true;

                    case 6:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        return false;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат числа\n");
                        Console.ResetColor();
                        Console.WriteLine();
                        return true;
                }
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа\n");
                Console.ResetColor();
                return true;
            }
        }

        private static void Main(string[] args)
        {
            while (Menu()) { }
        }
    }
}