using System;
using System.Linq;

namespace Лаба_4
{
    public class Laba4
    {
        public static Random rand = new Random();

        public static int[] mas = new int[0];
        public static bool sorted = false;

        public const int max =
            //0;
            int.MaxValue;

        public const int min =
            //0;
            int.MinValue;

        public static int Vvodn()
        {
            int n = 0;
            bool vihod = false;
            do
            {
                try
                {
                    Console.Write("Пожалуйста, введите n: ");
                    n = int.Parse(Console.ReadLine());
                    vihod = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
            } while (!vihod);
            return n;
        }

        public static int VvodPoisk()
        {
            int n = 0;
            bool vihod = false;
            do
            {
                try
                {
                    Console.Write("Пожалуйста, введите число для поиска в массиве: ");
                    n = int.Parse(Console.ReadLine());
                    vihod = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
            } while (!vihod);
            return n;
        }

        public static void VvodNK(ref int n, ref int k)
        {
            bool vihod = false;
            do
            {
                try
                {
                    Console.Write("Пожалуйста, введите N: ");
                    n = int.Parse(Console.ReadLine());
                    vihod = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
            } while (!vihod);
            vihod = false;
            do
            {
                try
                {
                    Console.Write("Пожалуйста, введите K: ");
                    k = int.Parse(Console.ReadLine());
                    if ((k < mas.Length) && (k >= 0))
                        vihod = true;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат числа");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
            } while (!vihod);
        }

        public static int[] DoMAS(int n)
        {
            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = rand.Next(min, max);
            }
            return mas;
        }

        public static void DelMin(ref int[] mas)
        {
            int min = mas.Min();
            mas = mas.Where(i => i != min).ToArray();
        }

        public static void Vivod(int[] mas, bool skobka = true)
        {
            if (mas.Length > 0)
            {
                if (skobka) Console.Write("[");
                for (int i = 0; i < mas.Length - 1; i++)
                    Console.Write($"{mas[i]}, ");
                Console.Write(mas[mas.Length - 1]);
                if (skobka) Console.Write("]");
                Console.WriteLine();
            }
            else
                if (skobka) Console.WriteLine("Массив пустой");
        }

        public static void Dobavit(ref int[] mas, int n, int k)
        {
            int[] newmas = new int[mas.Length + n];
            mas.CopyTo(newmas.AsMemory());
            for (int i = k; i - k < n; i++)
                newmas[i] = rand.Next(min, max);
            for (int i = k + n; i < newmas.Length; i++)
                newmas[i] = mas[i - n];
            mas = newmas.ToArray();
        }

        public static void Swap(ref int[] mas)
        {
            if (mas.Length % 2 == 0)
                for (int i = 0; i < mas.Length; i += 2)
                {
                    mas[i] ^= mas[i + 1];
                    mas[i + 1] ^= mas[i];
                    mas[i] ^= mas[i + 1];
                }
            else
                for (int i = 0; i < mas.Length - 1; i += 2)
                {
                    mas[i] ^= mas[i + 1];
                    mas[i + 1] ^= mas[i];
                    mas[i] ^= mas[i + 1];
                }
        }

        public static int[] Poisk(int[] mas, int poisk, ref int количество_сравнений)
        {
            if (!sorted)
            {
                int[] poiskmas = new int[mas.Length];
                int j = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    poiskmas[i] = -1;
                    if (mas[i] == poisk)
                        poiskmas[j++] = i;
                    количество_сравнений++;
                }
                return poiskmas.Where(i => i != -1).ToArray();
            }
            else return BinaryPoisk(mas, poisk, 0, mas.Length, ref количество_сравнений);
        }

        public static void Sort(ref int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                int mini = i;
                for (int j = i + 1; j < mas.Length; j++)
                    if (mas[j] < mas[mini])
                        mini = j;
                temp = mas[i];
                mas[i] = mas[mini];
                mas[mini] = temp;
                //mas[mini] ^= mas[i];
                //mas[i] ^= mas[mini];
                //mas[mini] ^= mas[i];
            }
        }

        public static void Proverka(int[] m)
        {
            if (m.Length < 1)
                throw new ArgumentNullException();
        }

        public static int[] BinaryPoisk(int[] array, int searchedValue, int left, int right, ref int количество_сравнений)
        {
            while (left <= right)
            {
                var middle = (left + right) / 2;
                if (searchedValue == array[middle])
                {
                    количество_сравнений++;
                    return new int[1] { middle };
                }
                else if (searchedValue < array[middle])
                {
                    количество_сравнений += 2;
                    right = middle - 1;
                }
                else
                    left = middle + 1;
            }
            return new int[0];
        }

        public static void menu()
        {
            try
            {
                Console.Write("   1. Создать массив\n" +
                    "   2. Распечатать массив\n" +
                    "   3. Удалить минимальный элемент массива\n" +
                    "   4. Добавить N элементов, начиная с номера K\n" +
                    "   5. Поменять местами элементы с четными и нечетными номерами\n" +
                    "   6. Найти элемент с заданным ключом\n" +
                    "   7. Рассортировать массив простым выбором\n" +
                    "   8. Выйти из программы\n\n" +
                    "Выберите задание: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        sorted = false;
                        int n = Vvodn();
                        mas = DoMAS(n);
                        Console.Clear();
                        menu();
                        break;

                    case 2:
                        Proverka(mas);
                        Console.Clear();
                        Console.WriteLine("Массив равен:");
                        Vivod(mas);
                        Console.WriteLine();
                        menu();
                        break;

                    case 3:
                        Proverka(mas);
                        DelMin(ref mas);
                        Console.Clear();
                        menu();
                        break;

                    case 4:
                        sorted = false;
                        Proverka(mas);
                        int N = 0;
                        int K = 0;
                        VvodNK(ref N, ref K);
                        Dobavit(ref mas, N, K);
                        Console.Clear();
                        menu();
                        break;

                    case 5:
                        sorted = false;
                        Proverka(mas);
                        Swap(ref mas);
                        Console.Clear();
                        menu();
                        break;

                    case 6:
                        Proverka(mas);
                        int poisk = VvodPoisk();
                        int sravn = 0;
                        Console.Clear();
                        Vivod(Poisk(mas, poisk, ref sravn), false);
                        Console.WriteLine("Колличество сравнений равно: {0}\n", sravn);
                        menu();
                        break;

                    case 7:
                        sorted = true;
                        Proverka(mas);
                        Sort(ref mas);
                        Console.Clear();
                        menu();
                        break;

                    case 8:
                        Console.Write("Нажмите любую клавишу для выхода...");
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат числа\n");
                        Console.ResetColor();
                        menu();
                        break;
                }
            }
            catch (ArgumentNullException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Функция применена к пустому массиву\n");
                Console.ResetColor();
                menu();
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа\n");
                Console.ResetColor();
                menu();
            }
        }

        private static void Main(string[] args)
        {
            /*int N = 0;
            int K = 0;
            int kolvo_sravn = 0;
            int n = Vvodn();
            int[] mas = DoMAS(n);
            Console.WriteLine("Изначальный массив:");
            Vivod(mas);
            DelMin(ref mas);
            Console.WriteLine("Массив, после удаления минимального:");
            Vivod(mas);
            VvodNK(ref N, ref K, ref mas);
            Dobavit(ref mas, N, K);
            Console.WriteLine("Массив полсе добавления элементов:");
            Vivod(mas);
            Swap(ref mas);
            Console.WriteLine("Массив после перестановки:");
            Vivod(mas);
            int poisk = VvodPoisk();
            Console.Write($"Массив адресов, покоторым находится значение {poisk}: ");
            Vivod(Poisk(mas, poisk, ref kolvo_sravn), false);
            Console.WriteLine($"Количество сравнений при поиске: {kolvo_sravn}");
            kolvo_sravn = 0;
            int[] masorigin = new int[mas.Length];
            mas.CopyTo(masorigin.AsMemory());
            Sort(ref mas);
            Sort(ref masorigin);
            Vivod(mas);
            Console.Write($"Массив адресов, покоторым находится значение {poisk}: ");
            Vivod(Poisk(mas, poisk, ref kolvo_sravn), false);
            Console.WriteLine($"Количество сравнений при поиске: {kolvo_sravn}");*/
            menu();
            Console.ReadKey();
        }
    }
}