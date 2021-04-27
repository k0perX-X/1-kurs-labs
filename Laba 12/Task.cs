using System;
using System.Diagnostics;
using Laba_10;

namespace Laba_12
{
    public unsafe partial class Task
    {
        private static Vehicle vehicle = new Vehicle();
        private static Car car = new Car();
        private static Train train = new Train();
        private static Express express = new Express();

        private UnidirectionalList<Vehicle> unidirectionalList = new UnidirectionalList<Vehicle>();
        private BidirectionalList<Vehicle> bidirectionalList = new BidirectionalList<Vehicle>();

        private static int TreeFunc(Vehicle obj)
        {
            return obj.PassengerCapacity;
        }

        private Tree<Vehicle> tree = new Tree<Vehicle>(TreeFunc);

        private bool MenuTask1()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nМЕНЮ\n");
                Console.ResetColor();
                Console.Write("   1.  Создать рандомный однонаправленный список\n" +
                              "   2.  Добавить рандомные элементы однонаправленный список\n" +
                              "   3.  Вывести однонаправленный список\n" +
                              "   4.  Удалить элемент из однонаправленного списка по индексу\n" +
                              "   5.  Удалить элемент из однонаправленного списка по имени\n" +
                              "   6.  Очистить однонаправленный список\n" +
                              "   7.  Создать рандомный двунаправленный список\n" +
                              "   8.  Добавить рандомные элементы двунаправленный список\n" +
                              "   9.  Вывести двунаправленный список\n" +
                              "   10. Удалить элемент из двунаправленного списка по индексу\n" +
                              "   11. Добавить в двунаправленный список элемент по индексу\n" +
                              "   12. Очистить двунаправленный список\n" +
                              "   13. Создать дерево поиска из рандомных элементов\n" +
                              "   14. Добавить элемент в дерево поиска\n" +
                              "   15. Вывести дерево поиска\n" +
                              "   16. Удалить элемент из дерева по значению\n" +
                              "   17. Сбалансировать дерево\n" +
                              "   18. Вывести минимальное и максимальное значения \n" +
                              "   19. Очистить дерево\n" +
                              "   20. Вернуться в главное меню\n" +
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
                            unidirectionalList = new UnidirectionalList<Vehicle>();
                            Console.Write("Введите количество элементов: ");
                            int x;
                            Random random = new Random();
                            while (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неверный формат числа");
                                Console.ResetColor();
                            }

                            for (int i = 0; i < x; i++)
                            {
                                switch (random.Next(0, 4))
                                {
                                    case 0:
                                        unidirectionalList.Add((Vehicle)vehicle.Init());
                                        //Debug.Print("0");
                                        break;

                                    case 1:
                                        unidirectionalList.Add((Car)car.Init());
                                        //Debug.Print("1");
                                        break;

                                    case 2:
                                        unidirectionalList.Add((Train)train.Init());
                                        //Debug.Print("2");
                                        break;

                                    case 3:
                                        unidirectionalList.Add((Express)express.Init());
                                        //Debug.Print("3");
                                        break;
                                }
                            }
                            Console.WriteLine("Получившийся список:\n" + unidirectionalList);
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
                            Console.Write("Введите количество элементов: ");
                            int x;
                            Random random = new Random();
                            while (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неверный формат числа");
                                Console.ResetColor();
                            }

                            for (int i = 0; i < x; i++)
                            {
                                switch (random.Next(0, 4))
                                {
                                    case 0:
                                        unidirectionalList.Add((Vehicle)vehicle.Init());
                                        //Debug.Print("0");
                                        break;

                                    case 1:
                                        unidirectionalList.Add((Car)car.Init());
                                        //Debug.Print("1");
                                        break;

                                    case 2:
                                        unidirectionalList.Add((Train)train.Init());
                                        //Debug.Print("2");
                                        break;

                                    case 3:
                                        unidirectionalList.Add((Express)express.Init());
                                        //Debug.Print("3");
                                        break;
                                }
                            }
                            Console.WriteLine("Получившийся список:\n" + unidirectionalList);
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
                            Console.WriteLine(unidirectionalList);
                        }
                        return true;

