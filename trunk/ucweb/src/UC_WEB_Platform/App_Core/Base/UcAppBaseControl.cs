using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Collections.Specialized;

using Microsoft.Reporting.WebForms;


using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;



namespace UCENTRIK.LIB.Base
{

    public class UcAppReportBaseControl : UcAppBaseControl
    {

        //protected ReportViewer reportViewer;



        ////--//----------- TO DELETE
        //protected void OnPagePreRender(object sender, EventArgs eventArgs)
        //{
        //    ListDictionary scripts = this.Page.ClientScript.GetType().GetField("_registeredClientScriptBlocks", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this.Page.ClientScript) as ListDictionary;

        //    foreach (object key in scripts.Keys)
        //    {
        //        Type type = key.GetType().GetField("_type", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(key) as Type;

        //        string registeredKey = key.GetType().GetField("_key", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(key) as string;

        //        if (Type.Equals(type, this.reportViewer.GetType()) &&

        //        (String.Equals(registeredKey, String.Concat("SqlReportingServicesActionScript", this.reportViewer.ClientID)) || String.Equals(registeredKey, this.reportViewer.ClientID)))
        //        {

        //            ScriptManager.RegisterClientScriptBlock(this.Page, type, registeredKey, scripts[key] as string, true);

        //        }
        //    }
        //}
        ////--//----------- TO DELETE



    }



    public class UcAppBaseControl : UcBaseControl //UserControl
    {


        public UcAppBasePage UcAppPage
        {
            get
            {
                return (UcAppBasePage)this.Page;
            }
        }




        protected bool readOnly = true;
        public bool ReadOnly
        {
            set
            {
                readOnly = value;
            }
            get
            {
                return readOnly;
            }
        }








        protected bool isApprovedToModify
        {
            get
            {
                if (this.UcPage.IsAuthorized)
                    return true;
                else
                    return false;
            }
        }


        //public Int32 GetCurrentUserId()
        //{
        //    Int32 userId = 0;

        //    UserDS.UserDSDataTable dt = BllProxyUser.GetUser(this.UcPage.UserName);
        //    if (dt.Rows.Count > 0)
        //    {
        //        userId = dt[0].user_id;
        //    }

        //    return userId;
        //}



    }


}
