using dotnet_concurrency.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_concurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Threads > Common Threading
            //CommonThreading ct = new CommonThreading();
            //Console.WriteLine("Hello from main thread.");
            // 2. Threads > Passing Parameters
            //PassingParameters pp = new PassingParameters();
            // 3. Threads > Divide And Conquer
            //DivideAndConquer dac = new DivideAndConquer();
            // 3. Threads > The Thread Pool
            TheThreadPool ttp = new TheThreadPool();
            Console.ReadLine();
        }
    }
}
