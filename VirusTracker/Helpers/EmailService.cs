using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using MailKit.Net.Pop3;
using VirusTracker.Models;
using VirusTracker.Data;
using Microsoft.AspNetCore.Identity;

namespace VirusTracker.Helpers
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
       // List<EmailMessage> ReceiveEmail();
    }
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;
        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        private string FormatText(string text, Patient patient, Doctor doctor)
        {
            var array = text.Split("\n");
            foreach (var a in array)
                System.Diagnostics.Debug.WriteLine(a);
            //System.Diagnostics.Debug.WriteLine(" <" + patient.emailAddress.Trim() + "> ");
            //System.Diagnostics.Debug.WriteLine(doctor.firstName.Trim() + " " + doctor.lastName.Trim() + " <epidemytracker@gmail.com>");
            string format = "";
            foreach(var l in array)
            {
                if(l != null && l.Length > 0)
                    if (l[0] != '>' && (l.Contains(" <" + patient.emailAddress.Trim() + "> ") == false && l.Contains(doctor.firstName.Trim() + " " + doctor.lastName.Trim() + " <epidemytracker@gmail.com>") == false))
                    {
                        System.Diagnostics.Debug.WriteLine(l);

                        format += l + "\n";
                    }
                        
            }
            System.Diagnostics.Debug.WriteLine(format);

            return format;
        }
        public List<EmailsModel> ReceiveEmail(Patient patient, Doctor doctor)
        {
            List<EmailsModel> emails = new List<EmailsModel>();
            using (var emailClient = new Pop3Client())
            {
                System.Diagnostics.Debug.WriteLine("0");
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                emailClient.Connect(_emailConfiguration.PopServer, _emailConfiguration.PopPort, true);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(_emailConfiguration.PopUsername, _emailConfiguration.PopPassword);
                System.Diagnostics.Debug.WriteLine("1");

                for (int  i = 0; i < emailClient.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("2");
                    var msg = emailClient.GetMessage(i);
                    //foreach(var m in msg.From.Mailboxes.ToList())
                    //{
                    //    System.Diagnostics.Debug.WriteLine(m.Address);
                    //}
                    if (msg.From.Mailboxes.ToList().Find(m => m.Address == patient.emailAddress.Trim()) != null)
                    {
                        System.Diagnostics.Debug.WriteLine("3");
                        var newEmail = new EmailsModel();
                        newEmail.doctorId = doctor.Id;
                        newEmail.patientId = patient.ID.ToString();
                        newEmail.fromAddress = patient.emailAddress;
                        newEmail.toAddress = doctor.Email;
                        newEmail.content = FormatText(msg.BodyParts.OfType<TextPart>().FirstOrDefault().Text, patient, doctor);
                        newEmail.date = msg.Date.UtcDateTime;
                        if (msg.Subject!=null)
                            newEmail.subject = msg.Subject;
                        //System.Diagnostics.Debug.WriteLine(i);
                        //var emailMessage = new EmailMessage
                        //{
                        //    Content = msg.TextBody,
                        //    Subject = msg.Subject
                        //};
                        //emailMessage.ToAddress = new EmailAddress { Name = doctor.firstName + " " + doctor.lastName, Address = "epidemytracker@gmail.com" };
                        //emailMessage.FromAddress = new EmailAddress { Name = patient.firstName + " " + patient.lastName, Address = patient.emailAddress };
                        //emails.Add(emailMessage);
                        emails.Add(newEmail);
                        System.Diagnostics.Debug.WriteLine("4");
                        System.Diagnostics.Debug.WriteLine("5");
                        //_dataContext.Patient.Find(patient).messages += newEmail.Id.ToString() + ",";
                        //System.Diagnostics.Debug.WriteLine(newEmail.Id.ToString());

                        emailClient.DeleteMessage(i);
                    }
                }
                emailClient.Disconnect(true);
            }
            return emails;
        }

        public async void Send(EmailMessage emailMessage)
        {
            var msg = new MimeMessage();
            msg.To.Add(new MailboxAddress(emailMessage.ToAddress.Name, emailMessage.ToAddress.Address));
            msg.From.Add(new MailboxAddress(emailMessage.FromAddress.Name, emailMessage.FromAddress.Address));

            msg.Subject = emailMessage.Subject;
            msg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailMessage.Content
            };
            using (var emailClient = new SmtpClient())
            {
               

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                await emailClient.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                await emailClient.SendAsync(msg);
                await emailClient.DisconnectAsync(true);
            }
        }

        public async void AnswerPatient(EmailMessage emailMessage, Patient patient, Doctor doctor)
        {
            var msg = new MimeMessage();
            msg.To.Add(new MailboxAddress(emailMessage.ToAddress.Name, emailMessage.ToAddress.Address));
            msg.From.Add(new MailboxAddress(emailMessage.FromAddress.Name, emailMessage.FromAddress.Address));

            msg.Subject = emailMessage.Subject;
            msg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailMessage.Content
            };
            var newEmail = new EmailsModel();
            newEmail.doctorId = doctor.Id;
            newEmail.patientId = patient.ID.ToString();
            newEmail.fromAddress = doctor.Email;
            newEmail.toAddress = patient.emailAddress;
            newEmail.content = msg.TextBody;
            newEmail.date = DateTime.Now;
            if (msg.Subject != null)
                newEmail.subject = msg.Subject;
            
            using (var emailClient = new SmtpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                await emailClient.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                await emailClient.SendAsync(msg);
                
                await emailClient.DisconnectAsync(true);
            }
            
        }
    }
}
