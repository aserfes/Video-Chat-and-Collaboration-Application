using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;


using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;


namespace UCENTRIK.LIB.Base
{


    public class UcKioskBaseControl : UcBaseControl
    {


        public UcKioskBasePage UcKioskPage
        {
            get
            {
                return (UcKioskBasePage)this.Page;
            }
        }

        //protected bool readOnly = true;
        //public bool ReadOnly
        //{
        //    set
        //    {
        //        readOnly = value;
        //    }
        //    get
        //    {
        //        return readOnly;
        //    }
        //}

        //public Int32 GetCurrentUserId()
        //{
        //    Int32 userId = 0;

        //    return userId;
        //}
    }



    public class UcKioskConnectBaseControl : UcKioskBaseControl
    {




//        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler ConnectBack;
        protected void goBack(UcControlArgs args)
        {
            if (ConnectBack != null)
                ConnectBack(this, args);
        }

        public event UcControlEventHandler ConnectNext;
        protected void goNext(UcControlArgs args)
        {
            if (ConnectNext != null)
                ConnectNext(this, args);
        }

        public event UcControlEventHandler ConnectError;
        protected void handleError(UcControlArgs args)
        {
            if (ConnectError != null)
                ConnectError(this, args);
        }
//        ///---------------------------------------------------------------------------------








        protected Int32 incidentId
        {
            get
            {
                Int32 incidentId = 0;
                Object objViewStateIncidentId = this.ViewState[this.ID + "IncidentId"];
                if (objViewStateIncidentId != null)
                    incidentId = Convert.ToInt32(objViewStateIncidentId);

                return incidentId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "IncidentId");
                this.ViewState.Add(this.ID + "IncidentId", value);
            }
        }
        public Int32 IncidentId
        {
            set
            {
                incidentId = value;
            }
        }


        //protected Int32 facilityId
        //{
        //    get
        //    {
        //        Int32 _facilityId = 0;
        //        Object objViewStateFacilityId = this.ViewState[this.ID + "FacilityId"];
        //        if (objViewStateFacilityId != null)
        //            _facilityId = Convert.ToInt32(objViewStateFacilityId);

        //        return _facilityId;
        //    }
        //    set
        //    {
        //        this.ViewState.Remove(this.ID + "FacilityId");
        //        this.ViewState.Add(this.ID + "FacilityId", value);
        //    }
        //}
        public Int32 FacilityId
        {
            get
            {
                //facilityId = value;
                return this.UcKioskPage.FacilityId;
            }
        }








        protected DateTime startTime
        {
            get
            {
                DateTime _startTime = DateTime.Now;
                Object objViewStateStartTime = this.ViewState[this.ID + "StartTime"];
                if (objViewStateStartTime != null)
                    _startTime = Convert.ToDateTime(objViewStateStartTime);

                return _startTime;
            }
            set
            {
                this.ViewState.Remove(this.ID + "StartTime");
                this.ViewState.Add(this.ID + "StartTime", value);
            }
        }









    }

}
