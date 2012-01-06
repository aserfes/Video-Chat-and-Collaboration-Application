using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using UCENTRIK.LIB.BllProxy;
using UCENTRIK.WEB.PLATFORM;



using System.Configuration;
using System.Globalization;
using System.Threading;


namespace UCENTRIK.LIB.Base
{

    public class UcAppReportBasePage : UcAppBasePage
    {

        protected override void OnInit(EventArgs e)
        {
            ((UcMasterPage)this.Master).MainUpdatePanelDisable = true;

            //--------------------------
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            //

            //--------------------------
            base.OnLoad(e);
        }

    
    }


    public class UcAppBasePage : UcBasePage  //System.Web.UI.Page
    {

        private const string ALLOW_PAGE_UPDATE = "Allow_Page_Update";

        UcentrikWeb.App_Controls.CommonControls.PageTitle pageTitle;




        public String SetPageTitle
        {
            set
            {
                pageTitle.Title = value;
            }
        }






        private bool _allowTimerUpdate = false;
        protected bool allowTimerUpdate
        {
            get
            {
                Object objViewStateAllowUpdate = this.ViewState[this.ID + ALLOW_PAGE_UPDATE];
                if (objViewStateAllowUpdate != null)
                    _allowTimerUpdate = Convert.ToBoolean(objViewStateAllowUpdate);

                return _allowTimerUpdate;
            }
            set
            {
                _allowTimerUpdate = value;
            }
        }
        //public bool AllowTimerUpdate
        //{
        //    get
        //    {
        //        return allowTimerUpdate;
        //    }
        //}







        public bool UpdateContent()
        {
            if (allowTimerUpdate)
            {
                updateContent();

                return true;
            }
            else
            {
                return false;
            }
        }
        protected virtual void updateContent()
        {
        }


        
            
        protected override void OnPreInit(EventArgs e)
        {
            //this.Theme = "SOS";

            //--------------------------
            base.OnPreInit(e);
        }



        
        protected override void OnInit(EventArgs e)
        {
            pageTitle = (UcentrikWeb.App_Controls.CommonControls.PageTitle)this.FindControl("PageTitle");

            //--------------------------
            base.OnInit(e);
        }








        protected override void OnLoad(EventArgs e)
        {
            if (this.IsPostBack)
                _allowTimerUpdate = allowTimerUpdate;




            string userName = this.UserName;
            bool isAuthorized = this.IsAuthorized;

            UcMasterPage ucMasterPage = (UcMasterPage)this.Master;
            ucMasterPage.ShowTheContent(this.IsAuthorized);


            //--------------------------
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.ViewState.Remove(this.ID + ALLOW_PAGE_UPDATE);
            this.ViewState.Add(this.ID + ALLOW_PAGE_UPDATE, _allowTimerUpdate);


            

            //--------------------------
            base.OnPreRender(e);
        }




    }
}
