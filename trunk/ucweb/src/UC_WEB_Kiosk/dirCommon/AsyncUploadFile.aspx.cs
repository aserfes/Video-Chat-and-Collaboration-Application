using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.Helpers;

namespace UcentrikWeb.dirAgent
{
    public partial class AsyncUploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			UCTXHelper.AddUCTXObjectsToHeader( this );
            ScriptManager.RegisterClientScriptInclude(this, GetType(), "common", this.ResolveClientUrl("~/dirJavascript/common.js"));
            ScriptManager.RegisterClientScriptInclude(this, GetType(), "upload", this.ResolveClientUrl("~/dirJavascript/async_upload.js"));
        }
    }
}