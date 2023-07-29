using System;
using System.Text;
// DI Container
// dotnet add package Microsoft.Extensions.DependencyInjection
using Microsoft.Extensions.DependencyInjection;
// Sử dụng Options khởi tạo dịch vụ trong DI
// dotnet add package Microsoft.Extensions.Options
using Microsoft.Extensions.Options;
// Sử dụng cấu hình từ File cho DI Container
// dotnet add package Microsoft.Extensions.Configuration
// dotnet add package Microsoft.Extensions.Options.ConfigurationExtensions
// Sau đó, muốn dùng định dạng nào thì thêm Package tương ứng, ví dụ dùng JSON:

// dotnet add package Microsoft.Extensions.Configuration.Json
// dotnet add package Microsoft.Extensions.Configuration.Ini
// dotnet add package Microsoft.Extensions.Configuration.Xml
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace dependency_injection
{
    // Inversion of Control (Dependency Inverse)
    // --- Dependency injection

    // 1) Dependency: Phụ thuộc
    // ClassC là Dependency của classB, ClassB là Dependency của classA

    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }

    class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC is created");
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classb)
        {
            b_dependency = classb;
            Console.WriteLine("ClassA is created");
        }
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }
    // class Horn
    // {
    //     public void Beep() => Console.WriteLine("Beep - Beep - Beep ...");
    // }
    // class Car
    // {
    //     // horn là một Dependecy của Car
    //     public Horn horn { set; get; }
    //     // Inject bằng phương thức khởi tạo
    //     public Car(Horn _horn) => this.horn = _horn;
    //     public void Beep()
    //     {
    //         // Sử dụng Dependecy đã được Inject
    //         horn.Beep();
    //     }
    // }

    /*
    Ví dụ, xây dựng lại code phần trên với kỹ thuật INJECT BẰNG HÀM TẠO
    kết hợp với thiết kế phụ thuộc lỏng lẻo giữa các dependency (Dependency Inverse) ở trên
    */
    public interface IHorn
    {
        void Beep();
    }
    public class Car
    {
        IHorn horn;                                  // IHorn (Interface) là một Dependecy của Car
        public Car(IHorn horn) => this.horn = horn; // Inject từ hàm  tạo
        public void Beep() => horn.Beep();
    }
    public class HeavyHorn : IHorn
    {
        public void Beep() => Console.WriteLine("(kêu to lắm) BEEP BEEP BEEP ...");
    }

    public class LightHorn : IHorn
    {
        public void Beep() => Console.WriteLine("(kêu bé lắm) beep  bep  bep ...");
    }
    //
    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }
    }
    public class MyServiceOptions
    {
        public string data1 { get; set; }
        public int data2 { get; set; }

    }
    public class MyService
    {
        public string data1 { set; get; }
        public int data2 { set; get; }
        public MyService(IOptions<MyServiceOptions> options)
        {
            var _option = options.Value;
            data1 = _option.data1;
            data2 = _option.data2;
        }
        public void PrintData() => Console.WriteLine($"{data1} / {data2}");

    }
    class Program
    {
        // Factory nhận tham số là IServiceProvider và trả về đối tượng địch vụ cần tạo
        public static IClassB CreateB2(IServiceProvider provider)
        {
            var b2 = new ClassB2(provider.GetService<IClassC>(),
            "Thực hiện trong ClassB2");
            return b2;
        }
        static void Main(string[] args)
        {
            // Thư viện Dependency Injection
            // DI Container: SericeCollection
            // - Đăng ký các dịch vụ (lớp)
            // - ServiceProvider -> Get Service |

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            //
            IClassC objectC = new ClassC1();            // new ClassC();
            IClassB objectB = new ClassB1(objectC);     // new ClassB();
            ClassA objectA = new ClassA(objectB);

            objectA.ActionA();
            //
            // Horn horn = new Horn();

            // var car = new Car(horn); // horn inject vào car
            // car.Beep(); // Beep - beep - beep ...

            Car car1 = new Car(new HeavyHorn());
            car1.Beep();                             // (kểu to lắm) BEEP BEEP BEEP ...

            Car car2 = new Car(new LightHorn());
            car2.Beep();
            //
            /*
            ServiceCollection là lớp triển khai giao diện IServiceCollection 
            nó có chức năng quản lý các dịch vụ (đăng ký dịch vụ - tạo dịch vụ - tự động inject - và các dependency của địch vụ ...). 
            ServiceCollection là trung tâm của kỹ thuật DI, nó là thành phần rất quan trọng trong ứng dụng ASP.NET
            */
            var services = new ServiceCollection();

            // Đăng ký các dịch vụ ...
            // IClassC, ClassC, ClassC1

            var serviceprovider = services.BuildServiceProvider();

            // Đăng ký dịch vụ IClassC tương ứng với đối tượng ClassC
            services.AddSingleton<IClassC, ClassC>();

            var provider = services.BuildServiceProvider();

            for (int i = 0; i < 5; i++)
            {
                var service = provider.GetService<IClassC>();
                Console.WriteLine(service.GetHashCode());
            }
            //
            services.AddTransient<IClassC, ClassC>();

            provider = services.BuildServiceProvider();

            for (int i = 0; i < 5; i++)
            {
                var service = provider.GetService<IClassC>();
                Console.WriteLine(service.GetHashCode());
            }
            //
            // Đăng ký dịch vụ IClassC tương ứng với đối tượng ClassC
            services.AddScoped<IClassC, ClassC>();

            provider = services.BuildServiceProvider();

            // Lấy dịch vụ trong scope toàn cục
            for (int i = 0; i < 5; i++)
            {
                var service = provider.GetService<IClassC>();
                Console.WriteLine(service.GetHashCode());
            }

            // Tạo ra scope mới
            using (var scope = provider.CreateScope())
            {
                // Lấy dịch vụ trong scope
                for (int i = 0; i < 5; i++)
                {
                    var service = scope.ServiceProvider.GetService<IClassC>();
                    Console.WriteLine(service.GetHashCode());
                }
            }
            // ClassA
            // IClassC, ClassC, ClassC1
            // IClassB, ClassB, ClassB1, ClassB2
            // Sử dụng Delegate, Factory đăng ký dịch vụ
            services.AddSingleton<ClassA, ClassA>();
            // services.AddSingleton<IClassB, ClassB2>(
            //     (provider) =>
            //     {
            //         var b2 = new ClassB2(provider.GetService<IClassC>(),
            //         "Thực hiện trong ClassB2");
            //         return b2;
            //     }
            // );

            services.AddSingleton<IClassB>(CreateB2);

            services.AddSingleton<IClassC, ClassC>();

            provider = services.BuildServiceProvider();

            ClassA service_a = provider.GetService<ClassA>();

            service_a.ActionA();

            // Sử dụng IOptions Inject thông số cho dịch vụ
            services = new ServiceCollection();
            services.AddSingleton<MyService>();
            // Đăng ký 1 option
            services.Configure<MyServiceOptions>(
                (MyServiceOptions options) =>
                {
                    options.data1 = "Xin chào các bạn";
                    options.data2 = 2023;
                });
            provider = services.BuildServiceProvider();
            var myservice = provider.GetService<MyService>();
            myservice.PrintData();

            // Nạp cấu hình File vào ứng dụng
            IConfigurationRoot configurationRoot;
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("cauhinh.json");
            configBuilder.Build();
            configurationRoot = configBuilder.Build();
            var key1 = configurationRoot
                            .GetSection("section1")
                            .GetSection("key1").Value;
            var data1 = configurationRoot
                    .GetSection("MyServiceOptions")
                    .GetSection("data1").Value;
            Console.WriteLine(data1);
            // Nạp cấu hình vào IOptions
            var sectionMyServiceOptions = configurationRoot.GetSection("MyServiceOptions");
            services = new ServiceCollection();
            services.AddSingleton<MyService>();
            // Đăng ký 1 option
            services.Configure<MyServiceOptions>(sectionMyServiceOptions);

            provider = services.BuildServiceProvider();
            myservice = provider.GetService<MyService>();
            myservice.PrintData();

            // Dependency Inject trong ứng dụng ASP.NET -> Trong dự án web
        }
    }
}