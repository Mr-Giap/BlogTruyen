using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FPTShop.Utils
{
    class SendEmail
    {
        public string FromEmail { get; private set; }
        public string FromPassWord { get; private set; }
        public string Host { get; private set; }
        public int Port { get; private set; }

        public SendEmail(string fromEmail, string fromPassWord, string host, int port)
        {
            Port = port;
            Host = host;
            FromPassWord = fromPassWord;
            FromEmail = fromEmail;
        }

        public string Send_Email(string toEmail, string subject, string body)
        {
            var smtp = new SmtpClient(Host, Port);
            {
                smtp.Credentials = new NetworkCredential(FromEmail, FromPassWord);
            }
            var msg = new MailMessage(FromEmail, toEmail, subject, body) { IsBodyHtml = true };
            try
            {
                smtp.EnableSsl = true;
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }
        public string SendEmailCc(string sendTo, string ccTo, string subject, string body)
        {
            var smtp = new SmtpClient(Host, Port);
            {
                smtp.Credentials = new NetworkCredential(FromEmail, FromPassWord);
            }
            var msg = new MailMessage(FromEmail, sendTo, subject, body);
            msg.CC.Add(ccTo);
            msg.IsBodyHtml = true;
            try
            {
                smtp.EnableSsl = true;
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }
    }
}
