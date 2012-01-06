using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

using UCENTRIK.LIB.CoreSystem;

namespace UCENTRIK.LIB.Base
{

    
    
    public class UcAppBaseLiteControl : UcAppBaseControl
    {


        ObjectDataSource objectdatasourceList;
        GridView gvList;
        Label lblMessage;
        Label lblCount;



        //        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler BackToList;
        protected void back(object sender, UcControlArgs e)
        {
            if (BackToList != null)
                BackToList(this, e);
        }
        //        ///---------------------------------------------------------------------------------





        public UcAppBaseLiteControl()
        {
        }





        private bool _allowSort = true;
        public bool AllowSort
        {
            set
            {
                _allowSort = value;
            }
        }


        
        
        protected string ucDataSourceSelectMethod;




        //protected string sortExpression = "";
        //public string SortExpression
        //{
        //    set
        //    {
        //        sortExpression = value;
        //    }
        //}

        //protected SortDirection sortDirection = SortDirection.Ascending;
        //public SortDirection SortDirection
        //{
        //    set
        //    {
        //        sortDirection = value;
        //    }
        //}




        protected string sortExpression
        {
            get
            {
                string _sortExpression = "";
                Object objViewStateSortExpression = this.ViewState[this.ID + "SortExpression"];
                if (objViewStateSortExpression != null)
                    _sortExpression = Convert.ToString(objViewStateSortExpression);

                return _sortExpression;
            }
            set
            {
                this.ViewState.Remove(this.ID + "SortExpression");
                this.ViewState.Add(this.ID + "SortExpression", value);
            }
        }
        public string SortExpression
        {
            set
            {
                sortExpression = value;
            }
        }

        protected SortDirection sortDirection
        {
            get
            {
                SortDirection _sortDirection = SortDirection.Ascending;
                Object objViewStateSortDirection = this.ViewState[this.ID + "SortDirection"];
                if (objViewStateSortDirection != null)
                    _sortDirection = (SortDirection)objViewStateSortDirection;

                return _sortDirection;
            }
            set
            {
                this.ViewState.Remove(this.ID + "SortDirection");
                this.ViewState.Add(this.ID + "SortDirection", value);
            }
        }

        public SortDirection SortDirection
        {
            set
            {
                sortDirection = value;
            }
        }












        public string UcDataSourceSelectMethod
        {
            set
            {
                ucDataSourceSelectMethod = value;
            }
        }









        protected override void OnInit(EventArgs e)
        {
            objectdatasourceList = (ObjectDataSource)this.FindControl("objectdatasourceList");
            gvList = (GridView)this.FindControl("gvList");
            lblMessage = (Label)this.FindControl("lblMessage");
            lblCount = (Label)this.FindControl("lblCount");

            objectdatasourceList.SelectMethod = ucDataSourceSelectMethod;

            gvList.DataSourceID = "objectdatasourceList";
            gvList.AutoGenerateColumns = false;

            gvList.AllowSorting = _allowSort;
            gvList.AllowPaging = true;
            gvList.EmptyDataText = "No records found";

            gvList.CssClass = "GridView";
            gvList.HeaderStyle.CssClass = "GridViewHeader";
            gvList.PagerStyle.CssClass = "GridViewPager";

            gvList.CellPadding = 5;
            gvList.EnableSortingAndPagingCallbacks = false;
            gvList.Width = Unit.Percentage(100);
            gvList.PageSize = UCENTRIK.AppSettings.UcConfParameters.UcGridViewPageRows;

            //gvList.RowCreated += GridView_RowCreated;
            gvList.RowDataBound += GridView_RowDataBound;
            //gvList.RowDeleting += GridView_RowDeleting;
            //gvList.RowDeleted += GridView_RowDeleted;
            gvList.Sorting += GridView_Sorting;






            //-------------------
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {

            //-------------------
            base.OnLoad(e);
        }
        protected override void OnPreRender(EventArgs e)
        {

            //-------------------
            base.OnPreRender(e);
        }









        //        ///---------------------------------------------------------------------------------
        protected void showTextMessage(string message)
        {
            lblMessage.CssClass = "TextMessage";
            lblMessage.Text = message;
        }
        protected void showErrorMessage(string message)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = message;
        }
        protected void clearMessage()
        {
            lblMessage.Text = "";
        }











        //        ///---------------------------------------------------------------------------------
        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //GridView gv = (GridView)sender;

            //GridViewRow row = e.Row;
            //if (row.RowType == DataControlRowType.DataRow)
            //{
            //    Int32 lastCell = row.Cells.Count - 1;
            //    if (_allowDelete)
            //    {
            //        foreach (Control cntrl in row.Cells[lastCell].Controls)
            //        {
            //            LinkButton lb = cntrl as LinkButton;
            //            if (lb != null)
            //                if (lb.CommandName == "Delete")
            //                    lb.Attributes.Add("onclick", "return confirm('Do you want to delete this record?');");
            //        }
            //    }
            //}
        }


        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView gv = (GridView)sender;

            if (e.Row.RowType == DataControlRowType.Header)
            {
                string sd = gv.SortDirection.ToString();
                string se = gv.SortExpression.ToString();

                TableCell cellSort = null;
                foreach (TableCell cell in e.Row.Cells)
                {
                    cellSort = null;

                    foreach (Control c in cell.Controls)
                    {
                        if (c is LinkButton)
                        {
                            LinkButton lb = (LinkButton)c;
                            if (lb.CommandArgument == se)
                            {
                                cellSort = cell;
                            }
                        }
                    }

                    if (cellSort != null)
                    {
                        Image ImgSort = new Image();

                        if (sd == "Ascending")
                            ImgSort.ImageUrl = this.getThemeImage("asc.png");
                        else
                            ImgSort.ImageUrl = this.getThemeImage("desc.png");

                        cellSort.Controls.Add(ImgSort);
                    }


                }
            }
        }


        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (!this.isApprovedToModify)
                e.Cancel = true;
        }


        protected void GridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            this.showTextMessage("The profile has been deleted");
        }


        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.sortExpression = e.SortExpression;
            this.sortDirection = e.SortDirection;
        }














        //        ///---------------------------------------------------------------------------------
        protected void dataSelected(object source, ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue != null)
            {
                Int32 cnt = ((DataTable)e.ReturnValue).Rows.Count;
//                lblCount.Text = cnt.ToString();
            }
        }















        //        ///---------------------------------------------------------------------------------
        protected void view_Back(object sender, UcControlArgs e)
        {
            gvList.DataBind();

            back(this, e);
        }








        protected string getThemeImage(string imageName)
        {
            string rootPath = AppHelper.GetApplicationPath("~");
            string themePath = this.Page.Theme;
            string path = rootPath + "/App_Themes/" + themePath + "/images/" + imageName;
            path = path.Replace("//", "/");

            return path;
        }



    }



}
