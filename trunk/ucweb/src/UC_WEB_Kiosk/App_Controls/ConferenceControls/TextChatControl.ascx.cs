using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.Helpers;
using UCENTRIK.LIB.Functions;
using UCENTRIK.DATASETS;
using UCENTRIK.Conference;

namespace UCENTRIK.WEB.PLATFORM.App_Controls.ConferenceControls
{


    public partial class TextChatControl : UcBaseControl
    {



        ///---------------------------------------------------------------------------------
        protected string confSessionId
        {
            get
            {
                string _confSessionId = null;
                Object objViewStateConfSessionId = this.ViewState[this.ID + "ConfSessionId"];
                if (objViewStateConfSessionId != null)
                    _confSessionId = Convert.ToString(objViewStateConfSessionId);

                return _confSessionId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "ConfSessionId");
                this.ViewState.Add(this.ID + "ConfSessionId", value);
            }
        }
        public string ConfSessionId
        {
            set
            {
                confSessionId = value;
            }
        }

        ///---------------------------------------------------------------------------------
        protected string confSessionUser
        {
            get
            {
                string _confSessionUser = null;
                Object objViewStateConfSessionUser = this.ViewState[this.ID + "ConfSessionUser"];
                if (objViewStateConfSessionUser != null)
                    _confSessionUser = Convert.ToString(objViewStateConfSessionUser);

                return _confSessionUser;
            }
            set
            {
                this.ViewState.Remove(this.ID + "ConfSessionUser");
                this.ViewState.Add(this.ID + "ConfSessionUser", value);
            }
        }
        public string ConfSessionUser
        {
            set
            {
                confSessionUser = value;
            }
        }











        protected void Page_Load(object sender, EventArgs e)
        {
            //ltText.Text = "";
        }








        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    UcTextChatController textChatController = (UcTextChatController)Application["UcTextChatController"];
        //    UcTextChatMessage[] messages = textChatController.GetMessages(confSessionId, 12);

        //    if (messages != null)
        //    {
        //        rptTextChat.DataSource = messages;
        //        rptTextChat.DataBind();
        //    }

            
        //    txtMessage.Focus();
        //}

        protected void Page_PreRender(object sender, EventArgs e)
        {
            UcTextChatController textChatController = (UcTextChatController)Application["UcTextChatController"];
            ChatDS.ChatDSDataTable dt = textChatController.GetMessages(confSessionId, 12);

            DataRow[] rows = dt.Select("", "chat_id");

            rptTextChat.DataSource = rows;
            rptTextChat.DataBind();
        }








        protected void btnSend_Click(object sender, EventArgs e)
        {
            UcTextChatController textChatController = (UcTextChatController)Application["UcTextChatController"];
            UcTextChatMessage message = new UcTextChatMessage(confSessionUser, txtMessage.Text.Trim());

            if (message.MessageText != "")
                textChatController.SendMessage(confSessionId, message);

            txtMessage.Text = "";
            txtMessage.Focus();

            upMessageBox.Update();
        }








//////-------------------------------------------------------------------------
//        protected void resetSubmitButtons(Control c)
//        {
//            if (c.HasControls())
//            {
//                foreach (Control cntrl in c.Controls)
//                {
//                    Button btn = cntrl as Button;
//                    if (btn != null)
//                    {
//                        btn.UseSubmitBehavior = false;
//                    }
//                    else
//                    {
//                        resetSubmitButtons(cntrl);
//                    }
//                }
//            }
//        }
//////-------------------------------------------------------------------------





        protected string getMessageSenderCssClass(object obj)
        {
            if(this.confSessionUser == obj.ToString())
                return "ErrorMessage";
            else
                return "TextMessage";
        }















        protected string getWrappedMessage(object obj)
        {
            string inText = obj.ToString();
            string outText = TextFunctions.FormatFreeText(inText, 50);
            outText = TextFunctions.FormatLineBreaks(outText);

            return outText;
        }



        protected string getChatTime(object obj)
        {
            string result = "";

            DateTime datetime = Convert.ToDateTime(obj);

            datetime = UcDateTime.GetUserLocalDateTime(datetime, this.UcPage.TimeZone);

            result = datetime.ToShortTimeString();
            return result;
        }

        protected string getChatDate(object obj)
        {
            string result = "";

            DateTime datetime = Convert.ToDateTime(obj);

            datetime = UcDateTime.GetUserLocalDateTime(datetime, this.UcPage.TimeZone);

            result = "(" + datetime.ToShortDateString() + ")";
            return result;
        }






        //---
    }
}