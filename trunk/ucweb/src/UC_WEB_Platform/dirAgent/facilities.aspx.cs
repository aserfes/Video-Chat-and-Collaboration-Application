using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;

namespace UcentrikWeb.dirAgent
{
    public partial class facilities : UcAppBasePage
    {
		protected void Page_Init( object sender, EventArgs e )
		{
			if( !this.Page.IsPostBack )
			{
				this.allowTimerUpdate = true;
			}
		}

		protected void Page_Load( object sender, EventArgs e )
        {
			if( !this.Page.IsPostBack )
			{
				//filterFacilities();

				sosFacility.FindFieldByHeaderText( "Agent" ).Visible = true;
				sosFacility.FindFieldByHeaderText( "Active" ).Visible = false;
				sosFacility.FindFieldByHeaderText( "Command" ).Visible = true;
			}
			
			sosFacility.UcDataBind( 0, ProxyHelper.GetUserAgentId( this.UserId ) );
		}

		//protected void filterFacilities()
		//{
		//    Int32 agentId = ProxyHelper.GetUserAgentId(this.UserId);
		//    sosFacility.UcDataBind(0, agentId);
		//}


    }
}


