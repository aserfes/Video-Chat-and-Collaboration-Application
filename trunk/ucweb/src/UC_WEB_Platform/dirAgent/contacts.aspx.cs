using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.dirAgent
{
    public partial class contacts : UcAppBasePage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            //sosContact.UcHeaderControl = ddlContact;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                filterContacts();
            
        }

        protected void filterContacts()
        {
            sosContact.UcDataBind();
        }

    }
}

