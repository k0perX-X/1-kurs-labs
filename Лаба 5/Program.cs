using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Лаба_4;

namespace Лаба_5
{
    internal class Program
    {
        public static int[] DobavitEl(int[] arr)
        {
            int[] newmas = new int[arr.Length + 1];
            newmas[0] = Laba4.rand.Next(Laba4.min, Laba4.max);
            for (int i = 0; i < arr.Length; i++)
            {
                newmas[i + 1] = arr[i];
            }
            return newmas;
        }

        public static int[,] DoDvumerMas(int n, int k)
        {
            var arr = new int[n, k];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                    arr[i, j] = Laba4.rand.Next(Laba4.min, Laba4.max);
            return arr;
        }

        public static void VivodDvumerMas(int[,] mas, bool skobka = true)
        {
            if (mas.Length > 0)
            {
                if (skobka) Console.Write("[");
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    if (skobka) Console.Write("[");
                    for (int j = 0; j < mas.GetLength(1) - 1; j++)
                        Console.Write($"{mas[i, j]}, ");
                    Console.Write(mas[i, mas.GetLength(1) - 1]);
                    if (skobka)
                        if (i != mas.GetLength(0) - 1) Console.Write("],");
                        else Console.Write("]");
                    if (i != mas.GetLength(0) - 1) Console.WriteLine();
                }
                if (skobka) Console.WriteLine("]");
            }
            else
                if (skobka) Console.WriteLine("Массив пустой");
        }

        public static void SizeOf(object arr, out long size)
        {
            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Тип или член устарел
                formatter.Serialize(stream, arr);
#pragma warning restore SYSLIB0011 // Тип или член устарел
                size = stream.Length;
                Debug.Print(size.ToString());
            }
        }

        public static void DelStolb(ref int[,] arr, int k)
        {
            var newmas = new int[arr.GetLength(0), arr.GetLength(1) - 1];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < k; j++)
                    newmas[i, j] = arr[i, j];
                for (int j = k + 1; j < arr.GetLength(1); j++)
                    newmas[i, j - 1] = arr[i, j];
            }
            arr = newmas;
        }

        public static void VivodDvumerMas(int[][] mas, bool skobka = true)
        {
            if (mas.Length > 0)
            {
                if (skobka) Console.Write("[");
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i].Length > 0)
                    {
                        if (skobka) Console.Write("[");
                        for (int j = 0; j < mas[i].Length - 1; j++)
                            Console.Write($"{mas[i][j]}, ");
                        Console.Write(mas[i][mas[i].Length - 1]);
                        if (skobka)
                            if (i != mas.Length - 1) Console.Write("],");
                            else Console.Write("]");
                        if (i != mas.Length - 1) Console.WriteLine();
                    }
                    else if (skobka)
                        if (i != mas.Length - 1) Console.WriteLine("[],");
                        else Console.Write("[]");
                }
                if (skobka) Console.WriteLine("]");
            }
            else
                if (skobka) Console.WriteLine("Массив пустой");
        }

        public static int[][] DoDvumerMas(int n, int min, int max)
        {
            int[][] arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new int[Laba4.rand.Next(min, max)];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = Laba4.rand.Next(Laba4.min, Laba4.max);
                }
            }
            return arr;
        }

        public static int[][] DobavitKN(int[][] arr, int k, int n, int min, int max)
        {
            int[][] mas = new int[arr.Length + k][];
            for (int i = 0; i < n; i++)
                mas[i] = arr[i];
            for (int i = n; i < n + k; i++)
            {
                mas[i] = new int[Laba4.rand.Next(min, max)];
                for (int j = 0; j < mas[i].Length; j++)
                {
                    mas[i][j] = Laba4.rand.Next(Laba4.min, Laba4.max);
                }
            }
            for (int i = n + k; i < mas.Length; i++)
                mas[i] = arr[i - k];
            return mas;
        }

        public static bool Menu()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nМЕНЮ\n");
                Console.ResetColor();
                Console.Write("   1. Задание для одномерного массива\n" +
                    "   2. Задание для двумерного массива\n" +
                    "   3. Задание для массива массивов\n" +
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
                            Console.WriteLine("Определение одномерного массива размером n");
                            int[] arr = Laba4.DoMAS(Laba4.Vvodn());
                            Console.WriteLine("\nВывод изначального массива");
                            Laba4.Vivod(arr);
                            SizeOf(arr, out _);
                            Console.WriteLine("\nВывод измененного массива");
                            arr = DobavitEl(arr);
                            SizeOf(arr, out _);
                            Laba4.Vivod(arr);
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
                            Console.WriteLine("Определение двумерного массива размером n*m");
                            var arr = DoDvumerMas(Laba4.Vvodn(), Laba4.Vvodn("Пожалуйста, введите m: "));
                            var k = Laba4.Vvodn("Пожалуйста, введите номер столбца, который требуется удалить: ", menshe: arr.GetLength(1)) - 1;
                            Console.WriteLine("\nВывод изначального массива");
                            VivodDvumerMas(arr);
                            SizeOf(arr, out _);
                            Console.WriteLine("\nВывод измененного массива");
                            DelStolb(ref arr, k);
                            VivodDvumerMas(arr);
                            SizeOf(arr, out _);
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
                            Console.WriteLine("Определение двумерного массива размером n*(в диапозоне от min до max)");
                            int min; int max; int kolvo;
                            var arr = DoDvumerMas(kolvo = Laba4.Vvodn(), min = Laba4.Vvodn("Пожалуйста, введите min: "), max = Laba4.Vvodn("Пожалуйста, введите max: "));
                            Console.WriteLine("Добавить К строк, начиная с номера N");
                            int k = Laba4.Vvodn("Пожалуйста, введите K: ");
                            int n = Laba4.Vvodn("Пожалуйста, введите N: ", menshe: kolvo);
                            Console.WriteLine("\nВывод изначального массива");
                            VivodDvumerMas(arr);
                            SizeOf(arr, out _);
                            Console.WriteLine("\nВывод измененного массива");
                            VivodDvumerMas(arr = DobavitKN(arr, k, n, min, max));
                            SizeOf(arr, out _);
                        }
                        Console.WriteLine();
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
            while (Menu()) ;
        }
    }
}