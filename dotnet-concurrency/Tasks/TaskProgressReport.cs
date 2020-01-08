using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Tasks
{
    class TaskProgressReport
    {
        // IProgress has Report method, Progress class does not
        // Progress<T> has protected virtual OnReport(T value) & ProgressChanged EventHandler
        // Report uses SynchronizationContext.Current, so that it's done on UI thread, that's why it can be out of order, it's async
        IProgress<int> progress = new Progress<int>((i) => Console.WriteLine(i));

        public TaskProgressReport()
        {
            for (int i = 1; i <= 100; i++)
            {
                progress.Report(i);
                Thread.Sleep(10);
            }
        }
    }
}
