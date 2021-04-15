using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Laba_12;

namespace UnitTestsLaba12
{
    [TestClass]
    public class BidirectionalList
    {
        [TestMethod]
        public void TestToString()
        {
            Task1.BidirectionalList<int> bidirectionalList = new Task1.BidirectionalList<int>();
            Debug.Print(bidirectionalList.ToString());
            bidirectionalList.Add(1);
            Debug.Print(bidirectionalList.ToString());
            for (int index = 0; index < 1000; index++)
                bidirectionalList.Add(index);
            Debug.Print(bidirectionalList.ToString());
        }

        [TestMethod]
        public void TestAdd()
        {
            Task1.BidirectionalList<int> bidirectionalList = new Task1.BidirectionalList<int>();
            Random random = new Random();
            for (int index = 0; index < 1000; index++)
                bidirectionalList.Add(random.Next(10000000));
            if (bidirectionalList.Length != 1000)
                throw new Exception("Length");
            Debug.Print(bidirectionalList.ToString());
        }

        [TestMethod]
        public void TestAddIndex()
        {
            Task1.BidirectionalList<int> bidirectionalList = new Task1.BidirectionalList<int>();
            Random random = new Random();
            bidirectionalList.Add(0, random.Next(10000000));
            bidirectionalList.Add(0, random.Next(10000000));
            bidirectionalList.Add(2, random.Next(10000000));
            bidirectionalList.Add(random.Next(1, 3), random.Next(10000000));
            if (bidirectionalList.Length != 4)
                throw new Exception("Length");
            Debug.Print(bidirectionalList.ToString());
        }

        [TestMethod]
        public void TestRemove()
        {
            Task1.BidirectionalList<int> bidirectionalList = new Task1.BidirectionalList<int>();
            Random random = new Random();
            bidirectionalList.Add(1);
            bidirectionalList.Remove(0);
            bidirectionalList.Add(1);
            bidirectionalList.Add(1);
            bidirectionalList.Remove(1);
            bidirectionalList.Remove(0);
            for (int index = 0; index < 1000; index++)
                bidirectionalList.Add(random.Next(10000000));
            bidirectionalList.Remove(0);
            bidirectionalList.Remove(1);
            bidirectionalList.Remove(random.Next(998));
            bidirectionalList.Remove(996);
            if (bidirectionalList.Length != 996)
                throw new Exception("Length");
            Debug.Print(bidirectionalList.ToString());
        }

        [TestMethod]
        public unsafe void TestFind()
        {
            static int func(int i)
            {
                return i;
            }
            Task1.BidirectionalList<int> bidirectionalList = new Task1.BidirectionalList<int>();
            Random random = new Random();
            for (int index = 0; index < 1000; index++)
                bidirectionalList.Add(index);
            if (bidirectionalList.Find<int>(0, &func) != 0)
                throw new Exception("0 " + bidirectionalList.Find<int>(0, &func));
            if (bidirectionalList.Find<int>(1, &func) != 1)
                throw new Exception("1 " + bidirectionalList.Find<int>(1, &func));
            if (bidirectionalList.Find<int>(999, &func) != 999)
                throw new Exception("999 " + bidirectionalList.Find<int>(999, &func).ToString());
            if (bidirectionalList.Find<int>(9999, &func) != -1)
                throw new Exception("-1 " + bidirectionalList.Find<int>(9999, &func).ToString());
            int x = random.Next(2, 999);
            if (bidirectionalList.Find<int>(x, &func) != x)
                throw new Exception("random " + bidirectionalList.Find<int>(x, &func));
            Debug.Print(bidirectionalList.ToString());
        }
    }

    [TestClass]
    public class UnidirectionalList
    {
        [TestMethod]
        public void TestToString()
        {
            Task1.UnidirectionalList<int> unidirectionalList = new Task1.UnidirectionalList<int>();
            Debug.Print(unidirectionalList.ToString());
            unidirectionalList.Add(1);
            Debug.Print(unidirectionalList.ToString());
            for (int index = 0; index < 1000; index++)
                unidirectionalList.Add(index);
            Debug.Print(unidirectionalList.ToString());
        }

