using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Text;
using System.IO;

namespace UCENTRIK.LIB
{
    public class InlineScript : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
            ScriptManager sm = ScriptManager.GetCurrent(this.Page);

            if (sm != null && sm.IsInAsyncPostBack)
            {
                StringBuilder sb = new StringBuilder();
                base.Render(new HtmlTextWriter(new StringWriter(sb)));
                string script = sb.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(InlineScript), UniqueID, script, false);
            }
            else
            {
                base.Render(writer);
            }
        }
    }
}
