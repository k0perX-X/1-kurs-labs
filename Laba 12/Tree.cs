using System;
using System.Linq;

namespace Laba_12
{
    public partial class Task
    {
        public class CollectionHandlerEventArgs : EventArgs
        {
            public string NameCollection { get; set; }
            public string TypeOfChange { get; set; }
            public object Object { get; set; }

            public CollectionHandlerEventArgs(string name, string type, object obj)
            {
                NameCollection = name;
                TypeOfChange = type;
                Object = obj;
            }

            public override string ToString()
            {
                return "Имя коллекции: " + NameCollection + "\nТип изменения: " + TypeOfChange + "\nОбъект: " + Object.ToString();
            }
        }

        public class Tree<T> : ICloneable
        {
            public T this[int index]
            {
                get
                {
                    return this.ToArray()[index];
                }

                set
                {
                    T[] mas = this.ToArray();
                    mas[index] = value;
                    BalancedFromArray(mas);
                }
            }

            public string Name { get; set; }

            public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

            public delegate void StandardDelegate();

            public event StandardDelegate DeleteEvent = () => { };

            public event StandardDelegate AddEvent = () => { };

            public event StandardDelegate ClearEvent = () => { };

            public event StandardDelegate BalanceEvent = () => { };

            public event CollectionHandler CollectionCountChanged =
                (object source, CollectionHandlerEventArgs args) => { };

            public event CollectionHandler CollectionReferenceChanged =
                (object source, CollectionHandlerEventArgs args) => { };

            public Tree(ToInt func)
            {
                this.func = func;
                root = new Point<T>(default(T), this);
            }

            public Tree(ToInt func, int capacity)
            {
                this.func = func;
                root = new Point<T>(default(T), this);
                for (int i = 0; i < capacity; i++)
                    Add(default(T));
            }

            public Tree(ToInt func, Tree<T> tree)
            {
                this.func = func;
                root = new Point<T>(default(T), this);
                foreach (T data in tree.ToArray())
                {
                    Add(data);
                }
            }

            public Tree(ToInt func, Point<T> root)
            {
                this.func = func;
                this.root = root;
            }

            public delegate int ToInt(T tValue);

            public class Point<TT>
            {
                public TT data;

                private Point<TT> _left, _right;

                public Point<TT> Left
                {
                    get
                    {
                        return _left;
                    }
                    set
                    {
                        _left = value;
                        tree.CollectionReferenceChanged(this, new CollectionHandlerEventArgs(tree.Name, "Left", this));
                    }
                }

                public Point<TT> Right
                {
                    get
                    {
                        return _right;
                    }
                    set
                    {
                        _right = value;
                        tree.CollectionReferenceChanged(this, new CollectionHandlerEventArgs(tree.Name, "Right", this));
                    }
                }

                private readonly Tree<TT> tree;

                public Point(TT d, Tree<TT> tree)
                {
                    this.tree = tree;
                    data = d;
                    Left = null;
                    Right = null;
                }

                public Point(TT d, Tree<TT> tree, Point<TT> left, Point<TT> right)
                {
                    this.tree = tree;
                    data = d;
                    this.Left = left;
                    this.Right = right;
                }

                public override string ToString()
                {
                    return data + "\n\n";
                }
            }

            private ToInt func;

            private Point<T> root;

            private int _length;

            public int Length
            {
                get
                {
                    return _length;
                }
            }

            public void Add(T obj)
            {
                CollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Add", this));
                AddEvent();
                if (_length == 0)
                {
                    root = new Point<T>(obj, this);
                }
                else
                {
                    Point<T> nextPoint = root;
                    bool bolshe;
                    if (func(obj) > func(nextPoint.data))
                        bolshe = true;
                    else
                        bolshe = false;
                    while (((bolshe) && (nextPoint.Right != null)) || ((!bolshe) && (nextPoint.Left != null)))
                    {
                        if (bolshe)
                            nextPoint = nextPoint.Right;
                        else
                            nextPoint = nextPoint.Left;
                        if (func(obj) > func(nextPoint.data))
                            bolshe = true;
                        else
                            bolshe = false;
                    }
                    if (bolshe)
                        nextPoint.Right = new Point<T>(obj, this);
                    else
                        nextPoint.Left = new Point<T>(obj, this);
                }

                _length++;
            }

