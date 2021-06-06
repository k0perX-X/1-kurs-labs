using System;
using Laba_10;
using Laba_12;

namespace Laba_13
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task.Tree<int> tree1 = new Task.Tree<int>((int x) => x);
            tree1.Name = "Tree 1";
            Task.Tree<int> tree2 = new Task.Tree<int>((int x) => x);
            tree2.Name = "Tree 2";

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            tree1.CollectionCountChanged += journal1.AddInList;
            tree1.CollectionReferenceChanged += journal1.AddInList;

            tree2.CollectionReferenceChanged += journal2.AddInList;
            tree1.CollectionReferenceChanged += journal2.AddInList;

            bool MenuTask1()
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nМЕНЮ\n");
                    Console.ResetColor();
                    Console.Write("   1.  Добавить элемент в дерево 1 поиска\n" +
                                  "   2.  Вывести дерево 1 поиска\n" +
                                  "   3.  Удалить элемент из дерева 1 по значению\n" +
                                  "   4.  Сбалансировать дерево 1 \n" +
                                  "   5.  Очистить дерево дерево 1\n" +
                                  "   6.  Добавить элемент в дерево 2 поиска\n" +
                                  "   7.  Вывести дерево 2 поиска\n" +
                                  "   8.  Удалить элемент из дерева 2 по значению\n" +
                                  "   9.  Сбалансировать дерево 2 \n" +
                                  "   10. Очистить дерево дерево 2\n" +
                                  "   11. Посмотреть журнал 1\n" +
                                  "   12. Посмотреть журнал 2\n" +
                                  "   13. Выход из программы\n" +
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
                                int x;
                                while (!int.TryParse(Console.ReadLine(), out x)) { }
                                tree1.Add(x);
                                Console.WriteLine("Получившееся дерево:\n" + tree1);
                            }
                            return true;

                        case 2:
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                            {
                                Console.WriteLine("Дерево поиска:\n" + tree1);
                            }
                            return true;

                        case 3:
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
                                tree1.Remove(x);
                                Console.WriteLine("Получившееся дерево:\n" + tree2);
                            }
                            return true;

                        case 4:
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                            {
                                tree1.ConvertToBalanced();
                                Console.WriteLine("Получившееся дерево:\n" + tree2);
                            }
                            return true;

                        case 5:
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                            {
                                tree1.Clear();
                            }
                            return true;

                        case 6:
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                            {
                                int x;
                                while (!int.TryParse(Console.ReadLine(), out x)) { }
                                tree2.Add(x);
                                Console.WriteLine("Получившееся дерево:\n" + tree1);
                            }
                            return true;

                        case 7:
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                            {
                                Console.WriteLine("Дерево поиска:\n" + tree2);
                            }
                            return true;

                        case 8:
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
                                tree2.Remove(x);
                                Console.WriteLine("Получившееся дерево:\n" + tree2);
                            }
                            return true;

                        case 9:
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                            {
                                tree1.ConvertToBalanced();
                                Console.WriteLine("Получившееся дерево:\n" + tree2);
                            }
                            return true;

                        case 10:
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                            {
                                tree2.Clear();
                            }
                            return true;

                        case 11:
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                            {
                                Console.WriteLine(journal1.ToString());
                            }
                            return true;

                        case 12:
                            str = "=";
                            str = str.PadRight(Console.WindowWidth, '=');
                            Console.WriteLine(str);
                            Console.SetCursorPosition(0, Console.CursorTop + Console.WindowHeight + 2);
                            Console.SetCursorPosition(0, Console.CursorTop - Console.WindowHeight);
                            {
                                Console.WriteLine(journal2.ToString());
                            }
                            return true;

                        case 13:
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

            while (MenuTask1()) { }
        }
    }
}