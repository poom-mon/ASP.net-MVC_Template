using System;
using System.Text; 
using System.IO; 
using System.Net.Mail;
using System.Net;
 
    public class ClsMail
    {
        // Natz > ส่งอีเมล์
        public static bool Send(string type, string from, string[] to, string[] cc, string[] bcc, string subject, string body, params string[] filePath)
        {
            try
            {
                SmtpClient client               = new SmtpClient();
                MailMessage mail                = new MailMessage();
                // client
                client.DeliveryMethod           = SmtpDeliveryMethod.Network;
                client.EnableSsl                = (type == "external") ? true : false;
                client.Host                     = (type == "external") ? "smtp.gmail.com" : "192.168.0.254";
                client.Port                     = (type == "external") ? 587 : 25;
                client.UseDefaultCredentials    = false;
                string Username                 = (type == "external") ? "internal@silkspan.com" : "internal@silkspan.local";
                string Password                 = (type == "external") ? "internalss" : "internalss";
                client.Credentials              = new NetworkCredential(Username, Password);
                // encoding
                mail.SubjectEncoding            = System.Text.Encoding.UTF8;
                mail.BodyEncoding               = System.Text.Encoding.UTF8;
                // add from 
                mail.From = new MailAddress(from);
                // add to
                if ((to != null) && (to.Length > 0))
                    foreach (string data in to)
                        mail.To.Add(new MailAddress(data));
                // add cc
                if ((cc != null) && (cc.Length > 0))
                    foreach (string data in cc)
                        mail.CC.Add(new MailAddress(data));
                // add bcc
                if ((bcc != null) && (bcc.Length > 0))
                    foreach (string data in bcc)
                        mail.Bcc.Add(new MailAddress(data));
                // add subject
                mail.Subject = subject;
                // add body
                mail.IsBodyHtml = true;
                mail.Body = body;
                // add attachment
                if ((filePath != null) && (filePath.Length > 0))
                    foreach (string path in filePath)
                        mail.Attachments.Add(new Attachment(path));// mail.Attachments.Add(new Attachment("c:\\Natz\\Natz.txt"));
                // send
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //send other mail
        public static bool SendAutherMail(string type, string Emailfrom,string EmailUsername ,string EmailPassword ,string[] to, string[] cc, string[] bcc, string subject, string body, params string[] filePath)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                // client
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = (type == "external") ? true : false;
                client.Host = (type == "external") ? "smtp.gmail.com" : "192.168.0.254";
                client.Port = (type == "external") ? 587 : 25;
                client.UseDefaultCredentials = false;
                string Username = (type == "external") ? EmailUsername : "internal@silkspan.local";
                string Password = (type == "external") ? EmailPassword : "internalss";
                client.Credentials = new NetworkCredential(Username, Password);
                // encoding
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                // add from 
                mail.From = new MailAddress(Emailfrom);
                // add to
                if ((to != null) && (to.Length > 0))
                    foreach (string data in to)
                        mail.To.Add(new MailAddress(data));
                // add cc
                if ((cc != null) && (cc.Length > 0))
                    foreach (string data in cc)
                        mail.CC.Add(new MailAddress(data));
                // add bcc
                if ((bcc != null) && (bcc.Length > 0))
                    foreach (string data in bcc)
                        mail.Bcc.Add(new MailAddress(data));
                // add subject
                mail.Subject = subject;
                // add body
                mail.IsBodyHtml = true;
                mail.Body = body;
                // add attachment
                if ((filePath != null) && (filePath.Length > 0))
                    foreach (string path in filePath)
                        mail.Attachments.Add(new Attachment(path)); 
                // send
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    } 