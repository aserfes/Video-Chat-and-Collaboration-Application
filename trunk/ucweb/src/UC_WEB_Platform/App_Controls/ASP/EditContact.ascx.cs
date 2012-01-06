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




namespace UCENTRIK.UserControls.ASP
{
    public partial class EditContact : UcAppBaseProfileDetailsControl
    {


        public Int32 ContactId
        {
            set
            {
                profileId = value;


                if (profileId == 0)
                {
                    dvControl.ChangeMode(DetailsViewMode.Insert);


                    chkbxAnonymous.Checked = true;
                }
                else
                {
                    if ((!this.readOnly) && (isContactChangeable))
                        dvControl.ChangeMode(DetailsViewMode.Edit);
                    else
                        dvControl.ChangeMode(DetailsViewMode.ReadOnly);


                    Parameter objAgentIdParameter = new Parameter("contact_id", DbType.Int32);
                    objAgentIdParameter.DefaultValue = profileId.ToString();

                    objectdatasourceEdit.SelectParameters["contact_id"] = objAgentIdParameter;

                    chkbxAnonymous.Checked = false;

                    dvControl.DataBind();
                }
            }
            get
            {
                if (IsAnonymous)
                    return 0;
                else
                    return profileId;
            }
        }






        public bool IsContactChangeable
        {
            set
            {
                isContactChangeable = value;
            }
        }
        protected bool isContactChangeable
        {
            get
            {
                bool _isContactChangeable = false;
                Object objViewStateIsContactChangeable = this.ViewState[this.ID + "IsContactChangeable"];
                if (objViewStateIsContactChangeable != null)
                    _isContactChangeable = Convert.ToBoolean(objViewStateIsContactChangeable);


                //return true;
                return _isContactChangeable;
            }
            set
            {
                this.ViewState.Remove(this.ID + "IsContactChangeable");
                this.ViewState.Add(this.ID + "IsContactChangeable", value);
            }
        }















        public bool ContactDefined
        {
            set
            {
                bool contactDefined = value;

                

                if (contactDefined)
                {
                    //this.isContactChangeable = false;

                    pnlAnonymous.Visible = false;
                    pnlFind.Visible = false;
                    pnlSearchResults.Visible = false;
                    pnlNotFound.Visible = false;

                    pnlContactDetails.Visible = true;
                    pnlAdd.Visible = false;
                }
                else
                {
                    pnlAnonymous.Visible = true;
                    pnlSearchResults.Visible = false;
                    pnlNotFound.Visible = false;
                    pnlContactDetails.Visible = false;


                    if ((!this.readOnly) && (isContactChangeable))
                    {
                        pnlFind.Visible = true;
                        pnlAdd.Visible = true;

                    }
                    else
                    {
                        pnlFind.Visible = false;
                        pnlAdd.Visible = false;
                    }


                    
                }

            }
        }



        public bool IsAnonymous
        {
            //set
            //{
            //    chkbxAnonymous.Checked = value;
            //}
            get
            {
                return chkbxAnonymous.Checked;
            }
        }









        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    pnlFind.Visible = isContactChangeable;
            //    pnlAdd.Visible = isContactChangeable;
            //    chkbxAnonymous.Enabled = isContactChangeable;
            //}
        }






        protected void dvControl_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            if (!this.Validate())
                e.Cancel = true;
        }

        protected void dvControl_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (!this.Validate())
                e.Cancel = true;
        }




        protected bool Validate()
        {
            TextBox txtFirstname = (TextBox)dvControl.Rows[1].FindControl("txtFirstname");
            TextBox txtLastname = (TextBox)dvControl.Rows[1].FindControl("txtLastname");
            TextBox txtEmail = (TextBox)dvControl.Rows[1].FindControl("txtEmail");
            TextBox txtPhone = (TextBox)dvControl.Rows[1].FindControl("txtPhone");


            String firstname = txtFirstname.Text;
            String lastname = txtLastname.Text;
            String email = txtEmail.Text;
            String phone = txtPhone.Text;


            if ((firstname != "") && (lastname != "") && (email != "") && (phone != ""))
                return true;
            else
                return false;

        }






        protected override void save()
        {
            this.dvControl.UpdateItem(true);
        }

        //=====================================================








        protected void btnFind_Click(object sender, EventArgs e)
        {
            ContactDS.ContactDSDataTable dt = BllProxyContact.GetContactsByPhoneNumber(txtPhoneNumber.Text);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    pnlSearchResults.Visible = true;
                    pnlNotFound.Visible = false;
                    pnlContactDetails.Visible = false;

                    rptContacts.DataSource = dt;
                    rptContacts.DataBind();
                }
                else
                {
                    this.ContactId = dt[0].contact_id;

                    pnlSearchResults.Visible = false;
                    pnlNotFound.Visible = false;
                    pnlContactDetails.Visible = true;
                }

            }
            else
            {
                this.ContactId = 0;

                pnlSearchResults.Visible = false;
                pnlNotFound.Visible = true;
                pnlContactDetails.Visible = false;
            }

            pnlAdd.Visible = true;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.ContactId = 0;
            chkbxAnonymous.Checked = false;

            pnlSearchResults.Visible = false;
            pnlNotFound.Visible = false;
            pnlContactDetails.Visible = true;
            pnlAdd.Visible = false;
        }




        protected void btnContact_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            this.ContactId = Convert.ToInt32(lb.CommandArgument);

            pnlSearchResults.Visible = false;
            pnlNotFound.Visible = false;
            pnlContactDetails.Visible = true;
            //pnlAdd.Visible = false;
        }







        public void Save()
        {
            if (!this.ReadOnly)
            {
                if (this.Page.IsValid)
                {
                    if (profileId == 0)
                    {
                        objectdatasourceEdit.InsertParameters.Add("user_id", "0");
                        objectdatasourceEdit.InsertParameters.Add("memo", "");
                        dvControl.InsertItem(true);
                    }
                    else
                    {
                        objectdatasourceEdit.UpdateParameters.Add("user_id", "0");
                        objectdatasourceEdit.UpdateParameters.Add("memo", "");
                        dvControl.UpdateItem(true);
                    }
                }
                else
                {
                    this.showErrorMessage("Not valid!");
                }
            }
        }




        public override void ClearControlData()
        {
            this.ContactId = 0;
            dvControl.ChangeMode(DetailsViewMode.ReadOnly);
        }



    }
}
