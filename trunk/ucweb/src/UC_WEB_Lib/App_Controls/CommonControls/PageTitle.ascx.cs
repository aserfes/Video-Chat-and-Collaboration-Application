using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UcentrikWeb.App_Controls.CommonControls
{
    public partial class PageTitle : System.Web.UI.UserControl
    {

        public string Title
        {
            set
            {
                ltTitle.Text = value;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
        }



    }
}