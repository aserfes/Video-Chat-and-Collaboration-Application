using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.Membership;
using UCENTRIK.LIB.EmailFunctions;

namespace UCENTRIK.UserControls.Controls
{
    public partial class PasswordRecovery : UcBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnSend_Click(object sender, EventArgs e)
        {
            UcEmailFunctions email = new UcEmailFunctions();
            bool isSuccess = email.SendEmail("sbylin@ucentrik.com", "TEST", "...testing...");

            if (isSuccess)
            {
                lblMessage.Text = "The message has been sent";
            }
            else
            {
                lblMessage.Text = "Cannot send the message";
            }
        }



        //---
    }
}