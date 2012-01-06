using System;
using System.Collections.Generic;
using System.Web;
//using UCENTRIK.LIB.Properties;

//using UCENTRIK.LIB.BllProxy;

namespace UCENTRIK.LIB.Model
{
    public class ConferenceStartupParameters : ICloneable
    {
        private string _userName;
        private string _userType;
        private string _conferenceName;
        private bool _useJavascript;
        private bool _shouldStartAppShare;
        private bool _shouldCreateConference;
        private bool _showVideoSelection;
        private int _videoWidth;
        private int _videoHeight;
        private int _videoFPS;
        private int _videoBandwidth;
        private int _videoQuality;
        private int _appSharevideoWidth;
        private int _appSharevideoHeight;
        private int _appSharevideoFPS;
        private int _appSharevideoBandwidth;
        private int _appSharevideoQuality;
        private bool _sendMicSound;
        private bool _receiveSound;
        private int _screenVideoWidth;
        private int _screenVideoHeight;
        private bool _keepAspectRatioForVideo;
        private bool _skipVideoPublishing;
        private bool _showVideoControlButtons;
        private bool _showAppShareControlButtons;
        private bool _forceCallbacks;
        private bool _resizeToFitParent;
        private bool _videoTransmitterMode;
        private bool _videoReceiverMode;
        private bool _receiveVideoOnlyOnExplicitCall;
        private string _userToReceive;
        private string _userToSkip;
        private string _backgroundColor;




        public int AppSharevideoWidth
        {
            get { return _appSharevideoWidth; }
            set { _appSharevideoWidth = value; }
        }

        public int AppSharevideoHeight
        {
            get { return _appSharevideoHeight; }
            set { _appSharevideoHeight = value; }
        }

        public int AppSharevideoFPS
        {
            get { return _appSharevideoFPS; }
            set { _appSharevideoFPS = value; }
        }

        public int AppSharevideoBandwidth
        {
            get { return _appSharevideoBandwidth; }
            set { _appSharevideoBandwidth = value; }
        }

        public int AppSharevideoQuality
        {
            get { return _appSharevideoQuality; }
            set { _appSharevideoQuality = value; }
        }

        public bool ShouldCreateConference
        {
            get { return _shouldCreateConference; }
            set { _shouldCreateConference = value; }
        }

        public int VideoWidth
        {
            get { return _videoWidth; }
            set { _videoWidth = value; }
        }

        public int VideoHeight
        {
            get { return _videoHeight; }
            set { _videoHeight = value; }
        }

        public int VideoFPS
        {
            get { return _videoFPS; }
            set { _videoFPS = value; }
        }

        public bool ShouldStartAppShare
        {
            get { return _shouldStartAppShare; }
            set { _shouldStartAppShare = value; }
        }

        public string ConferenceName
        {
            get { return _conferenceName; }
            set { _conferenceName = value; }
        }

