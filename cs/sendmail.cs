using System;
using System.Net;
using System.Net.Mail;

public class Mail
{
    static void Main()
    {

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("masonhwolf@gmail.com");
            mail.To.Add("mason.wolf@ajab.afcent.af.mil");

            int RandomSubject;
            Random x = new Random();
            RandomSubject = x.Next(1, 100000000);

            mail.Subject = RandomSubject.ToString() + " Boa Update " + DateTime.Now.ToString();
            mail.Body = "";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment("boa.txt");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("masonhwolf@gmail.com", "");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        Console.WriteLine("Complete.");
        Console.ReadLine();
    }
    }
