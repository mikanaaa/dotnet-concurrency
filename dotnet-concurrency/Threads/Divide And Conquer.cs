using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Threads
{
    class DivideAndConquer
    {
        int fullSum = 0;
        object locker = new object();
        public DivideAndConquer()
        {
            //Number of hardware threads
            int cpus = Environment.ProcessorCount;
            int from = 1;
            int to = 10;
            int portion = to / cpus;
            Thread[] threads = new Thread[cpus];
            //Splitting work among threads
            for (int i = 0; i < cpus; i++)
            {
                int portionFrom = from + i * portion;
                int portionTo = from + i * portion + portion - 1;
                threads[i] = new Thread(() => SumNumbers(portionFrom, portionTo));
                threads[i].Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine($"Summed value is: {fullSum}.");
        }
        void SumNumbers(int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                sum += i;
            }
            // Prevents multiple simulteneous writes
            lock (locker)
            {
                fullSum += sum;
            }
        }
    }
}
