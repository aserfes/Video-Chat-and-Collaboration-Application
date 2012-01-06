using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;

using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.LIB.Functions;




namespace UCENTRIK.WEB.PLATFORM.App_Controls.ASP
{
    public partial class NoteControl : UcAppBaseProfileControl
    {



        public Int32 IncidentId
        {
            set
            {
                this.incidentId = value;

                this.Update();
            }
        }
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




        public void Update()
        {
            pnlNotes.Visible = true;
            pnlNewNote.Visible = false;

            txtNote.Text = "";
            this.clearMessage();



            IncidentDS.IncidentNoteDSDataTable dt = BllProxyIncidentNote.GetAllIncidentNotes(this.incidentId);
            rptNote.DataSource = dt;
            rptNote.DataBind();


            if (dt.Rows.Count != 0)
            {
                rptNote.Visible = true;
                pnlEmpty.Visible = false;
            }
            else
            {
                rptNote.Visible = false;
                pnlEmpty.Visible = true;
            }


        }



        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //bool isAutoPostBack = Convert.ToBoolean(Context.Items["IsAutoPostBack"]);
            //if (isAutoPostBack)
            //    if(pnlNotes.Visible == true)
            //    this.Update();


            if (!this.IsPostBack)
                this.Update();

        }








        protected void btnAddNewNote_Click(object sender, EventArgs e)
        {
            pnlNotes.Visible = false;
            pnlNewNote.Visible = true;

            txtNote.Text = "";
            this.clearMessage();
        }


        protected void btnNewNoteCancel_Click(object sender, EventArgs e)
        {
            pnlNotes.Visible = true;
            pnlNewNote.Visible = false;

            txtNote.Text = "";
            this.clearMessage();
        }
        protected void btnNewNoteAdd_Click(object sender, EventArgs e)
        {
            string note = txtNote.Text;
            note = note.Trim();

            if (note != "")
            {
                BllProxyIncidentNote.InsertIncidentNote(this.incidentId, this.UcPage.UserId, note);
                this.Update();

                pnlNotes.Visible = true;
                pnlNewNote.Visible = false;

                txtNote.Text = "";
                this.showTextMessage("Note has been added");
            }
            else
            {
                this.showErrorMessage("Note cannot be left blank!");
            }

            
        }

















        protected string formatNote(object obj)
        {
            string result = "...";

            if (obj != null)
            {
                result = obj.ToString();
                result = TextFunctions.FormatFreeText(result, 50);
                result = TextFunctions.FormatLineBreaks(result);
            }

            return result;
        }






        

    }
}