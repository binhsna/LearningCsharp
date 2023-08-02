using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    class Program
    {
        public static void ShowUriInfo(string url)
        {
            Uri uri = new Uri(url);
            Console.WriteLine(url);
            Console.WriteLine($"Scheme   : {uri.Scheme}");
            Console.WriteLine($"Host     : {uri.Host}");
            Console.WriteLine($"Port     : {uri.Port}");
            Console.WriteLine($"Fragment : {uri.Fragment}");
            Console.WriteLine($"Query    : {uri.Query}");
            Console.WriteLine($"Path     : {uri.LocalPath}");
            foreach (var seg in uri.Segments)
                Console.WriteLine($"           {seg}");
            /*
            https://xuanthulab.net/abc/testpate.html?read=1#testfragment
            Scheme   : https
            Host     : xuanthulab.net
            Port     : 443
            Fragment : #testfragment
            Query    : ?read=1
            Path     : /abc/testpate.html
                    /
                    abc/
                    testpate.html
            */
        }
        public static void BuildUriExample()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Host = "xuanthulab.net";
            uriBuilder.Port = 80;
            uriBuilder.Path = "path/to/site";
            uriBuilder.Query = "lession=1";
            uriBuilder.Fragment = "xyz";
            Uri uri = uriBuilder.Uri;
            Console.WriteLine(uri);
            // http://xuanthulab.net/path/to/site?lession=1#xyz
        }
        public static void IPAddressExample(string ips)
        {
            IPAddress ipaddress;
            if (IPAddress.TryParse(ips, out ipaddress))
            {
                Console.WriteLine($"Broadcast     {IPAddress.Broadcast}");
                Console.WriteLine($"Loopback      {IPAddress.Loopback}");
                Console.WriteLine($"AddressFamily {ipaddress.AddressFamily}");
                Console.WriteLine($"IP4           {ipaddress.MapToIPv4().ToString()}");
                Console.WriteLine($"IP6           {ipaddress.MapToIPv6().ToString()}");
                /*
                    Broadcast     255.255.255.255
                    Loopback      127.0.0.1
                    AddressFamily InterNetwork
                    IP4           192.168.0.66
                    IP6           ::ffff:192.168.0.66
                */
            }
        }
        // Phương thức này gọi bởi RemoteCertificateValidationDelegate trong quá trình xác thức SSL
        // chỉ dùng khi kết nối HTTPS

        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            Console.WriteLine("ValidateServerCertificate");
            if (sslPolicyErrors == SslPolicyErrors.None) return true;
            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }

        // Kết nối đến server Tpc bằng TcpClient, đọc nội dung trả về
        public static async Task ReadHtmlAsync(string url)
        {

            using var client = new TcpClient();
            Console.WriteLine($"Start get {url}");
            Uri uri = new(url);

            var hostAdress = await Dns.GetHostAddressesAsync(uri.Host);
            IPAddress ipaddrress = hostAdress[0];
            Console.WriteLine($"Host: {uri.Host}, IP: {ipaddrress}:{uri.Port}");
            await client.ConnectAsync(ipaddrress.MapToIPv4(), uri.Port);
            Console.WriteLine("Connected");
            Console.WriteLine();


            Stream stream;
            if (uri.Scheme == "https")
            {
                // SslStream
                stream = new SslStream(client.GetStream(), false,
                                       new RemoteCertificateValidationCallback(ValidateServerCertificate),
                                       null);
                (stream as SslStream).AuthenticateAsClient(uri.Host);
            }
            else
            {
                // NetworkStream
                stream = client.GetStream();
            }

            Console.WriteLine($"Get Stream OK: {stream.GetType().Name}");


            // Xem: /psr-7-chuan-giao-dien-thong-diep-http.html#HTTPRequest
            StringBuilder header = new StringBuilder();
            header.Append($"GET {uri.PathAndQuery} HTTP/1.1\r\n");
            // header.Append($"GET {uri.PathAndQuery} HTTP/2\r\n");
            header.Append($"Host: {uri.Host}\r\n");
            header.Append($"\r\n");

            Console.WriteLine("Request:");
            Console.WriteLine(header);

            byte[] bsend = Encoding.UTF8.GetBytes(header.ToString());
            await stream.WriteAsync(bsend, 0, bsend.Length);

            await stream.FlushAsync();

            Console.WriteLine("Send Message OK");


            var ms = new MemoryStream();
            byte[] buffer = new byte[255];
            int bytes = -1;
            do
            {
                bytes = await stream.ReadAsync(buffer, 0, buffer.Length);

                // Lưu dữ liệu tải về vào ms
                ms.Write(buffer, 0, bytes);

                Array.Clear(buffer, 0, buffer.Length);

            } while (bytes != 0);

            Console.WriteLine($"Read OK");

            ms.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(ms);
            string html = reader.ReadToEnd();
            Console.WriteLine("Response:");
            Console.WriteLine(html);
        }
        static async Task Main(string[] args)
        {
            string url = "https://google.com.vn";
            await ReadHtmlAsync(url);
            //
            // IPHostEntry hostInfo = Dns.GetHostEntry("google.com.vn");
            // Console.WriteLine(hostInfo.HostName);
            // foreach (var ip in hostInfo.AddressList)
            // {
            //     Console.WriteLine(ip);
            // }
            /*
                google.com.vn
                216.58.221.227
                2404:6800:4005:800::2003
            */
        }
    }
}
