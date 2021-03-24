using System;
using System.Collections.Generic;
using Laba_10;
using System.Diagnostics;

namespace Laba_11
{
    public static class Task3
    {
        private static Car car = new Car();

        public class TestCollections
        {
            public List<Car> col1 = new List<Car>(1000);
            public List<string> col2 = new List<string>(1000);
            public Dictionary<Vehicle, Car> col3 = new Dictionary<Vehicle, Car>(1000);
            public Dictionary<string, Car> col4 = new Dictionary<string, Car>(1000);

            private static Car car = new Car();

            public TestCollections()
            {
                for (int i = 0; i < 1000; i++)
                {
                    car = (Car)car.Init();
                    while (col4.ContainsKey(car.ToString()))
                        car = (Car)car.Init();
                    col1.Add(car);
                    col2.Add(col1[i].ToString());
                    col3.Add(col1[i].BaseVehicle, (Car)col1[i].Clone());
                    col4.Add((string)col2[i].Clone(), (Car)col1[i].Clone());
                }
            }
        }

        private static TestCollections tc;

        public static void Run()
        {
            tc = new TestCollections();
            while (MenuTask3()) { }
        }

        private static bool MenuTask3()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nМЕНЮ ЗАДАЧИ  3\n");
                Console.ResetColor();
                Console.Write("   1.  Добавить\n" +
                              "   2.  Удалить по номеру\n" +
                              "   3.  Вывести элемент по номеру\n" +
                              "   4.  Измерить время 1 раз\n" +
                              "   5.  Измерить время 1000 раз\n" +
                              "   6.  Выйти в основное меню\n" +
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
                            car = (Car)car.Init();
                            while (tc.col4.ContainsKey(car.ToString()))
                                car = (Car)car.Init();
                            tc.col1.Add(car);
                            tc.col2.Add(tc.col1[^1].ToString());
                            tc.col3.Add(tc.col1[^1].BaseVehicle, (Car)tc.col1[^1].Clone());
                            tc.col4.Add((string)tc.col2[^1].Clone(), (Car)tc.col1[^1].Clone());
                        }
                        return true;

