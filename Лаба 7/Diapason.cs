using System;

namespace Лаба_7
{
    public class Diapason
    {
        public double X { get; set; }
        public double Y { get; set; }
        public static int count = 0;

        public Diapason()
        {
            this.X = 0;
            this.Y = 0;
            count++;
        }

        public Diapason(double x, double y)
        {
            this.X = x;
            this.Y = y;
            count++;
        }

        public bool Intersection(Diapason dp)
        {
            double x1, x2, y1, y2;
            if (dp.X > dp.Y)
            {
                x2 = dp.Y;
                y2 = dp.X;
            }
            else
            {
                y2 = dp.Y;
                x2 = dp.X;
            }
            if (this.X > this.Y)
            {
                x1 = this.Y;
                y1 = this.X;
            }
            else
            {
                y1 = this.Y;
                x1 = this.X;
            }
            if (x1 >= x2 & x1 <= y2)
                return true;
            if (y1 >= x2 & y1 <= y2)
                return true;
            if (x2 >= x1 & x2 <= y1)
                return true;
            if (y2 >= x1 & y2 <= y1)
                return true;
            return false;
        }

        public static double operator !(Diapason dp)
        {
            return Math.Abs(dp.X - dp.Y);
        }

        public static implicit operator int(Diapason dp)
        {
            return (int)dp.X;
        }

        public static explicit operator double(Diapason dp)
        {
            return dp.Y;
        }

        public static Diapason operator -(Diapason dp, int x)
        {
            dp.X -= x;
            return dp;
        }

        public static Diapason operator -(int y, Diapason dp)
        {
            dp.Y -= y;
            return dp;
        }

        public static bool operator <(Diapason dp1, Diapason dp2)
        {
            double x1, x2, y1, y2;
            if (dp1.X > dp1.Y)
            {
                x1 = dp1.Y;
                y1 = dp1.X;
            }
            else
            {
                y1 = dp1.Y;
                x1 = dp1.X;
            }
            if (dp2.X > dp2.Y)
            {
                x2 = dp2.Y;
                y2 = dp2.X;
            }
            else
            {
                y2 = dp2.Y;
                x2 = dp2.X;
            }
            if (y1 >= x2 & y1 <= y2)
                return true;
            return false;
        }

        public static bool operator >(Diapason dp1, Diapason dp2)
        {
            throw new Exception("Применение >");
        }

        ~Diapason()
        {
            count--;
        }
    }
}