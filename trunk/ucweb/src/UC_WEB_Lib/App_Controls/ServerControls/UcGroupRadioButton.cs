using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace UCENTRIK.LIB.App_Controls.ServerControls
{


    [ToolboxData("<{0}:UcGroupRadioButton runat=server></{0}:UcGroupRadioButton>")]
    public class UcGroupRadioButton : UcRadioButton, IPostBackDataHandler
    {
        public UcGroupRadioButton()
            : base()
        {
        }



        #region Properties

        private string Value
        {
            get
            {
                string val = Attributes["value"];
                if (val == null)
                    val = UniqueID;
                else
                    val = UniqueID + "_" + val;
                return val;
            }
        }

        #endregion

        #region Rendering

        protected override void Render(HtmlTextWriter output)
        {
            RenderInputTag(output);
        }

        private void RenderInputTag(HtmlTextWriter htw)
        {
            htw.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
            htw.AddAttribute(HtmlTextWriterAttribute.Type, "radio");
            htw.AddAttribute(HtmlTextWriterAttribute.Name, GroupName);
            htw.AddAttribute(HtmlTextWriterAttribute.Value, Value);
            if (Checked)
                htw.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
            if (!Enabled)
                htw.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");

            string onClick = Attributes["onclick"];
            if (AutoPostBack)
            {
                if (onClick != null)
                    onClick = String.Empty;
                onClick += Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                htw.AddAttribute(HtmlTextWriterAttribute.Onclick, onClick);
                htw.AddAttribute("language", "javascript");
            }
            else
            {
                if (onClick != null)
                    htw.AddAttribute(HtmlTextWriterAttribute.Onclick, onClick);
            }

            if (AccessKey.Length > 0)
                htw.AddAttribute(HtmlTextWriterAttribute.Accesskey, AccessKey);
            if (TabIndex != 0)
                htw.AddAttribute(HtmlTextWriterAttribute.Tabindex,
                    TabIndex.ToString(NumberFormatInfo.InvariantInfo));
            htw.RenderBeginTag(HtmlTextWriterTag.Input);
            htw.RenderEndTag();
        }

        #endregion

        #region IPostBackDataHandler Members

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            OnCheckedChanged(EventArgs.Empty);
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey,
            System.Collections.Specialized.NameValueCollection postCollection)
        {
            bool result = false;
            string value = postCollection[GroupName];
            if ((value != null) && (value == Value))
            {
                if (!Checked)
                {
                    Checked = true;
                    result = true;
                }
            }
            else
            {
                if (Checked)
                    Checked = false;
            }
            return result;
        }

        #endregion
    }



}
