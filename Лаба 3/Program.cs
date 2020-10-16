using System;

namespace Лаба_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            decimal fac(int n)
            {
                decimal f = 1;
                for (int i = 1; i <= n; i++)
                {
                    f *= i;
                }
                return f;
            }
            const decimal a = 0m;
            const decimal b = 1m;
            const decimal nk = 10;
            const decimal k = 10;
            const decimal e = 0.0001m;
            for (decimal x = (b - a) / k; x <= b; x += (b - a) / k)
            {
                decimal SE = 1, SN = 1;
                int n = 1;
                decimal an = decimal.MaxValue;
                while ((n <= nk) || (an > e))
                {
                    an = ((2 * n + 1) * (decimal)Math.Pow((double)x, 2 * n) / fac(n));
                    if (n <= nk)
                    {
                        SN += an;
                        n++;
                    }
                    if (an > e)
                    {
                        SE += an;
                    }
                }
                Console.WriteLine($"X = {x} SN = {SN} SE = {SE} Y = {(1 + 2 * x * x) * (decimal)Math.Pow(Math.E, (double)(x * x))}");
            }
            Console.ReadKey();
        }
    }
}