using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_concurrency.Tasks
{
    class TaskReturnValues
    {
        public TaskReturnValues()
        {
            // Action method returns void, running task return non generic task
            Task t1 = Task.Run(VoidHi);
            t1.Wait();
            // Func delegate returns 
            Task<int> t2 = Task.Run(GetInt);
            t2.Wait();
            Console.WriteLine(t2.Result);
            Task<int> t3 = Task.Run<int>(ReturnsTask2);
            t3.Wait();
            Console.WriteLine(t3.Result);
        }
        public void VoidHi() => Console.WriteLine("Void Hi.");
        public int GetInt() => 5;
        /// <summary>
        /// Async returns void, Task or Task<T>
        /// return is concrete value, and there needs to be some await
        /// </summary>
        /// <returns></returns>
        async public Task<int> ReturnsTask()
        {
            await Task.Delay(3000);
            return 15;
        }
        // Task.Run can have Func<Task<T> return type
        public Task<int> ReturnsTask2()
        {
            return Task<int>.Run(()=>20);
        }
    }
}
