<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScreenShare.aspx.cs" Inherits="UCENTRIK.WEB.KIOSK.dirKiosk.ScreenShare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Unit</title>
    <script type="text/javascript">

        var screenSubscriberStatus = "";

//        function OnScreenSubscriberStatusChanged(obj, newStatus) {
//            if (obj != null) {
//                if (screenSubscriberStatus == "active" && newStatus != "active") {
//                    screenSubscriberStatus = "";
//                    window.open("", "_self", "");
//                    window.close();
//                    return;
//                }
//                screenSubscriberStatus = newStatus;
//                
//                var status_off = screenSubscriberStatus == "off";
//                document.getElementById("ButtonControl").disabled = status_off;

//                var text = "Control On";
//                if (obj.id_control_by == 1)
//                {
//                     text = "Control Off";
//                }
//                document.getElementById("ButtonControl").value = text;
//            }
//        }

        function OnRefreshSubscriber(oid) {
            var obj = list_obj[oid];
            if (obj != null) {
                var newStatus = obj.status;
                if (screenSubscriberStatus == "active" && newStatus != "active") {
                    screenSubscriberStatus = "";
                    window.open("", "_self", "");
                    window.close();
                    return;
                }
                screenSubscriberStatus = newStatus;

                var status_off = obj.status == "off";
                document.getElementById("ButtonControl").disabled = status_off;

                var text = "Control On";
                if (obj.id_control_by == 1) {
                    text = "Control Off";
                }
                document.getElementById("ButtonControl").value = text;
            }
        }

    </script>
</head>
<body>
    <form runat="server">
    <div>
        <table border="1">
            <tr>
                <td>
                    <asp:Button ID="ButtonControl" runat="server" Text="Control On" ClientIDMode="Static"
                        Enabled="true" disabled="disabled" />
                </td>
            </tr>
            <tr>
                <td>
                    <object id="wye_uic_screen" classid="clsid:748C7CED-885E-4733-ADA6-890A0C94CBC6"
                        codebase="<%=uctx_cab%>" width="<%=this.UIControlWidth%>"
                        height="<%=this.UIControlHeight%>">
                    </object>
                </td>
            </tr>
        </table>
    </div>
   
    </form>
</body>
</html>
