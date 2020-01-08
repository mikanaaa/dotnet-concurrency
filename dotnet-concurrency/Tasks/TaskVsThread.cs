using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Tasks
{
    class TaskVsThread
    {
        // Task is background thread from thread pool, thread is foreground thread
        // Thread doesn't return value, and no continuation
        // Task can catch AggregateException in calling method, Thread cannot
    }
}
