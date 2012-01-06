using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class FacilityGroup : UcAppBaseLiteControl
    {



        protected Int32 facilityId
        {
            get
            {
                Int32 _facilityId = 0;
                Object objViewStateFacilityId = this.ViewState[this.ID + "FacilityId"];
                if (objViewStateFacilityId != null)
                    _facilityId = Convert.ToInt32(objViewStateFacilityId);

                return _facilityId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "FacilityId");
                this.ViewState.Add(this.ID + "FacilityId", value);
            }
        }
        public Int32 FacilityId
        {
            set
            {
                facilityId = value;
                setFacility(facilityId);
            }
        }











        public void UcDataBind()
        {
            GroupDS.GroupFacilityDSDataTable dt = BllProxyGroupFacility.GetAllGroupFacilities(facilityId);

            if (dt.Rows.Count != 0)
            {
                objectdatasourceList.SelectParameters.Clear();
                objectdatasourceList.SelectParameters.Add("facility_id", facilityId.ToString());

                gvList.Sort(sortExpression, sortDirection);
            }
            else
            {
                this.showErrorMessage("Facility does not exist!");
            }
        }







        //---------------------------------------------------------------------------------
        protected void Page_Init(object sender, EventArgs e)
        {
        }





        protected void setFacility(Int32 _facilityId)
        {
            this.clearMessage();

            FacilityDS.FacilityDSDataTable dt = BllProxyFacility.SelectFacility(_facilityId);

            if (dt.Rows.Count > 0)
            {
                lblFacilityName.Text = dt[0].facility_name;

                setFacilityGroups(_facilityId);
            }
            else
            {
                lblFacilityName.Text = "ERROR: " + _facilityId.ToString();
            }
        }


        protected void setFacilityGroups(Int32 _facilityId)
        {
            this.UcDataBind();
        }











        //        ///---------------------------------------------------------------------------------
        protected void gvList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridView gv = (GridView)sender;

            GridViewRow row = e.Row;
            if (row.RowType == DataControlRowType.DataRow)
            {
                Int32 lastCell = row.Cells.Count - 1;
                foreach (Control cntrl in row.Cells[lastCell].Controls)
                {
                    LinkButton lb = cntrl as LinkButton;
                    if (lb != null)
                    {
                        DataKey key = gv.DataKeys[e.Row.RowIndex];
                        bool inGroup = (key[1] is DBNull);

                        if (lb.CommandName == "Edit")
                        {
                            lb.Enabled = inGroup;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to add the group?');");
                        }

                        if (lb.CommandName == "Delete")
                        {
                            lb.Enabled = !inGroup;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to remove the group?');");
                        }
                    }

                }
            }
        }











        ///---------------------------------------------------------------------------------
        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.NewEditIndex].Value;


            BllProxyGroupFacility.SetGroupFacility(_id, facilityId, true);

            setFacilityGroups(facilityId);
            this.showTextMessage("Group has been added");

            e.Cancel = true;
        }
        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.RowIndex].Value;

            BllProxyGroupFacility.SetGroupFacility(_id, facilityId, false);

            setFacilityGroups(facilityId);
            this.showTextMessage("Group has been removed");

            e.Cancel = true;
        }
        ///---------------------------------------------------------------------------------








        protected void btnBack_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            this.back(this, args);
        }

    }
}

