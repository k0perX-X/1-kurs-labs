using System;

namespace Laba_12
{
    public partial class Task1
    {
        private unsafe class UnidirectionalList<T>
        {
            private class Point<TT>
            {
                public TT data; //информационное поле
                public Point<TT> next; //адресное поле

                public Point() //конструктор без параметров
                {
                    data = default(TT);
                    next = null;
                }

                public Point(TT d) //конструктор с параметрами
                {
                    data = d;
                    next = null;
                }

                public Point(TT d, Point<TT> next) //конструктор с параметрами
                {
                    data = d;
                    this.next = next;
                }

                public override string ToString()
                {
                    return data + "\n\n";
                }
            }

            private static T baseelement = default;

            private Point<T> point = new Point<T>(baseelement);

            public void Add(T data)
            {
                if ((object)point.data == (object)baseelement)
                {
                    point.data = data;
                }
                else if (point.next == null)
                {
                    point.next = new Point<T>(data);
                }
                else
                {
                    Point<T> nextpoint = point.next;
                    while (nextpoint.next != null)
                    {
                        nextpoint = nextpoint.next;
                    }

                    nextpoint.next = new Point<T>(data);
                }
            }

            public void Remove(int index)
            {
                if ((object)point.data == (object)baseelement)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (point.next == null)
                {
                    if (index == 0)
                    {
                        point.data = baseelement;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                else
                {
                    if (index == 0)
                    {
                        point = new Point<T>(point.next.data, point.next.next);
                    }
                    else if (index == 1)
                    {
                        if (point.next.next == null)
                        {
                            point.next = null;
                        }
                        else
                        {
                            point.next = new Point<T>(point.next.next.data, point.next.next.next);
                        }
                    }
                    else
                    {
                        Point<T> nextPoint = point.next;
                        Point<T> backPoint = point.next;
                        try
                        {
                            for (int j = 1; j < index; j++)
                            {
                                backPoint = nextPoint;
                                nextPoint = nextPoint.next;
                            }
                            backPoint.next = nextPoint.next;
                            nextPoint.next = null;
                            nextPoint.data = default;
                        }
                        catch (System.NullReferenceException)
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }
                }
            }

            public int Find<TT>(TT value, delegate*<T, TT> func)
            {
                if ((object)point.data == (object)baseelement)
                {
                    return -1;
                }
                else if (point.next == null)
                {
                    if (func(point.data).Equals(value))
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (func(point.data).Equals(value))
                    {
                        return 0;
                    }
                    Point<T> nextPoint = point.next;
                    int i = 1;
                    while (func(nextPoint.data).Equals(value))
                    {
                        if (nextPoint.next == null)
                            return -1;
                        nextPoint = nextPoint.next;
                        i++;
                    }
                    return i;
                }
            }

            public override string ToString()
            {
                string s = "";

                if ((object)point.data == (object)baseelement)
                {
                    return "";
                }
                else if (point.next == null)
                {
                    return "0.  " + point.ToString();
                }
                else
                {
                    int i = 0;
                    Point<T> nextpoint = point.next;
                    s += $"{i++}.  " + point.ToString();
                    while (nextpoint.next != null)
                    {
                        s += $"{i++}.  " + nextpoint.ToString();
                        nextpoint = nextpoint.next;
                    }
                    s += $"{i++}.  " + nextpoint.ToString();
                    return s;
                }
            }
        }
    }
}