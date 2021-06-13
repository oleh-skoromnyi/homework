using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsTask
{
    class Program
    {
        static object syncObject = new object();
        static void Main(string[] args)
        {
            //Task1
            var threadList = new List<Thread>();
            var processorCount = Environment.ProcessorCount;
            var arrayLength = 100000;
            var randomNumbers = new List<int>();
            for (int i = 0; i < processorCount; i++)
            {
                threadList.Add(new Thread(() => FillArray(arrayLength / processorCount,randomNumbers)));
            }

            StartThreadsAndWaitResult(threadList);
            Console.WriteLine(randomNumbers.Count);
            //Task2
            threadList.Clear();
            var sublist = new List<int>();
            var start = 20000;
            var end = 40000;
            for (int i = 0; i < processorCount; i++)
            {
                var from = start + (i * (end - start)) / processorCount;
                var to = start + ((i + 1) * (end - start)) / processorCount;

                if (i != processorCount - 1)
                { 
                    threadList.Add(new Thread(() => GetSublist( from, to, randomNumbers, sublist))); 
                }
                else
                {
                    threadList.Add(new Thread(() => GetSublist(from, end, randomNumbers, sublist)));
                }
            }
            StartThreadsAndWaitResult(threadList);
            Console.WriteLine(sublist.Count);
            //Task3
            threadList.Clear();
            var minValue = int.MaxValue;
            for (int i = 0; i < processorCount; i++)
            {
                var from = (i * arrayLength) / processorCount;
                var to = ((i + 1) * arrayLength) / processorCount;

                if (i != processorCount - 1)
                {
                    threadList.Add(new Thread(() => FindMin(from, to, randomNumbers, ref minValue)));
                }
                else
                {
                    threadList.Add(new Thread(() => FindMin(from, arrayLength, randomNumbers, ref minValue)));
                }
            }
            StartThreadsAndWaitResult(threadList);
            Console.WriteLine(minValue);
            //Task4
            threadList.Clear();
            decimal average = 0;
            for (int i = 0; i < processorCount; i++)
            {
                var from = (i * arrayLength) / processorCount;
                var to = ((i + 1) * arrayLength) / processorCount;

                if (i != processorCount - 1)
                {
                    threadList.Add(new Thread(() => FindAverage(from, to, randomNumbers, ref average)));
                }
                else
                {
                    threadList.Add(new Thread(() => FindAverage(from, arrayLength, randomNumbers, ref average)));
                }
            }
            StartThreadsAndWaitResult(threadList);
            Console.WriteLine(average);
        }

        private static void StartThreadsAndWaitResult(List<Thread> threadList)
        {
            foreach (var thread in threadList)
            {
                thread.Start();
            }

            foreach (var thread in threadList)
            {
                thread.Join();
            }
        }

        static void FillArray(int count, List<int> result)
        {
            var tempList = new List<int>();
            Random random = new Random();
            for (int i = 0; i < count; ++i)
            {
                tempList.Add(random.Next());
            }

            lock (syncObject)
            {
                result.AddRange(tempList);
            }
        }

        static void GetSublist(int start,int end,List<int>source,List<int>result)
        {
            var tempList = new List<int>();
            for (int i = start; i < end; ++i)
            {
                tempList.Add(source[i]);
            }

            lock (syncObject)
            {
                result.AddRange(tempList);
            }
        }
        static void FindMin(int start, int end, List<int> source, ref int result)
        {
            var tempResult = int.MaxValue;
            for (int i = start; i < end; ++i)
            {
                if (tempResult > source[i])
                {
                    tempResult = source[i];
                }
            }

            lock (syncObject)
            {
                if (result > tempResult)
                {
                    result = tempResult;
                }
            }
        }
        static void FindAverage(int start, int end, List<int> source, ref decimal result)
        {
            decimal tempResult = 0;
            for (int i = start; i < end; ++i)
            {
                tempResult += source[i];
            }

            lock (syncObject)
            {
                result += tempResult/((end-start)*Environment.ProcessorCount);
            }
        }
    }
}
