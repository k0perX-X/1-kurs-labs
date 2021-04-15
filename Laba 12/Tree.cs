using System.Diagnostics;
using System.Linq;

namespace Laba_12
{
    public partial class Task1
    {
        public unsafe class Tree<T>
        {
            private class Point<TT>
            {
                public TT data;

                public Point<TT> left,
                                 right;

                public Point(TT d)
                {
                    data = d;
                    left = null;
                    right = null;
                }

                public Point(TT d, Point<TT> left, Point<TT> right)
                {
                    data = d;
                    this.left = left;
                    this.right = right;
                }

                public override string ToString()
                {
                    return data + "\n\n";
                }
            }

            private delegate*<T, int> func;

            private Point<T> root = new Point<T>(default(T));

            private int _length;

            public int Length
            {
                get
                {
                    return _length;
                }
            }

            public Tree(delegate*<T, int> func)
            {
                this.func = func;
            }

            public void Add(T obj)
            {
                if (_length == 0)
                {
                    root = new Point<T>(obj);
                }
                else
                {
                    Point<T> nextPoint = root;
                    bool bolshe;
                    if (func(obj) > func(nextPoint.data))
                        bolshe = true;
                    else
                        bolshe = false;
                    while (((bolshe) && (nextPoint.right != null)) || ((!bolshe) && (nextPoint.left != null)))
                    {
                        if (bolshe)
                            nextPoint = nextPoint.right;
                        else
                            nextPoint = nextPoint.left;
                        if (func(obj) > func(nextPoint.data))
                            bolshe = true;
                        else
                            bolshe = false;
                    }
                    if (bolshe)
                        nextPoint.right = new Point<T>(obj);
                    else
                        nextPoint.left = new Point<T>(obj);
                }

                _length++;
            }

            public override string ToString()
            {
                string s = "";

                void f(Point<T> point, string route)
                {
                    if (point.left != null)
                        f(point.left, route + "L");
                    s += route + ": " + point;
                    if (point.right != null)
                        f(point.right, route + "R");
                }

                if (_length == 0)
                {
                    return "";
                }
                f(root, "");
                return s;
            }

            public T[] ConvertToArray()
            {
                void ToHigher(ref T[] arr, Point<T> point, ref int i)
                {
                    if (point.left != null)
                        ToHigher(ref arr, point.left, ref i);
                    arr[i] = point.data;
                    i++;
                    if (point.right != null)
                        ToHigher(ref arr, point.right, ref i);
                }
                T[] array = new T[_length];
                int i = 0;
                if (_length != 0)
                    ToHigher(ref array, root, ref i);
                return array;
            }

            public void ConvertToBalanced()
            {
                BalancedFromArray(ConvertToArray());
            }

            private void BalancedFromArray(T[] arr)
            {
                void f(int low, int high, Point<T> prevPoint, bool left)
                {
                    if (low < high)
                    {
                        if (left)
                        {
                            prevPoint.left = new Point<T>(arr[(high - low + 1) / 2 + low]);
                            f(low, (high - low + 1) / 2 + low - 1, prevPoint.left, true);
                            f((high - low + 1) / 2 + low + 1, high, prevPoint.left, false);
                        }
                        else
                        {
                            prevPoint.right = new Point<T>(arr[(high - low + 1) / 2 + low]);
                            f(low, (high - low + 1) / 2 + low - 1, prevPoint.right, true);
                            f((high - low + 1) / 2 + low + 1, high, prevPoint.right, false);
                        }
                    }
                    else if (low == high)
                    {
                        if (left)
                        {
                            prevPoint.left = new Point<T>(arr[low]);
                        }
                        else
                        {
                            prevPoint.right = new Point<T>(arr[low]);
                        }
                    }
                }

                if (_length != 0)
                {
                    root = new Point<T>(arr[arr.Length / 2]);
                    f(0, arr.Length / 2 - 1, root, true);
                    f(arr.Length / 2 + 1, arr.Length - 1, root, false);
                }
            }

            public void Remove(int value)
            {
                T[] arr = ConvertToArray().Where(x => func(x) != value).ToArray(); ;
                if (arr.Length == 0)
                {
                    root.data = default;
                    _length = 0;
                }
                else
                {
                    _length = arr.Length;
                    BalancedFromArray(arr);
                }
            }

            public T min()
            {
                Point<T> nextPoint = root;
                while (nextPoint.left != null)
                    nextPoint = nextPoint.left;
                return nextPoint.data;
            }

            public T max()
            {
                Point<T> nextPoint = root;
                while (nextPoint.right != null)
                    nextPoint = nextPoint.right;
                return nextPoint.data;
            }
        }
    }
}