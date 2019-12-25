using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Obsolete_Concurrency
{
    class AsynchronousDelegates
    {
        Func<string> getString = () => { Thread.Sleep(1000); return "Howdy from asynchronous delegate!"; };
        public AsynchronousDelegates()
        {
            getString.BeginInvoke((result) => { Console.WriteLine(getString.EndInvoke(result)); }, null);
        }
    }
}
