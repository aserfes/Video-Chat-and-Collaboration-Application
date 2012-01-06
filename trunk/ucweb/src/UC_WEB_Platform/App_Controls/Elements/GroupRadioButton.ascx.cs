using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

using UCENTRIK.LIB.App_Controls.ServerControls;


namespace UCENTRIK.WEB.PLATFORM.App_Controls.Elements
{
    public partial class GroupRadioButton : System.Web.UI.UserControl
    {

        protected UcGroupRadioButton grb;

        public string UcText
        {
            set
            {
                this.grb.Text = value;
            }
        }
        public string UcValue
        {
            get
            {
                return this.grb.UcValue;
            }
            set
            {
                this.grb.UcValue = value;
            }
        }




        //        ///---------------------------------------------------------------------------------
        public event EventHandler Test;
        protected void test(object sender, EventArgs e)
        {
            if (Test != null)
                Test(this, e);
        }
        //        ///---------------------------------------------------------------------------------


        
        
        
        
        protected void Page_Init(object sender, EventArgs e)
        {
            this.grb = new UcGroupRadioButton();
            this.grb.CheckedChanged += test;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            phRadioButton.Controls.Add(grb);
        }







    }
}