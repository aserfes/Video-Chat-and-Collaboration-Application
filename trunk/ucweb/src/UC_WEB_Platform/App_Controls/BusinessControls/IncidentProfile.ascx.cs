using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;





using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.LIB.Base; 
using UCENTRIK.Helpers;
using UCENTRIK.LIB.CoreSystem;

using UCENTRIK.LIB.Model;
using System.IO;



namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class IncidentProfile : UcAppBaseProfileControl
    {
        //-----------------------------------------------------------------------------------------------


        protected string regularButton = "Button";
        protected string selectedButton = "SelectedButton";



        public Int32 IncidentId
        {
            set
            {
                profileId = value;

                EditIncident.IsStatusChangeable = !this.readOnly;
                EditContact.IsContactChangeable = !this.readOnly;
                InfoAboutCall.IsStatusChangeable = !this.readOnly;

                mvOpenSession.ActiveViewIndex = 0;
                if (menuIncidentTabs.Items.Count > 0)
                    menuIncidentTabs.Items[0].Selected = true;

                
                EditIncident.IncidentId = profileId;
                InfoAboutCall.IncidentId = profileId;
                
                Int32 contactId = EditIncident.ContactId;
                EditContact.ContactId = contactId;
                if (contactId == 0)
                    EditContact.ContactDefined = false;
                else
                    EditContact.ContactDefined = true;

                
            }
        }





        private bool _allowConference = false;
        public bool AllowConference
        {
            set
            {
                this._allowConference = value;

                //EditIncident.IsStatusChangeable = this._allowConference;
                //EditContact.IsContactChangeable = this._allowConference;

                //btnSave.Visible = this._allowConference;
            }
        }

        protected void btnCloseAndExit_Click(object sender, EventArgs e)
        {
            if (this.isApprovedToModify)
            {
                EditIncident.SetCloseStatus();
                save();
            }
        }











        //---------------------------------------------------------------------------------
        protected void Page_Init(object sender, EventArgs e)
        {
            EditIncident.ReadOnly = this.readOnly;
            EditContact.ReadOnly = this.readOnly;
            InfoAboutCall.ReadOnly = this.readOnly;

            //EditIncident.IsStatusChangeable = !this.readOnly;
            //EditContact.IsContactChangeable = !this.readOnly;
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            //EditIncident.IsStatusChangeable = !this.readOnly;
            //EditContact.IsContactChangeable = !this.readOnly;

            btnSave.Visible = !this.readOnly;
            ButtonCloseAndExit.Visible = !this.readOnly;
            ButtonSaveAndExit.Visible = !this.readOnly;

            if (!this.IsPostBack)
            {
                MenuItem menuItem0 = new MenuItem("Call", "0");
                MenuItem menuItem1 = new MenuItem("Contact", "1");

                //MenuItem menuItem2 = new MenuItem("Video Chat", "2");
                MenuItem menuItem3 = new MenuItem("Text Chat", "3");
                
                //MenuItem menuItem4 = new MenuItem("Screen Cast", "4");
                MenuItem menuItem5 = new MenuItem("Transfer", "5");

                MenuItem menuItem6 = new MenuItem("Notes", "6");
                
                MenuItem menuItem7 = new MenuItem("AppShare Send", "7");
                MenuItem menuItem8 = new MenuItem("AppShare Receive", "8");


                MenuItem menuItemTest = new MenuItem("CTX", "9");




                menuItem0.Selected = true;


                menuIncidentTabs.Items.Add(menuItem0);
                menuIncidentTabs.Items.Add(menuItem1);
                //menuIncidentTabs.Items.Add(menuItem2);


                if (this._allowConference)
                {
                    menuIncidentTabs.Items.Add(menuItem3);
                    //menuIncidentTabs.Items.Add(menuItem4);
                    menuIncidentTabs.Items.Add(menuItem5);
                }


                
                menuIncidentTabs.Items.Add(menuItem6);

                ////--------------------------------------
                //menuIncidentTabs.Items.Add(menuItem7);
                //menuIncidentTabs.Items.Add(menuItem8);
                ////--------------------------------------


//                menuIncidentTabs.Items.Add(menuItemTest);
            }









            EditIncident.ReadOnly = this.readOnly;
            EditContact.ReadOnly = this.readOnly;
            InfoAboutCall.ReadOnly = this.readOnly;


            if (!this.Page.IsPostBack)
                Session.Remove(Utility.ConferenceStartupParametersSessionVariableName);
        }





        protected void mvOpenSession_ActiveViewChanged(object sender, EventArgs e)
        {
            switch (mvOpenSession.ActiveViewIndex)
            {
                case 0: // Incident details
                    selectIncident();
                    break;

                case 1: // Contact details
                    selectContact();
                    break;

                //case 2: // Video session
                //    selectConference();
                //    break;

                case 3: // Text Chat
                    selectTextChat();
                    break;


                //case 4: // Screen cast
                //    selectScreenCast();
                //    break;

                
                
                
                
                

                case 5: // Transfer
                    selectTransfer();
                    break;


                case 6: // Notes
                    selectNotes();
                    break;
                
                
                
                
                
                case 7: // AppShare send
                    selectAppShareSend();
                    break;

                case 8: // AppShare receive
                    selectAppShareReceive();
                    break;


                    
                    


                default:
                    IncidentHelper.SetIncidentStateInactive(profileId);
                    break;
            }






        }





        #region [SELECT TAB FUNCTIONS]

        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------

        protected void selectIncident()
        {
            //0:Incident details
            IncidentHelper.SetIncidentStateActive(profileId);
        }

        protected void selectContact()
        {
            //1:Contact details
            IncidentHelper.SetIncidentStateActive(profileId);
        }

        protected void selectTextChat()
        {
            //2:Text Chat


            string agentName = "";
            string conferenceName = "";

            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(profileId);
            if (dt.Rows.Count != 0)
            {
                conferenceName = dt[0].incident_guid.ToString();
                agentName = dt[0].agent_full_name;
            }


            if (this.UcPage.UserRoleId != 2)   // Agent
            {
                UserDS.UserDSDataTable dtU = BllProxyUser.SelectUser(this.UcPage.UserId);
                if (dtU.Rows.Count != 0)
                {
                    string userRoleTitle = "";


                    switch (this.UcPage.UserRoleId)
                    {
                        case 1: // Administrator
                            userRoleTitle = "ADMN";
                            break;

                        case 2: // Agent
                            userRoleTitle = "AGNT";
                            break;

                        case 3: // Manager
                            userRoleTitle = "MNGR";
                            break;

                        case 4: // User
                            userRoleTitle = "USER";
                            break;

                        case 5: // Supervisor
                            userRoleTitle = "SPVR";
                            break;
                    }


                    agentName = dtU[0].full_name + " [" + userRoleTitle + "]";
                }
            }


            TextChatControl.ConfSessionId = conferenceName;
            TextChatControl.ConfSessionUser = agentName;


            IncidentHelper.SetIncidentStateTextChat(profileId);
        }

        protected void selectConference()
        {
            //case 3: // Video session

            Guid sessionGUID = new Guid();
            string agentName = "";

            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(profileId);
            if (dt.Rows.Count != 0)
            {
                sessionGUID = dt[0].incident_guid;
                agentName = dt[0].agent_full_name;
            }



            String conferenceName = sessionGUID.ToString();


            ConferenceStartupParameters parameters = ConferenceHelper.GetParametersForMultiVideo(conferenceName, "USER");


            string tempConferenceName = Convert.ToString(1000000 + profileId);
            parameters.ConferenceName = tempConferenceName;
            //VideoChatControl.Parameters = parameters;

            IncidentHelper.SetIncidentStateVideoSession(profileId);
        }

        protected void selectScreenCast()
        {
            //4:Screen cast

            Guid guid = new Guid();
            string agentName = "";

            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(profileId);
            if (dt.Rows.Count != 0)
            {
                guid = dt[0].incident_guid;
                agentName = dt[0].agent_full_name;
            }

            String conferenceName = guid.ToString();


            ConferenceStartupParameters parameters = ConferenceHelper.GetParametersForScreenCast(conferenceName, agentName, true);


            //parameters.ShouldCreateConference = false;
            //parameters.ShouldStartAppShare = false;
            //parameters.UseJavascript = false;

            //string tempConferenceName = Convert.ToString(1000000 + profileId);
            //parameters.ConferenceName = tempConferenceName;


            IncidentHelper.SetIncidentStateScreenCast(profileId);
        }

        protected void selectNotes()
        {
            //5:Notes

            NoteControl.IncidentId = this.profileId;
            IncidentHelper.SetIncidentStateActive(profileId);
        }

        protected void selectTransfer()
        {
            //6:Transfer

            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(profileId);
            if (dt.Rows.Count != 0)
            {
                statusId = dt[0].status_id;
            }

            TransferIncident.IncidentId = this.profileId;
            TransferIncident.StatusId = this.statusId;
            IncidentHelper.SetIncidentStateActive(profileId);
        }

        protected void selectAppShareSend()
        {
            //7:AppShare send
            IncidentHelper.SetIncidentStateAppShareSend(profileId);
        }

        protected void selectAppShareReceive()
        {
            //8:AppShare receive
            IncidentHelper.SetIncidentStateAppShareReceive(profileId);
        }



        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------

        #endregion
























        /////---------------------------------------------------------------------------------



        protected override void save()
        {
            EditContact.Save();
            Int32 contactId = EditContact.ContactId;

            if ((contactId == 0) && (!EditContact.IsAnonymous))
            {
                this.showErrorMessage("Contact must be defined!");
                mvOpenSession.ActiveViewIndex = 1;
            }
            else
            {
                IncidentHelper.SetIncidentStateInactive(profileId);
                EditIncident.Save(contactId);
                InfoAboutCall.Save();
                
                UcControlArgs args = new UcControlArgs();
                dataSaved(args);

                SaveAudioRecord();
            }
        }

        private void SaveAudioRecord()
        {
            if (profileId != 0)
            {
				AudioUploadHelper.StartUploadInNewWindow( Page, profileId, AudioUploadHelper.SOURCE_CALLCENTER);
            }
        }
        
        public override void ClearControlData()
        {
            EditContact.ClearControlData();
            EditIncident.ClearControlData();
            InfoAboutCall.ClearControlData();
        }

        
        protected void TransferIncident_Next(object sender, UcControlArgs args)
        {
            //EditIncident.Refresh();
            goBack(args);
        }

        
        protected void menuIncidentTabs_MenuItemClick(object sender, MenuEventArgs e)
        {
            Int32 i = Int32.Parse(e.Item.Value);
            mvOpenSession.ActiveViewIndex = i;

            e.Item.Selected = true;
        }







        //---
    }
}

