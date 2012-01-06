using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

namespace UCENTRIK.WEB.KIOSK.Connect
{
    public partial class WaitScreen : UcKioskConnectBaseControl
    {
        protected Int32 timeOut = 30;

        public void Start()
        {
            string script = "window.resizeTo( 635, 390 )";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SetWaitScreenSize", script, true);

            //ltTimeSpan.Text = "";
            ltTimeSpan.Text = this.getTimeLeftText(0);

            startTime = DateTime.Now;
            pnlWait.Visible = true;
            pnlAgentsBusy.Visible = false;
            mode = 0;
        }

        protected Int32 mode
        {
            get
            {
                Int32 _mode = 0;
                Object objViewStateMode = this.ViewState[this.ID + "Mode"];
                if (objViewStateMode != null)
                    _mode = Convert.ToInt32(objViewStateMode);

                return _mode;
            }
            set
            {
                this.ViewState.Remove(this.ID + "Mode");
                this.ViewState.Add(this.ID + "Mode", value);
            }
        }

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

        //protected DateTime startTime
        //{
        //    get
        //    {
        //        DateTime _startTime = DateTime.Now;
        //        Object objViewStateStartTime = this.ViewState[this.ID + "StartTime"];
        //        if (objViewStateStartTime != null)
        //            _startTime = Convert.ToDateTime(objViewStateStartTime);

        //        return _startTime;
        //    }
        //    set
        //    {
        //        this.ViewState.Remove(this.ID + "StartTime");
        //        this.ViewState.Add(this.ID + "StartTime", value);
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            string script = "window.resizeTo( 500, 300 )";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SetWaitScreenSize", script, true);
        }

        protected void timerRefresh_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            DateTime last = new DateTime(t.Subtract(startTime).Ticks);
            TimeSpan span = t.Subtract(startTime);

//            //ltTimeSpan.Text = string.Format("{0:00}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);

            ltTimeSpan.Text = this.getTimeLeftText(span.Seconds);

            //======================================================================
            bool isSessionFinished = false;
            Int32 currentStatusId = BllProxyIncidentHelper.GetIncidentStatus(incidentId);

            if (currentStatusId != statusId)
            {
                UcControlArgs args = new UcControlArgs();
                switch (currentStatusId)
                {
                    case 1: //New
                        break;

                    case 2: //In-Progress
                        goNext(args);
                        break;

                    case 3: //Canceled
                        isSessionFinished = true;
                        goBack(args);
                        break;

                    case 4: //Closed
                        isSessionFinished = true;
                        goBack(args);
                        break;
                }

                statusId = currentStatusId;
            }
            //======================================================================

            TimeSpan max0 = new TimeSpan(0, 0, timeOut);
            TimeSpan max1 = new TimeSpan(0, 1, 0);

            if (TimeSpan.Compare(span, max0) > 0)
            {
                if (mode == 0)
                {
                    pnlWait.Visible = false;
                    pnlAgentsBusy.Visible = true;

                    upWork.Update();
                    mode = 1;
                }
            }

            if (TimeSpan.Compare(span, max1) > 0)
            {
                BllProxyIncidentHelper.SetIncidentStatus(incidentId, 3);

                isSessionFinished = true;
            }

            if (isSessionFinished)
            {
                BllProxyIncident.UpdateIncident(incidentId, 0, 0, 3, "[_EXPIRED_]");
                UcControlArgs args = new UcControlArgs();
                goBack(args);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BllProxyIncident.UpdateIncident(incidentId, 0, 0, 3, "[_INTERRUPTED_]");

            UcControlArgs args = new UcControlArgs();
            goBack(args);
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            ltTimeSpan.Text = this.getTimeLeftText(0);

            startTime = DateTime.Now;
            pnlWait.Visible = true;
            pnlAgentsBusy.Visible = false;
            mode = 0;

            BllProxyIncidentHelper.SetIncidentConnectCount(incidentId);

            upWork.Update();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ltTimeSpan.Text = "";

            BllProxyIncident.UpdateIncident(incidentId, 0, 0, 3, "[_ABANDONED_]");

            UcControlArgs args = new UcControlArgs();
            goBack(args);
        }

        //protected string getTimeLeftText(TimeSpan span)
        //{
        //    string result = "";





        //    if ((span < TimeSpan.FromSeconds(0)) || (span >= TimeSpan.FromSeconds(this.timeOut)))
        //    {
        //        //result = "More than " + timeOut.ToString() + " seconds left";
        //        result = "";
        //    }
        //    else
        //    {
        //        if (span > TimeSpan.FromSeconds(1))
        //        {
        //            int secLeft = this.timeOut - span.Seconds;
        //            result = secLeft.ToString() + " seconds left";
        //        }
        //        else
        //        {
        //            result = "1 second left";
        //        }


        //        //result = string.Format("{0:00}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);
        //    }



        //    return result;
        //}

        protected string getTimeLeftText(Int32 spanSeconds)
        {
            string result = "";

            if ((spanSeconds < 0) || (spanSeconds >= this.timeOut))
            {
                //result = "... " + spanSeconds.ToString();
                result = "";
            }
            else
            {
                int secLeft = this.timeOut - spanSeconds;

                if (secLeft == 1)
                    result = "1 second left";
                else
                    result = secLeft.ToString() + " seconds left";

                //result = string.Format("{0:00}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);
            }


            return result;
        }
    }
}
