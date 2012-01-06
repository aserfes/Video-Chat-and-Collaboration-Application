using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.IO;

namespace UCENTRIK.LIB
{
    public class NormalScript : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
            ScriptManager sm = ScriptManager.GetCurrent(this.Page);

            if (sm != null && sm.IsInAsyncPostBack)
            {
                StringBuilder sb = new StringBuilder();
                base.Render(new HtmlTextWriter(new StringWriter(sb)));
                string script = sb.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(NormalScript), UniqueID, script, false);
            }
            else
            {
                base.Render(writer);
            }
        }
    }
}
