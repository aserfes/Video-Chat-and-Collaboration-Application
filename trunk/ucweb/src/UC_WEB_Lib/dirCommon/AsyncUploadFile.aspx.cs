using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.Helpers;
using UCENTRIK.LIB.BllProxy;

namespace UcentrikWeb.dirAgent
{
    public partial class AsyncUploadFile : System.Web.UI.Page
    {
		protected void Page_Load( object sender, EventArgs e )
		{
			UCTXHelper.AddUCTXObjectsToHeader( this );

			Uri uri = new Uri( ProxyHelper.GetSettingValueString( "AudioUploadTargetPageUrl", "PLATFORM" ) );

			string script = string.Format
				( "var url_upload = {{ host: '{0}', port: {1}, path: '{2}' }};"
				, uri.Host
				, uri.Port
				, uri.PathAndQuery
				);

			ScriptManager.RegisterClientScriptBlock( this, GetType(), "url_upload", script, true );
			ScriptManager.RegisterClientScriptInclude( this, GetType(), "common", this.ResolveClientUrl( "~/dirJavascript/common.js" ) );
			ScriptManager.RegisterClientScriptInclude( this, GetType(), "upload", this.ResolveClientUrl( "~/dirJavascript/async_upload.js" ) );
		}
    }
}