using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class Agent : UcAppBaseOperationalControl
    {
//        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler ManageGroups;
        protected void manageGroups(object sender, UcControlArgs e)
        {
            if (ManageGroups != null)
                ManageGroups(this, e);
        }

        public event UcControlEventHandler ManageSkills;
        protected void manageSkills(object sender, UcControlArgs e)
        {
            if (ManageSkills != null)
                ManageSkills(this, e);
        }

        public event UcControlEventHandler ManageLanguages;
        protected void manageLanguages(object sender, UcControlArgs e)
        {
            if (ManageLanguages != null)
                ManageLanguages(this, e);
        }
//        ///---------------------------------------------------------------------------------

        public Control UcHeaderControl
        {
            set
            {
                phControls.Controls.Add(value);
            }
        }

        public void UcDataBind()
        {
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

            profileControl.AgentId = _id;

            mvControl.ActiveViewIndex = 1;
            e.Cancel = true;
        }

        ///---------------------------------------------------------------------------------


        ///---------------------------------------------------------------------------------
        protected void lbAgent_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Int32 _id = Convert.ToInt32(lb.CommandArgument);

            UcControlArgs args = new UcControlArgs();
            args.Id = _id;
            this.open(sender, args);

            profileControl.AgentId = _id;
            mvControl.ActiveViewIndex = 1;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //ltTest.Text = "NEW";
            //mvAgent.ActiveViewIndex = 1;
            //DetailsView1.ChangeMode(DetailsViewMode.Insert);

            //_id = 0;

            //objectdatasourceEdit.SelectParameters.Clear();
            //objectdatasourceEdit.SelectParameters.Add("agent_id", _id.ToString());


            mvControl.ActiveViewIndex = 1;
            profileControl.AgentId = 0;
        }

        protected void sosAgent_ManageGroups(object sender, UcControlArgs e)
        {
            manageGroups(this, e);
        }

        protected void sosAgent_ManageSkills(object sender, UcControlArgs e)
        {
            manageSkills(this, e);
        }

        protected void sosAgent_ManageLanguages(object sender, UcControlArgs e)
        {
            manageLanguages(this, e);
        }

        /////---------------------------------------------------------------------------------
    }
}