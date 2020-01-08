using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Tasks
{
    class TaskCancellation
    {
        // Token makes cancellation request after 5 seconds
        CancellationTokenSource cts = new CancellationTokenSource(5000);
        public TaskCancellation()
        {
            Console.WriteLine("5 Second until cancelling token.");
            try
            {
                LongMethod(cts.Token).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e);
            }
        }
        private async Task LongMethod(CancellationToken token)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i*1000);
                await Task.Delay(1000);
                token.ThrowIfCancellationRequested();
            }
        }
    }
}