                    case 4:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.Write("Введите номер элемента: ");
                            int x;
                            while (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неверный формат числа");
                                Console.ResetColor();
                            }
                            unidirectionalList.Remove(x);
                            Console.WriteLine("Получившийся список:\n" + unidirectionalList);
                        }
                        return true;

                    case 5:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        unsafe
                        {
                            static string func(Vehicle x)
                            {
                                return x.Name;
                            }
                            Console.Write("Введите имя элемента, который хотите удалить: ");
                            int x = unidirectionalList.Find<string>(Console.ReadLine(), &func);
                            if (x == -1)
                                Console.WriteLine("Элемента с таким именем нет");
                            else
                            {
                                unidirectionalList.Remove(x);
                                Console.WriteLine("Получившийся список:\n" + unidirectionalList);
                            }
                        }
                        return true;

                    case 6:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            unidirectionalList.Clear();
                        }
                        return true;

                    case 7:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            bidirectionalList = new BidirectionalList<Vehicle>();
                            Console.Write("Введите количество элементов: ");
                            int x;
                            Random random = new Random();
                            while (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неверный формат числа");
                                Console.ResetColor();
                            }

                            for (int i = 0; i < x; i++)
                            {
                                switch (random.Next(0, 4))
                                {
                                    case 0:
                                        bidirectionalList.Add((Vehicle)vehicle.Init());
                                        //Debug.Print("0");
                                        break;

                                    case 1:
                                        bidirectionalList.Add((Car)car.Init());
                                        //Debug.Print("1");
                                        break;

                                    case 2:
                                        bidirectionalList.Add((Train)train.Init());
                                        //Debug.Print("2");
                                        break;

                                    case 3:
                                        bidirectionalList.Add((Express)express.Init());
                                        //Debug.Print("3");
                                        break;
                                }
                            }
                            Console.WriteLine("Получившийся список:\n" + bidirectionalList);
                        }
                        Console.WriteLine();
                        return true;

                    case 8:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.Write("Введите количество элементов: ");
                            int x;
                            Random random = new Random();
                            while (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неверный формат числа");
                                Console.ResetColor();
                            }

                            for (int i = 0; i < x; i++)
                            {
                                switch (random.Next(0, 4))
                                {
                                    case 0:
                                        bidirectionalList.Add((Vehicle)vehicle.Init());
                                        //Debug.Print("0");
                                        break;

                                    case 1:
                                        bidirectionalList.Add((Car)car.Init());
                                        //Debug.Print("1");
                                        break;

                                    case 2:
                                        bidirectionalList.Add((Train)train.Init());
                                        //Debug.Print("2");
                                        break;

                                    case 3:
                                        bidirectionalList.Add((Express)express.Init());
                                        //Debug.Print("3");
                                        break;
                                }
                            }
                            Console.WriteLine("Получившийся список:\n" + bidirectionalList);
                        }
                        Console.WriteLine();
                        return true;

                    case 9:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.WriteLine(bidirectionalList);
                        }
                        return true;

                    case 10:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.Write("Введите номер элемента: ");
                            int x;
                            while (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неверный формат числа");
                                Console.ResetColor();
                            }
                            bidirectionalList.Remove(x);
                            Console.WriteLine("Получившийся список:\n" + bidirectionalList);
                        }
                        return true;

                    case 11:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.Write("Введите номер элемента: ");
                            int x = -1;
                            do
                            {
                                while (!int.TryParse(Console.ReadLine(), out x))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Неверный формат числа");
                                    Console.ResetColor();
                                }
                            } while (bidirectionalList.Length >= x && x > 0);
                            while (Menu1(x)) { }
                            Console.WriteLine("Получившийся список:\n" + bidirectionalList);
                        }
                        return true;

                    case 12:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            bidirectionalList.Clear();
                        }
                        return true;

                    case 13:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            tree = new Tree<Vehicle>(TreeFunc);
                            Console.Write("Введите количество элементов: ");
                            int x;
                            Random random = new Random();
                            while (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неверный формат числа");
                                Console.ResetColor();
                            }

                            for (int i = 0; i < x; i++)
                            {
                                switch (random.Next(0, 4))
                                {
                                    case 0:
                                        tree.Add((Vehicle)vehicle.Init());
                                        //Debug.Print("0");
                                        break;

                                    case 1:
                                        tree.Add((Car)car.Init());
                                        //Debug.Print("1");
                                        break;

                                    case 2:
                                        tree.Add((Train)train.Init());
                                        //Debug.Print("2");
                                        break;

                                    case 3:
                                        tree.Add((Express)express.Init());
                                        //Debug.Print("3");
                                        break;
                                }
                            }
                            Console.WriteLine("Получившееся дерево:\n" + tree);
                        }
                        return true;

                    case 14:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            while (Menu3()) { }
                            Console.WriteLine("Получившееся дерево:\n" + tree);
                        }
                        return true;

                    case 15:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.WriteLine("Дерево поиска:\n" + tree);
                        }
                        return true;

                    case 16:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.Write("Введите значение элемента: ");
                            int x;
                            Random random = new Random();
                            while (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неверный формат числа");
                                Console.ResetColor();
                            }
                            tree.Remove(x);
                            Console.WriteLine("Получившееся дерево:\n" + tree);
                        }
                        return true;

                    case 17:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            tree.ConvertToBalanced();
                            Console.WriteLine("Получившееся дерево:\n" + tree);
                        }
                        return true;

                    case 18:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            Console.WriteLine("Минимальное значение:\n" + tree.Min());
                            Console.WriteLine("Максимальное значение:\n" + tree.Max());
                        }
                        return true;

                    case 19:
                        str = "=";
                        str = str.PadRight(Console.WindowWidth, '=');
                        Console.WriteLine(str);
                        Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                        Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                        {
                            tree.Clear();
                        }
                        return true;

                    case 20:
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

        private bool Menu1(int i)
        {
            try
            {
                Console.Write("\n   1. Добавить в двунаправленный список Vehicle\n" +
                              "   2. Добавить в двунаправленный список Car\n" +
                              "   3. Добавить в двунаправленный список Train\n" +
                              "   4. Добавить в двунаправленный список Express\n" +
                              "\nВыберите: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        bidirectionalList.Add(i, (Vehicle)vehicle.Init());
                        //Debug.Print("0");
                        return false;

                    case 2:
                        bidirectionalList.Add(i, (Car)car.Init());
                        //Debug.Print("1");
                        return false;

                    case 3:
                        bidirectionalList.Add(i, (Train)train.Init());
                        //Debug.Print("2");
                        return false;

                    case 4:
                        bidirectionalList.Add(i, (Express)express.Init());
                        //Debug.Print("3");
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

        private bool Menu3()
        {
            try
            {
                Console.Write("\n   1. Добавить в двунаправленный список Vehicle\n" +
                              "   2. Добавить в двунаправленный список Car\n" +
                              "   3. Добавить в двунаправленный список Train\n" +
                              "   4. Добавить в двунаправленный список Express\n" +
                              "\nВыберите: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        tree.Add((Vehicle)vehicle.Init());
                        //Debug.Print("0");
                        return false;

                    case 2:
                        tree.Add((Car)car.Init());
                        //Debug.Print("1");
                        return false;

                    case 3:
                        tree.Add((Train)train.Init());
                        //Debug.Print("2");
                        return false;

                    case 4:
                        tree.Add((Express)express.Init());
                        //Debug.Print("3");
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

        public void RunTask1()
        {
            while (MenuTask1()) { }
        }
    }
}