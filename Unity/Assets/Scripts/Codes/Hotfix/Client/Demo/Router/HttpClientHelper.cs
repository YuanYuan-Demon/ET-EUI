using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ET.Client
{
    public static class HttpClientHelper
    {
        public static async ETTask<string> Get(string link)
        {
            try
            {
#if UNITY
                HttpWebRequest request = WebRequest.Create(link) as HttpWebRequest;
                request.Method = "GET";
                request.Timeout = 5000;

                using HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                using Stream responseStream = response.GetResponseStream();
                using StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string result = await streamReader.ReadToEndAsync();
#else
                using HttpClient httpClient = new();
                HttpResponseMessage response = await httpClient.GetAsync(link);
                string result = await response.Content.ReadAsStringAsync();
#endif
                return result;
            }
            catch (Exception e)
            {
                throw new($"http request fail: {link[..link.IndexOf('?')]}\n{e}");
            }
        }
    }
}