using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;

//using UcentrikWeb.BLL;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.DATASETS;
//using SOS_BLL.CODE;
using UcentrikWeb.CODE;



namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class UserProfile : UcBaseProfileDetailsControl
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






        ///---------------------------------------------------------------------------------
        ///---------------------------------------------------------------------------------
        protected void dvControl_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;
            DropDownList ddlUserRoles = (DropDownList)dv.FindControl("ddlUserRoles");

            HiddenField hf = (HiddenField)dv.FindControl("hfUserRoleId");

            ddlUserRoles.DataSource = BllProxyLookup.GetUserRoles();    // 3:Managers
            ddlUserRoles.DataBind();


            ListItem item = new ListItem("select user role", "");
            ddlUserRoles.Items.Insert(0, item);


            if (hf.Value != "")
                userRoleId = Convert.ToInt32(hf.Value);

            ListItem currentItem = ddlUserRoles.Items.FindByValue(userRoleId.ToString());

            if (currentItem != null)
                currentItem.Selected = true;
            else
                ddlUserRoles.Items.FindByValue("").Selected = true;

        }

        protected void dvControl_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            e.NewValues["user_role_id"] = userRoleId;
        } 








        protected void dvControl_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            String userName = e.Values["username"].ToString();

            //UserDS.UserDSDataTable dt = BllUser.GetUser(userName);
            UserDS.UserDSDataTable dt = BllProxyUser.GetUser(userName);

            e.Values.Add("user_role_id", userRoleId);

            if (dt.Rows.Count != 0)
            {
                this.showErrorMessage("ERROR!");

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
            userRoleId = Convert.ToInt32(ddl.SelectedValue);
        }




        public override void ClearControlData()
        {
            userRoleId = 0;
        }


    }
}

