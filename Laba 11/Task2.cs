using Laba_10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Laba_11
{
    public static class Task2
    {
        private static Queue<Vehicle> queue = new Queue<Vehicle>(10);

        private static Vehicle vehicle = new Vehicle();
        private static Car car = new Car();
        private static Train train = new Train();
        private static Express express = new Express();

        private static void PrintICollection(ICollection mas, bool bracket = true, bool inOneLine = false)
        {
            if (bracket) Console.Write("[");
            foreach (var m in mas)
            {
                Console.Write($"{m}, ");
                if (!inOneLine)
                    Console.WriteLine();
            }
            if (bracket) Console.Write("]");
        }

        public static void Run()
        {
            while (MenuTask2()) { }
        }

        private static bool MenuTask2()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nМЕНЮ ЗАДАЧИ  2\n");
                Console.ResetColor();
                Console.Write("   1.  Добавить в коллекцию\n" +
                              "   2.  Удалить и вывести следующий элемент из очереди\n" +
                              "   3.  Вывести следующий элемент очереди\n" +
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
                              "   14. Сортировка коллекции\n" +
                              "   15. Выйти в основное меню\n" +
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
                            if (queue.Count != 0)
                            {
                                queue.Dequeue().Show();
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
                            if (queue.Count != 0)
                            {
                                queue.Peek().Show();
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
                            foreach (object obj in queue)
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
                            foreach (object obj in queue)
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
                            foreach (object obj in queue)
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
                            foreach (object obj in queue)
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
                            foreach (object obj in queue)
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
                            foreach (object obj in queue)
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
                            foreach (object obj in queue)
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
                            foreach (object obj in queue)
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
                            foreach (object obj in queue)
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
                            Queue<Vehicle> queueCopy = new Queue<Vehicle>(10);
                            foreach (object o in queue)
                            {
                                queueCopy.Enqueue((Vehicle)((ICloneable)o).Clone());
                            }
                            Console.WriteLine("Изначальное значение: ");
                            foreach (object obj in queue)
                            {
                                ((IInit)obj).Show();
                                Console.WriteLine();
                            }
                            Console.WriteLine("Клонированное: ");
                            foreach (object obj in queueCopy)
                            {
                                ((IInit)obj).Show();
                                Console.WriteLine();
                            }
                        }
                        return true;

                    case 14:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            queue = new Queue<Vehicle>(queue.OrderBy(x => x.PassengerCapacity));
                        }
                        return true;

                    case 15:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
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
                            queue.Enqueue((Vehicle)vehicle.Init());
                        }
                        return false;

                    case 2:
                        {
                            queue.Enqueue((Vehicle)car.Init());
                        }
                        return false;

                    case 3:
                        {
                            queue.Enqueue((Vehicle)train.Init());
                        }
                        return false;

                    case 4:
                        {
                            queue.Enqueue((Vehicle)express.Init());
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