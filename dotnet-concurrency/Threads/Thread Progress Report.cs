using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Threads
{
    // Alternative to EventHandler is IProgress Progress class & it's method OnProgress & ProgressChanged event
    class ThreadProgressReport
    {
        EventHandler progressReporter;
        public ThreadProgressReport(EventHandler progressHandler)
        {
            this.progressReporter = progressHandler;
            new Thread(DoStuff).Start();
        }
        private void DoStuff()
        {
            
            for (int i = 0; i < 100; i++)
            {
                // This eventhandler is created, and handled in main thread
                // This eventhandler is invoked in this thread
                progressReporter.Invoke(i + 1, null);
                Thread.Sleep(100);
            }
        }
    }
}