        public string ServerUrl
        {
            get
            {
                //return Settings.Default.ServerUrl;
                //return ProxyHelper.GetSettingValueString("ServerUrl");
                return "rtmpt://media01.soslivecoach.com:80/SosVideoServer1";
            }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        public int VideoBandwidth
        {
            get { return _videoBandwidth; }
            set { _videoBandwidth = value; }
        }

        public int VideoQuality
        {
            get { return _videoQuality; }
            set { _videoQuality = value; }
        }

        public bool UseJavascript
        {
            get { return _useJavascript; }
            set { _useJavascript = value; }
        }

        public bool ShowVideoSelection
        {
            get { return _showVideoSelection; }
            set { _showVideoSelection = value; }
        }

        public bool SendMicSound
        {
            get { return _sendMicSound; }
            set { _sendMicSound = value; }
        }

        public bool ReceiveSound
        {
            get { return _receiveSound; }
            set { _receiveSound = value; }
        }

        public String CrmUserName
        {
            get
            {
                //return Settings.Default.CrmUserName;
                //return ProxyHelper.GetSettingValueString("CrmUserName");
                return @"admin";
            }
        }

        public String CrmUserPassword
        {
            get
            {
                //return Settings.Default.CrmUserPassword;
                //return ProxyHelper.GetSettingValueString("CrmUserPassword");
                return @"admin";
            }
        }

        public String CrmServiceUrl
        {
            get
            {
                //return Settings.Default.CrmServiceUrl;
                //return ProxyHelper.GetSettingValueString("CrmServiceUrl");
                return @"http://licensing.soslivecoach.com/CRM/CRMService.asmx";
            }
        }

        public String LoginServiceUrl
        {
            get
            {
                //return Settings.Default.LoginServiceUrl;
                //return ProxyHelper.GetSettingValueString("LoginServiceUrl");
                return @"http://licensing.soslivecoach.com/CRM/LoginService.asmx";
            }
        }

        public bool IgnoreCrm
        {
            get
            {
                return true;
            }
        }

        public int ScreenVideoWidth
        {
            get { return _screenVideoWidth; }
            set { _screenVideoWidth = value; }
        }

        public int ScreenVideoHeight
        {
            get { return _screenVideoHeight; }
            set { _screenVideoHeight = value; }
        }

        public bool KeepAspectRatioForVideo
        {
            get { return _keepAspectRatioForVideo; }
            set { _keepAspectRatioForVideo = value; }
        }

        public bool SkipVideoPublishing
        {
            get { return _skipVideoPublishing; }
            set { _skipVideoPublishing = value; }
        }

        public bool ShowVideoControlButtons
        {
            get { return _showVideoControlButtons; }
            set { _showVideoControlButtons = value; }
        }

        public bool ShowAppShareControlButtons
        {
            get { return _showAppShareControlButtons; }
            set { _showAppShareControlButtons = value; }
        }

        public bool ForceCallbacks
        {
            get { return _forceCallbacks; }
            set { _forceCallbacks = value; }
        }

        public bool ResizeToFitParent
        {
            get { return _resizeToFitParent; }
            set { _resizeToFitParent = value; }
        }

        public bool VideoTransmitterMode
        {
            get { return _videoTransmitterMode; }
            set { _videoTransmitterMode = value; }
        }

        public bool VideoReceiverMode
        {
            get { return _videoReceiverMode; }
            set { _videoReceiverMode = value; }
        }

        public bool ReceiveVideoOnlyOnExplicitCall
        {
            get { return _receiveVideoOnlyOnExplicitCall; }
            set { _receiveVideoOnlyOnExplicitCall = value; }
        }

        public string UserToReceive
        {
            get { return _userToReceive; }
            set { _userToReceive = value; }
        }

        public string UserToSkip
        {
            get { return _userToSkip; }
            set { _userToSkip = value; }
        }

        public string BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        #region ICloneable Members

        public object Clone()
        {
            ConferenceStartupParameters clone = new ConferenceStartupParameters();
            clone.AppSharevideoBandwidth = this.AppSharevideoBandwidth;
            clone.AppSharevideoFPS = this.AppSharevideoFPS;
            clone.AppSharevideoHeight = this.AppSharevideoHeight;
            clone.AppSharevideoQuality = this.AppSharevideoQuality;
            clone.AppSharevideoWidth = this.AppSharevideoWidth;
            clone.ConferenceName = this.ConferenceName;
            clone.ForceCallbacks = this.ForceCallbacks;
            clone.KeepAspectRatioForVideo = this.KeepAspectRatioForVideo;
            clone.ReceiveSound = this.ReceiveSound;
            clone.ResizeToFitParent = this.ResizeToFitParent;
            clone.ScreenVideoHeight = this.ScreenVideoHeight;
            clone.ScreenVideoWidth = this.ScreenVideoWidth;
            clone.SendMicSound = this.SendMicSound;
            clone.ShouldCreateConference = this.ShouldCreateConference;
            clone.ShouldStartAppShare = this.ShouldStartAppShare;
            clone.ShowAppShareControlButtons = this.ShowAppShareControlButtons;
            clone.ShowVideoControlButtons = this.ShowVideoControlButtons;
            clone.ShowVideoSelection = this.ShowVideoSelection;
            clone.SkipVideoPublishing = this.SkipVideoPublishing;
            clone.UseJavascript = this.UseJavascript;
            clone.UserName = this.UserName;
            clone.UserType = this.UserType;
            clone.UserToReceive = this.UserToReceive;
            clone.UserToSkip = this.UserToSkip;
            clone.VideoBandwidth = this.VideoBandwidth;
            clone.VideoFPS = this.VideoFPS;
            clone.VideoHeight = this.VideoHeight;
            clone.VideoQuality = this.VideoQuality;
            clone.VideoReceiverMode = this.VideoReceiverMode;
            clone.VideoTransmitterMode = this.VideoTransmitterMode;
            clone.ReceiveVideoOnlyOnExplicitCall = this.ReceiveVideoOnlyOnExplicitCall;
            clone.VideoWidth = this.VideoWidth;
            clone.BackgroundColor = this.BackgroundColor;

            return clone;
        }

        #endregion
    }


