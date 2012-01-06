using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;


namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class GroupProfile : UcAppBaseProfileDetailsControl
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






        public Int32 GroupId
        {
            set
            {
                profileId = value;


                if (profileId == 0)
                {
                    dvControl.ChangeMode(DetailsViewMode.Insert);
                }
                else
                {
                    dvControl.ChangeMode(dvMode);

                    Parameter objGroupIdParameter = new Parameter("group_id", DbType.Int32);
                    objGroupIdParameter.DefaultValue = profileId.ToString();

                    objectdatasourceEdit.SelectParameters["group_id"] = objGroupIdParameter;
                }
            }
        }



        ///---------------------------------------------------------------------------------
        ///---------------------------------------------------------------------------------
        protected void dvControl_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;

            //if (this.ReadOnly)
            //{
            //    dv.Rows[2].Visible = false;
            //}

            if (this.AllowManagement)
            {
                Control cntrl;
                LinkButton lb;

                cntrl = dv.Rows[3].FindControl("lbManageAgents");
                lb = cntrl as LinkButton;
                if (lb != null)
                    lb.Visible = true;

                cntrl = dv.Rows[3].FindControl("lbManageFacilities");
                lb = cntrl as LinkButton;
                if (lb != null)
                    lb.Visible = true;
            }
        }


















        protected override void save()
        {
            try
            {
                if (profileId == 0)
                {
                    this.dvControl.InsertItem(true);
                }
                else
                {
                    this.dvControl.UpdateItem(true);
                }
            }
            catch
            {
                this.showErrorMessage("Profile cannot be saved!");
            }


        }




        
            
        protected void lbManageAgents_Click(object sender, EventArgs e)
        {
            //LinkButton lb = (LinkButton)sender;

            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;

            manageAgents(this, args);
        }

        protected void lbManageFacilities_Click(object sender, EventArgs e)
        {
            //LinkButton lb = (LinkButton)sender;

            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;

            manageFacilities(this, args);
        }











        public override void ClearControlData()
        {
            TextBox txtGroupName = dvControl.FindControl("txtGroupName") as TextBox;

            if (txtGroupName != null)
                txtGroupName.Text = "";
        }



        //---
    }
}

