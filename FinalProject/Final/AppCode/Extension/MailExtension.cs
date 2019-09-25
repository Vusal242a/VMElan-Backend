using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Final.AppCode.Extension
{
    public static partial class Extension
    {
        static public bool SendMail(string subject, string Content, string toMails)
        {
            if (string.IsNullOrEmpty(subject))
                throw new ArgumentNullException("subject");
            if (string.IsNullOrEmpty(Content))
                throw new ArgumentNullException("body");
            if (string.IsNullOrEmpty(toMails))
                throw new ArgumentNullException("toMails");

            MailMessage mail = new MailMessage(new MailAddress("fullstackstaff@mail.ru", "VMELAN"), new MailAddress(toMails))
            {
                Subject = subject,
                Body = Content,
                IsBodyHtml = true
            };

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Credentials = new NetworkCredential("fullstackstaff", "!d@v#l0pmentgroup20!9"),
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            int retry = 3;
            do
            {
                try
                {
                    client.Send(mail);
                    return true;
                }
                catch (Exception) { }

                retry--;
            } while (retry > 0);

            return false;
        }
    }
}