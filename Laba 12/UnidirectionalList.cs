using System;

namespace Laba_12
{
    public partial class Task1
    {
        public unsafe class UnidirectionalList<T>
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

            private int _length;

            public int Length
            {
                get
                {
                    return _length;
                }
            }

            private Point<T> point = new Point<T>();

            public void Add(T data)
            {
                if (_length == 0)
                {
                    point.data = data;
                    _length = 1;
                }
                else if (point.next == null)
                {
                    point.next = new Point<T>(data);
                    _length = 2;
                }
                else
                {
                    Point<T> nextPoint = point.next;
                    while (nextPoint.next != null)
                    {
                        nextPoint = nextPoint.next;
                    }

                    _length++;
                    nextPoint.next = new Point<T>(data);
                }
            }

            public void Remove(int index)
            {
                if (_length == 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (point.next == null)
                {
                    if (index == 0)
                    {
                        point.data = default;
                        _length = 0;
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
                        _length--;
                    }
                    else if (index == 1)
                    {
                        if (point.next.next == null)
                        {
                            point.next = null;
                            _length--;
                        }
                        else
                        {
                            point.next = new Point<T>(point.next.next.data, point.next.next.next);
                            _length--;
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
                            _length--;
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
                if (_length == 0)
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
                    while (!func(nextPoint.data).Equals(value))
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

                if (_length == 0)
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