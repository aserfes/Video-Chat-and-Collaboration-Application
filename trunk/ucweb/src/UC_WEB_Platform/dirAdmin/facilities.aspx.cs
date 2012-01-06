using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;

namespace UcentrikWeb.dirAdmin
{
    public partial class facilities : UcAppBasePage
    {


        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                filterFacilities();
        }



        protected void mvFacility_ActiveViewChanged(object sender, EventArgs e)
        {
        }



        protected void filterFacilities()
        {
            sosFacility.UcDataBind(0, 0);
        }




        protected void sosFacility_Back(object sender, UcControlArgs e)
        {
            sosFacility.UcDataBind(0, 0);
            mvFacility.ActiveViewIndex = 0;
        }


        protected void sosFacility_ManageGroups(object sender, UcControlArgs e)
        {
            FacilityGroup.FacilityId = e.Id;
            FacilityGroup.UcDataBind();
            mvFacility.ActiveViewIndex = 1;
        }


    }
}

