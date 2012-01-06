using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;

namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class QuestionProfile : UcAppBaseProfileDetailsControl
    {







        public Int32 QuestionId
        {
            set
            {
                profileId = value;

                if (profileId == 0)
                {
                    questinTypeId = 0;
                    dvControl.ChangeMode(DetailsViewMode.Insert);
                }
                else
                {
                    dvControl.ChangeMode(dvMode);

                    Parameter objAgentIdParameter = new Parameter("question_id", DbType.Int32);
                    objAgentIdParameter.DefaultValue = profileId.ToString();

                    objectdatasourceEdit.SelectParameters["question_id"] = objAgentIdParameter;
                }
            }
        }


        protected Int32 questinTypeId
        {
            get
            {
                Int32 _questinTypeId = 0;
                Object objViewStateQuestinTypeId = this.ViewState[this.ID + "QuestinTypeId"];
                if (objViewStateQuestinTypeId != null)
                    _questinTypeId = Convert.ToInt32(objViewStateQuestinTypeId);

                return _questinTypeId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "QuestinTypeId");
                this.ViewState.Add(this.ID + "QuestinTypeId", value);
            }
        }




















        ///---------------------------------------------------------------------------------
        ///---------------------------------------------------------------------------------
        protected void dvControl_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;
            DropDownList ddlQuestionTypes = (DropDownList)dv.FindControl("ddlQuestionTypes");

            HiddenField hf = (HiddenField)dv.FindControl("hfQuestionTypeId");

            if (hf.Value != "")
                questinTypeId = Convert.ToInt32(hf.Value);

            if (ddlQuestionTypes != null)
            {
                ddlQuestionTypes.DataSource = BllProxyLookup.GetQuestionTypes();
                ddlQuestionTypes.DataBind();

                ListItem item = new ListItem("select type", "0");
                ddlQuestionTypes.Items.Insert(0, item);



                ListItem currentItem = ddlQuestionTypes.Items.FindByValue(questinTypeId.ToString());

                if (currentItem != null)
                    currentItem.Selected = true;
                else
                    ddlQuestionTypes.Items.FindByValue("0").Selected = true;
            }


            if (this.ReadOnly)
            {
                dv.Rows[6].Visible = false;
            }
        }

        protected void dvControl_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            e.NewValues["type_id"] = questinTypeId;
        }



        protected void ddlQuestionTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            questinTypeId = Convert.ToInt32(ddl.SelectedValue);
        }


        /////---------------------------------------------------------------------------------






        protected override void save()
        {
            if (profileId == 0)
            {
                if (questinTypeId != 0)
                {
                    Parameter objSurveyQuestionIdParameter = new Parameter("type_id", DbType.Int32);
                    objSurveyQuestionIdParameter.DefaultValue = questinTypeId.ToString();
                    objectdatasourceEdit.InsertParameters["type_id"] = objSurveyQuestionIdParameter;

                    this.dvControl.InsertItem(true);
                }
                else
                {
                    this.showErrorMessage("Question Type cannot be left blank!");
                }
            }
            else
            {
                this.dvControl.UpdateItem(true);
            }

        }















        public override void ClearControlData()
        {

            TextBox txtQuestionText = dvControl.FindControl("txtQuestionText") as TextBox;
            if (txtQuestionText != null)
                txtQuestionText.Text = "";


            DropDownList ddlQuestionTypes = dvControl.FindControl("ddlQuestionTypes") as DropDownList;
            if (ddlQuestionTypes != null)
                ddlQuestionTypes.SelectedIndex = 0;

        }







        //---
    }
}


