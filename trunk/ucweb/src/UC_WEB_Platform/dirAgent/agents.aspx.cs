using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.dirAgent
{
    public partial class agents : UcAppBasePage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            sosAgent.UcHeaderControl = ddlAgent;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.Page.IsPostBack)
            //{
            //    ddlAgent.DataSource = BllProxyLookup.GetUserRoles();
            //    ddlAgent.DataBind();

            //    ListItem item = new ListItem("All", "0");
            //    ddlAgent.Items.Insert(0, item);

            //    ddlAgent.Items.FindByValue("0").Selected = true;

            //    filterUsers();
            //}
        }

        protected void ddlAgentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filterUsers();
        }

        //protected void filterUsers()
        //{
        //    Int32 userRoleId = Convert.ToInt32(ddlAgent.SelectedValue);
        //    sosUser.UcDataBind(userRoleId);
        //}

    }
}

