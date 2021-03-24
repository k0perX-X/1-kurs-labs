using System;
using System.Collections;
using System.Linq;

namespace Laba_10
{
    public class Program
    {
        private class SortByName : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Vehicle s1 = (Vehicle)ob1;
                Vehicle s2 = (Vehicle)ob2;
                return String.Compare(s1.Name, s2.Name);
            }
        }

        private static int IntInput(string inputSuggestion, int greater = int.MinValue, int less = int.MaxValue)
        {
            int n;
            bool vihod = false;
            do
            {
                Console.Write(inputSuggestion);
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
                else if (n > less)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Число больше разрешенного");
                    Console.ResetColor();
                }
                else if (n < greater)
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

        private static void PrintMas(string[] mas, bool bracket = true, bool inOneLine = false)
        {
            if (mas.Length > 0)
            {
                if (bracket) Console.Write("[");
                for (int i = 0; i < mas.Length - 1; i++)
                    Console.Write($"{mas[i]}, ");
                Console.Write(mas[^1]);
                if (bracket) Console.Write("]");
                if (!inOneLine)
                    Console.WriteLine();
            }
            else if (bracket)
                if (!inOneLine)
                    Console.WriteLine("Массив пустой");
                else
                    Console.Write("Массив пустой");
        }

        private static bool Menu()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nМЕНЮ\n");
                Console.ResetColor();
                Console.Write("   1. Часть 1\n" +
                              "   2. Часть 2\n" +
                              "   3. Часть 3\n" +
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
                            Console.WriteLine("Vehicle");
                            Console.Write("Name: ");
                            Vehicle vehicle = new Vehicle(Console.ReadLine(), IntInput("Passenger capacity: "));
                            vehicle.Show();
                            Console.WriteLine();
                            Console.WriteLine("Car");
                            Console.Write("Name: ");
                            Car car = new Car(Console.ReadLine(), IntInput("Passenger capacity: "),
                                IntInput("Number of doors: "));
                            car.Show();
                            Console.WriteLine();
                            Console.WriteLine("Train");
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            int passengerCapacity = IntInput("Passenger capacity: ");
                            int numberOfStations = IntInput("Number of stations:");
                            string[] stations = new string[numberOfStations];
                            for (int i = 0; i < numberOfStations; i++)
                            {
                                Console.Write($"Station №{i + 1}: ");
                                stations[i] = Console.ReadLine();
                            }

                            Train train = new Train(name, passengerCapacity, stations);
                            train.Show();
                            Console.WriteLine();
                            Console.WriteLine("Express");
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            passengerCapacity = IntInput("Passenger capacity: ");
                            numberOfStations = IntInput("Number of stations:");
                            stations = new string[numberOfStations];
                            for (int i = 0; i < numberOfStations; i++)
                            {
                                Console.Write($"Station №{i + 1}: ");
                                stations[i] = Console.ReadLine();
                            }

                            Express express = new Express(name, passengerCapacity, stations, IntInput("Speed: "));
                            express.Show();
                            Console.WriteLine();
                            Console.WriteLine("Array");
                            Vehicle[] vehicles = new[] { vehicle, car, train, express };
                            foreach (var veh in vehicles)
                            {
                                veh.Show();
                                Console.WriteLine();
                            }
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
                            //Init
                            Car car = new Car();
                            Train train = new Train
                            {
                                NumberOfPassengersInTheCarriage = new[] { 30, 40, 30, 50 },
                                Stations = new[]
                                {
                                    "Заводская", "Воздушная", "Хлебозаводская", "Народная", "32 км", "Центральная",
                                    "Конечная"
                                }
                            };
                            Express express = new Express
                            {
                                NumberOfPassengersInTheCarriage = new[] { 10, 20, 30, 40, 50 },
                                Stations = new[]
                                {
                                    "Заводская", "Народная", "32 км", "Центральная", "Дальняя"
                                }
                            };
                            Train[] trains = new[]
                            {
                                train,
                                express,
                                new Train {NumberOfPassengersInTheCarriage = new[] {50, 40, 30, 50}},
                                new Train {NumberOfPassengersInTheCarriage = new[] {0, 0, 0, 0}},
                                new Express {NumberOfPassengersInTheCarriage = new[] {50, 60, 37, 40}}
                            };
                            //Количество пассажиров во всех вагонах экспресса.
                            Console.WriteLine(
                                $"Количество пассажиров во всех вагонах экспресса: {Enumerable.Sum(express.NumberOfPassengersInTheCarriage)}");
                            //Одинаковые остановки у поезда и экспресса
                            Console.Write("Одинаковые остановки у поезда и экспресса: ");
                            PrintMas(express.Stations.Where(station => train.Stations.Contains(station)).ToArray());
                            //Количество пассажиров едущих на экспрессе среди всех поездов
                            int sum = 0;
                            foreach (var t in trains)
                            {
                                if (t is Express)
                                {
                                    sum += Enumerable.Sum(t.NumberOfPassengersInTheCarriage);
                                }
                            }
                            Console.WriteLine($"Количество пассажиров едущих на экспрессе среди всех поездов: {sum}");
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
                            //IInit
                            IInit[] inits = new IInit[]
                            {
                                (IInit)(new Vehicle().Init()), (IInit)(new Car().Init()), (IInit)(new Train().Init()),
                                (IInit)(new Express().Init()), (IInit)(new Passenger().Init())
                            };
                            foreach (IInit init in inits)
                            {
                                init.Show();
                                Console.WriteLine();
                            }
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            //IComparer
                            object[] objects = new[]
                            {
                                (IInit) (new Vehicle().Init()), (IInit) (new Car().Init()), (IInit) (new Train().Init()),
                                (IInit) (new Express().Init())
                            };
                            foreach (Vehicle o in objects)
                            {
                                o.Show();
                                Console.WriteLine();
                            }
                            str = "=";
                            str = str.PadRight(Console.WindowWidth / 2, '=');
                            Console.WriteLine(str);
                            Array.Sort(objects, new SortByName());
                            foreach (Vehicle o in objects)
                            {
                                o.Show();
                                Console.WriteLine();
                            }
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Vehicle vehicleOriginal = (Vehicle)new Vehicle().Init();
                            Vehicle vehicleClone = (Vehicle)vehicleOriginal.Clone();
                            Vehicle vehicleShallowCopy = (Vehicle)vehicleOriginal.ShallowCopy();
                            Console.WriteLine($"Original:");
                            vehicleOriginal.Show();
                            Console.WriteLine("\nClone:");
                            vehicleClone.Show();
                            Console.WriteLine("\nShallowCopy:");
                            vehicleShallowCopy.Show();
                            vehicleOriginal.Name = "Edited";
                            vehicleOriginal.Passengers[0].Name = "Edited";
                            Console.WriteLine($"\nOriginal:");
                            vehicleOriginal.Show();
                            Console.WriteLine("\nClone:");
                            vehicleClone.Show();
                            Console.WriteLine("\nShallowCopy:");
                            vehicleShallowCopy.Show();
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

        private static void Main(string[] args)
        {
            while (Menu())
            {
            }
        }
    }
}