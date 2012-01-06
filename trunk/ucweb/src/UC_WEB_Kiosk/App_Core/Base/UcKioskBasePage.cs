using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using UCENTRIK.LIB.BllProxy;


using UCENTRIK.WEB;



using UCENTRIK.DATASETS;




namespace UCENTRIK.LIB.Base
{

    public class UcKioskBasePage : UcBasePage
    {

        protected string facilityName
        {
            get
            {
                string _facilityName = "";
                Object objViewStateFacilityName = this.ViewState[this.ID + "FacilityName"];
                if (objViewStateFacilityName != null)
                    _facilityName = Convert.ToString(objViewStateFacilityName);

                return _facilityName;
            }
            set
            {
                this.ViewState.Remove(this.ID + "FacilityName");
                this.ViewState.Add(this.ID + "FacilityName", value);
            }
        }
        public string FacilityName
        {
            get
            {
                return facilityName;
            }
        }

        protected Int32 facilityId
        {
            get
            {
                Int32 _facilityId = 0;
                Object objViewStateFacilityId = this.ViewState[this.ID + "FacilityId"];
                if (objViewStateFacilityId != null)
                    _facilityId = Convert.ToInt32(objViewStateFacilityId);

                return _facilityId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "FacilityId");
                this.ViewState.Add(this.ID + "FacilityId", value);
            }
        }
        public Int32 FacilityId
        {
            get
            {
                return facilityId;
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
        public Guid FacilityGuid
        {
            get
            {
                return facilityGuid;
            }
        }












        protected bool isActive
        {
            get
            {
                bool _isActive = false;
                Object objViewStateIsActive = this.ViewState[this.ID + "IsActive"];
                if (objViewStateIsActive != null)
                    _isActive = Convert.ToBoolean(objViewStateIsActive);

                return _isActive;
            }
            set
            {
                this.ViewState.Remove(this.ID + "IsActive");
                this.ViewState.Add(this.ID + "IsActive", value);
            }
        }
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }








        public void SetFacilityName(string facilityName)
        {
            MasterKiosk master = (MasterKiosk)this.Master;
            master.FacilityName = facilityName;
        }












        protected bool loginAllowed = false;
        public bool LoginAllowed
        {
            set
            {
                loginAllowed = value;
            }
            get
            {
                return loginAllowed;
            }
        }



        protected override void OnLoad(EventArgs e)
        {
            string userName = this.UserName;
            bool isAuthorized = this.IsAuthorized;

            MasterKiosk ucMasterPage = (MasterKiosk)this.Master;
            ucMasterPage.ShowTheContent(this.IsAuthorized);






            if (!this.Page.IsPostBack)
            {
                if (this.UserId != 0)
                {
                    FacilityDS.FacilityDSDataTable dt = BllProxyFacility.GetFacilityByUser(this.UserId);

                    facilityId = 0;
                    if (dt.Rows.Count == 0)
                    {
                        this.SetFacilityName("No Facility assigned to the username: " + this.UserName);
                    }
                    else
                    {
                        facilityId = dt[0].facility_id;
                        isActive = dt[0].active;
                        facilityName = dt[0].facility_name;
                        facilityGuid = dt[0].facility_guid;

                        this.SetFacilityName(facilityName);
                    }
                }
                else
                {
                    this.SetFacilityName("Logged out...");
                }

            }



            base.OnLoad(e);
        }











    }

}
