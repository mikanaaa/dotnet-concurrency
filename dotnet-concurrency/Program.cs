using dotnet_concurrency.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            // 4. Threads > The Thread Pool
            //TheThreadPool ttp = new TheThreadPool();
            //Console.ReadLine();
            // 5. Threads > Cancel Thread
            //CancellationTokenSource cts = new CancellationTokenSource();
            //CancelThread ct = new CancelThread();
            //ct.InvokeThreadMethod(cts);
            //Console.WriteLine("Press enter before 10/10 to quit operation");
            //Console.ReadLine();
            //cts.Cancel();
            // 6. Threads > Thread Progress Report
            EventHandler progressReporter = new EventHandler((object o, EventArgs arg) => { Console.WriteLine($"{(int)o}%"); });
            ThreadProgressReport tpr = new ThreadProgressReport(progressReporter);
        }
    }
}
