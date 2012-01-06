using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.AppSettings;
using UCENTRIK.LIB.BllProxy;
using System.Collections.Specialized;

namespace UCENTRIK.WEB.KIOSK.dirKiosk
{
    public partial class UcKioskConnect : UcKioskBasePage
    {
        protected Int32 incidentId
        {
            get
            {
                Int32 _incidentId = 0;
                Object objViewStateIncidentId = this.ViewState[this.ID + "IncidentId"];
                if (objViewStateIncidentId != null)
                    _incidentId = Convert.ToInt32(objViewStateIncidentId);

                return _incidentId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "IncidentId");
                this.ViewState.Add(this.ID + "IncidentId", value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                mvConference.ActiveViewIndex = 0;
            }
        }

        protected void mvConference_ActiveViewChanged(object sender, EventArgs e)
        {
            MultiView mv = (MultiView)sender;

            switch (mv.ActiveViewIndex)
            {
                case 0://Start

                    break;

                case 1://Wait
                    WaitScreen.IncidentId = incidentId;
                    WaitScreen.Start();
                    break;

                case 2://Connect
                    LiveConnect.IncidentId = incidentId;
                    LiveConnect.Start();
                    break;

                case 3://Survey
                    Survey.IncidentId = incidentId;
                    Survey.Start();
                    break;

                case 4://Error
                    ErrorControl.Start();
                    break;

                case 5://Finish
                    Finish.Start();
                    break;

                default:
                    break;
            }

            upPage.Update();
        }

        protected void Home_KioskEntered(object sender, UcControlArgs e)
        {
            incidentId = e.Id;
            mvConference.ActiveViewIndex = 1;   //Waiting
        }

        protected void WaitScreen_SessionStarted(object sender, UcControlArgs e)
        {
            mvConference.ActiveViewIndex = 2;   //LiveConnect
        }

        protected void WaitScreen_SessionCanceled(object sender, UcControlArgs e)
        {
            //mvConference.ActiveViewIndex = 0;   //Home
            //this.Refresh();
			CallFinish();
		}

        protected void Survey_SurveyFinished(object sender, UcControlArgs e)
        {
            //mvConference.ActiveViewIndex = 0;   //Home
            //this.Refresh();
			CallFinish();
		}

        protected void LiveConnect_SessionFinished(object sender, UcControlArgs e)
        {
			CallFinish();
		}

        protected void Error_Handled(object sender, UcControlArgs e)
        {
            //mvConference.ActiveViewIndex = 0;   //Home
            //this.Refresh();
			CallFinish();
        }

        protected void Connect_Error(object sender, UcControlArgs e)
        {
            ErrorControl.Message = e.Message;
            mvConference.ActiveViewIndex = 4;   //Error
        }

		void CallFinish()
		{
			// mvConference.ActiveViewIndex = 5;   //Finish
			string script = "window.open('../close.htm', '_self', null);";
			ScriptManager.RegisterClientScriptBlock( this, this.GetType(), "CloseWin", script, true );
		}
    }
}


