using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.DATASETS;
using UcentrikWeb.CODE;
using UCENTRIK.AppSettings;
using UCENTRIK.Membership;


namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class UserProfile : UcAppBaseProfileDetailsControl
    {



        protected Int32 userRoleId
        {
            get
            {
                Int32 _userRoleId = 0;
                Object objViewStateStatusId = this.ViewState[this.ID + "UserRoleId"];
                if (objViewStateStatusId != null)
                    _userRoleId = Convert.ToInt32(objViewStateStatusId);

                return _userRoleId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "UserRoleId");
                this.ViewState.Add(this.ID + "UserRoleId", value);
            }
        }




        
        public Int32 UserId
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
                    //dvControl.ChangeMode(DetailsViewMode.Edit);
                    dvControl.ChangeMode(dvMode);

                    Parameter objAgentIdParameter = new Parameter("user_id", DbType.Int32);
                    objAgentIdParameter.DefaultValue = profileId.ToString();

                    objectdatasourceEdit.SelectParameters["user_id"] = objAgentIdParameter;
                }
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




        ///---------------------------------------------------------------------------------
        ///---------------------------------------------------------------------------------
        protected void dvControl_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;
            DropDownList ddlUserRoles = (DropDownList)dv.FindControl("ddlUserRoles");

            HiddenField hfUserRoleId = (HiddenField)dv.FindControl("hfUserRoleId");

            UcBasePage page = Page as UcBasePage;

            ddlUserRoles.DataSource = BllProxyLookup.GetUserRoles(page.UserRoleId);
            ddlUserRoles.DataBind();

            ListItem itemSelectUserRole = new ListItem("select user role", "");
            ddlUserRoles.Items.Insert(0, itemSelectUserRole);


            if (hfUserRoleId.Value != "")
                userRoleId = Convert.ToInt32(hfUserRoleId.Value);

            ListItem currentItemUserRole = ddlUserRoles.Items.FindByValue(userRoleId.ToString());

            if (currentItemUserRole != null)
                currentItemUserRole.Selected = true;
            else
                ddlUserRoles.Items.FindByValue("").Selected = true;







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






            if (this.profileId == 0)
                timeZone = UcDefaults.UcDefaultTimeZone;
            else
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
            e.NewValues["user_role_id"] = userRoleId;
            e.NewValues["time_zone"] = timeZone;

            String userName = e.OldValues["username"].ToString();

            UserPool userPool = (UserPool)Application["UserPool"];
            userPool.RemoveUser(userName);


            if (userName == this.UcAppPage.UserName)
            {
                FormsAuthentication.SignOut();
                this.Refresh();
            }
        } 








        protected void dvControl_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            String userName = e.Values["username"].ToString();

            //UserDS.UserDSDataTable dt = BllUser.GetUser(userName);
            UserDS.UserDSDataTable dt = BllProxyUser.GetUser(userName);

            e.Values.Add("user_role_id", userRoleId);
            e.Values.Add("time_zone", timeZone);


            if (dt.Rows.Count != 0)
            {
                this.showErrorMessage("User with the same username already exists!");

                e.Cancel = true;
            }
        }







        protected override void save()
        {
            try
            {
                if (profileId == 0)
                    this.dvControl.InsertItem(true);
                else
                    this.dvControl.UpdateItem(true);



            }
            catch
            {
                lblMessage.Text = "Cannot save the user's data";
            }
        }






        protected void ddlUserRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            if(ddl.SelectedValue != "")
                userRoleId = Convert.ToInt32(ddl.SelectedValue);
        }




        public override void ClearControlData()
        {
            userRoleId = 0;

            string[] ssTxt = new string[] {
                "txtUsername",
                "txtFirstname",
                "txtLastname",
                "txtPassword"
            };

            foreach (string s in ssTxt)
            {
                TextBox txt = dvControl.FindControl(s) as TextBox;
                if (txt != null)
                    txt.Text = "";
            }



            DropDownList ddlUserRoles = dvControl.FindControl("ddlUserRoles") as DropDownList;
            if (ddlUserRoles != null)
                ddlUserRoles.SelectedIndex = 0;



        }






        protected void ddlTimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            timeZone = Convert.ToString(ddl.SelectedValue);
        }





    }
}

