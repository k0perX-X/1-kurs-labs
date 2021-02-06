using System;

namespace Лаба_7
{
    public class DiapasonArray
    {
        private Random rnd = new Random();
        public static int count = 0;

        public Diapason[] arr { get; set; }

        public DiapasonArray()
        {
            arr = new Diapason[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = new Diapason(i, 10 - i);
            }
            count++;
        }

        public void Vivod()
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.WriteLine($"X: {arr[i].X}, Y: {arr[i].Y},");
            }
            Console.WriteLine($"X: {arr[arr.Length - 1].X}, Y: {arr[arr.Length - 1].Y}]");
        }

        public DiapasonArray(int n, double min, double max)
        {
            arr = new Diapason[n];
            double mm = max - min;
            if (double.IsInfinity(mm))
                throw new Exception("Inappropriate min and max values");
            for (int i = 0; i < n; i++)
                arr[i] = new Diapason(rnd.NextDouble() * mm + min, rnd.NextDouble() * mm + min);
            count++;
        }

        public DiapasonArray(double min, double max)
        {
            arr = new Diapason[IntVvod("Введите количество элементов в массиве: ", 0)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].X = DoubleVvod($"Введите X у {i} элемента массива: ", min, max);
                arr[i].Y = DoubleVvod($"Введите Y у {i} элемента массива: ", min, max);
            }
            Console.WriteLine("Вы ввели массив: ");
            Vivod();
            count++;
        }

        private static double DoubleVvod(string predlojenie_vvoda, double bolshe = int.MinValue, double menshe = int.MaxValue)
        {
            double n;
            bool vihod = false;
            do
            {
                Console.Write(predlojenie_vvoda);
                if (!double.TryParse(Console.ReadLine(), out n))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
                else if (n > menshe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Число больше разрешенного");
                    Console.ResetColor();
                }
                else if (n < bolshe)
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

        private static int IntVvod(string predlojenie_vvoda, int bolshe = int.MinValue, int menshe = int.MaxValue)
        {
            int n;
            bool vihod = false;
            do
            {
                Console.Write(predlojenie_vvoda);
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат числа");
                    Console.ResetColor();
                }
                else if (n > menshe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Число больше разрешенного");
                    Console.ResetColor();
                }
                else if (n < bolshe)
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

        public Diapason MaxValue()
        {
            if (arr.Length == 0)
                return null;
            double max = !arr[0];
            int im = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < !arr[i])
                {
                    im = i;
                    max = !arr[i];
                }
            }
            return arr[im];
        }

        ~DiapasonArray()
        {
            count--;
        }
    }
}