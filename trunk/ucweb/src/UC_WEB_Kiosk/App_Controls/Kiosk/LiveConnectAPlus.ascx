<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LiveConnectAPlus.ascx.cs"
    Inherits="UCENTRIK.WEB.KIOSK.Connect.LiveConnectAPlus" %>
<%@ Register TagPrefix="ucentrik" TagName="ViewChatControl" Src="../ConferenceControls/ViewChatControl.ascx" %>
<div id="container1">
    <div id="video">
        <object id="wye_uic_video_subscriber" classid="clsid:748C7CED-885E-4733-ADA6-890A0C94CBC6"
            codebase="<%=uctx_cab%>" >
        </object>
    </div>
    <div id="status">
        <h3>
            Status
        </h3>
        <div id="status_info">
            <asp:UpdatePanel ID="upTimeSpent" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblAgentName" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="Label1" runat="server" Text=" - online - "></asp:Label>
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="ltTimeSpan" runat="server" Text="0:00"></asp:Label>
                            </td>
                            <td align="left" valign="middle">
                                <asp:Timer ID="timerRefresh" runat="server" Interval="1000" OnTick="timerRefresh_Tick">
                                </asp:Timer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="kiosk">
        <div id="kiosk_image">
            <object id="wye_uic_video_publisher" classid="clsid:748C7CED-885E-4733-ADA6-890A0C94CBC6"
                codebase="<%=uctx_cab%>" >
            </object>
        </div>
        <div id="kiosk_status">
            <asp:UpdatePanel ID="upDiconnect" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="btnDisconnect" runat="server" Text="Hang-up" CommandName="DISCONNECT"
                        Width="100" Height="25" OnClick="btnDisconnect_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="chat">
        <h3>
            Chat</h3>
        <div id="dialog">
             <ucentrik:ViewChatControl ID="ViewChatControl" runat="server" RowsToShow="9" />
        </div>
    </div>
    <div style="visibility:hidden">
        <a runat="server" id="hrefViewAppshare" target="_blank" >Receive appshare</a>
    </div>
</div>

