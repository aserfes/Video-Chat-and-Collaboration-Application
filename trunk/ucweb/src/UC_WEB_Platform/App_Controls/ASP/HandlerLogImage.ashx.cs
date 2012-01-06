using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.DATASETS;

namespace UCENTRIK.WEB.PLATFORM.App_Controls.ASP
{
    /// <summary>
    /// Summary description for HandlerLogImage
    /// </summary>
    public class HandlerLogImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string field = context.Request.QueryString["field"];
            int incident_id = int.Parse(context.Request.QueryString["incident_id"]);
            object dataImage = BllProxyLog.GetImage(incident_id, field);

            byte[] content = dataImage as byte[];
            if (content != null)
            {
                context.Response.BinaryWrite(content);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}