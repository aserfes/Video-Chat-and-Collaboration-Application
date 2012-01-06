using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.Membership;





namespace UCENTRIK.LIB.Base
{




    public class UcBasePage : Page
    {

        public string UserName
        {
            get
            {
                return Convert.ToString(Context.Items["UserName"]);
            }
        }
        public Int32 UserId
        {
            get
            {
                UserPool _userPool = (UserPool)Application["UserPool"];
                Int32 userId = _userPool.GetUserId(this.UserName);

                return userId;
            }
        }
        public Int32 UserRoleId
        {
            get
            {
                return Convert.ToInt32(Context.Items["UserRoleId"]);
            }
        }
        public bool IsAuthorized
        {
            get
            {
                return Convert.ToBoolean(Context.Items["IsAuthorized"]);
            }
        }
        public string TimeZone
        {
            get
            {
                return Convert.ToString(Context.Items["TimeZone"]);
            }
        }


        public void Refresh()
        {
            this.Response.Redirect(Page.Request.Url.ToString(), true);
        }

    }




}