    public static class ConferenceHelper
    {

        //----------------------------------------------------------------------------------------
        public static ConferenceStartupParameters GetParameters(string conferenceName, string userName)
        {
            ConferenceStartupParameters parameters = new ConferenceStartupParameters();

            parameters.ConferenceName = conferenceName;
            parameters.UserName = userName;

            parameters.UserType = "Client";

            parameters.ShouldCreateConference = false;

            parameters.VideoWidth = 640;    // 320;
            parameters.VideoHeight = 480;   // 240;
            parameters.VideoFPS = 20;               //
            parameters.VideoBandwidth = 0;          //56000
            parameters.VideoQuality = 80;           //

            parameters.AppSharevideoWidth = 800;
            parameters.AppSharevideoHeight = 600;
            parameters.AppSharevideoFPS = 20;       //
            parameters.AppSharevideoBandwidth = 0;  //
            parameters.AppSharevideoQuality = 100;  //

            parameters.ShouldStartAppShare = false;

            parameters.UseJavascript = true;

            parameters.ShowVideoSelection = false;
            parameters.SendMicSound = false;            //
            parameters.ReceiveSound = false;            //

            parameters.ScreenVideoWidth = 320;  // 640;
            parameters.ScreenVideoHeight = 240; // 480;

            parameters.VideoTransmitterMode = false;    //
            parameters.VideoReceiverMode = false;        //

//            parameters.UseJavascript = true;

            parameters.KeepAspectRatioForVideo = true;






            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            parameters.VideoFPS = 30;
            parameters.VideoBandwidth = 0;
            parameters.VideoQuality = 80;


            parameters.AppSharevideoFPS = 5;
            parameters.AppSharevideoBandwidth = 0;
            parameters.AppSharevideoQuality = 80;
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=



            parameters.BackgroundColor = "#C4C4C4";


            return parameters;

        }

        public static ConferenceStartupParameters GetParametersForReceiver(string conferenceName, string userName, string userNameToSkip)
        {
            ConferenceStartupParameters parameters = GetParameters(conferenceName, userName);

            parameters.UserToSkip = userNameToSkip;
            parameters.VideoReceiverMode = true;
            parameters.ReceiveSound = true;
            parameters.SendMicSound = true;


            //parameters.BackgroundColor = "#0b0b0b";

            return parameters;
        }
        public static ConferenceStartupParameters GetParametersForTransmitter(string conferenceName, string userName)
        {
            ConferenceStartupParameters parameters = GetParameters(conferenceName, userName);

            parameters.UserType = "Coach";
            parameters.VideoTransmitterMode = true;
            parameters.ReceiveSound = true;
            parameters.SendMicSound = true;
            
            return parameters;
        }
        public static ConferenceStartupParameters GetParametersForMultiVideo(string conferenceName, string userName)
        {
            ConferenceStartupParameters parameters = GetParameters(conferenceName, userName);

            parameters.ReceiveSound = true;

            return parameters;
        }
        public static ConferenceStartupParameters GetParametersForScreenCast(string conferenceName, string userName, bool isToSend)
        {
            ConferenceStartupParameters parameters = GetParameters(conferenceName, userName);

            if (isToSend)
            {
                parameters.UserType = "Coach";
                parameters.ShouldStartAppShare = true;
            }

            return parameters;
        }
        //----------------------------------------------------------------------------------------




        //---
    }
}
