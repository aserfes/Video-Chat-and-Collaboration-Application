using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.LIB.Model;


namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class FacilityProfile : UcAppBaseProfileDetailsControl
    {




//        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler ManageGroups;
        protected void manageGroups(object sender, UcControlArgs e)
        {
            if (ManageGroups != null)
                ManageGroups(this, e);
        }
//        ///---------------------------------------------------------------------------------







        protected Int32 userId
        {
            get
            {
                Int32 _userId = 0;
                Object objViewStateUserId = this.ViewState[this.ID + "UserId"];
                if (objViewStateUserId != null)
                    _userId = Convert.ToInt32(objViewStateUserId);

                return _userId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "UserId");
                this.ViewState.Add(this.ID + "UserId", value);
            }
        }



        protected Int32 surveyId
        {
            get
            {
                Int32 _surveyId = 0;
                Object objViewStateSurveyId = this.ViewState[this.ID + "SurveyId"];
                if (objViewStateSurveyId != null)
                    _surveyId = Convert.ToInt32(objViewStateSurveyId);

                return _surveyId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "SurveyId");
                this.ViewState.Add(this.ID + "SurveyId", value);
            }
        }




        //public Int32 FacilityId
        //{
        //    set
        //    {
        //        profileId = value;


        //        if (profileId == 0)
        //        {
        //            dvFacility.ChangeMode(DetailsViewMode.Insert);
        //        }
        //        else
        //        {
        //            dvFacility.ChangeMode(DetailsViewMode.Edit);

        //            Parameter objAgentIdParameter = new Parameter("facility_id", DbType.Int32);
        //            objAgentIdParameter.DefaultValue = profileId.ToString();

        //            objectdatasourceEdit.SelectParameters["facility_id"] = objAgentIdParameter;
        //            //objectdatasourceEdit.Select();
        //        }
        //    }
        //}




        public Int32 FacilityId
        {
            set
            {
                profileId = value;

                if (profileId == 0)
                {
                    userId = 0;
                    surveyId = 0;
                    dvControl.ChangeMode(DetailsViewMode.Insert);
                }
                else
                {
                    //dvControl.ChangeMode(DetailsViewMode.Edit);
                    dvControl.ChangeMode(dvMode);

                    Parameter objAgentIdParameter = new Parameter("facility_id", DbType.Int32);
                    objAgentIdParameter.DefaultValue = profileId.ToString();

                    objectdatasourceEdit.SelectParameters["facility_id"] = objAgentIdParameter;
                }
            }
        }





        
        protected Guid facilityGuid
        {
            get
            {
                Guid _facilityGuid = new Guid();
                Object objViewStateFacilityGuid = this.ViewState[this.ID + "FacilityGuid"];
                if (objViewStateFacilityGuid != null)
                    _facilityGuid = new Guid(Convert.ToString(objViewStateFacilityGuid));

                return _facilityGuid;
            }
            set
            {
                this.ViewState.Remove(this.ID + "FacilityGuid");
                this.ViewState.Add(this.ID + "FacilityGuid", value);
            }
        }


















        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public void Start()
        {




            //ConferenceStartupParameters parameters = new ConferenceStartupParameters();
            //parameters.ConferenceName = facilityGuid.ToString();
            //parameters.UserName = "Name";
            //parameters.UserType = "Client";
            //parameters.ShouldCreateConference = false;
            //parameters.VideoWidth = 160;    // 160-->182 (Panel Width   [+22] )
            //parameters.VideoHeight = 120;   // 120-->162 (Panel Height  [+42] )
            //parameters.VideoFPS = 20;
            //parameters.VideoBandwidth = 56000;
            //parameters.VideoQuality = 80;
            //parameters.AppSharevideoWidth = 640;
            //parameters.AppSharevideoHeight = 480;
            //parameters.AppSharevideoFPS = 10;
            //parameters.AppSharevideoBandwidth = 0;
            //parameters.AppSharevideoQuality = 100;
            //parameters.ShouldStartAppShare = false;
            //parameters.UseJavascript = false;
            //parameters.ShowVideoSelection = false;
            //parameters.SendMicSound = false;
            //parameters.ReceiveSound = false;
            //parameters.ScreenVideoWidth = 160;    // 160-->182 (Panel Width   [+22] )
            //parameters.ScreenVideoHeight = 120;   // 120-->162 (Panel Height  [+42] )
            //parameters.VideoTransmitterMode = false;
            //parameters.VideoReceiverMode = false;
            //parameters.UseJavascript = true;
            //parameters.KeepAspectRatioForVideo = false;




            string conferenceName = facilityGuid.ToString();
            ConferenceStartupParameters parameters1 = ConferenceHelper.GetParametersForReceiver(conferenceName, "KIOSK", "");
            ConferenceStartupParameters parameters2 = ConferenceHelper.GetParametersForScreenCast(conferenceName, "KIOSK", false);

            //ConfVideo.Parameters = parameters1;
            //ScreenCast.Parameters = parameters2;
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------




        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    this.Start();
        //}















        ///---------------------------------------------------------------------------------
        ///---------------------------------------------------------------------------------
        protected void dvControl_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;


            //----------------------------------------------------------------------
            DropDownList ddlManagers = (DropDownList)dv.FindControl("ddlManagers");

            HiddenField hfUser = (HiddenField)dv.FindControl("hfUserId");
            if (hfUser.Value == "")
                userId = 0;
            else
                userId = Convert.ToInt32(hfUser.Value);







            //----------------------------------------------------------------------
            HiddenField hfFacilityGuid = (HiddenField)dv.FindControl("hfFacilityGuid");
            if (hfFacilityGuid.Value == "")
                facilityGuid = new Guid();
            else
                facilityGuid = new Guid(Convert.ToString(hfFacilityGuid.Value));

            this.Start();
            //----------------------------------------------------------------------



            if (ddlManagers != null)
            {
                ddlManagers.DataSource = BllProxyUser.GetUsersByRole(3, 1);    // 3:Managers
                ddlManagers.DataBind();

                ListItem item = new ListItem("select user", "0");
                ddlManagers.Items.Insert(0, item);

                ListItem currentItem = ddlManagers.Items.FindByValue(userId.ToString());
                if (currentItem != null)
                    currentItem.Selected = true;
                else
                    ddlManagers.Items.FindByValue("0").Selected = true;
            }


            //----------------------------------------------------------------------
            DropDownList ddlSurvey = (DropDownList)dv.FindControl("ddlSurvey");
            HiddenField hfSurvey = (HiddenField)dv.FindControl("hfSurveyId");

            if (hfSurvey.Value == "")
                surveyId = 0;
            else
                surveyId = Convert.ToInt32(hfSurvey.Value);

            if (ddlSurvey != null)
            {
                ddlSurvey.DataSource = BllProxySurvey.GetAllSurveys();    // 3:Managers
                ddlSurvey.DataBind();

                ListItem item = new ListItem("select survey", "0");
                ddlSurvey.Items.Insert(0, item);

                ListItem currentItem = ddlSurvey.Items.FindByValue(surveyId.ToString());
                if (currentItem != null)
                    currentItem.Selected = true;
                else
                    ddlSurvey.Items.FindByValue("0").Selected = true;
            }




            if (this.ReadOnly)
            {
                dv.Rows[6].Visible = false;
            }

			bool is_command_visible = false;

			if( this.AllowManagement )
			{
				Control cntrl = dv.Rows[ 3 ].FindControl( "lbManageGroups" );
				LinkButton lb = cntrl as LinkButton;
				if( lb != null )
					lb.Visible = true;

				HiddenField hf_agent = dv.FindControl( "hfAgentId" ) as HiddenField;

				is_command_visible = hf_agent != null && !string.IsNullOrEmpty( hf_agent.Value );
			}

			dv.Rows[ dv.Rows.Count - 1 ].Visible = is_command_visible;
        }






        protected void dvControl_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            e.NewValues["user_id"] = userId;
            e.NewValues["survey_id"] = surveyId;
        } 





        /////---------------------------------------------------------------------------------
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //}

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //}

        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //}


        /////---------------------------------------------------------------------------------
       







        /////---------------------------------------------------------------------------------
        //protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        //{
        //}

        //protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        //{
        //}
        /////---------------------------------------------------------------------------------





        
        //protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    goBack(e);
        //}

        //protected void btnEditSave_Click(object sender, EventArgs e)
        //{
        //    if (profileId == 0)
        //    {
        //        objectdatasourceEdit.InsertParameters.Add("user_id", this.GetCurrentUserId().ToString());
        //        dvFacility.InsertItem(true);
        //    }
        //    else
        //    {
        //        dvFacility.UpdateItem(true);
        //    }

        //    goBack(e);
        //}



        protected void ddlManagers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            userId = Convert.ToInt32(ddl.SelectedValue);
        }





        protected void ddlSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            surveyId = Convert.ToInt32(ddl.SelectedValue);
        }




        protected override void save()
        {
            //if (userId != 0)
            //{

            FacilityDS.FacilityDSDataTable dt = BllProxyFacility.GetFacilityByUser(this.UcAppPage.UserId);





            bool isUserUnique = false;
            if (dt.Rows.Count != 0)
            {
                if (this.UcAppPage.UserId == dt[0].user_id)
                    isUserUnique = true;
            }
            else
            {
                isUserUnique = true;
            }






            if (isUserUnique)
            {
                try
                {

                    if (profileId == 0)
                    {
                        //if (userId == 0)
                        //    userId = this.GetCurrentUserId();

                        Parameter objUserIdParameter = new Parameter("user_id", DbType.Int32);
                        objUserIdParameter.DefaultValue = userId.ToString();
                        objectdatasourceEdit.InsertParameters["user_id"] = objUserIdParameter;


                        Parameter objSurveyIdParameter = new Parameter("survey_id", DbType.Int32);
                        objSurveyIdParameter.DefaultValue = surveyId.ToString();
                        objectdatasourceEdit.InsertParameters["survey_id"] = objSurveyIdParameter;


                        this.dvControl.InsertItem(true);
                    }
                    else
                    {
                        this.dvControl.UpdateItem(true);
                    }
                }
                catch
                {
                    this.showErrorMessage("Profile cannot be saved!");
                }
            }
            else
            {
                this.showErrorMessage("User is assigned to another Facility");
            }

            //}
            //else
            //{
            //    this.showErrorMessage("User cannot be left blank!");
            //}



        }












        protected void lbManageGroups_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;

            manageGroups(this, args);
        }


		protected void btn_release_Click( object sender, EventArgs e )
		{
			int facility_id = Convert.ToInt32( ( sender as LinkButton ).CommandArgument );
			BllProxyFacility.SetCommand( facility_id, 0, null );
			Refresh();
		}



        //protected string getSurveyById(object obj)
        //{
        //    string surveyName = "";
        //    Int32 surveyId = Convert.ToInt32(obj);
        //    SurveyDS.SurveyDSDataTable dt = BllProxySurvey.SelectSurvey(surveyId);
        //    if (dt.Rows.Count != 0)
        //        surveyName = dt[0].survey_name;

        //    return surveyName;
        //}









        public override void ClearControlData()
        {
            string[] ssTxt = new string[] {
                "txtFacility",
                "txtAddress",
                "txtPhone"
            };

            foreach (string s in ssTxt)
            {
                TextBox txt = dvControl.FindControl(s) as TextBox;
                if (txt != null)
                    txt.Text = "";
            }


            
            string[] ssDdl = new string[] {
                "ddlManagers",
                "ddlSurvey"
            };

            foreach (string s in ssDdl)
            {
                DropDownList ddl = dvControl.FindControl(s) as DropDownList;
                if (ddl != null)
                    ddl.SelectedIndex = 0;
            }





            CheckBox chkboxActive = dvControl.FindControl("chkboxActive") as CheckBox;
            if (chkboxActive != null)
                chkboxActive.Checked = false;


        }









        //-------------------------------------------------------------------

    }
}