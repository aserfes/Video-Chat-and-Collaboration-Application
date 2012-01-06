using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

namespace UCENTRIK.WEB.KIOSK.Connect
{
    public partial class Error : UcKioskConnectBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void timerRefresh_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            DateTime last = new DateTime(t.Subtract(startTime).Ticks);
            TimeSpan span = t.Subtract(startTime);

            //ltTimeSpan.Text = string.Format("{0:00}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);
            //======================================================================


            TimeSpan max0 = new TimeSpan(0, 0, 5);

            if (TimeSpan.Compare(span, max0) > 0)
            {
                UcControlArgs args = new UcControlArgs();
                goNext(args);
            }
        }

        public void Start()
        {
            startTime = DateTime.Now;
        }

        public string Message 
        {
            set
            {
                LabelMessage.Text = value;
            }
        }
    }
}
