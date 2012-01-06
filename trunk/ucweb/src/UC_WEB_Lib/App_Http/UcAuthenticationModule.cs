using System;
using System.Web;
using System.Web.SessionState;
using System.Security.Principal;

using System.Web.Security;
using UCENTRIK.Membership;

using System.IO;
using System.Text.RegularExpressions;

namespace UCENTRIK.HttpModules
{
    /// <summary>
    /// Authentication & Authorization module.
    /// </summary>
    public class UcAuthenticationModule : IHttpModule, IReadOnlySessionState
    {
        private string _username = "";
        private FormsAuthenticationTicket _ticket;
        private UserPool _userPool;

        public UcAuthenticationModule()
        {
        }
        public void Dispose()
        {
        }

        protected HttpContext getContext(HttpApplication app)
        {
            return (HttpContext)app.Context;
        }

        // <EVENT listing>
        //***********************************************************************************
        //  *****  Pre-Execution Events  ----------------------------------------------------
        //    BeginRequest
        //    AuthenticateRequest
        //    PostAuthenticateRequest
        //    AuthorizeRequest
        //    PostAuthorizeRequest
        //    ResolveRequestCache
        //    PostResolveRequestCache
        //    MapRequestHandler
        //    PostMapRequestHandler
        //    AcquireRequestState
        //    PostAcquireRequestState
        //    PreRequestHandlerExecute
        //
        //
        //
        //
        //  *****  ProcessRequest(Handler Execution  ----------------------------------------
        //
        //
        //
        //
        //  *****  Post-Execution Events  ---------------------------------------------------
        //    PostRequestHandlerExecute
        //    ReleaseRequestState
        //    PostReleaseRequestState
        //    UpdateRequestCache
        //    PostUpdateRequestCache
        //    LogRequest
        //    PostLogRequest
        //    EndRequest
        //    PreSendRequestHeaders
        //    PreSendRequestContent
        //***********************************************************************************




        public void Init(HttpApplication r_objApplication)
        {
            HttpContext objContext = this.getContext(r_objApplication); ;
            _userPool = (UserPool)objContext.Application["UserPool"];



            //------------------------------------------
            r_objApplication.AuthenticateRequest += new EventHandler(this.AuthenticateRequest);
            r_objApplication.AuthorizeRequest += new EventHandler(this.AuthorizeRequest);

            ////------------------------------------------
            r_objApplication.ReleaseRequestState += new EventHandler(this.ReleaseRequestState);
        }







        private void AuthenticateRequest(object r_objSender, EventArgs r_objEventArgs)
        {
            HttpApplication objApp = (HttpApplication)r_objSender;
            HttpContext objContext = this.getContext(objApp);

            string url = objContext.Request.Url.ToString();
            if (url.Contains(".aspx"))
            {
                _username = "";


                HttpCookie authCoockie = objContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                bool isValid = false;
                if (authCoockie != null)
                {
                    //try
                    //{
                    string encryptedTicket = authCoockie.Values[0].ToString();
                    _ticket = FormsAuthentication.Decrypt(encryptedTicket);
                    _username = _ticket.Name;

                    if (!_ticket.Expired)
                        isValid = _userPool.ValidateUser(_username);
                    //}
                    //catch
                    //{
                    //    FormsAuthentication.SignOut();
                    //}
                }

                //if (isValid)
                //{
                //    if (FormsAuthentication.SlidingExpiration)
                //        FormsAuthentication.SetAuthCookie(_username, false);
                //}
                //else
                //{
                //    _username = "";
                //    FormsAuthentication.SignOut();
                //}
                objContext.Items.Add("isValid", isValid);






                //-------------------------------------------------------------------
                objContext.Items.Add("UserName", _username);



                //-------------------------------------------------------------------
                string timeZone = _userPool.GetUserTimeZone(_username);
                objContext.Items.Add("TimeZone", timeZone);

            }
        }


