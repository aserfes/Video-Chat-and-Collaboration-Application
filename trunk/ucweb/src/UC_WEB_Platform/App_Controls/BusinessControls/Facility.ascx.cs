using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

using System.Runtime.Serialization;
using System.Text;
using System.Configuration;


namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class Facility : UcAppBaseOperationalControl
    {
        public event UcControlEventHandler ManageGroups;
		int agent_id;

        protected void manageGroups(object sender, UcControlArgs e)
        {
            if (ManageGroups != null)
                ManageGroups(this, e);
        }

        public Control UcHeaderControl
        {
            set
            {
                phControls.Controls.Add(value);
            }
        }
        
        //public void UcDataBind()
        //{
        //    if (mvControl.ActiveViewIndex == 0)
        //        gvList.Sort(sortExpression, sortDirection);
        //    else if (mvControl.ActiveViewIndex == 1)
        //        profileControl.Refresh();
        //}

        public void UcDataBind(Int32 statusId, Int32 agentId)
        {
			this.agent_id = agentId;
			//Parameter objStatusIdParameter = new Parameter("status_id", DbType.Int32);
			//Parameter objAgentIdParameter = new Parameter("agent_id", DbType.Int32);
			//objStatusIdParameter.DefaultValue = statusId.ToString();
			//objAgentIdParameter.DefaultValue = agentId.ToString();

            objectdatasourceList.SelectParameters.Clear();
			//objectdatasourceList.SelectParameters["status_id"] = objStatusIdParameter;
			//objectdatasourceList.SelectParameters["agent_id"] = objAgentIdParameter;
			Parameter p = new Parameter( "stamp_max_ms", DbType.Int32 );
			p.DefaultValue = ConfigurationManager.AppSettings[ "facility.status_stamp_max_ms" ];
			objectdatasourceList.SelectParameters[ "stamp_max_ms" ] = p;

			if( ucDataSourceSelectMethod == "GetFacilitiesByAgent" )
			{
				p = new Parameter( "agent_id", DbType.Int32 );
				p.DefaultValue = agentId.ToString();
				objectdatasourceList.SelectParameters[ "agent_id" ] = p;
			}

            //gvList.Sort(sortExpression, sortDirection);

            if (mvControl.ActiveViewIndex == 0)
                gvList.Sort(sortExpression, sortDirection);
            else if (mvControl.ActiveViewIndex == 1)
                profileControl.Refresh();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            profileControl.ReadOnly = this.readOnly;
        }

        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.NewEditIndex].Value;

            profileControl.FacilityId = _id;

            mvControl.ActiveViewIndex = 1;
            e.Cancel = true;
        }

        protected void lbFacility_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Int32 _id = Convert.ToInt32(lb.CommandArgument);

            UcControlArgs args = new UcControlArgs();
            args.Id = _id;
            this.open(sender, args);

            profileControl.FacilityId = _id;
            mvControl.ActiveViewIndex = 1;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mvControl.ActiveViewIndex = 1;
            profileControl.FacilityId = 0;
        }

        protected void sosFacility_ManageGroups(object sender, UcControlArgs e)
        {
            manageGroups(this, e);
        }

		int SetCommand( object sender, string command, string error )
		{
			int facility_id = Convert.ToInt32( ( sender as LinkButton ).CommandArgument );

			FacilityDS.FacilityDSDataTable dt = BllProxyFacility.SelectFacility( facility_id );
			if( dt.Rows.Count == 0 )
			{
				showErrorMessage( error );
				return 0;
			}

			int id = dt[ 0 ].agent_id;
			if( id != 0 && id != agent_id )
			{
				showErrorMessage( error );
				return 0;
			}

			BllProxyFacility.SetCommand( facility_id, agent_id, command );
			return facility_id;
		}

		protected void btn_call_Click( object sender, EventArgs e )
		{
			int facility_id = SetCommand( sender, "call", "Failed to call facility" );

			if( facility_id == 0 ) return;

			Response.Redirect( "CallQueue.aspx" );
		}

		protected void btn_release_Click( object sender, EventArgs e )
		{
			int facility_id = Convert.ToInt32( ( sender as LinkButton ).CommandArgument );

			FacilityDS.FacilityDSDataTable dt = BllProxyFacility.SelectFacility( facility_id );
			if( dt.Rows.Count == 0 || agent_id != dt[ 0 ].agent_id )
			{
				showErrorMessage( "Failed to release facility" );
				return;
			}

			BllProxyFacility.SetCommand( facility_id, 0, null );
		}
	}
}