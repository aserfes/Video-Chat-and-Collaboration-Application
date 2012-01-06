using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.dirAdmin
{
    public partial class contacts : UcAppBasePage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
//            sosContact.UcHeaderControl = ddlContact;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.Page.IsPostBack)
            //{
            //    ddlContact.DataSource = BllProxyLookup.GetUserRoles();
            //    ddlContact.DataBind();

            //    ListItem item = new ListItem("All", "0");
            //    ddlContact.Items.Insert(0, item);

            //    ddlContact.Items.FindByValue("0").Selected = true;

            //    filterUsers();
            //}
        }

        protected void ddlContactStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filterUsers();
        }

        //protected void filterUsers()
        //{
        //    Int32 userRoleId = Convert.ToInt32(ddlContact.SelectedValue);
        //    sosUser.UcDataBind(userRoleId);
        //}

    }
}