        private void AuthorizeRequest(object r_objSender, EventArgs r_objEventArgs)
        {
            HttpApplication objApp = (HttpApplication)r_objSender;
            HttpContext objContext = this.getContext(objApp);

            string url = objContext.Request.Url.ToString();
            if (url.Contains(".aspx"))
            {

                Int32 userRoleId = 0;
                bool isAuthorized = false;

                //HttpApplication objApp = (HttpApplication)r_objSender;
                //HttpContext objContext = this.getContext(objApp); ;

                //string url = objContext.Request.Url.ToString();




                if (url.Contains(@"/dir"))
                {
                    int i = url.IndexOf(@"/dir", 0);
                    int j = url.IndexOf(@"/", i + 1);
                    url = url.Substring(0, j + 1);
                }


                if (_username == "")
                {

                    if (
                            (url.Contains(@"/dirAdmin/")) ||
                            (url.Contains(@"/dirReport/")) ||
                            (url.Contains(@"/dirAgent/")) ||
                            (url.Contains(@"/dirUser/")) ||
                            (url.Contains(@"/dirKiosk/"))
                        )
                        isAuthorized = false;
                    else
                        isAuthorized = true;


                }
                else
                {
                    userRoleId = _userPool.GetUserRoleId(_username);


                    if ((url.Contains(@"/dirAdmin/")) || (url.Contains(@"/dirReport/")) || (url.Contains(@"/dirAgent/")) || (url.Contains(@"/dirUser/")))
                    {
                        switch (userRoleId)
                        {
                            case 1: // Admin
                                if ((url.Contains(@"/dirCommon/")) || (url.Contains(@"/dirUser/")) || (url.Contains(@"/dirAdmin/")) || (url.Contains(@"/dirReport/")))
                                    isAuthorized = true;
                                break;

                            case 2: // Agent
                                if ((url.Contains(@"/dirCommon/")) || (url.Contains(@"/dirUser/")) || (url.Contains(@"/dirAgent/")))
                                    isAuthorized = true;
                                break;

                            case 3: // Manager
                                if ((url.Contains(@"/dirCommon/")) || (url.Contains(@"/dirUser/")))
                                    isAuthorized = true;
                                break;

                            case 4: // User
                                if ((url.Contains(@"/dirCommon/")) || (url.Contains(@"/dirUser/")))
                                    isAuthorized = true;
                                break;

                            case 5: // Supervisor
                                if ((url.Contains(@"/dirCommon/")) || (url.Contains(@"/dirUser/")) || (url.Contains(@"/dirAdmin/")) || (url.Contains(@"/dirReport/")))
                                    isAuthorized = true;
                                break;

                            default:
                                if (url.Contains(@"/dirCommon/"))
                                    isAuthorized = true;
                                break;

                        }
                    }
                    else
                    {
                        isAuthorized = true;
                    }
                }





                //-------------------------------------------------------------------
                objContext.Items.Add("UserRoleId", userRoleId);
                objContext.Items.Add("IsAuthorized", isAuthorized);

            }
        }


        private void ReleaseRequestState(object r_objSender, EventArgs r_objEventArgs)
        {
            HttpApplication objApp = (HttpApplication)r_objSender;
            HttpContext objContext = this.getContext(objApp);

            string url = objContext.Request.Url.ToString();

            if (url.Contains(".aspx"))
            {
                //bool isValid = Convert.ToBoolean(objContext.Items["isValid"]);
                bool isValid = false;
                if (objContext.Items.Contains("isValid"))
                    isValid = Convert.ToBoolean(objContext.Items["isValid"]);



                //bool isInAsyncPostBack = false;
                //if (objContext.Items.Contains("IsInAsyncPostBack"))
                //    isInAsyncPostBack = Convert.ToBoolean(objContext.Items["IsInAsyncPostBack"]);

                bool isAutoPostBack = false;
                if (objContext.Items.Contains("IsAutoPostBack"))
                    isAutoPostBack = Convert.ToBoolean(objContext.Items["IsAutoPostBack"]);





                if (isValid)
                {
                    if (!isAutoPostBack)
                    {
                        if (FormsAuthentication.SlidingExpiration)
                            FormsAuthentication.SetAuthCookie(_username, false);
                    }
                }
                else
                {
                    _username = "";
                    FormsAuthentication.SignOut();

                    objContext.Items["UserName"] = _username;
                    objContext.Items["UserRoleId"] = 0;
                    objContext.Items["IsAuthorized"] = false;
                    objContext.Items["TimeZone"] = 0;
                }
            }
        }





    }



}
