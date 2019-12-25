using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_concurrency.Obsolete_Concurrency
{
    // Commonly used in WebClient type
    // It is pattern, no new types are introduced

    class EventAsynchronousPattern
    {
        public EventAsynchronousPattern()
        {
            WebClient wc = new WebClient();
            wc.DownloadFileAsync(new Uri("http://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_001.JPG"),"downloaded_image.jpg");
            wc.DownloadFileCompleted += DownloadCompleted;
            wc.DownloadProgressChanged += DownloadProgress;
            Console.ReadLine();
        }
        // Callback when operation is completed
        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Completed.");
        }
        // Percent of file download completed
        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage);
        }
    }
}