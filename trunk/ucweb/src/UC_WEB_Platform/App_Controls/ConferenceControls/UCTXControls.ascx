<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTXControls.ascx.cs"
    Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.BusinessControls.UCTXControls" %>
<%@ Register TagPrefix="ucentrik" TagName="ViewChatControl" Src="ViewChatControl.ascx" %>
<table width="100%" cellspacing="0" cellpadding="0" border="0">
    <tr>
        <td align="center">
            <asp:Label ID="Label5" runat="server" Text="Screen sharing:"></asp:Label>
            <asp:Panel ID="Panel5" runat="server" BorderWidth="1px" Width="240px" Visible="true">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Own:"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="ButtonStartAppShare" runat="server" Text="Start" ClientIDMode="Static" Enabled="true" />
                            <asp:Button ID="ButtonStopAppShare" runat="server" Text="Stop" ClientIDMode="Static" Enabled="true" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Kiosk:"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Panel ID="pnlScreenCast" runat="server" Visible="true">
                                <a runat="server" id="hrefViewAppshare" target="_blank" onclick="CleanupScreenSharingObjects(); SendStartAppshareRequest(list_obj.conv.oid, '1', '2'); return true;" ClientIDMode="Static">View Unit in new window</a>
                                <a runat="server" id="hrefViewAppshareInactive" ClientIDMode="Static" disabled="disabled" style="display:none">View Unit in new window</a>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="Label6" runat="server" Text="Audio settings:"></asp:Label>
            <asp:Panel ID="Panel2" runat="server" BorderWidth="1px" Width="240px" Visible="true">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Own:"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="ButtonAPStart" runat="server" Text="Start" ClientIDMode="Static" />
                            <asp:Button ID="ButtonAPStop" runat="server" Text="Stop" ClientIDMode="Static" disabled="disabled" />
                            <asp:Button ID="ButtonAPMute" runat="server" Text="Mute" ClientIDMode="Static" disabled="disabled" />
                        </td>
                        <td rowspan="2">
                            <asp:Button ID="ButtonASHold" runat="server" Text="Hold" ClientIDMode="Static" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Kiosk:"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="ButtonASStart" runat="server" Text="Start" ClientIDMode="Static" />
                            <asp:Button ID="ButtonASStop" runat="server" Text="Stop" ClientIDMode="Static" disabled="disabled" />
                            <asp:Button ID="ButtonASMute" runat="server" Text="Mute" ClientIDMode="Static" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelVolume" runat="server" Text="Volume:"></asp:Label>
                        </td>
                        <td align="left" colspan="2" style="padding:3 0 3 5;">
                            <asp:Panel ID="pnlAudioVolume" runat="server" Visible="true" BorderWidth="0px">
                                <div id="slider" style="width: 140px" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <%--tr>
                        <td>
                        </td>
                        <td>
                            <asp:Panel ID="pnlAudioHold" runat="server" Visible="true">
                                <asp:Button ID="ButtonASHold" runat="server" Text="Audio Hold" ClientIDMode="Static"
                                    disabled="disabled" />
                            </asp:Panel>
                        </td>
                    </tr--%>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="Label3" runat="server" Text="Video settings:"></asp:Label>
            <asp:Panel ID="pnlVideoSettings" runat="server" BorderWidth="1px" Width="240px" Visible="true">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Own:"></asp:Label>
                        </td>
                        <td>
                            <select id="ctrl_resolution" onchange="ctrl_resolution_OnChange()" class="resolComboBox" >
                            </select>
                            <asp:Button ID="ButtonStartVideoPub" runat="server" Text="Start" ClientIDMode="Static" />
                            <asp:Button ID="ButtonStopVideoPub" runat="server" Text="Stop" ClientIDMode="Static"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelKioskVideo" runat="server" Text="Kiosk:"></asp:Label>
                        </td>
                        <td>
                            <select id="ctrl_kiosk_resolution" onchange="ctrl_kiosk_resolution_OnChange()" class="resolComboBox" >
                            </select>
                            <asp:Button ID="ButtonStartVideoSubscr" runat="server" Text="Start" ClientIDMode="Static" />
                            <asp:Button ID="ButtonStopVideoSubscr" runat="server" Text="Stop" ClientIDMode="Static"
                                disabled="disabled" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr height="5px">
        <td>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Panel ID="Panel1" runat="server" BorderWidth="1px" ScrollBars="None" Visible="true"
                Width="240px">
                <div style="position: relative; width: 240px; height: 180px;">
                    <asp:Panel ID="Panel3" runat="server" BorderWidth="0px" Width="240px" Height="180px"
                        Visible="true">
                        <object id="wye_uic_video_subscriber" classid="clsid:748C7CED-885E-4733-ADA6-890A0C94CBC6"
                            codebase="<%=uctx_cab%>" width="240px" height="180px">
                        </object>
                    </asp:Panel>
                    <div style="position: absolute; left: 135px; top: 95px; background-color: green;
                        width: 100px; height: 80px;">
                        <asp:Panel ID="Panel4" runat="server" BorderWidth="1px" Width="0px" Height="0px"
                            Visible="true">
                            <object id="wye_uic_video_publisher" classid="clsid:748C7CED-885E-4733-ADA6-890A0C94CBC6"
                                codebase="<%=uctx_cab%>" width="100" height="80">
                            </object>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
        </td>
    </tr>
    <tr height="5px">
        <td>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Panel ID="pnlTextChat" runat="server" BorderWidth="1px" Width="240px" Height="140px"
                ScrollBars="None" Visible="true">
                <table height="140px" cellspacing="4" cellpadding="0" border="0">
                    <tr>
                        <td  align="center" valign="bottom" >
                            <ucentrik:ViewChatControl ID="ViewChatControl" runat="server" RowsToShow="7" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>