            public void AddDefault()
            {
                Add(default(T));
            }

            public override string ToString()
            {
                string s = "";

                void f(Point<T> point, string route)
                {
                    if (point.Left != null)
                        f(point.Left, route + "L");
                    s += route + ": " + point;
                    if (point.Right != null)
                        f(point.Right, route + "R");
                }

                if (_length == 0)
                {
                    return "";
                }
                f(root, "");
                return s;
            }

            public T[] ToArray()
            {
                void ToHigher(ref T[] arr, Point<T> point, ref int i)
                {
                    if (point.Left != null)
                        ToHigher(ref arr, point.Left, ref i);
                    arr[i] = point.data;
                    i++;
                    if (point.Right != null)
                        ToHigher(ref arr, point.Right, ref i);
                }
                T[] array = new T[_length];
                int i = 0;
                if (_length != 0)
                    ToHigher(ref array, root, ref i);
                return array;
            }

            public void ConvertToBalanced()
            {
                BalancedFromArray(ToArray());
            }

            private void BalancedFromArray(T[] arr)
            {
                BalanceEvent();
                void f(int low, int high, Point<T> prevPoint, bool left)
                {
                    if (low < high)
                    {
                        if (left)
                        {
                            prevPoint.Left = new Point<T>(arr[(high - low + 1) / 2 + low], this);
                            f(low, (high - low + 1) / 2 + low - 1, prevPoint.Left, true);
                            f((high - low + 1) / 2 + low + 1, high, prevPoint.Left, false);
                        }
                        else
                        {
                            prevPoint.Right = new Point<T>(arr[(high - low + 1) / 2 + low], this);
                            f(low, (high - low + 1) / 2 + low - 1, prevPoint.Right, true);
                            f((high - low + 1) / 2 + low + 1, high, prevPoint.Right, false);
                        }
                    }
                    else if (low == high)
                    {
                        if (left)
                        {
                            prevPoint.Left = new Point<T>(arr[low], this);
                        }
                        else
                        {
                            prevPoint.Right = new Point<T>(arr[low], this);
                        }
                    }
                }

                if (_length != 0)
                {
                    root = new Point<T>(arr[arr.Length / 2], this);
                    f(0, arr.Length / 2 - 1, root, true);
                    f(arr.Length / 2 + 1, arr.Length - 1, root, false);
                }
            }

            public bool Remove(int value)
            {
                CollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Remove", this));
                int startLength = Length;
                T[] arr = ToArray().Where(x => func(x) != value).ToArray();
                DeleteEvent();
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

                if (Length == startLength)
                    return false;
                else
                    return true;
            }

            public T Find(int value)
            {
                Point<T> point = root;
                while (func(point.data) != value)
                {
                    if (func(point.data) > value)
                        if (point.Left != null)
                            point = point.Left;
                        else
                            throw new ArgumentException();
                    else
                        if (point.Right != null)
                        point = point.Right;
                    else
                        throw new ArgumentException();
                }
                return point.data;
            }

            public T Min()
            {
                Point<T> nextPoint = root;
                while (nextPoint.Left != null)
                    nextPoint = nextPoint.Left;
                return nextPoint.data;
            }

            public T Max()
            {
                Point<T> nextPoint = root;
                while (nextPoint.Right != null)
                    nextPoint = nextPoint.Right;
                return nextPoint.data;
            }

            public object Clone()
            {
                return new Tree<T>(func, root);
            }

            public Tree<T> Copy()
            {
                return new Tree<T>(func, this);
            }

            public void Clear()
            {
                CollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Clear", this));
                ClearEvent();
                root = new Point<T>(default, this);
                _length = 0;
                GC.Collect();
            }
        }
    }
}