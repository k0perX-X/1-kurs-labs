using Laba_10;
using System;
using System.Collections;

namespace Laba_11
{
    public static class Task1
    {
        private static Hashtable ht = new Hashtable(20);

        private static Vehicle vehicle = new Vehicle();
        private static Car car = new Car();
        private static Train train = new Train();
        private static Express express = new Express();

        public static void Run()
        {
            while (MenuTask1()) { }
        }

        private static bool MenuTask1()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nМЕНЮ ЗАДАЧИ  1\n");
                Console.ResetColor();
                Console.Write("   1.  Добавить в коллекцию\n" +
                              "   2.  Удалить из коллекции\n" +
                              "   3.  Вывести элемент коллекции\n" +
                              "   4.  Печать количества элементов типа Vehicle\n" +
                              "   5.  Печать количества элементов типа Car\n" +
                              "   6.  Печать количества элементов типа Train\n" +
                              "   7.  Печать количества элементов типа Express\n" +
                              "   8.  Печать всех элементов типа Vehicle\n" +
                              "   9.  Печать всех элементов типа Car\n" +
                              "   10. Печать всех элементов типа Train\n" +
                              "   11. Печать всех элементов типа Express\n" +
                              "   12. Печать всей коллекции\n" +
                              "   13. Проверка создания копии коллекции\n" +
                              "   14. Выйти в основное меню\n" +
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
                            Console.Write("Количество элементов: ");
                            int count;
                            while (!int.TryParse(Console.ReadLine(), out count))
                            {
                                Console.Write("Количество элементов: ");
                            }
                            for (int i = 0; i < count; i++)
                                while (Menu1()) { }
                        }
                        return true;

                    case 2:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            if (ht.Count != 0)
                            {
                                Console.WriteLine(ht.Keys.ToString());
                                Console.WriteLine("Введите название элемента: ");
                                ht.Remove(Console.ReadLine());
                            }
                            else
                            {
                                Console.WriteLine("В коллекции нет элементов");
                            }
                        }
                        return true;

                    case 3:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            if (ht.Count != 0)
                            {
                                Console.Write("Введите название элемента: ");
                                object x = Console.ReadLine();
                                while (!ht.ContainsKey(x))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Такого элемента нет в коллекции");
                                    Console.ResetColor();
                                    Console.Write("Введите название элемента: ");
                                    x = Console.ReadLine();
                                }
                                ((IInit)ht[x]).Show();
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("В коллекции нет элементов");
                            }
                        }
                        return true;

                    case 4:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            int count = 0;
                            foreach (object obj in ht.Values)
                                if (obj.GetType() == typeof(Vehicle))
                                    count++;
                            Console.WriteLine($"Количество Vehicle в коллекции {count}");
                        }
                        return true;

                    case 5:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            int count = 0;
                            foreach (object obj in ht.Values)
                                if (obj.GetType() == typeof(Car))
                                    count++;
                            Console.WriteLine($"Количество Vehicle в коллекции {count}");
                        }
                        return true;

                    case 6:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            int count = 0;
                            foreach (object obj in ht.Values)
                                if (obj.GetType() == typeof(Train))
                                    count++;
                            Console.WriteLine($"Количество Vehicle в коллекции {count}");
                        }
                        return true;

                    case 7:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            int count = 0;
                            foreach (object obj in ht.Values)
                                if (obj.GetType() == typeof(Express))
                                    count++;
                            Console.WriteLine($"Количество Vehicle в коллекции {count}");
                        }
                        return true;

                    case 8:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            foreach (object obj in ht.Values)
                                if (obj.GetType() == typeof(Vehicle))
                                {
                                    ((IInit)obj).Show();
                                    Console.WriteLine();
                                }
                        }
                        return true;

                    case 9:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            foreach (object obj in ht.Values)
                                if (obj.GetType() == typeof(Car))
                                {
                                    ((IInit)obj).Show();
                                    Console.WriteLine();
                                }
                        }
                        return true;

                    case 10:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            foreach (object obj in ht.Values)
                                if (obj.GetType() == typeof(Train))
                                {
                                    ((IInit)obj).Show();
                                    Console.WriteLine();
                                }
                        }
                        return true;

                    case 11:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            foreach (object obj in ht.Values)
                                if (obj.GetType() == typeof(Express))
                                {
                                    ((IInit)obj).Show();
                                    Console.WriteLine();
                                }
                        }
                        return true;

                    case 12:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            foreach (object obj in ht.Values)
                            {
                                ((IInit)obj).Show();
                                Console.WriteLine();
                            }
                        }
                        return true;

                    case 13:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Hashtable htCopy = new Hashtable(ht.Count);
                            foreach (object htKey in ht.Keys)
                            {
                                htCopy.Add(htKey, ((ICloneable)ht[htKey]).Clone());
                            }
                            Console.WriteLine("Изначальное значение: ");
                            foreach (object obj in ht.Values)
                            {
                                ((IInit)obj).Show();
                                Console.WriteLine();
                            }
                            Console.WriteLine("Клонированное: ");
                            foreach (object obj in htCopy.Values)
                            {
                                ((IInit)obj).Show();
                                Console.WriteLine();
                            }
                        }
                        return true;

                    case 14:
                        return false;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат числа");
                        Console.ResetColor();
                        Console.WriteLine();
                        return true;
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа");
                Console.ResetColor();
                return true;
            }
        }

        private static bool Menu1()
        {
            try
            {
                Console.Write("\n   1. Добавить в коллекцию Vehicle\n" +
                              "   2. Добавить в коллекцию Car\n" +
                              "   3. Добавить в коллекцию Train\n" +
                              "   4. Добавить в коллекцию Express\n" +
                              "\nВыберите задание: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            Console.Write("Введите название элемента: ");
                            object x = Console.ReadLine();
                            while (ht.ContainsKey(x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Элемент с таким названием уже есть в коллекции");
                                Console.ResetColor();
                                Console.Write("Введите название элемента: ");
                                x = Console.ReadLine();
                            }
                            ht.Add(x, vehicle.Init());
                        }
                        return false;

                    case 2:
                        {
                            Console.Write("Введите название элемента: ");
                            object x = Console.ReadLine();
                            while (ht.ContainsKey(x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Элемент с таким названием уже есть в коллекции");
                                Console.ResetColor();
                                Console.Write("Введите название элемента: ");
                                x = Console.ReadLine();
                            }
                            ht.Add(x, car.Init());
                        }
                        return false;

                    case 3:
                        {
                            Console.Write("Введите название элемента: ");
                            object x = Console.ReadLine();
                            while (ht.ContainsKey(x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Элемент с таким названием уже есть в коллекции");
                                Console.ResetColor();
                                Console.Write("Введите название элемента: ");
                                x = Console.ReadLine();
                            }
                            ht.Add(x, train.Init());
                        }
                        return false;

                    case 4:
                        {
                            Console.Write("Введите название элемента: ");
                            object x = Console.ReadLine();
                            while (ht.ContainsKey(x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Элемент с таким названием уже есть в коллекции");
                                Console.ResetColor();
                                Console.Write("Введите название элемента: ");
                                x = Console.ReadLine();
                            }
                            ht.Add(x, express.Init());
                        }
                        return false;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат числа");
                        Console.ResetColor();
                        Console.WriteLine();
                        return true;
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа");
                Console.ResetColor();
                return true;
            }
        }
    }
}