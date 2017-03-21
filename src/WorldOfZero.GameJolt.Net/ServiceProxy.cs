using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfZero.GameJolt.Net
{
    public class ServiceProxy
    {
        public async Task<string> Get(string host)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(host);
            var response = await request.GetResponseAsync();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var responseString = await stream.ReadToEndAsync();
                return responseString;
            }
        }
    }
}
