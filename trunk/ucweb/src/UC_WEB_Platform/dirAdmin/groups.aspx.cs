using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.dirAdmin
{
    public partial class groups : UcAppBasePage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                filterGroups();
        }



        protected void mvGroup_ActiveViewChanged(object sender, EventArgs e)
        {
        }


        protected void filterGroups()
        {
            sosGroup.UcDataBind(0, 0);
        }



        protected void sosGroup_Back(object sender, UcControlArgs e)
        {
            sosGroup.UcDataBind(0, 0);
            mvGroup.ActiveViewIndex = 0;
        }


        protected void sosGroup_ManageAgents(object sender, UcControlArgs e)
        {
            GroupAgent.GroupId = e.Id;
            GroupAgent.UcDataBind();
            mvGroup.ActiveViewIndex = 1;
        }
        protected void sosGroup_ManageFacilities(object sender, UcControlArgs e)
        {
            GroupFacility.GroupId = e.Id;
            mvGroup.ActiveViewIndex = 2;
        }






    }
}

