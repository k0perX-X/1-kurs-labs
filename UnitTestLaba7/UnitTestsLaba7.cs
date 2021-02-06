using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Diapason = ����_7.Diapason;
using DiapasonArray = ����_7.DiapasonArray;

namespace UnitTestLaba7
{
    [TestClass]
    public class UnitTestDiapason
    {
        [TestMethod]
        public void ��������_Diapason_���_����������()
        {
            Diapason dp;
            dp = new Diapason();
            if (dp.X != 0)
            {
                throw new Exception("X �� ����� 0");
            }
            if (dp.Y != 0)
            {
                throw new Exception("Y �� ����� 0");
            }
        }

        [TestMethod]
        public void ��������_Diapason_c_�����������_MAX_MIN()
        {
            Diapason dp;
            dp = new Diapason(double.MinValue, double.MinValue);
            if (dp.X != double.MinValue)
            {
                throw new Exception("�� ����� double.MinValue");
            }
            if (dp.Y != double.MinValue)
            {
                throw new Exception("�� ����� double.MinValue");
            }
            dp = new Diapason(double.MaxValue, double.MaxValue);
            if (dp.X != double.MaxValue)
            {
                throw new Exception("�� ����� double.MaxValue");
            }
            if (dp.Y != double.MaxValue)
            {
                throw new Exception("�� ����� double.MaxValue");
            }
        }

        [TestMethod]
        public void ��������_Diapason_c_�����������_���������_��������()
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
                    throw new Exception("�� ����� ��������");
                }
                if (dp.Y != y)
                {
                    throw new Exception("�� ����� ��������");
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
            if (!����_7.Program.Intersection(dp1, dp2))
                throw new Exception("����_7.Program.Intersection(dp1, dp2)");
            if (!����_7.Program.Intersection(dp2, dp1))
                throw new Exception("����_7.Program.Intersection(dp2, dp1)");
            if (!����_7.Program.Intersection(dp1, dp1))
                throw new Exception("����_7.Program.Intersection(dp1, dp1)");

            dp1 = new Diapason(1.5, 2);
            dp2 = new Diapason(1, 4);
            if (!dp1.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!dp2.Intersection(dp1))
                throw new Exception("dp2.Intersection(dp1)");
            if (!dp2.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!����_7.Program.Intersection(dp1, dp2))
                throw new Exception("����_7.Program.Intersection(dp1, dp2)");
            if (!����_7.Program.Intersection(dp2, dp1))
                throw new Exception("����_7.Program.Intersection(dp2, dp1)");
            if (!����_7.Program.Intersection(dp1, dp1))
                throw new Exception("����_7.Program.Intersection(dp1, dp1)");

            dp1 = new Diapason(1.5, 2);
            dp2 = new Diapason(1.7, 4);
            if (!dp1.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!dp2.Intersection(dp1))
                throw new Exception("dp2.Intersection(dp1)");
            if (!dp2.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (!����_7.Program.Intersection(dp1, dp2))
                throw new Exception("����_7.Program.Intersection(dp1, dp2)");
            if (!����_7.Program.Intersection(dp2, dp1))
                throw new Exception("����_7.Program.Intersection(dp2, dp1)");
            if (!����_7.Program.Intersection(dp1, dp1))
                throw new Exception("����_7.Program.Intersection(dp1, dp1)");

            dp1 = new Diapason(1, 1.5);
            dp2 = new Diapason(1.7, 4);
            if (dp1.Intersection(dp2))
                throw new Exception("dp1.Intersection(dp2)");
            if (dp2.Intersection(dp1))
                throw new Exception("dp1.Intersection(dp2)");
            if (����_7.Program.Intersection(dp1, dp2))
                throw new Exception("����_7.Program.Intersection(dp1, dp2)");
            if (����_7.Program.Intersection(dp2, dp1))
                throw new Exception("����_7.Program.Intersection(dp2, dp1)");
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
                    throw new Exception("�� ����� ��������");
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
                    throw new Exception("�� ����� ��������");
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
                    throw new Exception("�� ����� ��������");
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
                    throw new Exception("�� ����� ��������");
                if (((int)y - dp).Y != 0)
                    throw new Exception("�� ����� ��������");
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
        public void ��������_DiapasonArray_���_����������()
        {
            DiapasonArray arr = new DiapasonArray();
            for (int i = 0; i < 10; i++)
                if (arr.arr[i].X != i || arr.arr[i].Y != 10 - i)
                    throw new Exception("�� ����� ��������");
        }

        [TestMethod]
        public void ��������_DiapasonArray_c_�����������_N_MAX_MIN()
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