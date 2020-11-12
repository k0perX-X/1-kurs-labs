using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Лаба_4;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSort()
        {
            for (int kolvo = 0; kolvo < 10000; kolvo++)
            {
                int[] mas = Laba4.DoMAS(Laba4.rand.Next(1000));
                int[] masorigin = new int[mas.Length];
                mas.CopyTo(masorigin.AsMemory());
                Laba4.Sort(ref mas);
                for (int i = 0; i < mas.Length - 1; i++)
                    if (mas[i] > mas[i + 1])
                    {
                        Debug.Print(MassToString(masorigin) + "\n\n" + MassToString(mas));
                        throw new ArgumentOutOfRangeException(MassToString(masorigin) + "\n\n" + MassToString(mas));
                    }
            }
        }

        //[TestMethod]
        //public void TestSwapMass()
        //{
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        int[] mas = Laba4.DoMAS(Laba4.rand.Next(2, 1000));
        //        int[] masorigin = new int[mas.Length];
        //        mas.CopyTo(masorigin.AsMemory());
        //        int ind1 = Laba4.rand.Next(mas.Length);
        //        int ind2 = Laba4.rand.Next(mas.Length);
        //        int a = mas[ind1];
        //        int b = mas[ind2];
        //        //Debug.Print(mas.AsMemory().ToString());
        //        //Debug.Print(MassToString(mas));
        //        mas[ind1] ^= mas[ind2];
        //        Debug.Print($"1 {mas[ind1]} 2 {mas[ind2]} \n");
        //        mas[ind2] ^= mas[ind1];
        //        Debug.Print($"1 {mas[ind1]} 2 {mas[ind2]} \n");
        //        mas[ind1] ^= mas[ind2];
        //        Debug.Print($"1 {mas[ind1]} 2 {mas[ind2]} \n\n");
        //        //mas[ind1] = (int)mas[ind1] ^ (int)mas[ind2];
        //        //mas[ind2] = (int)mas[ind2] ^ (int)mas[ind1];
        //        //mas[ind1] = (int)mas[ind1] ^ (int)mas[ind2];
        //        if ((a != mas[ind2]) || (b != mas[ind1]))
        //            throw new ArgumentOutOfRangeException($"итерация {i+1} a {a}, b {b}, ind1 {mas[ind1]}, ind2 {mas[ind2]}");
        //    }
        //}

        //[TestMethod]
        //public void TestSwap()
        //{
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        int a = Laba4.rand.Next(int.MinValue, int.MaxValue);
        //        int b = Laba4.rand.Next(int.MinValue, int.MaxValue);
        //        int a1 = a;
        //        int b1 = b;
        //        //a ^= b;
        //        //b ^= a;
        //        //a ^= b;
        //        a = a ^ b;
        //        b = b ^ a;
        //        a = a ^ b;
        //        if ((a != b1) || (b != a1))
        //            throw new ArgumentOutOfRangeException($"a {a}, b{b}, a1{a1}, b1{b1}");
        //    }
        //}

        public static string MassToString(int[] mas)
        {
            string s = "";
            for (int i = 0; i < mas.Length; i++)
                s += mas[i].ToString() + ", ";
            return s;
        }
    }
}