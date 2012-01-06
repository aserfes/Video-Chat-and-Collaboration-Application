using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;
using System.Configuration;
using System.IO;

namespace UCENTRIK.WEB.KIOSK.Connect
{
    public partial class Home : UcKioskConnectBaseControl
    {
        protected bool isKioskOpen
        {
            get
            {
                bool _isKioskOpen = false;
                Object objViewStateIsKioskOpen = this.ViewState[this.ID + "IsKioskOpen"];
                if (objViewStateIsKioskOpen != null)
                    _isKioskOpen = Convert.ToBoolean(objViewStateIsKioskOpen);

                return _isKioskOpen;
            }
            set
            {
                this.ViewState.Remove(this.ID + "IsKioskOpen");
                this.ViewState.Add(this.ID + "IsKioskOpen", value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                ltMessage.Text = "Kiosk is closed";

                FacilityDS.FacilityGroupDSDataTable dt = BllProxyFacilityGroup.GetAllFacilityGroups(this.FacilityId);
                FacilityDS.FacilityGroupDSRow[] rows = (FacilityDS.FacilityGroupDSRow[])dt.Select("facility_id is not NULL");
                rptGroups.DataSource = rows;
                rptGroups.DataBind();

                SkillDS.SkillDSDataTable dtSkills = BllProxySkill.GetSkillList(0);
                ddlSkill.DataSource = dtSkills.Rows;
                ddlSkill.DataBind();
                if (ddlSkill.Items.Count > 0)
                {
                    ddlSkill.Items[0].Selected = true;
                }

                LanguageDS.LanguageDSDataTable dtLanguages = BllProxyLanguage.GetLanguageList(0);
                ddlLanguage.DataSource = dtLanguages.Rows;
                ddlLanguage.DataBind();
                if (ddlLanguage.Items.Count > 0)
                {
                    ddlLanguage.Items[0].Selected = true;
                }

                //btnStart.Enabled = false;
                //rptGroups.Enabled = false;
                foreach (Control c in rptGroups.Items)
                {
                    Button btn = (Button)c.FindControl("btnStart");
                    btn.Enabled = false;
                }

                pnlKioskInactive.Visible = false;
                pnlKioskOpen.Visible = false;
                pnlKioskClosed.Visible = true;

                Start(2);
            }
        }

        protected void timerRefresh_Tick(object sender, EventArgs e)
        {
            ltTimeSpan.Text = DateTime.Now.ToLongTimeString();

            if (checkKioskOpen())
            {
                if (!isKioskOpen)
                {
                    ltMessage.Text = "Kiosk is open";


                    //btnStart.Enabled = true;
                    //rptGroups.Enabled = true;
                    foreach (Control c in rptGroups.Items)
                    {
                        Button btn = (Button)c.FindControl("btnStart");
                        btn.Enabled = true;
                    }


                    pnlKioskInactive.Visible = false;
                    pnlKioskOpen.Visible = true;
                    pnlKioskClosed.Visible = false;

                    isKioskOpen = true;
                    upWork.Update();
                }
            }
            else
            {
                if (isKioskOpen)
                {
                    ltMessage.Text = "Kiosk is closed";


                    //btnStart.Enabled = false;
                    //rptGroups.Enabled = false;
                    foreach (Control c in rptGroups.Items)
                    {
                        Button btn = (Button)c.FindControl("btnStart");
                        btn.Enabled = false;
                    }


                    pnlKioskInactive.Visible = false;
                    pnlKioskOpen.Visible = false;
                    pnlKioskClosed.Visible = true;

                    isKioskOpen = false;
                    upWork.Update();
                }
            }
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Int32 groupId = Convert.ToInt32(btn.CommandArgument);

            Start(groupId);
        }

        private void Start(Int32 groupId)
        {
            //Int32 skillID = 0;
            //if (!string.IsNullOrEmpty(ddlSkill.SelectedValue))
            //{
            //    skillID = Convert.ToInt32(ddlSkill.SelectedValue);
            //}
            //Int32 langID = 0;
            //if (!string.IsNullOrEmpty(ddlLanguage.SelectedValue))
            //{
            //    langID = Convert.ToInt32(ddlLanguage.SelectedValue);
            //}


            Int32 skillID = 0;
            Int32.TryParse(Session["skillID"] as string, out skillID);
            Int32 langID = 0;
            Int32.TryParse(Session["langID"] as string, out langID);
            Int32.TryParse(Session["groupId"] as string, out groupId);

            UcControlArgs args = new UcControlArgs();
            if (skillID == 0 || langID == 0 || groupId == 0)
            {
                args.Message = "Skill, Language and Group must be defined";
                args.Cancel = true;

                handleError(args);
                return;
            }

            Int32 incidentId = BllProxyIncident.InsertIncident(groupId, skillID, langID, this.FacilityId, 0, 0);

            if (incidentId != 0)
            {
                string screenUserHelp = null;
                string consName = null;
                string deviceMake = null;
                string deviceModel = null;
                int deviceValue = 0;
                string deviceType = null;
                string kioskID = null;
                string kioskName = null;
                string kioskLocation = null;
                string transactValue = null;
                bool transactCompletion = false;
                byte[] inspectorBin = null;
                byte[] driverLicense = null;
                byte[] idCard = null;

                try
                {
                    kioskID = Session["kioskID"] as string;
                    kioskName = Session["kioskName"] as string;
                    kioskLocation = Session["kioskLocation"] as string;

                    screenUserHelp = ConfigurationManager.AppSettings["screenUserHelp"];
					consName = Session[ "kioskUser" ] as string;
					if( string.IsNullOrEmpty( consName ) )
						consName = ConfigurationManager.AppSettings[ "consumerName" ];
                    deviceMake = ConfigurationManager.AppSettings["deviceMake"];
                    deviceModel = ConfigurationManager.AppSettings["deviceModel"];
                    deviceValue = Int32.Parse(ConfigurationManager.AppSettings["deviceValue"]);
                    deviceType = ConfigurationManager.AppSettings["deviceType"];
                    transactValue = ConfigurationManager.AppSettings["transactValue"];
                    transactCompletion = Boolean.Parse(ConfigurationManager.AppSettings["transactCompletion"]);

                    string imagePath = null;

                    imagePath = ConfigurationManager.AppSettings["idCard"];
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        idCard = ReadDataFromFile(imagePath);
                    }
                    imagePath = ConfigurationManager.AppSettings["inspectorBin"];
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        inspectorBin = ReadDataFromFile(imagePath);
                    }
                    imagePath = ConfigurationManager.AppSettings["driverLicense"];
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        driverLicense = ReadDataFromFile(imagePath);
                    }
                }
                catch
                {
                    args.Message = "Get data from Kiosk is failed.";
                    args.Cancel = true;
                }

                BllProxyLog.InsertLog(incidentId,
                                        consName,
                                        deviceMake,
                                        deviceModel,
                                        deviceValue,
                                        deviceType,
                                        kioskID,
                                        kioskName,
                                        kioskLocation,
                                        idCard,
                                        inspectorBin,
                                        driverLicense,
                                        transactValue,
                                        transactCompletion,
                                        screenUserHelp,
										"");

                if (args.Cancel)
                {
                    handleError(args);
                }
                else
                {
                    args.Id = incidentId;
                    goNext(args);
                }
            }
            else
            {
                args.Message = "Cannot create incident!";
                args.Cancel = true;

                handleError(args);
            }
        }

        private byte[] ReadDataFromFile(string path)
        {
            try
            {
                FileStream fs = File.OpenRead(path);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                return data;
            }
            catch
            {
                return null;
            }
        }

        protected bool checkKioskOpen()
        {
            bool result = false;

            FacilityDS.FacilityDSDataTable dt = BllProxyFacility.SelectFacility(this.FacilityId);
            if (dt.Rows.Count != 0)
            {
                result = dt[0].active;
            }
            return result;

            //if (DateTime.Now.Second < 50)
            //    return true;
            //else
            //    return false;
        }
    }
}
