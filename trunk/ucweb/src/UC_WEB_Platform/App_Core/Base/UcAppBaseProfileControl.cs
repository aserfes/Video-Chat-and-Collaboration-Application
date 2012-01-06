using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using UCENTRIK.AppSettings;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;



namespace UCENTRIK.LIB.Base
{



    public class UcAppBaseProfileControl : UcAppBaseControl
    {

        protected Label lblMessage;
        protected Button btnSave;
        protected Button btnBack;



//        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler ProfileBackButton;
        protected void goBack(UcControlArgs args)
        {
            if (ProfileBackButton != null)
                ProfileBackButton(this, args);
        }
        public event UcControlEventHandler ProfileNextButton;
        protected void goNext(UcControlArgs args)
        {
            if (ProfileNextButton != null)
                ProfileNextButton(this, args);
        }
        public event UcControlEventHandler ProfileSaveButton;
        protected void dataSaved(UcControlArgs args)
        {
            if (ProfileSaveButton != null)
                ProfileSaveButton(this, args);
        }
//        ///---------------------------------------------------------------------------------




        ///---------------------------------------------------------------------------------
        protected Int32 profileId
        {
            get
            {
                Int32 _profileId = 0;
                Object objViewStateProfileId = this.ViewState[this.ID + "ProfileId"];
                if (objViewStateProfileId != null)
                    _profileId = Convert.ToInt32(objViewStateProfileId);

                return _profileId;
            }
            set
            {
                this.clearMessage();

                this.ViewState.Remove(this.ID + "ProfileId");
                this.ViewState.Add(this.ID + "ProfileId", value);
            }
        }
        protected Int32 statusId
        {
            get
            {
                Int32 _statusId = 0;
                Object objViewStateStatusId = this.ViewState[this.ID + "StatusId"];
                if (objViewStateStatusId != null)
                    _statusId = Convert.ToInt32(objViewStateStatusId);

                return _statusId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "StatusId");
                this.ViewState.Add(this.ID + "StatusId", value);
            }
        }



        //protected bool readOnly = true;
        //public bool ReadOnly
        //{
        //    set
        //    {
        //        readOnly = value;
        //    }
        //    get
        //    {
        //        return readOnly;
        //    }
        //}



        private bool _allowManagement = false;
        public bool AllowManagement
        {
            set
            {
                _allowManagement = value;
            }
            get
            {
                return _allowManagement;
            }
        }




        public bool ShowBackButton
        {
            set
            {
                btnBack.Visible = value;
            }
        }















        ///---------------------------------------------------------------------------------
        protected override void OnInit(EventArgs e)
        {
            lblMessage = (Label)this.FindControl("lblMessage");
            btnSave = (Button)this.FindControl("btnSave");
            btnBack = (Button)this.FindControl("btnBack");

            //------------------
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {

            //------------------
            base.OnLoad(e);
        }
        protected override void OnPreRender(EventArgs e)
        {

            //------------------
            base.OnPreRender(e);
        }



//        ///---------------------------------------------------------------------------------
        protected void showTextMessage(string message)
        {
            if (lblMessage != null)
            {
                lblMessage.CssClass = "TextMessage";
                lblMessage.Text = message;
            }
        }
        protected void showErrorMessage(string message)
        {
            if (lblMessage != null)
            {
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Text = message;
            }
        }
        protected void clearMessage()
        {
            if (lblMessage != null)
            {
                lblMessage.Text = "";
            }
        }








        ///---------------------------------------------------------------------------------
        protected void btnBack_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            goBack(args);
        }

        ///---------------------------------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.isApprovedToModify)
            {
                save();
            }
        }



        ///---------------------------------------------------------------------------------
        protected virtual void save()
        {
        }

        ///---------------------------------------------------------------------------------
        public virtual void ClearControlData()
        {
        }
    }




















    public class UcAppBaseProfileDetailsControl : UcAppBaseProfileControl
    {
        ObjectDataSource objectdatasourceEdit;
        DetailsView dvControl;










        protected DetailsViewMode dvMode = DetailsViewMode.ReadOnly;
        //protected bool readOnly
        //{
        //    set
        //    {
        //        bool ro = value;
        //        if (ro)
        //        {
        //            _dvMode = DetailsViewMode.Insert;
        //        }
        //        else
        //        {
        //            _dvMode = DetailsViewMode.Edit;
        //        }
        //    }
        //}









        public void Refresh()
        {
            //this.profileId = this.profileId;
            dvControl.DataBind();
        }



        protected override void OnInit(EventArgs e)
        {
            objectdatasourceEdit = (ObjectDataSource)this.FindControl("objectdatasourceEdit");
            dvControl = (DetailsView)this.FindControl("dvControl");

            dvControl.DataSourceID = "objectdatasourceEdit";
            dvControl.AutoGenerateRows = false;
            
            dvControl.AllowPaging = false;
            dvControl.EnableViewState = true;

            dvControl.GridLines = GridLines.Both;
            dvControl.Width = Unit.Percentage(100);
            dvControl.CssClass = "DetailsView";

            dvControl.CellPadding = 4;
            dvControl.CellSpacing = 0;
            dvControl.EnablePagingCallbacks = false;

            dvControl.ItemInserted += DetailsView_ItemInserted;
            dvControl.ItemUpdated += DetailsView_ItemUpdated;

            
            objectdatasourceEdit.EnableViewState = true;
            objectdatasourceEdit.Inserted += objectdatasource_Inserted;

            //---------------------------------------
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (readOnly)
                dvMode = DetailsViewMode.ReadOnly;
            else
                dvMode = DetailsViewMode.Edit;

            dvControl.DefaultMode = dvMode;

            if (btnSave != null)
                btnSave.Visible = !readOnly;
            
            
            //---------------------------------------
            base.OnLoad(e);
        }




        







        protected void DetailsView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;
            args.IsNew = true;
            args.NavigateTo = "NEXT";
            dataSaved(args);
        }

        protected void DetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;
            args.IsNew = false;
            dataSaved(args);
        }



        protected void objectdatasource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            profileId = Convert.ToInt32(e.ReturnValue);
        }




        public override void ClearControlData()
        {
            this.profileId = 0;
        }





        


    }








}
