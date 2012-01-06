using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;

using UCENTRIK.LIB.BllProxy;
using UCENTRIK.DATASETS;
using UcentrikWeb.CODE;

using UCENTRIK.Membership;
using UCENTRIK.Base;



namespace UCENTRIK.WEB.LIB.App_Controls.CommonControls
{
    public partial class UserAccount : UcBaseProfileDetailsControl
    {


        protected bool _showFirstAndLastName = false;
        public bool ShowFirstAndLastName
        {
            set
            {
                _showFirstAndLastName = value;
            }
        }






        protected string timeZone
        {
            get
            {
                string _timeZone = "";
                Object objViewStateStatusId = this.ViewState[this.ID + "TimeZone"];
                if (objViewStateStatusId != null)
                    _timeZone = Convert.ToString(objViewStateStatusId);

                return _timeZone;
            }
            set
            {
                this.ViewState.Remove(this.ID + "TimeZone");
                this.ViewState.Add(this.ID + "TimeZone", value);
            }
        }





        protected void Page_Init(object sender, EventArgs e)
        {
            this.profileId = this.UcPage.UserId;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.profileId == 0)
            {
                dvControl.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dvControl.ChangeMode(dvMode);

                Parameter objAgentIdParameter = new Parameter("user_id", DbType.Int32);
                objAgentIdParameter.DefaultValue = this.profileId.ToString();

                objectdatasourceEdit.SelectParameters["user_id"] = objAgentIdParameter;
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
        }













        ///---------------------------------------------------------------------------------
        ///---------------------------------------------------------------------------------
        protected void dvControl_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;

            //------------------------------
            dv.Rows[4].Visible = this._showFirstAndLastName; // First name
            dv.Rows[5].Visible = this._showFirstAndLastName; // Last name
            //------------------------------







            TextBox txtNewPassword = (TextBox)dv.FindControl("txtNewPassword");
            txtNewPassword.Attributes.Add("value", txtNewPassword.Text);
            TextBox txtConfirmPassword = (TextBox)dv.FindControl("txtConfirmPassword");
            txtConfirmPassword.Attributes.Add("value", txtConfirmPassword.Text);






            //-----------------------------------------------------------------------------------
            DropDownList ddlTimeZone = (DropDownList)dv.FindControl("ddlTimeZone");
            HiddenField hfTimeZone = (HiddenField)dv.FindControl("hfTimeZone");

            ListItem emptyItem = new ListItem("select time zone", "");
            ddlTimeZone.Items.Insert(0, emptyItem);

            List<TimeZoneInfo> timeZones = new List<TimeZoneInfo>(TimeZoneInfo.GetSystemTimeZones());
            timeZones.Sort
            (
                delegate(TimeZoneInfo left, TimeZoneInfo right)
                {
                    int comparison = left.BaseUtcOffset.CompareTo(right.BaseUtcOffset);
                    return comparison == 0 ? string.CompareOrdinal(left.DisplayName, right.DisplayName) : comparison;
                }
            );

            foreach (TimeZoneInfo zone in timeZones)
            {
                ListItem itemTimeZone = new ListItem(zone.DisplayName, zone.StandardName);
                ddlTimeZone.Items.Add(itemTimeZone);
            }






            timeZone = Convert.ToString(hfTimeZone.Value);
            ListItem currentItemTimeZone = ddlTimeZone.Items.FindByValue(timeZone);
            if (currentItemTimeZone != null)
                currentItemTimeZone.Selected = true;
            else
                ddlTimeZone.Items.FindByValue("").Selected = true;

            //-----------------------------------------------------------------------------------






        }


        protected void dvControl_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            DetailsView dv = (DetailsView)sender;


            //-------------------------------------------------------------------------
            e.NewValues["time_zone"] = timeZone;



            //-------------------------------------------------------------------------
            TextBox txtNewPassword = (TextBox)dv.FindControl("txtNewPassword");
            TextBox txtConfirmPassword = (TextBox)dv.FindControl("txtConfirmPassword");



            if (txtNewPassword.Text.CompareTo(txtConfirmPassword.Text) == 0)
            {
                e.NewValues["password"] = txtNewPassword.Text;
            }
            else
            {
                this.showErrorMessage("Passwords do not match, please retype!");
                e.Cancel = true;
            }



            if (e.Cancel)
            {
                e.NewValues["password"] = e.OldValues["password"];
            }

        }




        protected void dvControl_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            this.showTextMessage("User account has been saved.");
        }












        protected override void save()
        {
            try
            {
                if (this.profileId != 0)
                    this.dvControl.UpdateItem(true);

                UserPool _userPool = (UserPool)this.Context.Application["UserPool"];
                if (_userPool != null)
                    //_userPool.SetUserTimeZone(this.UcPage.UserName, this.timeZone);
                    _userPool.ReloadUserData(this.UcPage.UserName);

            }
            catch //(Exception ex)
            {
                this.showErrorMessage("Cannot save the data!");
                //this.showErrorMessage(ex.Message);
            }
        }

















        protected void ddlTimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            timeZone = Convert.ToString(ddl.SelectedValue);
        }



        //public override void ClearControlData()
        //{
        //    //timeZone = 0;
        //}


    }
}

