using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCENTRIK.Extensions
{
    public static class ControlExtensions
    {
        public static void Show(this System.Web.UI.Control control)
        {
            if (control == null)
                return;

            control.Visible = true;
        }

        public static void Hide(this System.Web.UI.Control control)
        {
            if (control == null)
                return;

            control.Visible = false;
        }
    }
}