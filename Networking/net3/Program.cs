using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
// dotnet add package Newtonsoft.Json

namespace net3
{
    class Program
    {
        class MyHttpServer
        {
            private HttpListener listener;
            public MyHttpServer(string[] prefixes)
            {
                if (!HttpListener.IsSupported)
                {
                    throw new Exception("HttpListener is not supported");
                }
                listener = new HttpListener();
                foreach (string prefix in prefixes)
                {
                    listener.Prefixes.Add(prefix);
                }
            }
            public async Task Start()
            {
                listener.Start();
                Console.WriteLine("Http Server Started");
                do
                {
                    Console.WriteLine(DateTime.Now.ToLongTimeString() + " waiting a client connect");
                    var context = await listener.GetContextAsync();
                    await ProcessRequest(context);

                    Console.WriteLine(DateTime.Now.ToLongTimeString() + " client connected");
                } while (listener.IsListening);
            }

            public async Task ProcessRequest(HttpListenerContext context)
            {
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                Console.WriteLine($"{request.HttpMethod} {request.RawUrl} {request.Url.AbsolutePath}");
                var outputStream = response.OutputStream;

                switch (request.Url.AbsolutePath)
                {
                    case "/":
                        {
                            var buffer = Encoding.UTF8.GetBytes("Xin chao cac ban");
                            response.ContentLength64 = buffer.Length;
                            await outputStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                        break;
                    case "/json":
                        {
                            response.Headers.Add("content-type", "application/json");
                            var product = new
                            {
                                Name = "Macbook Pro",
                                Predicate = 2000
                            };
                            var json = JsonConvert.SerializeObject(product);
                            var buffer = Encoding.UTF8.GetBytes(json);
                            response.ContentLength64 = buffer.Length;
                            await outputStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                        break;
                    case "/anh2.png":
                        {
                            response.Headers.Add("content-type", "image/png");
                            var buffer = await File.ReadAllBytesAsync("2.png");
                            response.ContentLength64 = buffer.Length;
                            await outputStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                        break;
                    default:
                        {
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                            var buffer = Encoding.UTF8.GetBytes("NOT FOUND");
                            response.ContentLength64 = buffer.Length;
                            await outputStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                        break;
                }
                outputStream.Close();
            }
        }
        static async Task Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // // Kiểm tra hệ thống có hỗ trợ không
            // if (HttpListener.IsSupported)
            // {
            //     Console.WriteLine("Support HttpListener");
            // }
            // else
            // {
            //     Console.WriteLine("Not Support HttpListener");
            //     throw new Exception("Not Support HttpListener");
            // }
            // // 
            // var server = new HttpListener();
            // server.Prefixes.Add("http://*:8080/");
            // server.Start();
            // Console.WriteLine("Server HTTP Start");
            // do
            // {
            //     var context = await server.GetContextAsync();
            //     Console.WriteLine("Client connected");

            //     var response = context.Response;
            //     var outputStream = response.OutputStream;

            //     response.Headers.Add("content-type", "text/html");

            //     var html = "<h1>Hello World</h1>";
            //     var bytes = Encoding.UTF8.GetBytes(html);
            //     await outputStream.WriteAsync(bytes, 0, bytes.Length);
            //     outputStream.Close();
            // } while (server.IsListening);

            var server = new MyHttpServer(new string[] { "http://*:8080/" });
            await server.Start();
        }
    }
}
