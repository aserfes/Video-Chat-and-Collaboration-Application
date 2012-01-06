using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using UCENTRIK.LIB.BllProxy;
using System.Web.UI.WebControls;

namespace UCENTRIK.LIB.Helpers
{
    public static class UCTXHelper
    {
        public static void SetCommonSettings(Page page)
        {
            if (!page.ClientScript.IsClientScriptBlockRegistered("setConferenceSetting"))
            {
				string server = ProxyHelper.GetSettingValueString( "Server", "CTX_SERVER" );
				string[] ss = server.Split( ':' );
				string script = string.Format
					( "setConferenceSetting('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');"
					, ss[ 0 ]
					, ss[ 1 ]
					, ss[ 2 ]
					, ss[ 3 ]
					, ProxyHelper.GetSettingValueString( "TimerSpan", "CTX_SERVER" )
					, ProxyHelper.GetSettingValueString( "DifFrameCount", "CTX_SERVER" )
					, string.Empty
					);

				ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "setConferenceSetting", script, true);
            }
        }

        public static void AddUCTXObjectsToHeader(Page page)
        {
			string uctx_cab = System.Configuration.ConfigurationManager.AppSettings[ "uctx.cab" ];

            LiteralControl lt1 = new LiteralControl();
            lt1.Text = "<object id=\"wye_util\" classid=\"clsid:E9BA40CC-AB0D-4554-88C3-E6B95B86C0FD\" codebase=\"" + uctx_cab + "\"></object>";
            if (!IsControlInHeader(page, lt1))
            {
                page.Header.Controls.Add(lt1);
            }
            LiteralControl lt2 = new LiteralControl();
			lt2.Text = "<object id=\"wye_console\" classid=\"clsid:E604E28F-732B-4C67-9D39-2D6DC9D9010C\" codebase=\"" + uctx_cab + "\"></object>";
            if (!IsControlInHeader(page, lt2))
            {
                page.Header.Controls.Add(lt2);
            }
            LiteralControl lt3 = new LiteralControl();
			lt3.Text = "<object id=\"wye_ui\" classid=\"clsid:A0FDD61F-052C-41C8-A8B2-B27E76A9DCEB\" codebase=\"" + uctx_cab + "\"></object>";
            if (!IsControlInHeader(page, lt3))
            {
                page.Header.Controls.Add(lt3);
            }
        }

        public static bool IsControlInHeader(Page page, LiteralControl lt)
        {
            foreach (Control control in page.Header.Controls)
            {
                LiteralControl temp = control as LiteralControl;
                if (temp != null && temp.Text == lt.Text)
                {
                    return true;
                }
            }
            return false;
        }
    }
}