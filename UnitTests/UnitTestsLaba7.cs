using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Diapason = Лаба_7.Diapason;
using DiapasonArray = Лаба_7.DiapasonArray;

namespace UnitTestLaba7
{
    [TestClass]
    public class UnitTestDiapason
    {
        [TestMethod]
        public void Создание_Diapason_без_параметров()
        {
            Diapason dp;
            dp = new Diapason();
            if (dp.X != 0)
            {
                throw new Exception("X не равно 0");
            }
            if (dp.Y != 0)
            {
                throw new Exception("Y не равно 0");
            }
        }

        [TestMethod]
        public void Создание_Diapason_c_параметрами_MAX_MIN()
        {
            Diapason dp;
            dp = new Diapason(double.MinValue, double.MinValue);
            if (dp.X != double.MinValue)
            {
                throw new Exception("Не равно double.MinValue");
            }
            if (dp.Y != double.MinValue)
            {
                throw new Exception("Не равно double.MinValue");
            }
            dp = new Diapason(double.MaxValue, double.MaxValue);
            if (dp.X != double.MaxValue)
            {
                throw new Exception("Не равно double.MaxValue");
            }
            if (dp.Y != double.MaxValue)
            {
                throw new Exception("Не равно double.MaxValue");
            }
        }

        [TestMethod]
        public void Создание_Diapason_c_параметрами_случайные_значения()
        {
            Diapason dp;
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double x, y;
                if (rnd.Next(2) == 0)
                    x = rnd.NextDouble() * double.MinValue;
                else
                    x = rnd.NextDouble() * double.MaxValue;
                if (rnd.Next(2) == 0)
                    y = rnd.NextDouble() * double.MinValue;
                else
                    y = rnd.NextDouble() * double.MaxValue;
                dp = new Diapason(x, y);
                if (dp.X != x)
                {
                    throw new Exception("Не равно значению");
                }
                if (dp.Y != y)
                {
                    throw new Exception("Не равно значению");
                }
            }
        }

        [TestMethod]
        public void Intersection()
        {
            Diapason dp1 = new Diapason(1.5, 2);
            Diapason dp2 = new Diapason(2, 4);
            if (!dp1.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!dp2.Intersection(dp1))
                throw new Exception("dp2.Intersection(dp1)");
            if (!dp2.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!Лаба_7.Program.Intersection(dp1, dp2))
                throw new Exception("Лаба_7.Program.Intersection(dp1, dp2)");
            if (!Лаба_7.Program.Intersection(dp2, dp1))
                throw new Exception("Лаба_7.Program.Intersection(dp2, dp1)");
            if (!Лаба_7.Program.Intersection(dp1, dp1))
                throw new Exception("Лаба_7.Program.Intersection(dp1, dp1)");

            dp1 = new Diapason(1.5, 2);
            dp2 = new Diapason(1, 4);
            if (!dp1.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!dp2.Intersection(dp1))
                throw new Exception("dp2.Intersection(dp1)");
            if (!dp2.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!Лаба_7.Program.Intersection(dp1, dp2))
                throw new Exception("Лаба_7.Program.Intersection(dp1, dp2)");
            if (!Лаба_7.Program.Intersection(dp2, dp1))
                throw new Exception("Лаба_7.Program.Intersection(dp2, dp1)");
            if (!Лаба_7.Program.Intersection(dp1, dp1))
                throw new Exception("Лаба_7.Program.Intersection(dp1, dp1)");

            dp1 = new Diapason(1.5, 2);
            dp2 = new Diapason(1.7, 4);
            if (!dp1.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!dp2.Intersection(dp1))
                throw new Exception("dp2.Intersection(dp1)");
            if (!dp2.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!Лаба_7.Program.Intersection(dp1, dp2))
                throw new Exception("Лаба_7.Program.Intersection(dp1, dp2)");
            if (!Лаба_7.Program.Intersection(dp2, dp1))
                throw new Exception("Лаба_7.Program.Intersection(dp2, dp1)");
            if (!Лаба_7.Program.Intersection(dp1, dp1))
                throw new Exception("Лаба_7.Program.Intersection(dp1, dp1)");

            dp1 = new Diapason(1, 1.5);
            dp2 = new Diapason(1.7, 4);
            if (dp1.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (dp2.Intersection(dp1))
                throw new Exception("dp1.Intersection(dp2)");
            if (Лаба_7.Program.Intersection(dp1, dp2))
                throw new Exception("Лаба_7.Program.Intersection(dp1, dp2)");
            if (Лаба_7.Program.Intersection(dp2, dp1))
                throw new Exception("Лаба_7.Program.Intersection(dp2, dp1)");
        }

        [TestMethod]
        public void Operator_exclamation_mark()
        {
            Diapason dp;
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double x, y;
                if (rnd.Next(2) == 0)
                    x = rnd.NextDouble() * double.MinValue;
                else
                    x = rnd.NextDouble() * double.MaxValue;
                if (rnd.Next(2) == 0)
                    y = rnd.NextDouble() * double.MinValue;
                else
                    y = rnd.NextDouble() * double.MaxValue;
                dp = new Diapason(x, y);
                if (!dp != Math.Abs(x - y))
                    throw new Exception("Не равно значению");
            }
        }

