using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Threads
{
    //Starting thread is time consuming , because it creates local variable stack
    //Good for parallel programming
    //Always background
    //Thread.CurrentThread.IsThreadPoolThread
    class TheThreadPool
    {
        public TheThreadPool()
        {
            // Easiest way to run on pooled thread
            Task.Run(() => { Console.WriteLine("Hello world from pooled thread!"); });
            // ThreadPool is static class.
            // Prevents oversubcription, more active threads than CPU cores
            // Queues tasks
        }
    }
}