                    case 2:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            if (tc.col1.Count != 0)
                            {
                                Console.Write("Введите номер элемента: ");
                                int x = -1;
                                while (!int.TryParse(Console.ReadLine(), out x) || (x > tc.col1.Count - 1) || (x < 0))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Неверный формат числа");
                                    Console.ResetColor();
                                    Console.Write("Введите номер элемента: ");
                                }
                                tc.col3.Remove(tc.col1[x].BaseVehicle);
                                tc.col4.Remove(tc.col2[x]);
                                tc.col1.RemoveAt(x);
                                tc.col2.RemoveAt(x);
                            }
                            else
                            {
                                Console.WriteLine("В коллекциях нет элементов");
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
                            if (tc.col1.Count != 0)
                            {
                                Console.Write("Введите номер элемента: ");
                                int x = -1;
                                while (!int.TryParse(Console.ReadLine(), out x) || (x > tc.col1.Count - 1) || (x < 0))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Неверный формат числа");
                                    Console.ResetColor();
                                    Console.Write("Введите номер элемента: ");
                                }
                                Console.WriteLine("col1");
                                tc.col1[x].Show();
                                Console.WriteLine($"\n\ncol2\n{tc.col2[x]}");
                                Console.Write("\ncol3\nkey: ");
                                tc.col1[x].BaseVehicle.Show();
                                Console.Write("\nvalue: ");
                                Vehicle key = default;
                                foreach (KeyValuePair<Vehicle, Car> pair in tc.col3)
                                {
                                    if (pair.Key == tc.col1[x].BaseVehicle)
                                    {
                                        key = pair.Key;
                                        break;
                                    }
                                }
                                tc.col3[key].Show();
                                Console.Write($"\n\ncol3\nkey: {tc.col1[x].ToString()}\nvalue: ");
                                tc.col4[tc.col1[x].ToString()].Show();
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("В коллекциях нет элементов");
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
                            if (tc.col1.Count != 0)
                            {
                                Console.Write("col1\nFirst: ");
                                long time;
                                time = Stopwatch.GetTimestamp();
                                tc.col1.Contains(tc.col1[0]);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.Write($"{time}\nCenter: ");
                                int i = tc.col1.Count / 2;
                                time = Stopwatch.GetTimestamp();
                                tc.col1.Contains(tc.col1[i]);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.Write($"{time}\nLast: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col1.Contains(tc.col1[^1]);
                                time = Stopwatch.GetTimestamp() - time;
                                Car car = new Car();
                                Console.Write($"{time}\nNon-existent: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col1.Contains(car);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.WriteLine(time);

                                Console.Write("\ncol2\nFirst: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col2.Contains(tc.col2[0]);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.Write($"{time}\nCenter: ");
                                i = tc.col2.Count / 2;
                                time = Stopwatch.GetTimestamp();
                                tc.col2.Contains(tc.col2[i]);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.Write($"{time}\nLast: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col2.Contains(tc.col2[^1]);
                                time = Stopwatch.GetTimestamp() - time;
                                string carstr = car.ToString();
                                Console.Write($"{time}\nNon-existent: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col2.Contains(carstr);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.WriteLine(time);

                                Console.Write("\ncol3 key\nFirst: ");
                                Vehicle carbase = tc.col1[0].BaseVehicle;
                                time = Stopwatch.GetTimestamp();
                                tc.col3.ContainsKey(carbase);
                                time = Stopwatch.GetTimestamp() - time;
                                carbase = tc.col1[tc.col2.Count / 2].BaseVehicle;
                                Console.Write($"{time}\nCenter: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col3.ContainsKey(carbase);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.Write($"{time}\nLast: ");
                                carbase = tc.col1[^1].BaseVehicle;
                                time = Stopwatch.GetTimestamp();
                                tc.col3.ContainsKey(carbase);
                                time = Stopwatch.GetTimestamp() - time;
                                carbase = car.BaseVehicle;
                                Console.Write($"{time}\nNon-existent: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col3.ContainsKey(carbase);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.WriteLine(time);

                                Console.Write("\ncol3 value\nFirst: ");
                                car = tc.col1[0];
                                time = Stopwatch.GetTimestamp();
                                tc.col3.ContainsValue(car);
                                time = Stopwatch.GetTimestamp() - time;
                                car = tc.col1[tc.col2.Count / 2];
                                Console.Write($"{time}\nCenter: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col3.ContainsValue(car);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.Write($"{time}\nLast: ");
                                car = tc.col1[^1];
                                time = Stopwatch.GetTimestamp();
                                tc.col3.ContainsValue(car);
                                time = Stopwatch.GetTimestamp() - time;
                                car = new Car();
                                Console.Write($"{time}\nNon-existent: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col3.ContainsValue(car);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.WriteLine(time);

                                Console.Write("\ncol4 key\nFirst: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col4.ContainsKey(tc.col2[0]);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.Write($"{time}\nCenter: ");
                                i = tc.col1.Count / 2;
                                time = Stopwatch.GetTimestamp();
                                tc.col4.ContainsKey(tc.col2[i]);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.Write($"{time}\nLast: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col4.ContainsKey(tc.col2[^1]);
                                time = Stopwatch.GetTimestamp() - time;
                                carstr = car.ToString();
                                Console.Write($"{time}\nNon-existent: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col4.ContainsKey(carstr);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.WriteLine(time);

                                Console.Write("\ncol4 value\nFirst: ");
                                car = tc.col1[0];
                                time = Stopwatch.GetTimestamp();
                                tc.col4.ContainsValue(car);
                                time = Stopwatch.GetTimestamp() - time;
                                car = tc.col1[tc.col2.Count / 2];
                                Console.Write($"{time}\nCenter: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col4.ContainsValue(car);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.Write($"{time}\nLast: ");
                                car = tc.col1[^1];
                                time = Stopwatch.GetTimestamp();
                                tc.col4.ContainsValue(car);
                                time = Stopwatch.GetTimestamp() - time;
                                car = new Car();
                                Console.Write($"{time}\nNon-existent: ");
                                time = Stopwatch.GetTimestamp();
                                tc.col4.ContainsValue(car);
                                time = Stopwatch.GetTimestamp() - time;
                                Console.WriteLine(time);
                            }
                            else
                            {
                                Console.WriteLine("В коллекциях нет элементов");
                            }
                        }
                        return true;

                    case 5:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            if (tc.col1.Count != 0)
                            {
                                decimal average(long[] times)
                                {
                                    decimal a = 0;
                                    for (int i = 0; i < times.Length; i++)
                                        a += times[i];
                                    return a / times.Length;
                                }
                                long[] times = new long[1000];
                                long time;
                                Car car;
                                string carstr;
                                Vehicle carbase;

                                Console.Write("col1\nFirst: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col1.Contains(tc.col1[0]);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.Write($"{average(times)}\nCenter: ");
                                int i = tc.col1.Count / 2;
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col1.Contains(tc.col1[i]);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.Write($"{average(times)}\nLast: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col1.Contains(tc.col1[^1]);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                car = new Car();
                                Console.Write($"{average(times)}\nNon-existent: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col1.Contains(car);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.WriteLine(average(times));

                                Console.Write("\ncol2\nFirst: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col2.Contains(tc.col2[0]);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.Write($"{average(times)}\nCenter: ");
                                i = tc.col2.Count / 2;
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col2.Contains(tc.col2[i]);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.Write($"{average(times)}\nLast: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col2.Contains(tc.col2[^1]);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                carstr = car.ToString();
                                Console.Write($"{average(times)}\nNon-existent: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col2.Contains(carstr);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.WriteLine(average(times));

                                Console.Write("\ncol3 key\nFirst: ");
                                carbase = tc.col1[0].BaseVehicle;
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col3.ContainsKey(carbase);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                carbase = tc.col1[tc.col2.Count / 2].BaseVehicle;
                                Console.Write($"{average(times)}\nCenter: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col3.ContainsKey(carbase);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.Write($"{average(times)}\nLast: ");
                                carbase = tc.col1[^1].BaseVehicle;
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col3.ContainsKey(carbase);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                carbase = car.BaseVehicle;
                                Console.Write($"{average(times)}\nNon-existent: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col3.ContainsKey(carbase);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.WriteLine(average(times));

                                Console.Write("\ncol3 value\nFirst: ");
                                car = tc.col1[0];
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col3.ContainsValue(car);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                car = tc.col1[tc.col2.Count / 2];
                                Console.Write($"{average(times)}\nCenter: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col3.ContainsValue(car);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.Write($"{average(times)}\nLast: ");
                                car = tc.col1[^1];
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col3.ContainsValue(car);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                car = new Car();
                                Console.Write($"{average(times)}\nNon-existent: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col3.ContainsValue(car);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.WriteLine(average(times));

                                Console.Write("\ncol4 key\nFirst: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col4.ContainsKey(tc.col2[0]);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.Write($"{average(times)}\nCenter: ");
                                i = tc.col1.Count / 2;
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col4.ContainsKey(tc.col2[i]);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.Write($"{average(times)}\nLast: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col4.ContainsKey(tc.col2[^1]);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                carstr = car.ToString();
                                Console.Write($"{average(times)}\nNon-existent: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col4.ContainsKey(carstr);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.WriteLine(average(times));

                                Console.Write("\ncol4 value\nFirst: ");
                                car = tc.col1[0];
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col4.ContainsValue(car);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                car = tc.col1[tc.col2.Count / 2];
                                Console.Write($"{average(times)}\nCenter: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col4.ContainsValue(car);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.Write($"{average(times)}\nLast: ");
                                car = tc.col1[^1];
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col4.ContainsValue(car);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                car = new Car();
                                Console.Write($"{average(times)}\nNon-existent: ");
                                for (int j = 0; j < times.Length; j++)
                                {
                                    time = Stopwatch.GetTimestamp();
                                    tc.col4.ContainsValue(car);
                                    time = Stopwatch.GetTimestamp() - time;
                                    times[j] = time;
                                }
                                Console.WriteLine(average(times));
                            }
                            else
                            {
                                Console.WriteLine("В коллекциях нет элементов");
                            }
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