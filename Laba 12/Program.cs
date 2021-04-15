using System;

namespace Laba_12
{
    internal class Program
    {
        private static bool Menu()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nМЕНЮ\n");
                Console.ResetColor();
                Console.Write("   1. Задание 1\n" +
                              "   2. Задание 2\n" +
                              "   3. Задание 3\n" +
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
                            Task1 task1 = new Task1();
                            task1.Run();
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
                        }
                        return true;

                    case 4:
                        Console.Write("Нажмите любую клавишу для выхода...");
                        Console.ReadKey();
                        return false;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат числа");
                        Console.ResetColor();
                        Console.WriteLine();
                        return true;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа");
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