using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba_12
{
    public partial class Task
    {
        public unsafe class BidirectionalList<T> : ICloneable, IEnumerable<T>, IEnumerator<T>
        {
            public BidirectionalList()
            {
                Reset();
            }

            public BidirectionalList(int capacity)
            {
                Reset();
                for (int i = 0; i < capacity; i++)
                    Add(default(T));
            }

            public BidirectionalList(BidirectionalList<T> unidirectionalList)
            {
                Reset();
                foreach (T data in unidirectionalList)
                {
                    Add(data);
                }
            }

            public BidirectionalList(Point<T> startPoint)
            {
                Reset();
                point = startPoint;
            }

            public class Point<TT>
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
                    Point<T> nextPoint = point.next;
                    while (nextPoint.next != null)
                    {
                        nextPoint = nextPoint.next;
                    }

                    _length++;
                    nextPoint.next = new Point<T>(data, nextPoint);
                }
            }

            public void Add(int index, T data)
            {
                if (index == _length)
                {
                    this.Add(data);
                }
                else
                {
                    if (_length == 0)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    else if (point.next == null)
                    {
                        if (index == 0)
                        {
                            point = new Point<T>(data, point, null);
                            _length++;
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
                            point = new Point<T>(data, point, null);
                            _length++;
                        }
                        else if (index == 1)
                        {
                            point.next = new Point<T>(data, point.next, point);
                            _length++;
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
                        _length = 0;
                        point.data = default;
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
                        point = point.next;
                        point.prev = null;
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

            public object Clone()
            {
                return new BidirectionalList<T>(point);
            }

            private Point<T> _current;

            public object Current
            {
                get
                {
                    return _current.data;
                }
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return _current.data;
                }
            }

            public void Reset()
            {
                _current = point;
            }

            public bool MoveNext()
            {
                if (_current.next == null)
                {
                    Reset();
                    return false;
                }
                else
                {
                    _current = _current.next;
                    return true;
                }
            }

            public BidirectionalList<T> Copy()
            {
                return new BidirectionalList<T>(this);
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (_length == 0)
                    yield break;
                Point<T> current = point;
                while (current != null)
                {
                    yield return current.data;
                    current = current.next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Dispose()
            {
            }

            public void Clear()
            {
                point = new Point<T>();
                _length = 0;
                Reset();
                GC.Collect();
            }
        }
    }
}