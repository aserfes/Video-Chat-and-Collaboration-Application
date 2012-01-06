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

    
    
    public class UcAppBaseOperationalControl : UcAppBaseControl
    {


        ObjectDataSource objectdatasourceList;
        MultiView mvControl;
        GridView gvList;
        Label lblMessage;
        Label lblCount;
        Panel pnlAdd;
        UcAppBaseProfileControl profileControl;



        //        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler ProfileOpen;
        protected void open(object sender, UcControlArgs e)
        {
            if (ProfileOpen != null)
                ProfileOpen(this, e);
        }
        public event UcControlEventHandler BackToList;
        protected void back(object sender, UcControlArgs e)
        {
            if (BackToList != null)
                BackToList(this, e);
        }
        public event UcControlEventHandler Next;
        protected void next(object sender, UcControlArgs e)
        {
            if (Next != null)
                Next(this, e);
        }
        //        ///---------------------------------------------------------------------------------





        public UcAppBaseOperationalControl()
        {
        }




        private bool _allowManagement = false;
        public bool AllowManagement
        {
            set
            {
                _allowManagement = value;
            }
        }


        private bool _allowDelete = false;
        public bool AllowDelete
        {
            set
            {
                _allowDelete = value;
            }
        }

        private bool _allowSort = true;
        public bool AllowSort
        {
            set
            {
                _allowSort = value;
            }
        }


        protected string sortExpression = "";
        protected SortDirection sortDirection = SortDirection.Ascending;
        protected string ucDataSourceSelectMethod;





        public string SortExpression
        {
            set
            {
                sortExpression = value;
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
            mvControl = (MultiView)this.FindControl("mvControl");
            gvList = (GridView)this.FindControl("gvList");
            lblMessage = (Label)this.FindControl("lblMessage");
            lblCount = (Label)this.FindControl("lblCount");
            pnlAdd = (Panel)this.FindControl("pnlAdd");

            profileControl = (UcAppBaseProfileControl)this.FindControl("profileControl");


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

            gvList.RowCreated += GridView_RowCreated;
            gvList.RowDataBound += GridView_RowDataBound;
            gvList.RowDeleting += GridView_RowDeleting;
            gvList.RowDeleted += GridView_RowDeleted;



            Int32 lastColumn = gvList.Columns.Count - 1;
            if (_allowDelete)
            {
                gvList.Columns[0].Visible = false;
                gvList.Columns[1].Visible = true;
                gvList.Columns[lastColumn].Visible = true;

                pnlAdd.Visible = true;
            }
            else
            {
                gvList.Columns[0].Visible = true;
                gvList.Columns[1].Visible = false;
                gvList.Columns[lastColumn].Visible = false;

                pnlAdd.Visible = false;
            }



            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            profileControl.ReadOnly = this.ReadOnly;
            profileControl.AllowManagement = this._allowManagement;

            base.OnLoad(e);
        }
        protected override void OnPreRender(EventArgs e)
        {
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
            GridView gv = (GridView)sender;

            GridViewRow row = e.Row;
            if (row.RowType == DataControlRowType.DataRow)
            {
                Int32 lastCell = row.Cells.Count - 1;
                if (_allowDelete)
                {
                    foreach (Control cntrl in row.Cells[lastCell].Controls)
                    {
                        LinkButton lb = cntrl as LinkButton;
                        if (lb != null)
                            if (lb.CommandName == "Delete")
                                lb.Attributes.Add("onclick", "return confirm('Do you want to delete this record?');");
                    }
                }
            }
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
                            //if ((lb.CommandArgument == se) && (cell.Visible == true))
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




        //        ///---------------------------------------------------------------------------------
        protected void dataSelected(object source, ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue != null)
            {
                Int32 cnt = ((DataTable)e.ReturnValue).Rows.Count;
                lblCount.Text = cnt.ToString();
            }
        }







        //        ///---------------------------------------------------------------------------------
        protected void view_Back(object sender, UcControlArgs e)
        {
            if(e.Message != "")
                this.showTextMessage(e.Message);

            mvControl.ActiveViewIndex = 0;
            gvList.DataBind();

            profileControl.ClearControlData();

            back(this, e);
        }
        protected void view_Save(object sender, UcControlArgs e)
        {

            if (e.IsNew)
            {
                this.showTextMessage("The profile has been created");
                mvControl.ActiveViewIndex = 0;
            }
            else
            {
                this.showTextMessage("The profile has been saved");
                mvControl.ActiveViewIndex = 0;
            }


            gvList.DataBind();

            profileControl.ClearControlData();

            if (e.NavigateTo == "NEXT")
                next(this, e);
            else
                back(this, e);
        }


        //        ///---------------------------------------------------------------------------------
        public string getThemeImage(string imageName)
        {
            string rootPath = AppHelper.GetApplicationPath("~");
            string themePath = this.Page.Theme;
            string path = rootPath + "/App_Themes/" + themePath + "/images/" + imageName;
            path = path.Replace("//", "/");

            return path;
        }

		public DataControlField FindFieldByHeaderText( string header )
		{
			if( gvList == null ) return null;

			for( int i = 0; i < gvList.Columns.Count; i++ )
			{
				DataControlField field = gvList.Columns[ i ];
				if( field.HeaderText == header )
					return field;
			}
			return null;
		}



    }



}
