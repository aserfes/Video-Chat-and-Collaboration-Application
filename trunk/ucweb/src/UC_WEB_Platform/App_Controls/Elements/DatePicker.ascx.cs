using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

using UCENTRIK.LIB.Base;

namespace UcentrikWeb.App_Controls.Elements
{
    public partial class DatePicker : UcAppBaseControl
    {
        protected DateTime date = DateTime.Now;

        public DateTime Date
        {
            set
            {
                this.date = value;
                updateDate();
            }
            get
            {
                return this.getDate();
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                updateDate();
            }
        }


        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int year = Convert.ToInt32(ddlYear.SelectedValue);
            //int month = Convert.ToInt32(ddlMonth.SelectedValue);
            //int day = Convert.ToInt32(ddlDay.SelectedValue);

            this.date = this.getDate();

            updateDate();
        }


        protected DateTime getDate()
        {
            int year = Convert.ToInt32(ddlYear.SelectedValue);
            int month = Convert.ToInt32(ddlMonth.SelectedValue);
            int day = Convert.ToInt32(ddlDay.SelectedValue);

            //this.date = new DateTime(year, month, day);


            if (day > DateTime.DaysInMonth(year, month))
                day = DateTime.DaysInMonth(year, month);


            return new DateTime(year, month, day);
        }

        protected void updateDate()
        {

            ddlYear.Items.Clear();
            ddlMonth.Items.Clear();
            ddlDay.Items.Clear();


            //ddlYear.ClearSelection();
            //ddlMonth.ClearSelection();
            //ddlDay.ClearSelection();


            for (int i = 1; i <= DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                if (i == date.Day)
                    item.Selected = true;
                ddlDay.Items.Add(item);
            }
            for (int i = 1; i <= 12; i++)
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                ListItem item = new ListItem(monthName, i.ToString());
                if (i == date.Month)
                    item.Selected = true;
                ddlMonth.Items.Add(item);
            }
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 5; i--)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                if (i == date.Year)
                    item.Selected = true;
                ddlYear.Items.Add(item);
            }

        }



    }
}