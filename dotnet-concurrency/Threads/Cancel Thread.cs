using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Threads
{
    class CancelThread
    {
        public void InvokeThreadMethod(CancellationTokenSource cts)
        {
            cts.Token.Register(new Action(() => { Console.WriteLine("Request to cancel is put."); }));
            new Thread(() => DoStuff(cts.Token)).Start();
        }
        private void  DoStuff(CancellationToken token)
        {
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(2500);
                    Console.WriteLine($"{i}/10");
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
