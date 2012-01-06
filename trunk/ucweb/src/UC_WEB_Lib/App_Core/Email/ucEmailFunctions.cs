using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

using System.Text;
using System.Net.Mail;



namespace UCENTRIK.LIB.EmailFunctions
{


    public class UcEmailFunctions
    {
       


        protected HttpContext context;
        protected SmtpClient smtpClient;

        public UcEmailFunctions()
        {
            context = HttpContext.Current;
            smtpClient = new SmtpClient();
        }





        protected bool sendEmail(MailMessage message)
        {
            try
            {
                this.smtpClient.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }






        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------


        //--------------------------------------------------------------------------  Password Recovery
        //
        public bool SendEmail(string to, string subject, string body)
        {
            bool chkResult = false;

            string from = "system@ucentrik.com";

            MailMessage message = new MailMessage(from, to, subject, body);

            if (message != null)
            {
                chkResult = this.sendEmail(message);
            }

            return chkResult;
        }











        //---
    }
}

