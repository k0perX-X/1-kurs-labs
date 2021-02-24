using System;

namespace Laba_10
{
    internal class Program
    {
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
                            Car car = new Car(Console.ReadLine(), IntInput("Passenger capacity: "), IntInput("Number of doors: "));
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