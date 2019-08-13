using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Performance
{
    class Person
    {
        public string name;
        public int age;
    }
    struct human
    {
        public string name;
        public int age;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var forcomp = BenchmarkRunner.Run<ForVsForEach>();
            Console.ReadKey();
        }
    }
     [MemoryDiagnoser]
    public class ForVsForEach
    {
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        List<int> list3 = new List<int>();
      public  ForVsForEach()
        {
            for (int i = 0; i < 1000; i++)
                list1.Add(i);
        }
        [Benchmark]
        public void For()
        {

            for (int i = 0; i < list1.Count; i++)
            {
                list2.Add(list1[i]);
            }
        }
        [Benchmark]
        public void ForEach()
        {
            foreach (int number in list1)
            {
                list3.Add(number);
            }
        }
    }

    public class stringvsbuilder
    {
        public stringvsbuilder()
        {

        }
        [Benchmark]
        public void stringg()
        {
            String s = "abhay";

            for (int i = 0; i < 100; i++)
            {
                s += "singh";
            }
        }
        [Benchmark]
        public void builder()
        {
            StringBuilder ss = new StringBuilder("abhay");

            for (int i = 0; i < 100; i++)
            {
                ss.Append("singh");
            }
        }
    }

    public class ArrayAndList
    {
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        int [] arr=new int[1000];
        public ArrayAndList()
        {
            for (int i = 0; i < 1000; i++)
                list1.Add(i);
        }
        [Benchmark]
        public void Array()
        {

            for (int i = 0; i < list1.Count; i++)
            {
                arr[i] = list1[i];
            }
        }

        [Benchmark]
        public void List()
        {

            for (int i = 0; i < list1.Count; i++)
            {
                list2.Add(list1[i]);
            }
        }
    }
}
