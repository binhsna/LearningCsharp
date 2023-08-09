
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailUtils
{
    public class MailUtils
    {
        // Cách 1: Trên máy tính đã cài đặt -> Server: Mail Transporter (CentOS / Qmail, SendMail)
        // localhost
        public static async Task<string> SendMail(string _from, string _to, string _subject, string _body)
        {
            MailMessage message = new(_from, _to, _subject, _body)
            {
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            using var smtpClient = new SmtpClient("localhost");

            try
            {
                await smtpClient.SendMailAsync(message);
                return "Gui email thanh cong";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Gui email that bai";
            }

        }

        // Cách 2: Gửi mail qua google
        public static async Task<string> SendGmail(string _from, string _to, string _subject, string _body, string _gmail, string _password)
        {
            MailMessage message = new(_from, _to, _subject, _body)
            {
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            using var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_gmail, _password);

            try
            {
                await smtpClient.SendMailAsync(message);
                return "Gui email thanh cong";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Gui email that bai";
            }
        }
        // Cách 3: Dùng thư viện của bên thứ 3

    }
}