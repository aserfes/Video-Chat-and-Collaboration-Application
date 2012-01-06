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
    public partial class User : UcAppBaseOperationalControl
    {



        


        public Control UcHeaderControl
        {
            set
            {
                phControls.Controls.Add(value);
            }
        }




        public void UcDataBind(Int32 userRoleId)
        {
            objectdatasourceList.SelectParameters.Clear();

            Parameter objStatusIdParameter = new Parameter("user_role_id", DbType.Int32);
            objStatusIdParameter.DefaultValue = userRoleId.ToString();
            objectdatasourceList.SelectParameters["user_role_id"] = objStatusIdParameter;

            objStatusIdParameter = new Parameter("login_user_role_id", DbType.Int32);
            UcBasePage page = this.Page as UcBasePage;
            if (page != null)
            {
                objStatusIdParameter.DefaultValue = page.UserRoleId.ToString();
                objectdatasourceList.SelectParameters["login_user_role_id"] = objStatusIdParameter;
            }

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

            profileControl.UserId = _id;

            mvControl.ActiveViewIndex = 1;
            e.Cancel = true;
        }

        ///---------------------------------------------------------------------------------


        ///---------------------------------------------------------------------------------
        protected void lbUser_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Int32 _id = Convert.ToInt32(lb.CommandArgument);

            UcControlArgs args = new UcControlArgs();
            args.Id = _id;
            this.open(sender, args);

            profileControl.UserId = _id;
            mvControl.ActiveViewIndex = 1;
        }






        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mvControl.ActiveViewIndex = 1;
            profileControl.UserId = 0;
        }













        /////---------------------------------------------------------------------------------
    }
}