using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_concurrency.Tasks
{
    class TasksBasics
    {
        public TasksBasics()
        {
            //Static properties and methods
            //await Task.Delay(1000) -- Task that delays method for 1 second
            //Task.Factory -- Creating and configuring Tasks
            //Task.Run(Action) -- Creates and runs Action delegate in task
            //Task<int>.Run(Func<int>) -- Task that runs Func and returns value
            //Task.WaitAll/Any(Task[] tasks) -- Waits for execution of all/any tasks in array
            //Task.WhenAll/Any(Task[] tasks) -- Returns task with results, that task is completed when parameteres are completed
            // Contains Parallel Class
            Task t = Task.Run(() => Console.WriteLine("Hello again!"));
            // Task is created from ThreadPool, it is background thread
            t.GetAwaiter().OnCompleted(() => Console.WriteLine("Hi again!"));
            // TaskAwaiter calls callback, when task is completed
            // IsCompleted & GetResult() additional property and method
            t.Wait(); // Waits for task to complete before continuing execution
            // t.ContinueWith((t2) => Console.WriteLine(t2.Exception)); // Continues task when it completed
            // t.Exception -- AggregateException that stopped task
            // AggregateException -- Flatten() & InnerExceptions, collection of exceptions that happened
            // t.IsCanceled t.IsCompleted t.IsFaulted -- common Task object props
        }
    }
}
