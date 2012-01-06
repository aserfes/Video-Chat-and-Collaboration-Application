using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.LIB.Model;
using UCENTRIK.Helpers;
using UCENTRIK.LIB.CoreSystem;
using System.Configuration;
using UCENTRIK.WEB.PLATFORM;
using UCENTRIK.LIB.Helpers;



namespace UCENTRIK.WEB.KIOSK.Connect
{
    public partial class LiveConnect : UcKioskConnectBaseControl
    {


        






        protected Int32 interval = 1;   // seconds
		protected string uctx_cab;

        protected ConferenceStartupParameters parameters;



        protected Int32 statusId
        {
            get
            {
                Int32 _statusId = 0;
                Object objViewStateStatusId = this.ViewState[this.ID + "StatusId"];
                if (objViewStateStatusId != null)
                    _statusId = Convert.ToInt32(objViewStateStatusId);

                return _statusId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "StatusId");
                this.ViewState.Add(this.ID + "StatusId", value);
            }
        }

        protected string state
        {
            get
            {
                string _state = "";
                Object objViewStateState = this.ViewState[this.ID + "State"];
                if (objViewStateState != null)
                    _state = Convert.ToString(objViewStateState);

                return _state;
            }
            set
            {
                this.ViewState.Remove(this.ID + "State");
                this.ViewState.Add(this.ID + "State", value);
            }
        }






        public void Start()
        {
            ltTimeSpan.Text = "";
            lblAgentName.Text = "";

            pnlDisconnect.Visible = true;
            pnlDisconnectConfirm.Visible = false;


            pnlNew.Visible = true;
            pnlContent.Visible = false;
            pnlScreenCast.Visible = false;
            pnlAppShareSend.Visible = false;
            pnlAppShareReceive.Visible = false;





            Guid sessionGUID;

            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(incidentId);

            if (dt.Rows.Count != 0)
            {
                sessionGUID = dt[0].incident_guid;


                string facilityName = dt[0].facility_name;
                string agentName = dt[0].agent_full_name;


                lblAgentName.Text = agentName;

                //----------------------------------------------------------------------------
                String conferenceName = sessionGUID.ToString();






                ConferenceStartupParameters parameters1 = ConferenceHelper.GetParametersForTransmitter(conferenceName, facilityName);
                ConferenceStartupParameters parameters2 = ConferenceHelper.GetParametersForReceiver(conferenceName, agentName, facilityName);
                this.parameters = ConferenceHelper.GetParametersForScreenCast(conferenceName, facilityName, false);



                Session[Utility.ConferenceStartupParametersSessionVariableName] = this.parameters;


                parameters1.ScreenVideoWidth = 320;
                parameters1.ScreenVideoHeight = 240;


                string tempConferenceName = Convert.ToString(1000000 + incidentId);
                //string tempConferenceName = conferenceName;


                parameters1.ConferenceName = tempConferenceName;





                parameters2.VideoWidth = 640;
                parameters2.VideoHeight = 480;

                parameters2.ScreenVideoWidth = 640;     // 320;
                parameters2.ScreenVideoHeight = 480;    // 240;
                parameters2.ConferenceName = tempConferenceName;

                parameters.ConferenceName = tempConferenceName;


                UpdateVideoEvents(tempConferenceName);
                UpdateScreenEvents(tempConferenceName);
                UpdateAudioEvents(tempConferenceName);


                //this.startVideoTransmitter(parameters1);      // !!!!!
                //this.startVideoReceiver(parameters2);
                //this.startCreenCast(this.parameters);




                //--
                //TextChatControl.ConfSessionId = conferenceName;
                //TextChatControl.ConfSessionUser = facilityName;
                ViewChatControl.ConfSessionId = conferenceName;
                ViewChatControl.ConfSessionUser = facilityName;
                //--


                //----------------------------------------------------------------------------
                startTime = DateTime.Now;
            }
            else
            {
                Response.Redirect("UcKioskConnect.aspx");
            }
        }

