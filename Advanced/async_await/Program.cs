using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace async_await
{
    class Program
    {
        static void DoSomeThing(int seconds, string mgs, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} ... Start");
                Console.ResetColor();
            }
            string a = "abc";
            //...
            lock (a)
            {
                //...
            }

            for (int i = 1; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs,10} {i,2}");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                }
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} ... End");
                Console.ResetColor();
            }
        }

        // asynchronous (Đa luồng: Multi thread) -> Bất đồng bộ
        static async Task Task2()
        {
            Task t2 = new Task(() =>
                       {
                           DoSomeThing(10, "T2", ConsoleColor.Green);
                       }); // () => {}
            t2.Start();
            await t2; // Trả về task luôn -> Không cần return
            Console.WriteLine("T2 da hoan thanh");
        }
        static async Task Task3()
        {
            Task t3 = new Task((object obj) =>
                 {
                     string tentacvu = (string)obj;
                     DoSomeThing(10, tentacvu, ConsoleColor.Yellow);
                 }, "T3"); // (Object ob) => {}
            t3.Start();
            await t3; // Trả về task luôn -> Không cần return
            Console.WriteLine("T3 da hoan thanh");
        }

        // async/await
        static async Task Abc()
        {
            // Task task = new Task(() =>
            // {
            //     // ... Các chỉ thị
            // });
            // task.Start();
            // await task;
            // ...
            await File.WriteAllTextAsync("1.txt", "Nội dung");
            // ...
        }
        static async Task<string> Task4()
        {
            Task<string> t4 = new Task<string>(
                      () =>
                      {
                          DoSomeThing(10, "T4", ConsoleColor.Green);
                          return "Return from T4";
                      }
                  ); // () => {return string;} 
            t4.Start();
            var kq = await t4;
            Console.WriteLine("T4 hoan thanh");
            return kq;
        }
        static async Task<string> Task5()
        {
            Task<string> t5 = new Task<string>(
               (object obj) =>
               {
                   string t = (string)obj;
                   DoSomeThing(4, t, ConsoleColor.Yellow);
                   return $"Return from {t}";
               }, "T5"); // (object obj) => {return string;} 

            t5.Start();
            string kq = await t5;
            Console.WriteLine("T5 hoan thanh");
            return kq;
        }
        static async Task<string> GetWeb(string url)
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("Bat dau tai");
            HttpResponseMessage kq = await httpClient.GetAsync(url);
            Console.WriteLine("Bat dau doc noi dung");
            string content = await kq.Content.ReadAsStringAsync();
            Console.WriteLine("Hoan thanh");
            return content;
        }
        static async Task Main(string[] args)
        {
            // synchronous (Đơn luồng) -> Đồng bộ

            // DoSomeThing(10, "T2", ConsoleColor.Green);
            // DoSomeThing(4, "T3", ConsoleColor.Yellow);

            // asynchronous (Đa luồng): Chạy song song với nhau -> Không đồng bộ
            // Task
            // Task t2 = new Task(Action);// () => {}
            // Task t3 = new Task(Action<Object>, Object);// (Object obj) => {}

            // Task t2 = Task2(); // Thread
            // Task t3 = Task3(); // Thread
            // DoSomeThing(6, "T1", ConsoleColor.Magenta); // Thread

            // // Wait() -> Phải đợi task kết thúc mới chạy tiếp code
            // // t2.Wait();
            // // t3.Wait();
            // // Task.WaitAll(t2, t3);
            // await t2;
            // await t3;

            // Task<T> -> Khi tak chạy xong -> Có giá trị trả về
            // Task<string> t4 = new Task<string>(Func<string>); // () => {return string;} 
            // Task<string> t4 = new Task<string>(Func<object, string>, object); // (object obj) => {return string;} 
            Task<string> t4 = Task4();
            Task<string> t5 = Task5();

            DoSomeThing(6, "T1", ConsoleColor.Magenta);

            var kq4 = await t4;
            var kq5 = await t5;

            Console.WriteLine(kq4);
            Console.WriteLine(kq5);

            //
            var task = GetWeb("https://xuanthulab.net");
            DoSomeThing(6, "T1", ConsoleColor.Magenta);

            var content = await task;
            Console.WriteLine(content);
            Console.WriteLine("Press any key");
            Console.ReadKey();

        }
    }
}
