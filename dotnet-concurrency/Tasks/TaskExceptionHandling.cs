using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_concurrency.Tasks
{
    class TaskExceptionHandling
    {
        public TaskExceptionHandling()
        {
            Console.WriteLine("Enter integer:");
            // Enter 0 to cause divide by 0 exception
            int input = Int32.Parse(Console.ReadLine());
            try
            {
                // Try block can contain async "task" and it will catch exception
                var t = DivideAsync(input);
                t.Wait();
                // Result causes exception
                Console.WriteLine(t.Result);
            }
            // Catches all exceptions in task
            catch (AggregateException ae)
            {
                foreach (var error in ae.Flatten().InnerExceptions)
                {
                    Console.WriteLine(error);
                }
            }
        }
        async private Task<int> DivideAsync(int input)
        {
            Console.WriteLine("Waiting 3 seconds...");
            await Task.Delay(3000);
            return 1000 / input;
        }
    }
}
