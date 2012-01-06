<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Error.ascx.cs" Inherits="UCENTRIK.WEB.KIOSK.Connect.Error" %>
<table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
    border="0">
    <tr height="100px">
        <td>
            <asp:UpdatePanel ID="upTimeWaiting" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer ID="timerRefresh" runat="server" Interval="1000" OnTick="timerRefresh_Tick">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="upError" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
                        border="0">
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr height="350px">
                            <td align="center">
                                <div id="KioskError">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="KioskError">
                                SYSTEM ERROR
                            </td>
                        </tr>
                        <tr>
                            <td class="KioskError">
                                <asp:Label ID="LabelMessage" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
