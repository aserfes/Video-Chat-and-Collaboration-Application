using System;
using System.Collections.Generic;
using System.Web;

using UCENTRIK.LIB.BllProxy;
using UCENTRIK.AppSettings;

namespace UCENTRIK.LIB.CoreSystem
{
    public class UcSystem
    {
        public static void HandleException(Exception ex, string userName, string pageUrl)
        {
            _handleException(ex, userName, pageUrl, 0);
        }

        private static void _handleException(Exception ex, string userName, string pageUrl, Int32 parentExId)
        {
            string application = UcConfParameters.UcAppName;

            if (ex != null)
            {
                string message = ex.Message;
                string stacktrace = ex.StackTrace;

                if (stacktrace == null)
                    stacktrace = String.Empty;

                Int32 exId = BllProxyException.InsertException(parentExId, message, stacktrace, application, userName, pageUrl);

                _handleException(ex.InnerException, "", "", exId);
            }
        }
    }
}
