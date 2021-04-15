using System;

namespace Laba_12
{
    public partial class Task1
    {
        private unsafe class BidirectionalList<T>
        {
            private class Point<TT>
            {
                public TT data;

                public Point<TT> next, //адрес следующего элемента
                                 prev; //адрес предыдущего элемента

                public Point()
                {
                    data = default;
                    next = null;
                    prev = null;
                }

                public Point(TT d)
                {
                    data = d;
                    next = null;
                    prev = null;
                }

                public Point(TT d, Point<TT> prev)
                {
                    data = d;
                    next = null;
                    this.prev = prev;
                }

                public Point(TT d, Point<TT> next, Point<TT> prev)
                {
                    data = d;
                    this.next = next;
                    this.prev = prev;
                }

                public override string ToString()
                {
                    return data + "\n";
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

            private static T baseelement = default;

            private Point<T> point = new Point<T>(baseelement);

            public void Add(T data)
            {
                if ((object)point.data == (object)baseelement)
                {
                    _length++;
                    point.data = data;
                }
                else if (point.next == null)
                {
                    _length++;
                    point.next = new Point<T>(data, point);
                }
                else
                {
                    Point<T> nextpoint = point.next;
                    while (nextpoint.next != null)
                    {
                        nextpoint = nextpoint.next;
                    }

                    _length++;
                    nextpoint.next = new Point<T>(data, nextpoint);
                }
            }

            public void Add(int index, T data)
            {
                if (index == _length)
                    this.Add(data);
                else
                {
                    if ((object)point.data == (object)baseelement)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    else if (point.next == null)
                    {
                        if (index == 0)
                        {
                            point = new Point<T>(data, point, null);
                        }
                        else
                        {
                            throw new IndexOutOfRangeException();
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
                            nextPoint.prev = new Point<T>(data, nextPoint, backPoint);
                            backPoint.next = nextPoint.prev;
                            _length++;
                        }
                        catch (System.NullReferenceException)
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }
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
                        _length = 0;
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
                            point.next = new Point<T>(point.next.next.data, point.next.next.next, null);
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
                            nextPoint.prev = null;
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