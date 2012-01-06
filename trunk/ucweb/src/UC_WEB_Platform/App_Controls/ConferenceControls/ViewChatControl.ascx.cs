using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.Functions;
using UCENTRIK.DATASETS;
using UCENTRIK.Conference;

namespace UCENTRIK.WEB.PLATFORM.App_Controls.ConferenceControls
{
    public partial class ViewChatControl : UcBaseControl
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
                //confSessionUser = this.UcPage.UserName;
                confSessionUser = value;
            }
        }

        protected Int32 rowsToShow = 1;
        public string RowsToShow
        {
            set
            {
                string s = value;
                Int32.TryParse(s, out rowsToShow);
            }
        }

        public bool ShowSendControl
        {
            set
            {
                //pnlSend.Visible = value;
            }
        }

        private string _anonymousName = "";
        public string AnonymousName
        {
            set
            {
                this._anonymousName = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtMessage.Attributes.Add("style", "overflow:hidden;");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            UcTextChatController textChatController = (UcTextChatController)Application["UcTextChatController"];
            ChatDS.ChatDSDataTable dt = textChatController.GetMessages(confSessionId, rowsToShow);

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

        protected string getMessageSenderName(object obj)
        {
            if (this._anonymousName == "")
            {
                return obj.ToString();
            }
            else
            {
                if (this.confSessionUser == obj.ToString())
                    return "Me";
                else
                    return this._anonymousName;
            }
        }

        protected string getMessageSenderCssClass(object obj)
        {
            if (this.confSessionUser == obj.ToString())
                return "TextChatMessageSender";
            else
                return "TextChatMessageReceiver";
        }

        protected string getMessageSenderTextCssClass(object obj)
        {
            if (this.confSessionUser == obj.ToString())
                return "TextChatMessageSenderText";
            else
                return "TextChatMessageReceiverText";
        }

        protected string getWrappedMessage(object obj)
        {
            string inText = obj.ToString();
            string outText = TextFunctions.FormatFreeText(inText, 25);
            outText = TextFunctions.FormatLineBreaks(outText);

            return outText;
        }
    }
}