        [TestMethod]
        public void TestAdd()
        {
            Task1.UnidirectionalList<int> unidirectionalList = new Task1.UnidirectionalList<int>();
            Random random = new Random();
            for (int index = 0; index < 1000; index++)
                unidirectionalList.Add(random.Next(10000000));
            if (unidirectionalList.Length != 1000)
                throw new Exception("Length");
            Debug.Print(unidirectionalList.ToString());
        }

        [TestMethod]
        public void TestRemove()
        {
            Task1.UnidirectionalList<int> unidirectionalList = new Task1.UnidirectionalList<int>();
            Random random = new Random();
            unidirectionalList.Add(1);
            unidirectionalList.Remove(0);
            unidirectionalList.Add(1);
            unidirectionalList.Add(1);
            unidirectionalList.Remove(1);
            unidirectionalList.Remove(0);
            for (int index = 0; index < 1000; index++)
                unidirectionalList.Add(random.Next(10000000));
            unidirectionalList.Remove(0);
            unidirectionalList.Remove(1);
            unidirectionalList.Remove(random.Next(998));
            unidirectionalList.Remove(996);
            if (unidirectionalList.Length != 996)
                throw new Exception("Length");
            Debug.Print(unidirectionalList.ToString());
        }

        [TestMethod]
        public unsafe void TestFind()
        {
            static int func(int i)
            {
                return i;
            }
            Task1.UnidirectionalList<int> unidirectionalList = new Task1.UnidirectionalList<int>();
            Random random = new Random();
            for (int index = 0; index < 1000; index++)
                unidirectionalList.Add(index);
            if (unidirectionalList.Find<int>(0, &func) != 0)
                throw new Exception("0 " + unidirectionalList.Find<int>(0, &func));
            if (unidirectionalList.Find<int>(1, &func) != 1)
                throw new Exception("1 " + unidirectionalList.Find<int>(1, &func));
            if (unidirectionalList.Find<int>(999, &func) != 999)
                throw new Exception("999 " + unidirectionalList.Find<int>(999, &func).ToString());
            if (unidirectionalList.Find<int>(9999, &func) != -1)
                throw new Exception("-1 " + unidirectionalList.Find<int>(9999, &func).ToString());
            int x = random.Next(2, 999);
            if (unidirectionalList.Find<int>(x, &func) != x)
                throw new Exception("random " + unidirectionalList.Find<int>(x, &func));
            Debug.Print(unidirectionalList.ToString());
        }
    }

    [TestClass]
    public unsafe class Tree
    {
        private static int func(int i)
        {
            return i;
        }

        [TestMethod]
        public void TestToString()
        {
            Task1.Tree<int> tree = new Task1.Tree<int>(&func);
            Debug.Print(tree.ToString());
            tree.Add(1);
            Debug.Print(tree.ToString());
            for (int index = 0; index < 1000; index++)
                tree.Add(index);
            Debug.Print(tree.ToString());
        }

        [TestMethod]
        public void TestAdd()
        {
            Task1.Tree<int> tree = new Task1.Tree<int>(&func);
            Random random = new Random();
            for (int index = 0; index < 1000; index++)
                tree.Add(random.Next(10000000));
            if (tree.Length != 1000)
                throw new Exception("Length");
            Debug.Print(tree.ToString());
        }

        [TestMethod]
        public void TestRemove()
        {
            Task1.Tree<int> tree = new Task1.Tree<int>(&func);
            Random random = new Random();
            tree.Add(1);
            tree.Remove(1);
            tree.Add(1);
            tree.Add(1);
            tree.Remove(1);
            tree.Remove(1);
            if (tree.Length != 0)
                throw new Exception("Length 1");
            for (int index = 0; index < 1000; index++)
                tree.Add(index);
            tree.Remove(0);
            tree.Remove(1);
            tree.Remove(999);
            tree.Remove(random.Next(2, 998));
            if (tree.Length != 996)
                throw new Exception("Length 2");
            Debug.Print(tree.ToString());
        }
    }
}