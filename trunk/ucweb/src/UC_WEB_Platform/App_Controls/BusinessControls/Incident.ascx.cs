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





namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class Incident : UcAppBaseOperationalControl
    {



        public bool AllowConference
        {
            set
            {
                profileControl.AllowConference = value;
            }
        }




        public Control UcHeaderControl
        {
            set
            {
                phControls.Controls.Add(value);
            }
        }



        public void UcDataBind(Int32 statusId, Int32 agentId)
        {
            
            Parameter objStatusIdParameter = new Parameter("status_id", DbType.Int32);
            Parameter objAgentIdParameter = new Parameter("agent_id", DbType.Int32);
            objStatusIdParameter.DefaultValue = statusId.ToString();
            objAgentIdParameter.DefaultValue = agentId.ToString();

            objectdatasourceList.SelectParameters.Clear();
            objectdatasourceList.SelectParameters["status_id"] = objStatusIdParameter;
            objectdatasourceList.SelectParameters["agent_id"] = objAgentIdParameter;

            gvList.Sort(sortExpression, sortDirection);
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

            profileControl.IncidentId = _id;

            mvControl.ActiveViewIndex = 1;
            e.Cancel = true;
        }

        ///---------------------------------------------------------------------------------


        ///---------------------------------------------------------------------------------
        protected void lbIncident_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Int32 _id = Convert.ToInt32(lb.CommandArgument);

            UcControlArgs args = new UcControlArgs();
            args.Id = _id;
            this.open(sender, args);

            if (!args.Cancel)
            {
                profileControl.IncidentId = _id;

                //showVideo(_id);

                mvControl.ActiveViewIndex = 1;
            }
            else
            {
                this.showTextMessage(args.Message);
            }
        }

























        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //ltTest.Text = "NEW";
            //mvIncident.ActiveViewIndex = 1;
            //DetailsView1.ChangeMode(DetailsViewMode.Insert);

            //_id = 0;

            //objectdatasourceEdit.SelectParameters.Clear();
            //objectdatasourceEdit.SelectParameters.Add("incident_id", _id.ToString());
        }











        
        ///---------------------------------------------------------------------------------
        protected void lbIncident_PreRender(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            if (lb.CommandName == "")
            {
                //lb.CommandName = "PUBLIC";
                lb.Text = "PUBLIC";
                lb.CssClass = "AltText";
            }
            else
            {
                lb.Text = lb.CommandName;
            }



        }
        
        /////---------------------------------------------------------------------------------






        protected string showIcon(object obj)
        {
            string s = "";
            //Int32 id = Convert.ToInt32(obj);

            if (obj != DBNull.Value)
                s = "<img src='../images/lock.png'>";

            return s;
        }





        //---
    }
}