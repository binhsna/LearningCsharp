using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Example
{
    class Program
    {
        //In thông tin, Task ID và thread ID đang chạy
        public static void PintInfo(string info) =>
                Console.WriteLine($"{info,10}    task:{Task.CurrentId,3}    " +
                                  $"thread: {Thread.CurrentThread.ManagedThreadId}");

        // Phương thức phù hợp với Action<int>, được làm tham số action của Parallel.For
        public static async void RunTask(/*int*/ string i)
        {
            PintInfo($"Start {i,10}");
            // Task.Delay(1000).Wait();          // Task dừng 1s - rồi mới chạy tiếp
            await Task.Delay(1);         // Task.Delay là một async nên có thể await, RunTask chuyển điểm gọi nó tại đây
            PintInfo($"Finish {i,10}");
        }
        // Thi hành song song tác vụ với Parallel.For  
        // Parallel.ForEach chạy song song tác vụ
        public static void ParallelFor()
        {
            // ParallelLoopResult result = Parallel.For(1, 20, RunTask);   // Vòng lặp tạo ra 20 lần chạy RunTask
            // Console.WriteLine($"All task start and finish: {result.IsCompleted}");
            string[] source = new string[] {"xuanthulab1","xuanthulab2","xuanthulab3",
                                    "xuanthulab4","xuanthulab5","xuanthulab6",
                                    "xuanthulab7","xuanthulab8","xuanthulab9"};
            // Dùng List thì khởi tạo
            // List<string> source = new List<string>();
            // source.Add("xuanthulab1");

            ParallelLoopResult result = Parallel.ForEach(source, RunTask);

            Console.WriteLine($"All task started: {result.IsCompleted}");
        }
        // Parallel.Invoke chạy song song nhiều loại tác vụ (phương thức)
        public static void actionA()
        {
            PintInfo($"Finish {"ActionA",10}");
        }

        public static void actionB()
        {
            PintInfo($"Finish {"ActionB",10}");
        }


        public static void ParallelInvoke()
        {
            Action action1 = () =>
            {
                RunTask("Action1");
            };

            Parallel.Invoke(action1, actionA, actionB);
        }
        static void Main(string[] args)
        {
            // ParallelFor();
            ParallelInvoke();
            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
    }
}
