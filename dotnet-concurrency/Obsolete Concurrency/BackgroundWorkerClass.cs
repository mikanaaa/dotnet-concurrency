using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Obsolete_Concurrency
{
    class BackgroundWorkerClass
    {
        public BackgroundWorker bw { get; set; }

        public BackgroundWorkerClass()
        {
            this.bw = new BackgroundWorker();
            //Asign delegates to event to run
            bw.DoWork += Bw_DoWork;
            //Run when completed
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.ProgressChanged += ProgressReport;
            //Set to true or it will throw an exception on progress report
            bw.WorkerReportsProgress = true;
            //Invoke event that runs DoWork delegates
            bw.RunWorkerAsync();
            Console.ReadLine();
        }

        private void ProgressReport(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage + " %");
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Work completedm canceled or raised exception.");
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(20);
                //Sender is background worker
                (sender as BackgroundWorker).ReportProgress(i + 1);
                Console.WriteLine("This is work done by background worker ...");
            }
        }
    }
}
