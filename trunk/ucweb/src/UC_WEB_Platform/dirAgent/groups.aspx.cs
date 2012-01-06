using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.dirAgent
{
    public partial class groups : UcAppBasePage
    {



        private Int32 _agentId;


        protected void Page_Init(object sender, EventArgs e)
        {
            _agentId = ProxyHelper.GetUserAgentId(this.UserId);
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
            sosGroup.UcDataBind(_agentId, 0);
        }







        protected void sosGroup_Back(object sender, UcControlArgs e)
        {
            sosGroup.UcDataBind(_agentId, 0);
            mvGroup.ActiveViewIndex = 0;
        }





        protected void sosGroup_ManageAgents(object sender, UcControlArgs e)
        {
            GroupAgent.GroupId = e.Id;
            mvGroup.ActiveViewIndex = 1;
        }
        protected void sosGroup_ManageFacilities(object sender, UcControlArgs e)
        {
            GroupFacility.GroupId = e.Id;
            mvGroup.ActiveViewIndex = 2;
        }






    }
}