        [TestMethod]
        public void Operator_int()
        {
            Diapason dp;
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double x, y;
                if (rnd.Next(2) == 0)
                    x = rnd.NextDouble() * double.MinValue;
                else
                    x = rnd.NextDouble() * double.MaxValue;
                if (rnd.Next(2) == 0)
                    y = rnd.NextDouble() * double.MinValue;
                else
                    y = rnd.NextDouble() * double.MaxValue;
                dp = new Diapason(x, y);
                if ((int)dp != (int)x)
                    throw new Exception("Не равно значению");
            }
        }

        [TestMethod]
        public void Operator_double()
        {
            Diapason dp;
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double x, y;
                if (rnd.Next(2) == 0)
                    x = rnd.NextDouble() * double.MinValue;
                else
                    x = rnd.NextDouble() * double.MaxValue;
                if (rnd.Next(2) == 0)
                    y = rnd.NextDouble() * double.MinValue;
                else
                    y = rnd.NextDouble() * double.MaxValue;
                dp = new Diapason(x, y);
                if ((double)dp != y)
                    throw new Exception("Не равно значению");
            }
        }

        [TestMethod]
        public void Operator_minus()
        {
            Diapason dp;
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double x, y;
                if (rnd.Next(2) == 0)
                    x = rnd.NextDouble() * double.MinValue;
                else
                    x = rnd.NextDouble() * double.MaxValue;
                if (rnd.Next(2) == 0)
                    y = rnd.NextDouble() * double.MinValue;
                else
                    y = rnd.NextDouble() * double.MaxValue;
                dp = new Diapason((int)x, (int)y);
                if ((dp - (int)x).X != 0)
                    throw new Exception("Не равно значению");
                if (((int)y - dp).Y != 0)
                    throw new Exception("Не равно значению");
            }
        }

        [TestMethod]
        public void Operator_less()
        {
            Diapason dp1 = new Diapason(1.5, 2);
            Diapason dp2 = new Diapason(2, 4);
            if (!(dp1 < dp2))
                throw new Exception("!(dp1 < dp2)");
            if (dp2 < dp1)
                throw new Exception("dp2 < dp1");
            dp1 = new Diapason(1.5, 2);
            dp2 = new Diapason(1.7, 4);
            if (!(dp1 < dp2))
                throw new Exception("!(dp1 < dp2)");
            if (dp2 < dp1)
                throw new Exception("dp2 < dp1");
            dp1 = new Diapason(1.5, 2);
            dp2 = new Diapason(3, 4);
            if (dp1 < dp2)
                throw new Exception("dp1 < dp2");
            if (dp2 < dp1)
                throw new Exception("dp2 < dp1");
        }
    }

    [TestClass]
    public class UnitTestDiapasonArray
    {
        [TestMethod]
        public void Создание_DiapasonArray_без_параметров()
        {
            DiapasonArray arr = new DiapasonArray();
            for (int i = 0; i < 10; i++)
                if (arr.arr[i].X != i || arr.arr[i].Y != 10 - i)
                    throw new Exception("Не равно значению");
        }

        [TestMethod]
        public void Создание_DiapasonArray_c_параметрами_N_MAX_MIN()
        {
            Random rnd = new Random();
            DiapasonArray da;
            for (int i = 0; i < 1000; i++)
            {
                double x, y;
                do
                {
                    if (rnd.Next(2) == 0)
                        x = rnd.NextDouble() * double.MinValue;
                    else
                        x = rnd.NextDouble() * double.MaxValue;
                    if (rnd.Next(2) == 0)
                        y = rnd.NextDouble() * double.MinValue;
                    else
                        y = rnd.NextDouble() * double.MaxValue;
                } while (x > y);
                da = new DiapasonArray(rnd.Next(1000), x, y);
            }
        }
    }
}