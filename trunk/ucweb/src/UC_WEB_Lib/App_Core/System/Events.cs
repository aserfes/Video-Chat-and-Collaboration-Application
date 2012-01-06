using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Runtime.InteropServices;

namespace UCENTRIK.LIB.Base
{


    public class UcControlArgs : EventArgs
    {
        public Int32 Id { get; set; }
        public bool Cancel { get; set; }
        public string Message { get; set; }
        public bool IsNew { get; set; }
        public string NavigateTo { get; set; }
    }

    public class UcUserArgs : EventArgs
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public Int32 UserId { get; set; }
        public Int32 UserRoleId { get; set; }
        public string Message { get; set; }
        public bool Cancel { get; set; }
    }


    public class UcReportArgs : EventArgs
    {
        public Int32 Group { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }




    [Serializable]
    [ComVisible(true)]
    public delegate void UcControlEventHandler(object sender, UcControlArgs e);

    [Serializable]
    [ComVisible(true)]
    public delegate void UcUserEventHandler(object sender, UcUserArgs e);

    [Serializable]
    [ComVisible(true)]
    public delegate void UcReportEventHandler(object sender, UcReportArgs e);



}
