using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.dirAgent
{
    public partial class users : UcAppBasePage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            sosUser.UcHeaderControl = ddlUserRoles;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                ddlUserRoles.DataSource = BllProxyLookup.GetUserRoles(UserRoleId);
                ddlUserRoles.DataBind();

                ListItem item = new ListItem("All", "0");
                ddlUserRoles.Items.Insert(0, item);

                ddlUserRoles.Items.FindByValue("0").Selected = true;

                filterUsers();
            }
        }

        protected void ddlUserRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterUsers();
        }

        protected void filterUsers()
        {
            Int32 userRoleId = Convert.ToInt32(ddlUserRoles.SelectedValue);
            sosUser.UcDataBind(userRoleId);
        }

    }
}

