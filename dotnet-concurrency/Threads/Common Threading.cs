using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace dotnet_concurrency.Threads
{
    class CommonThreading
    {
        Thread thread1 = new Thread(SayHello);
        // Important properties:
        // thread1.IsAlive
        // thread1.IsBackground -- it is foreground by default
        // thread1.IsThreadPoolThread
        // thread1.Join() -- blocks calling thread until thread1 is completed
        // thread1.Name, Priority, ThreadState
        // thread1.Start() -- calls thread, with parameter if delegate is ParameterizedThreadStart
        // ThreadStart & ParameterizedThreadStart types of delegates of Thread constructor
        //--------------------------------------    
        //Common types used in threading:
        //LazyInitializer -- instance created when needed
        //AutoResetEvent -- signal for synchronization
        //CancellationToken -- notify cancel request
        //CancellationTokenRegistration
        //CancellationTokenSource
        //CountdownEvent -- signal for synchronization
        //Interlocked -- perform thread safe calculations on properties
        //ManualResetEvent -- signal for synchronization
        //Monitor -- manual locking
        //Mutex -- mutually exclusive
        //Semaphore -- allow specific number of thread in piece of code 
        //ThreadPool -- object pool design pattern for threads
        //--------------------------------------    
        //Static properties & methods:
        //Thread.CurrentThread -- executing thread
        //Thread.Sleep() -- executing thread wait's
        //Thread.Yield() -- executing thread passes processor time to another thread

        public CommonThreading()
        {
            thread1.Start();
        }
        public static void SayHello()
        {
            Thread.Sleep(500);
            Console.WriteLine("Hello from simple thread after 500 milliseconds.");
        }
    }
}
