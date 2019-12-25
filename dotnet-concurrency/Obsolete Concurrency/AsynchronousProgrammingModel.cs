using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;

namespace dotnet_concurrency.Obsolete_Concurrency
{
    class AsynchronousProgrammingModel
    {
        public AsynchronousProgrammingModel()
        {
            HttpWebRequest req = WebRequest.CreateHttp("https://jsonplaceholder.typicode.com/posts");
            // Returned result value not used
            var result = req.BeginGetResponse((IAsyncResult res) =>
            {
                // EndGetResponse inside Begin delgate parameter
                var wr = req.EndGetResponse(res);
                var stream = wr.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                Console.WriteLine(sr.ReadToEnd());
            }, null);

            Console.ReadLine();
        }
    }
}
