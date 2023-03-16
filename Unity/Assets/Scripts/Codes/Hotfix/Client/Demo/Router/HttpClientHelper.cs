using System;
using System.IO;
using System.Net;
using System.Text;

namespace ET.Client
{
    public static class HttpClientHelper
    {
        public static async ETTask<string> Get(string link)
        {
            try
            {
                var request = WebRequest.Create(link) as HttpWebRequest;
                request.Method = "GET";
                request.Timeout = 5000;

                using var response = await request.GetResponseAsync() as HttpWebResponse;
                using var responseStream = response.GetResponseStream();
                using var streamReader = new StreamReader(responseStream, Encoding.UTF8);
                var result = await streamReader.ReadToEndAsync();

                //using HttpClient httpClient = new();
                //HttpResponseMessage response = await httpClient.GetAsync(link);
                //string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"http request fail: {link[..link.IndexOf('?')]}\n{e}");
            }
        }
    }
}