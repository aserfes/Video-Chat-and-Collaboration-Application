using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.Model;
using System.Configuration;
using UCENTRIK.LIB.Helpers;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.Helpers;

namespace UCENTRIK.WEB.PLATFORM.App_Controls.BusinessControls
{
    public partial class UCTXControls : System.Web.UI.UserControl
    {
		protected string uctx_cab;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                LoadBase();
            }
        }

        private void LoadBase()
        {
			uctx_cab = System.Configuration.ConfigurationManager.AppSettings[ "uctx.cab" ];

            UCTXHelper.AddUCTXObjectsToHeader(Page);
            AddJavascripts(Page);
            UCTXHelper.SetCommonSettings(Page);
            AddJQuery(Page);
        }

        public void ShowVideoChat(Int32 incidentId, string conferenceName, string userToTransmit, string userToReceive)
        {
            ConferenceStartupParameters parameters1 = ConferenceHelper.GetParametersForTransmitter(conferenceName, userToTransmit);
            ConferenceStartupParameters parameters2 = ConferenceHelper.GetParametersForReceiver(conferenceName, userToReceive, userToTransmit);

            string tempConferenceName = Convert.ToString(1000000 + incidentId);

            if ((parameters1 != null) && (parameters2 != null))
            {
                LoadBase();

                parameters1.ScreenVideoWidth = 240;
                parameters1.ScreenVideoHeight = 180;
                parameters1.ConferenceName = tempConferenceName;

                parameters2.ScreenVideoWidth = 240;
                parameters2.ScreenVideoHeight = 180;
                parameters2.ConferenceName = tempConferenceName;

                this.Visible = true;

                UpdateVideoEvents(tempConferenceName);
                UpdateScreenEvents(tempConferenceName);
                UpdateAudioEvents(tempConferenceName, incidentId);
                UpdateVolumeSliderEvents();

                ViewChatControl.ConfSessionId = conferenceName;
                ViewChatControl.ConfSessionUser = userToTransmit;
            }
            else
            {
                this.Visible = false;
            }
        }

        public void HideVideoChat()
        {
            RunScript("javascript:Destroy();");
            this.Visible = false;
        }

        private void AddJQuery(Page page)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered("jquery.min.js"))
            {
                ScriptManager.RegisterClientScriptInclude(page, page.GetType(), "jquery.min.js", ResolveClientUrl("~/dirJavascript/jquery-1.6.2.min.js"));
            }
            if (!page.ClientScript.IsClientScriptIncludeRegistered("jquery-ui.min.js"))
            {
                ScriptManager.RegisterClientScriptInclude(page, page.GetType(), "jquery-ui.min.js", ResolveClientUrl("~/dirJavascript/jquery-ui.min.js"));
            }
            LiteralControl lt1 = new LiteralControl();
            lt1.Text = "<link href=\"../dirStyle/jquery-ui.css\" rel=\"stylesheet\" type=\"text/css\" />";
            if (!UCTXHelper.IsControlInHeader(page, lt1))
            {
                page.Header.Controls.Add(lt1);
            }
            lt1 = new LiteralControl();
            lt1.Text = "<link href=\"../dirStyle/slider.css\" rel=\"stylesheet\" type=\"text/css\" />";
            if (!UCTXHelper.IsControlInHeader(page, lt1))
            {
                Page.Header.Controls.Add(lt1);
            }
        }

        private void AddJavascripts(Page page)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered("uctx_core"))
            {
                page.ClientScript.RegisterClientScriptInclude("uctx_core", ResolveClientUrl("~/dirJavascript/uctx_core.js"));
            }
            if (!page.ClientScript.IsClientScriptIncludeRegistered("video"))
            {
                page.ClientScript.RegisterClientScriptInclude("video", ResolveClientUrl("~/dirJavascript/video.js"));
            }
            if (!page.ClientScript.IsClientScriptIncludeRegistered("audio"))
            {
                page.ClientScript.RegisterClientScriptInclude("audio", ResolveClientUrl("~/dirJavascript/audio.js"));
            }
            if (!page.ClientScript.IsClientScriptIncludeRegistered("utils"))
            {
                page.ClientScript.RegisterClientScriptInclude("utils", ResolveClientUrl("~/dirJavascript/utils.js"));
            }
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("screen"))
            {
                page.ClientScript.RegisterClientScriptInclude("screen", ResolveClientUrl("~/dirJavascript/screen.js"));
            }
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("UCTXControls"))
            {
                page.ClientScript.RegisterClientScriptInclude("UCTXControls", ResolveClientUrl("~/dirJavascript/UCTXControls.js"));
            }
        }

        private void UpdateVolumeSliderEvents()
        {
            RunScript("InitSlider();");
        }

        private void UpdateAudioEvents(string confId, int incident)
        {
            string script = null;

            string samplesPerSec = ProxyHelper.GetSettingValueString("AudioSamplesPerSec", "PLATFORM");
            string speexQuality = ProxyHelper.GetSettingValueString("SpeexQuality", "PLATFORM");
            string audioOutputDeviceID = ProxyHelper.GetSettingValueString("AudioOutputDeviceID", "PLATFORM");
            string audioDeviceID = ProxyHelper.GetSettingValueString("VideoDeviceID", "PLATFORM");

			string fileName = AudioUploadHelper.GetFileName( incident, AudioUploadHelper.SOURCE_CALLCENTER);
            script = "StartAudioPublisher(6, " + confId + ", 2, 0, '" + audioDeviceID + "', '" + samplesPerSec + "', '" + speexQuality + "', '" + fileName + "', 'OnRefreshAudioPublisher');";
            ButtonAPStart.OnClientClick = "javascript:" + script + "return false;";
            RunScript(script);

            script = "StartAudioSubscriber(6, " + confId + ", 2, 1, 0, '" + audioOutputDeviceID + "', 'OnRefreshAudioSubscriber');";
            ButtonASStart.OnClientClick = "javascript:" + script + "return false;";
            RunScript(script);

            string scriptHold = string.Empty;
            script = "javascript:StopAudioPublisher('aspp6_" + confId + "_2_1');";
            scriptHold += script;
            ButtonAPStop.OnClientClick = script + "return false;";
            ButtonAPMute.OnClientClick = script + "return false;";

            script = "javascript:StopAudioSubscriber('auds6_" + confId + "_2_1_1');";
            scriptHold += script;
            ButtonASStop.OnClientClick = script + "return false;";
            ButtonASMute.OnClientClick = script + "return false;";

            ButtonASHold.OnClientClick = scriptHold + "return false;";
        }

        private void UpdateScreenEvents(string confId)
        {
            //ButtonSSNW.Visible = true;
            //string script = "javascript:window.open('../dirAgent/ScreenShare.aspx?confId=" + confId + "', 'ScreenCast', 'width=screen.width,height=screen.height,resizable=yes');return false;";
            //ButtonSSNW.Attributes.Add("OnClick", script);

            //Issue: We had next issue when screen share is opened in new window using java script "...window.open...". 
            //Reason: "Events "KeyDown" is not fired during remote control".
            //Solution: We used other way to open page. It's reference to document.
            hrefViewAppshare.Attributes.Add("href", "~/dirAgent/ScreenShare.aspx?confId=" + confId);

            string script = null;

            string scrpIDProcess = ProxyHelper.GetSettingValueString("ScreenIDProcess", "PLATFORM");
            string scrpDevice = ProxyHelper.GetSettingValueString("ScreenDevice", "PLATFORM");
            string scrpTypePixel = ProxyHelper.GetSettingValueString("ScreenTypePixel", "PLATFORM");

            script = "javascript:CleanupScreenSharingObjects();";
            script = script + string.Format("StartScreenPublisher(5, {0}, 2, 0, '{1}', '{2}', '{3}');", confId, scrpIDProcess, scrpDevice, scrpTypePixel);
            script = script + "SendAppshareStartedEvent(list_obj.conv.oid, '1', '2');return false;";
            ButtonStartAppShare.OnClientClick = script;

            script = "javascript:SendAppshareStoppedEvent(list_obj.conv.oid, '1', '2');";
            script = script + "CleanupScreenSharingObjects();return false;";
            ButtonStopAppShare.OnClientClick = script;
        }

        private void UpdateVideoEvents(string confId)
        {
            string script = null;

            string viewMethod = ProxyHelper.GetSettingValueString("VideoViewMethod", "PLATFORM");

            script = "javascript:StartVideoSubscriber(4, " + confId + ", 2, 1, 0, 'wye_uic_video_subscriber', " + viewMethod  + ",'OnRefreshVideoSubscriber');";
            ButtonStartVideoSubscr.OnClientClick = script + "return false;";
            RunScript(script);

            script = "javascript:StopVideoSubscriber('vids4_" + confId + "_2_1_1');";
            ButtonStopVideoSubscr.OnClientClick = script + "return false;";

            string theoraBitrate = ProxyHelper.GetSettingValueString("TheoraBitrate", "PLATFORM");
            string theoraQuality = ProxyHelper.GetSettingValueString("TheoraQuality", "PLATFORM");
            string theoraKeyframe = ProxyHelper.GetSettingValueString("TheoraKeyframe", "PLATFORM");
            string videoWidth = ProxyHelper.GetSettingValueString("VideoWidth", "PLATFORM");
            string videoHeight = ProxyHelper.GetSettingValueString("VideoHeight", "PLATFORM");
            string timePerFrame = ProxyHelper.GetSettingValueString("VideoTimePerFrame", "PLATFORM");
            string videoDeviceID = ProxyHelper.GetSettingValueString("VideoDeviceID", "PLATFORM");

            script = "javascript:StartVideoPublisher(4, " + confId + ", 2, 0, 'wye_uic_video_publisher'," + theoraBitrate + "," + theoraQuality + "," + theoraKeyframe + "," + videoWidth + "," + videoHeight + "," + timePerFrame + "," + videoDeviceID + ", 'OnRefreshVideoPublisher');";
            ButtonStartVideoPub.OnClientClick = script + "return false;";
            RunScript(script);

            script = "javascript:StopVideoPublisher('vthp4_" + confId + "_2_1');";
            ButtonStopVideoPub.OnClientClick = script + "return false;";
        }

        private void RunScript(string script)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), script, script, true);
        }

    }
}