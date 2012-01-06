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
    public partial class Contact : UcAppBaseOperationalControl
    {






        public Control UcHeaderControl
        {
            set
            {
                phControls.Controls.Add(value);
            }
        }




        public void UcDataBind()
        {
            //Parameter objStatusIdParameter = new Parameter("contact_role_id", DbType.Int32);
            //objStatusIdParameter.DefaultValue = contactRoleId.ToString();

            //objectdatasourceList.SelectParameters.Clear();
            //objectdatasourceList.SelectParameters["contact_role_id"] = objStatusIdParameter;

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

            profileControl.ContactId = _id;

            mvControl.ActiveViewIndex = 1;
            e.Cancel = true;
        }

        ///---------------------------------------------------------------------------------

        ///---------------------------------------------------------------------------------
        protected void lbContact_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Int32 _id = Convert.ToInt32(lb.CommandArgument);

            UcControlArgs args = new UcControlArgs();
            args.Id = _id;
            //this.open(sender, args);
            
            profileControl.ContactId = _id;
            mvControl.ActiveViewIndex = 1;
        }













        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mvControl.ActiveViewIndex = 1;
            profileControl.ContactId = 0;
        }













        /////---------------------------------------------------------------------------------
    }
}