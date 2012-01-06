using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using UCENTRIK.Configuration;

namespace UCENTRIK.Utility
{
    public class MailSender
    {
        public enum EmailTemplate
        {
            RegistrationConfirmation = 0,
            AccountActivationNotification = 1,
            RestorePassword = 2
        }

        public static void SendEmail(string recipients, string subject, EmailTemplate emailTemplate, Dictionary<string, string> values)
        {
            try
            {
                var emailBody = GetTemplate(emailTemplate);

                if (!String.IsNullOrEmpty(emailBody))
                {
                    foreach (var keyValuePair in values)
                    {
                        emailBody = emailBody.Replace("##" + keyValuePair.Key + "##", HttpUtility.HtmlEncode(keyValuePair.Value));
                    }

                    var mailMessage = new MailMessage(new MailAddress(GetFromAddress()), new MailAddress(recipients));
                    mailMessage.Subject = subject;
                    mailMessage.Body = emailBody;
                    mailMessage.IsBodyHtml = true;

                    var client = new SmtpClient();
                    client.EnableSsl = UcentrikConfiguration.MailSenderUseSsl;
                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.Message);
            }
        }

        #region Private methods

        private static string GetTemplate(EmailTemplate emailTemplate)
        {
            switch (emailTemplate)
            {
                case EmailTemplate.RegistrationConfirmation:
                    return System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/Email/RegistrationConfirmation.html"));
                case EmailTemplate.AccountActivationNotification:
                    return System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/Email/AccountActivationNotification.html"));
                case EmailTemplate.RestorePassword:
                    return System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/Email/RestorePassword.html"));
                default:
                    return null;
            }
        }

        private static String GetFromAddress()
        {
            var section = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
            if (section == null)
                return String.Empty;

            return section.From;
        }

        #endregion
    }
}