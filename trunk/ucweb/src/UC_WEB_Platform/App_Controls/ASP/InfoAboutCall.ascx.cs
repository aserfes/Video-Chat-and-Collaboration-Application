using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using System.IO;
using UCENTRIK.Helpers;


namespace UCENTRIK.UserControls.ASP
{
    public partial class InfoAboutCall : UcAppBaseProfileDetailsControl
    {
        public Int32 IncidentId
        {
            set
            {
                profileId = value;

                if ((!this.readOnly) && (isStatusChangeable))
                    dvControl.ChangeMode(DetailsViewMode.Edit);
                else
                    dvControl.ChangeMode(DetailsViewMode.ReadOnly);

                Parameter objIncidentIdParameter = new Parameter("incident_id", DbType.Int32);
                objIncidentIdParameter.DefaultValue = profileId.ToString();
                objectdatasourceEdit.SelectParameters["incident_id"] = objIncidentIdParameter;

                dvControl.DataBind();
            }
        }

        public bool IsStatusChangeable
        {
            set
            {
                isStatusChangeable = value;
            }
        }
        protected bool isStatusChangeable
        {
            get
            {
                bool _isStatusChangeable = false;
                Object objViewStateIsStatusChangeable = this.ViewState[this.ID + "IsStatusChangeable"];
                if (objViewStateIsStatusChangeable != null)
                    _isStatusChangeable = Convert.ToBoolean(objViewStateIsStatusChangeable);

                return _isStatusChangeable;
            }
            set
            {
                this.ViewState.Remove(this.ID + "IsStatusChangeable");
                this.ViewState.Add(this.ID + "IsStatusChangeable", value);
            }
        }


        public void Save()
        {
            if (profileId > 0)
            {
                //objectdatasourceEdit.UpdateParameters.Add("incident_id", profileId.ToString());
                dvControl.UpdateItem(true);
            }
        }

		protected string GetAudioLinkName()
		{
			return AudioUploadHelper.GetAudioLinkName
				( profileId
				, (bool) Eval( "audio_callcenter" )
				, (bool) Eval( "audio_facility" )
				, (bool) Eval( "audio_merged" )
				);
		}

		protected string GetAudioLink()
		{
			return AudioUploadHelper.GetAudioLink
				( profileId
				, (bool) Eval( "audio_callcenter" )
				, (bool) Eval( "audio_facility" )
				, (bool) Eval( "audio_merged" )
				);
		}
    }
}



