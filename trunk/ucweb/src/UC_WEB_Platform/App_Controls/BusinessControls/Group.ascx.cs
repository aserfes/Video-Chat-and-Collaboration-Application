using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;


using System.Runtime.Serialization;
using System.Text;


namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class Group : UcAppBaseOperationalControl
    {



//        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler ManageAgents;
        protected void manageAgents(object sender, UcControlArgs e)
        {
            if (ManageAgents != null)
                ManageAgents(this, e);
        }
        public event UcControlEventHandler ManageFacilities;
        protected void manageFacilities(object sender, UcControlArgs e)
        {
            if (ManageFacilities != null)
                ManageFacilities(this, e);
        }
//        ///---------------------------------------------------------------------------------












        ///---------------------------------------------------------------------------------
        protected Int32 agentId
        {
            get
            {
                Int32 _agentId = 0;
                Object objViewStateAgentId = this.ViewState[this.ID + "AgentId"];
                if (objViewStateAgentId != null)
                    _agentId = Convert.ToInt32(objViewStateAgentId);

                return _agentId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "AgentId");
                this.ViewState.Add(this.ID + "AgentId", value);
            }
        }

        protected Int32 facilityId
        {
            get
            {
                Int32 _facilityId = 0;
                Object objViewStateFacilityId = this.ViewState[this.ID + "FacilityId"];
                if (objViewStateFacilityId != null)
                    _facilityId = Convert.ToInt32(objViewStateFacilityId);

                return _facilityId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "FacilityId");
                this.ViewState.Add(this.ID + "FacilityId", value);
            }
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

        public void UcDataBind(Int32 agentId, Int32 facilityId)
        {
            this.agentId = agentId;
            this.facilityId = facilityId;

            Parameter objAgentIdParameter = new Parameter("agent_id", DbType.Int32);
            Parameter objFacilityIdParameter = new Parameter("facility_id", DbType.Int32);
            
            objAgentIdParameter.DefaultValue = agentId.ToString();
            objFacilityIdParameter.DefaultValue = facilityId.ToString();

            objectdatasourceList.SelectParameters.Clear();
            objectdatasourceList.SelectParameters["agent_id"] = objAgentIdParameter;
            objectdatasourceList.SelectParameters["facility_id"] = objFacilityIdParameter;

            //gvList.Sort(sortExpression, sortDirection);

            if (mvControl.ActiveViewIndex == 0)
                gvList.Sort(sortExpression, sortDirection);
            else if (mvControl.ActiveViewIndex == 1)
                profileControl.Refresh();

        }






        //---------------------------------------------------------------------------------
        protected void Page_Init(object sender, EventArgs e)
        {
            profileControl.ReadOnly = this.readOnly;
        }






        ///---------------------------------------------------------------------------------
        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.NewEditIndex].Value;

            profileControl.GroupId = _id;

            mvControl.ActiveViewIndex = 1;
            e.Cancel = true;
        }

        ///---------------------------------------------------------------------------------


        ///---------------------------------------------------------------------------------
        protected void lbGroup_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Int32 _id = Convert.ToInt32(lb.CommandArgument);

            UcControlArgs args = new UcControlArgs();
            args.Id = _id;
            this.open(sender, args);

            profileControl.GroupId = _id;
            mvControl.ActiveViewIndex = 1;
        }







        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mvControl.ActiveViewIndex = 1;
            profileControl.GroupId = 0;
        }


















        //---------------------------------------------------------------------------------
        protected void viewEdit_Back(object sender, UcControlArgs e)
        {
            mvControl.ActiveViewIndex = 0;
            this.UcDataBind(this.agentId, this.facilityId);
            profileControl.ClearControlData();
        }
        protected void viewEdit_Save(object sender, UcControlArgs e)
        {
            if (e.IsNew)
            {
                this.showTextMessage("The profile has been created");
                this.profileControl.GroupId = e.Id;
            }
            else
            {
                this.showTextMessage("The profile has been saved");
                mvControl.ActiveViewIndex = 0;
                gvList.DataBind();
                profileControl.ClearControlData();
            }
        }







        protected void sosGroup_ManageAgents(object sender, UcControlArgs e)
        {
            manageAgents(this, e);
        }
        protected void sosGroup_ManageFacilities(object sender, UcControlArgs e)
        {
            manageFacilities(this, e);
        }
        







        /////---------------------------------------------------------------------------------
    }
}