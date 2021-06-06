using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Laba_12;

namespace UnitTestsLaba13
{
    [TestClass]
    public class TestTree
    {
        private static int func(int i)
        {
            return i;
        }

        [TestMethod]
        public void IndexSetTest()
        {
            Task.Tree<int> tree = new Task.Tree<int>(func);
            Random random = new Random();
            for (int index = 0; index < 1000; index++)
                tree.Add(random.Next(10000000));
            for (int index = 0; index < 1000; index++)
            {
                tree[index] = 0;
            }
        }
    }

    [TestClass]
    public class TestJournal
    {
        [TestMethod]
        public void Journal()
        {
            Task.Tree<int> tree1 = new Task.Tree<int>((int x) => x);
            tree1.Name = "Tree 1";
            Task.Tree<int> tree2 = new Task.Tree<int>((int x) => x);
            tree2.Name = "Tree 2";

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            tree1.CollectionCountChanged += journal1.AddInList;
            tree1.CollectionReferenceChanged += journal1.AddInList;

            tree2.CollectionReferenceChanged += journal2.AddInList;
            tree1.CollectionReferenceChanged += journal2.AddInList;
            Random random = new Random();
            for (int index = 0; index < 10; index++)
                tree1.Add(random.Next(10000000));
            for (int index = 0; index < 10; index++)
                tree2.Add(random.Next(10000000));
            Debug.Print(journal1.ToString());
            Debug.Print(journal2.ToString());
            foreach (Journal.JournalEntry journalEntry in journal1.List)
            {
                Debug.Print(journalEntry.CollectionState);
                Debug.Print(journalEntry.NameCollection);
                Debug.Print(journalEntry.TypeOfChange);
            }
        }
    }
}