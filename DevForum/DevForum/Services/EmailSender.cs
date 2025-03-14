﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace DevForum.Services
{
    public class MyEmailSender : Microsoft.AspNetCore.Identity.UI.Services.IEmailSender
    {
        public IConfiguration Configuration { get; }
        public MyEmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string HtmlMessage)
        {
            using (MailMessage mm = new MailMessage(Configuration["NetMail:sender"], email))
            {
                mm.Subject = subject;
                string body = HtmlMessage;
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = Configuration["NetMail:smtpHost"];
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(Configuration["NetMail:sender"], Configuration["NetMail:senderpassword"]);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                return Task.CompletedTask;
            }
        }
    }
}
