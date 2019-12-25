using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Threads
{
    // Method is thread safe if:
    // Only access local variables it's safe by default
    // Access of object or class properties makes it unsafe, lock, mutex, manualresetevent for safety
    // Synchronization makes it safe
    // Race Condition - two threads access variable at same time
    // Deadlock: mutual exclusion, hold and wait, no preemption, circular wait
    //

    class ThreadSafe
    {
        public ThreadSafe()
        {
            Console.WriteLine("Deadlock sample:");
            object obj1 = new object();
            object obj2 = new object();
            new Thread(() =>
            {
                lock (obj1)
                {
                    Console.WriteLine("Thread 1 entered obj1 lock");
                    Thread.Sleep(2000);
                    Console.WriteLine("Thread 1 waiting obj2 lock");
                    lock (obj2)
                    {
                        Console.WriteLine("Thread 1 entered obj2 lock");
                    }
                }
            }).Start();
            new Thread(() =>
            {
                lock (obj2)
                {
                    Console.WriteLine("Thread 2 entered obj2 lock");
                    Thread.Sleep(2000);
                    Console.WriteLine("Thread 2 waiting obj1 lock");
                    lock (obj1)
                    {
                        Console.WriteLine("Thread 2 entered obj1 lock");
                    }
                }
            }).Start();
        }
    }
}
