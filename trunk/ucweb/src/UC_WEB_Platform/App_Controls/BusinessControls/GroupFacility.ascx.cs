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
    public partial class GroupFacility : UcAppBaseLiteControl
    {



        protected Int32 groupId
        {
            get
            {
                Int32 _groupId = 0;
                Object objViewStateGroupId = this.ViewState[this.ID + "GroupId"];
                if (objViewStateGroupId != null)
                    _groupId = Convert.ToInt32(objViewStateGroupId);

                return _groupId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "GroupId");
                this.ViewState.Add(this.ID + "GroupId", value);
            }
        }
        public Int32 GroupId
        {
            set
            {
                groupId = value;
                setGroup(groupId);
            }
        }











        public void UcDataBind()
        {
            GroupDS.GroupFacilityDSDataTable dt = BllProxyGroupFacility.GetAllGroupFacilities(groupId);

            if (dt.Rows.Count != 0)
            {
                //lblSurvey.Text = dt[0].survey_name;

                objectdatasourceList.SelectParameters.Clear();
                objectdatasourceList.SelectParameters.Add("group_id", groupId.ToString());

                gvList.Sort(sortExpression, sortDirection);
            }
            else
            {
                this.showErrorMessage("Group does not exist!");
            }
        }


        //protected void gvList_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    this.sortExpression = e.SortExpression;
        //    this.sortDirection = e.SortDirection;
        //}

















        //public Control UcHeaderControl
        //{
        //    set
        //    {
        //        phControls.Controls.Add(value);
        //    }
        //}








        //---------------------------------------------------------------------------------
        protected void Page_Init(object sender, EventArgs e)
        {
        }





        protected void setGroup(Int32 _groupId)
        {
            this.clearMessage();

            GroupDS.GroupDSDataTable dt = BllProxyGroup.SelectGroup(_groupId);

            if (dt.Rows.Count > 0)
            {
                lblGroupName.Text = dt[0].group_name;

                setGroupFacilities(_groupId);
            }
            else
            {
                lblGroupName.Text = "ERROR: " + groupId.ToString();
            }
        }


        protected void setGroupFacilities(Int32 _groupId)
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
                            lb.Attributes.Add("onclick", "return confirm('Do you want to add the facility?');");
                        }

                        if (lb.CommandName == "Delete")
                        {
                            lb.Enabled = !inGroup;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to remove the facility?');");
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


            BllProxyGroupFacility.SetGroupFacility(groupId, _id, true);

            setGroupFacilities(groupId);
            this.showTextMessage("Facility has been added");

            e.Cancel = true;
        }
        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.RowIndex].Value;

            BllProxyGroupFacility.SetGroupFacility(groupId, _id, false);

            setGroupFacilities(groupId);
            this.showTextMessage("Facility has been removed");

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

