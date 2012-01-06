using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.Base;
using System.Data;

namespace UCENTRIK.WEB.PLATFORM.App_Controls.BusinessControls
{
    public partial class Language : UcAppBaseOperationalControl
    {
        public event UcControlEventHandler ManageAgents;
        protected void manageAgents(object sender, UcControlArgs e)
        {
            if (ManageAgents != null)
                ManageAgents(this, e);
        }

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

        public Control UcHeaderControl
        {
            set
            {
                phControls.Controls.Add(value);
            }
        }

        public void UcDataBind(Int32 agentId)
        {
            this.agentId = agentId;

            Parameter objAgentIdParameter = new Parameter("agent_id", DbType.Int32);

            objAgentIdParameter.DefaultValue = agentId.ToString();

            objectdatasourceList.SelectParameters.Clear();
            objectdatasourceList.SelectParameters["agent_id"] = objAgentIdParameter;

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

            profileControl.LanguageId = _id;

            mvControl.ActiveViewIndex = 1;
            e.Cancel = true;
        }

        protected void lbLanguage_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Int32 _id = Convert.ToInt32(lb.CommandArgument);

            UcControlArgs args = new UcControlArgs();
            args.Id = _id;
            this.open(sender, args);

            profileControl.LanguageId = _id;
            mvControl.ActiveViewIndex = 1;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mvControl.ActiveViewIndex = 1;
            profileControl.LanguageId = 0;
        }

        protected void viewEdit_Back(object sender, UcControlArgs e)
        {
            mvControl.ActiveViewIndex = 0;
            this.UcDataBind(this.agentId);
            profileControl.ClearControlData();
        }
        protected void viewEdit_Save(object sender, UcControlArgs e)
        {
            if (e.IsNew)
            {
                this.showTextMessage("The profile has been created");
                this.profileControl.LanguageId = e.Id;
            }
            else
            {
                this.showTextMessage("The profile has been saved");
                mvControl.ActiveViewIndex = 0;
                gvList.DataBind();
                profileControl.ClearControlData();
            }
        }

        protected void Language_ManageAgents(object sender, UcControlArgs e)
        {
            manageAgents(this, e);
        }
    }
}