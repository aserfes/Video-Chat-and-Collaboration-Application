using System;
using System.Web;
using UCENTRIK.Helpers;


namespace UCENTRIK.WEB.PLATFORM.dirAgent
{
	public partial class AudioRecordReceiver : System.Web.UI.Page
	{
		protected void Page_Load( object sender, EventArgs e )
		{
			if( this.IsPostBack ) return;

			AudioUploadHelper.ProcessUpload( Request );
		}
	}
}
