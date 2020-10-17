using System;
using System.Linq;

namespace Лаба_4
{
    public class Laba4
    {
        public static Random rand = new Random();

        private const int max =
            //10;
            int.MaxValue;
        private const int min =
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

        public static void VvodNK(ref int n, ref int k, ref int[] mas)
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
            {
                Console.WriteLine("Массив пустой");
            }
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

        private static void Main(string[] args)
        {
            int N = 0;
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
            Console.WriteLine($"Количество сравнений при поиске: {kolvo_sravn}");
            Console.ReadKey();
        }
    }
}