using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace net1
{
    class Program
    {
        static void ShowHeaders(HttpResponseHeaders headers)
        {
            Console.WriteLine("CAC HEADER");
            foreach (var header in headers)
            {
                Console.WriteLine($"{header.Key} : {header.Value}");
            }
        }
        public static async Task<string> GetWebContent(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                // Thiết lập header
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                ShowHeaders(httpResponseMessage.Headers);
                string html = await httpResponseMessage.Content.ReadAsStringAsync();
                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Loi";
            }
        }
        public static async Task<byte[]> DownloadDataBytes(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                // Thêm header
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                ShowHeaders(httpResponseMessage.Headers);
                var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                return bytes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static async Task DownloadStream(string url, string filename)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();

                using var streamWrite = File.OpenWrite(filename);

                int SIZE_BUFFER = 500;
                var buffer = new byte[SIZE_BUFFER];
                bool endRead = false;
                do
                {
                    int numBytes = await stream.ReadAsync(buffer, 0, SIZE_BUFFER);
                    if (numBytes == 0)
                    {
                        endRead = true;
                    }
                    else
                    {
                        await streamWrite.WriteAsync(buffer, 0, numBytes);
                    }
                } while (!endRead);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
        static async Task Main(string[] args)
        {
            // Uri, Dns, Ping
            // string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
            // var uri = new Uri(url);
            // var uritype = typeof(Uri);
            // uritype.GetProperties().ToList().ForEach(property =>
            // {
            //     Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            // });
            // Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");

            // var hostname = Dns.GetHostName();
            // Console.WriteLine(hostname);

            // var url = "https://xuanthulab.net";
            // var uri = new Uri(url);
            // Console.WriteLine(uri.Host);
            // var ipHostEntry = Dns.GetHostEntry(uri.Host);
            // Console.WriteLine(ipHostEntry.HostName);
            // ipHostEntry.AddressList.ToList().ForEach(ip => Console.WriteLine(ip));

            /* Lớp Ping(System.Net.NetworkInformation.Ping), 
            lớp này cho phép ứng dụng xác định một máy từ xa(như server, máy trong mạng...) có phản hồi không.
            */
            // var ping = new Ping();
            // var pingReply = ping.Send("google.com.vn");
            // Console.WriteLine(pingReply.Status);
            // if (pingReply.Status == IPStatus.Success)
            // {
            //     Console.WriteLine(pingReply.RoundtripTime);
            //     Console.WriteLine(pingReply.Address);
            // }

            // Http Request - HttpClient (GET, POST, PUT)
            // var url = "https://www.google.com/search?q=xuanthulab";
            var url = "https://dulichhoangnguyen.com/upload/images/dai%20dien%201(1).jpg";
            // var html = await GetWebContent(url);
            // var bytes = await DownloadDataBytes(url);
            // // Console.WriteLine(html);
            // string filename = "1.png";
            // using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            // stream.Write(bytes, 0, bytes.Length);

            // await DownloadStream(url, "2.png");
            using var httpClient = new HttpClient();
            var httpMessageRequest = new HttpRequestMessage();
            httpMessageRequest.Method = HttpMethod.Post;
            // httpMessageRequest.RequestUri = new Uri("https://www.google.com.vn");
            httpMessageRequest.RequestUri = new Uri("https://postman-echo.com/post");
            httpMessageRequest.Headers.Add("User-Agent", "Mozilla/5.0");
            //
            string data = @"{
                ""key1"": ""giatri1"",
                ""key2"": ""giatri2""
            }";
            //

            // httpMessageRequest.Content => FormatException HTML, File, ...
            // POST => FORM HTML
            /*
                key1 => value1                  [Input]
                key2 => [value2-1, value2-2]    [Multi Select]
            */
            // var parameters = new List<KeyValuePair<string, string>>();
            // parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
            // parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
            // parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));
            // var content = new FormUrlEncodedContent(parameters);
            // Console.WriteLine(data);
            // var content = new StringContent(data, Encoding.UTF8, "application/json");
            var content = new MultipartFormDataContent();
            // Upload file 1.txt
            Stream fileStream = File.OpenRead("1.txt");
            var fileUpload = new StreamContent(fileStream); // part
            content.Add(fileUpload, "fileUpload", "abc.xyz");
            //
            content.Add(new StringContent("value1"), "key1");

            httpMessageRequest.Content = content;
            //
            var httpResponseMessage = await httpClient.SendAsync(httpMessageRequest);

            ShowHeaders(httpResponseMessage.Headers);

            var html = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(html);


        }
    }
}
//27'19