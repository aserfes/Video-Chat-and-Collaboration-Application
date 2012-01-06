using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UCENTRIK.WEB.PLATFORM
{
    public partial class _default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("dirCommon/LogIn.aspx", false);
            this.Context.ApplicationInstance.CompleteRequest();
        }
    }
}

//TODO2: Improve style of AsyncUploadFile.aspx
//TODO2: Restriction of audio record file size by time.
//TODO2: mp3 format of audio record file.
//TODO2: Merge agent and kiosk audio records using GStreamer tool.
//TODO2: Move recording settings to database.
//TODO2: Check if file is exist before uploading. Add function "Util.Query("IsFileExist","%path%") returns "1" - success, "0" - failed" to UCTX control.
//TODO2: Send audio file after user will close kiosk window.