        private void AddJavascripts(Page page)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered("uctx"))
            {
                ScriptManager.RegisterClientScriptInclude(page, page.GetType(), "uctx", ResolveClientUrl("~/dirJavascript/uctx_core.js"));
            }
            if (!page.ClientScript.IsClientScriptIncludeRegistered("video"))
            {
                ScriptManager.RegisterClientScriptInclude(page, page.GetType(), "video", ResolveClientUrl("~/dirJavascript/video.js"));
            }
            if (!page.ClientScript.IsClientScriptIncludeRegistered("screen"))
            {
                ScriptManager.RegisterClientScriptInclude(page, page.GetType(), "screen", ResolveClientUrl("~/dirJavascript/screen.js"));
            }
            if (!page.ClientScript.IsClientScriptIncludeRegistered("audio"))
            {
                ScriptManager.RegisterClientScriptInclude(page, page.GetType(), "audio", ResolveClientUrl("~/dirJavascript/audio.js"));
            }
        }

        private void UpdateAudioEvents(string confId)
        {
            string script = null;

            string samplesPerSec = ProxyHelper.GetSettingValueString("AudioSamplesPerSec", "KIOSK");
            string speexQuality = ProxyHelper.GetSettingValueString("SpeexQuality", "KIOSK");
            string audioOutputDeviceID = ProxyHelper.GetSettingValueString("AudioOutputDeviceID", "KIOSK");
            string audioDeviceID = ProxyHelper.GetSettingValueString("VideoDeviceID", "KIOSK");

            script = "StartAudioPublisher(6, " + confId + ", 1, 1, '" + audioDeviceID + "', '" + samplesPerSec + "', '" + speexQuality + "', '');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StartAudioPublisher", script, true);

            script = "StartAudioSubscriber(6, " + confId + ", 1, 2, 1, '" + audioOutputDeviceID + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StartAudioSubscriber", script, true);
        }

        private void UpdateScreenEvents(string confId)
        {
            string script = null;

            string scrpIDProcess = ProxyHelper.GetSettingValueString("ScreenIDProcess", "KIOSK");
            string scrpDevice = ProxyHelper.GetSettingValueString("ScreenDevice", "KIOSK");
            string scrpTypePixel = ProxyHelper.GetSettingValueString("ScreenTypePixel", "KIOSK");

            script = "StartScreenPublisher(5, " + confId + ", 1, 1, '" + scrpIDProcess + "', '" + scrpDevice + "', '" + scrpTypePixel + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StartScreenPublisher", script, true);
        }

        private void UpdateVideoEvents(string confId)
        {
            string script = null;

            string theoraBitrate = ProxyHelper.GetSettingValueString("TheoraBitrate", "KIOSK");
            string theoraQuality = ProxyHelper.GetSettingValueString("TheoraQuality", "KIOSK");
            string theoraKeyframe = ProxyHelper.GetSettingValueString("TheoraKeyframe", "KIOSK");
            string videoWidth = ProxyHelper.GetSettingValueString("VideoWidth", "KIOSK");
            string videoHeight = ProxyHelper.GetSettingValueString("VideoHeight", "KIOSK");
            string timePerFrame = ProxyHelper.GetSettingValueString("VideoTimePerFrame", "KIOSK");
            string videoDeviceID = ProxyHelper.GetSettingValueString("VideoDeviceID", "KIOSK");

            string viewMethod = ProxyHelper.GetSettingValueString("VideoViewMethod", "KIOSK");

            script = "StartVideoPublisher(4, " + confId + ", 1, 1, 'wye_uic_video_publisher'," + theoraBitrate + "," + theoraQuality + "," + theoraKeyframe + "," + videoWidth + "," + videoHeight + "," + timePerFrame + "," + videoDeviceID + ", '')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StartVideoPublisher", script, true);

            script = "StartVideoSubscriber(4, " + confId + ", 1, 2, 1, 'wye_uic_video_subscriber'," + viewMethod + " ,'')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StartVideoSubscriber", script, true);
        }


        //public void Start()
        //{
        //    ltTimeSpan.Text = "";
        //    lblAgentName.Text = "";

        //    pnlDisconnect.Visible = true;
        //    pnlDisconnectConfirm.Visible = false;


        //    pnlNew.Visible = true;
        //    pnlContent.Visible = false;
        //    pnlScreenCast.Visible = false;
        //    pnlAppShareSend.Visible = false;
        //    pnlAppShareReceive.Visible = false;





        //    Guid sessionGUID;

        //    IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(incidentId);

        //    if (dt.Rows.Count != 0)
        //    {
        //        sessionGUID = dt[0].incident_guid;


        //        string facilityName = dt[0].facility_name;
        //        string agentName = dt[0].agent_full_name;


        //        lblAgentName.Text = agentName;

        //        //----------------------------------------------------------------------------
        //        String conferenceName = sessionGUID.ToString();






        //        ConferenceStartupParameters parameters1 = ConferenceHelper.GetParametersForTransmitter(conferenceName, facilityName);
        //        ConferenceStartupParameters parameters2 = ConferenceHelper.GetParametersForReceiver(conferenceName, agentName, facilityName);
        //        this.parameters = ConferenceHelper.GetParametersForScreenCast(conferenceName, facilityName, false);



        //        Session[Utility.ConferenceStartupParametersSessionVariableName] = this.parameters;


        //        this.startVideoTransmitter(parameters1);
        //        this.startVideoReceiver(parameters2);
        //        this.startCreenCast(this.parameters);




        //        //--
        //        //TextChatControl.ConfSessionId = conferenceName;
        //        //TextChatControl.ConfSessionUser = facilityName;
                //ViewChatControl.ConfSessionId = conferenceName;
                //ViewChatControl.ConfSessionUser = facilityName;
        //        //--


        //        //----------------------------------------------------------------------------
        //        startTime = DateTime.Now;
        //    }
        //    else
        //    {
        //        Response.Redirect("UcKioskConnect.aspx");
        //    }
        //}

        protected void startVideoTransmitter(ConferenceStartupParameters parameters)
        {
            //ucVideoTransmitter.Parameters = parameters;
        }
        protected void startVideoReceiver(ConferenceStartupParameters parameters)
        {
            //ucVideoReceiver.Parameters = parameters;
        }
        protected void startCreenCast(ConferenceStartupParameters parameters)
        {
            //AppShareControl.Parameters = parameters;
        }

        protected void startCreenCast()
        {
            this.parameters = (ConferenceStartupParameters)Session[Utility.ConferenceStartupParametersSessionVariableName];

            if (this.parameters != null)
                this.startCreenCast(this.parameters);
        }








        protected void Page_Init(object sender, EventArgs e)
        {
            timerRefresh.Interval = 1000 * this.interval;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                Session.Remove(Utility.ConferenceStartupParametersSessionVariableName);
                startTime = DateTime.Now;

				uctx_cab = System.Configuration.ConfigurationManager.AppSettings[ "uctx.cab" ];

                UCTXHelper.AddUCTXObjectsToHeader(Page);
                AddJavascripts(Page);
                UCTXHelper.SetCommonSettings(Page);
            }


            //this.parameters = (ConferenceStartupParameters)Session[Utility.ConferenceStartupParametersSessionVariableName];
            //if (this.parameters != null)
            //{
            ////    this.startVideoReceiver(parameters);
            ////    this.startVideoSession(parameters);
            //    this.startCreenCast(this.parameters);
            //}
        }






        protected void setContentPanel(string state)
        {


            string currentState = state;

            if (currentState != this.state)
            {



                pnlNew.Visible = false;
                pnlContent.Visible = false;
                pnlScreenCast.Visible = false;
                pnlAppShareSend.Visible = false;
                pnlAppShareReceive.Visible = false;



                switch (state)
                {
                    case "NEW":
                        pnlNew.Visible = true;
                        break;

                    case "ACT":
                        pnlContent.Visible = true;
                        break;

                    case "VID":
                        pnlContent.Visible = true;
                        break;

                    case "SCT":
                        startCreenCast();
                        pnlScreenCast.Visible = true;
                        break;

                    case "APS":
                        pnlAppShareSend.Visible = true;
                        break;

                    case "APR":
                        pnlAppShareReceive.Visible = true;
                        break;

                    case "CLS":
                        break;


                    default:
                        pnlNew.Visible = false;
                        break;


                }


                this.state = currentState;
                upContent.Update();
            }



            
        }




        protected void btnDisconnect_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string commandName = btn.CommandName;
            string commandArgument = btn.CommandArgument;


            pnlDisconnect.Visible = false;
            pnlDisconnectConfirm.Visible = false;

            if (commandName == "DISCONNECT")
            {
                pnlDisconnectConfirm.Visible = true;
            }
            else if (commandName == "CONFIRM")
            {
                BllProxyIncidentHelper.SetIncidentStatus(this.incidentId, 3);   // 3:Canceled
                BllProxyIncidentState.DeleteIncidentState(this.incidentId);

                UcControlArgs args = new UcControlArgs();
                goNext(args);
            }
            else if (commandName == "CANCEL")
            {
                pnlDisconnect.Visible = true;
            }
            else
            {
                pnlDisconnect.Visible = true;
            }


            //UpdatePanel1.Update();

        }




























        protected void timerRefresh_Tick(object sender, EventArgs e)
        {


            //-----------------------------------------------------------------------
            bool checkState = BllProxyIncidentState.SetIncidentState1(incidentId, this.interval);


            pnlConnected.Visible = checkState;
            pnlDisconnected.Visible = !checkState;
            upDiconnect.Update();
            upConnectionStatus.Update();





            //-----------------------------------------------------------------------
            DateTime t = DateTime.Now;
            DateTime last = new DateTime(t.Subtract(startTime).Ticks);
            TimeSpan span = t.Subtract(startTime);

            ltTimeSpan.Text = string.Format("{0:00}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);





            Int32 currentStatusId = 0;
            string state = "";
            bool isActive = IncidentHelper.GetIncidentState(incidentId, ref currentStatusId, ref state);
            


            //btnDisconnect.Enabled = isActive;
            //upDiconnect.Update();


            bool isSessionFinished = false;

            if (currentStatusId != statusId)
            {
                switch (currentStatusId)
                {
                    case 1: //New
                        break;

                    case 2: //In-Progress
                        break;

                    case 3: //Canceled
                        isSessionFinished = true;
                        break;

                    case 4: //Closed
                        isSessionFinished = true;
                        break;

                }

                statusId = currentStatusId;
            }


            if (statusId == 2) //In-Progress
            {
                this.setContentPanel(state);
            }



            if (isSessionFinished)
            {
                UcControlArgs args = new UcControlArgs();
                goNext(args);
            }
        }




        ////----------------------------------------------------------------------------------------
    }
}
