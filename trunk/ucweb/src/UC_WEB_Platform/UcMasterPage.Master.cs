using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Configuration;


using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.AppSettings;

using UCENTRIK.LIB.Model;

using UCENTRIK.ROUTING;
using UCENTRIK.LIB.CoreSystem;
using UCENTRIK.Templates;



namespace UCENTRIK.WEB.PLATFORM
{
    public partial class UcMasterPage : UcBaseMasterPage
    {
        protected new UcAppBasePage page;

        public void ShowVideoChat(Int32 incidentId, string conferenceName, string userToTransmit, string userToReceive)
        {
            upVideoChat.Update();
            this.AgentRegistration.CurrentIncidentId = incidentId;
        }

        public string HeaderText
        {
            set
            {
                ltHeaderText.Text = value;
            }
        }

        public void ShowTheContent(bool show)
        {
            
            //Panel1.Visible = true;
            //Panel1.Visible = show;
            //Panel2.Visible = !show;



            if (show)
            {
                AccessDenied.Visible = false;
            }
            else
            {
                AccessDenied.Visible = true;

                OperatingPlaceHolder.Controls.Clear();
                OperatingPlaceHolder.Controls.Add(AccessDenied);
            }


            TitlePlaceHolder.Visible = show;
        }

        public void HideVideoChat()
        {
            //pnlVideoTransmitter.Visible = false;
            //pnlVideoReceiver.Visible = false;
            //pnlTextChat.Visible = false;

            //ViewChatControl.ConfSessionId = "";
            //ViewChatControl.ConfSessionUser = "";

            upVideoChat.Update();


            //this.AgentRegistration.CurrentIncidentId = 0;


            //page.Refresh();
        }

        public bool MainUpdatePanelDisable
        {
            set
            {
                bool enabled = !value;

                timerRefresh.Enabled = enabled;
                UcScriptManager.SupportsPartialRendering = enabled;
                UcScriptManager.EnablePartialRendering = enabled;

                if (!enabled)
                {
                    Literal lt = new Literal();
                    lt.Text = "<meta http-equiv='refresh' content='" + "3600" + "'>";   //FormsAuthentication.TimeOut = 60min
                    this.Head.Controls.Add(lt);

                    //HtmlMeta tag = new HtmlMeta();
                    //tag.Name = "<meta http-equiv='refresh' content='10'>";
                    //tag.Content = "10";
                    //Head.Controls.Add(tag);
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //UcScriptManager.SupportsPartialRendering = false;
            //UcScriptManager.EnablePartialRendering = false;
            //timerRefresh.Enabled = false;
            //=======================================================


            timerRefresh.Interval = 1000 * UcConfParameters.UcPageRefreshInterval;

            page = (UcAppBasePage)this.Page;

            //this.isInAsyncPostBack = UcScriptManager.IsInAsyncPostBack;
            //Context.Items.Add("IsInAsyncPostBack", this.isInAsyncPostBack);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ltHeader.Text = Templates.Templates.GetHtmlHeader();
                ltFooter.Text = Templates.Templates.GetHtmlFooter();
                ltSideBar.Text = Templates.Templates.GetHtmlSideBar();
            }

            this.showBusinessControls();
        }

        protected void ucLogOn_LoggingOut(object sender, UcUserArgs e)
        {
            switch (e.UserRoleId)
            {
                case 1: // Admin
                    break;

                case 2: // Agent
                    Int32 agentId = ProxyHelper.GetUserAgentId(e.UserId);
                    AgentPool agentPool = (AgentPool)Application["AgentPool"];
                    agentPool.UnRegisterAgent(agentId);
                    break;

                case 3: // Manager
                    break;

                case 5: // Supervisor
                    break;

                default:
                    break;
            }
        }

        protected void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (!page.IsAuthorized)
            {
                Response.Redirect("../default.aspx");
            }
            //----------------------------------------




            if (ucSideMenu.UpdateMenu())
                upMenu.Update();



            //------------------------------------------------------ 0 - Show Time
            //lblTimer.Text = DateTime.Now.ToLongTimeString();


            //------------------------------------------------------ 1 - Update Agent Status
            if (AgentRegistration.UpdateAgentStatus())
            {
                upAgentRegistration.Update();
                //if (AgentRegistration.IsOnline)
                //{
                //    pnlVideoTransmitter.Visible = true;
                //}
                //else
                //{
                //    pnlVideoTransmitter.Visible = false;
                //}
                //upVideoChat.Update();
            }

            //------------------------------------------------------ 2 - Update Agent Status
            if (page.UpdateContent())
                upBusinessControlPanel.Update();




            //----------------------------------------
            Context.Items.Add("IsAutoPostBack", true);
        }

        //protected void UcScriptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        //{
        //    string userName = page.UserName;
        //    string pageUrl = page.Request.Url.ToString();

        //    Exception ex = new Exception("UCENTRIK Exception Code: " + "AJAX", e.Exception);
        //    UcSystem.HandleException(ex, userName, pageUrl);

        //    string errorPath = AppHelper.GetApplicationPath("~/dirApp/error.aspx?code=AJAX");
        //    Response.Redirect(errorPath);
        //}













        //--------------------------------------------------------------------------------------

        protected void showBusinessControls()
        {
            string userName = page.UserName;
            Int32 userRole = page.UserRoleId;

            AgentRegistration.Active = false;

            if (userName != "")
            {
                Panel3.Visible = false;
                switch (userRole)
                {
                    case 1: //ADMIN
                        break;

                    case 2: //AGENT
                        AgentRegistration.Active = true;    //this.page.AllowTimerUpdate;
                        break;

                    case 3: //USER
                        break;

                    case 5: //SUPERVISOR
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
