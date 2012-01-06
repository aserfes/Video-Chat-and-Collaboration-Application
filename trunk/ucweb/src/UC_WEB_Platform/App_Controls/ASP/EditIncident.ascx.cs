using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UCENTRIK.UserControls.ASP
{
    public partial class EditIncident : UcAppBaseProfileDetailsControl
    {



        public Int32 IncidentId
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
                    profileId = value;

                    if ((!this.readOnly) && (isStatusChangeable))
                        dvControl.ChangeMode(DetailsViewMode.Edit);
                    else
                        dvControl.ChangeMode(DetailsViewMode.ReadOnly);

                    Parameter objIncidentIdParameter = new Parameter("incident_id", DbType.Int32);
                    objIncidentIdParameter.DefaultValue = profileId.ToString();
                    objectdatasourceEdit.SelectParameters["incident_id"] = objIncidentIdParameter;

                    dvControl.DataBind();
                }
            }
        }


        public bool IsStatusChangeable
        {
            set
            {
                isStatusChangeable = value;
            }
        }
        protected bool isStatusChangeable
        {
            get
            {
                bool _isStatusChangeable = false;
                Object objViewStateIsStatusChangeable = this.ViewState[this.ID + "IsStatusChangeable"];
                if (objViewStateIsStatusChangeable != null)
                    _isStatusChangeable = Convert.ToBoolean(objViewStateIsStatusChangeable);

                return _isStatusChangeable;
                //return true;
            }
            set
            {
                this.ViewState.Remove(this.ID + "IsStatusChangeable");
                this.ViewState.Add(this.ID + "IsStatusChangeable", value);
            }
        }

        public void SetCloseStatus()
        {
            Control datafield = dvControl.Rows[0].Controls[1];
            RadioButtonList rbl = (RadioButtonList)datafield.FindControl("rblStatus");
            rbl.SelectedIndex = 3;
            statusId = Convert.ToInt32(rbl.SelectedValue);
        }

        protected override void save()
        {
            this.dvControl.UpdateItem(true);
        }

        //============================================================================================
        //============================================================================================
        //============================================================================================

        public Int32 ContactId
        {
            get
            {
                Int32 _contactId = 0;

                Control datafield = dvControl.Rows[0].Controls[1];
                HiddenField hf = (HiddenField)datafield.FindControl("hfContactBId");

                if (hf.Value != "")
                    _contactId = Convert.ToInt32(hf.Value);

                return _contactId;
            }
        }









        ///---------------------------------------------------------------------------------
        ///---------------------------------------------------------------------------------



        protected void rblStatus_PreRender(object sender, EventArgs e)
        {
            RadioButtonList rbl = (RadioButtonList)sender;
            rbl.Items.FindByValue("1").Enabled = false;     // 1: New incident

            //foreach (ListItem item in rbl.Items)
            //{
            //    if (item.Value == "1")  // New incident
            //    {
            //        item.Enabled = false;
            //        break;
            //    }
            //}
        }



        protected void rblStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rbl = (RadioButtonList)sender;
            statusId = Convert.ToInt32(rbl.SelectedValue);
        }











        ///---------------------------------------------------------------------------------
        ///---------------------------------------------------------------------------------
        protected void dvControl_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;

            Control datafield = dv.Rows[0].Controls[1];
            HiddenField hf1 = (HiddenField)datafield.FindControl("hfStatusId");
            HiddenField hf2 = (HiddenField)datafield.FindControl("hfContactBId");

            RadioButtonList rbl = (RadioButtonList)datafield.FindControl("rblStatus");

            rbl.DataSource = BllProxyLookup.GetIncidentStatuses();
            rbl.DataBind();

            statusId = Convert.ToInt32(hf1.Value);

            if (statusId != 0)
                rbl.Items.FindByValue(statusId.ToString()).Selected = true;




            dv.Rows[4].Visible = !this.isStatusChangeable;  // Status Text
            dv.Rows[5].Visible = this.isStatusChangeable;   // Status Radio buttons
        }


        protected void dvControl_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            e.NewValues["status_id"] = statusId;

            if (e.Keys["agent_id"] == DBNull.Value)
                e.Keys["agent_id"] = 0;
        }






        ///---------------------------------------------------------------------------------
        ///---------------------------------------------------------------------------------
        public void Save(Int32 contactId)
        {
            //dvControl.ChangeMode(DetailsViewMode.Edit);


            if (profileId == 0)
            {
                //objectdatasourceEdit.InsertParameters.Add("contact_id", contactId.ToString());

                //dvIncident.InsertItem(true);
            }
            else
            {
                objectdatasourceEdit.UpdateParameters.Add("contact_id", contactId.ToString());

                dvControl.UpdateItem(true);
            }
        }

















    }
}



