<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WaitScreen.ascx.cs"
    Inherits="UCENTRIK.WEB.KIOSK.Connect.WaitScreen" %>
<asp:UpdatePanel ID="upWork" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdatePanel ID="upTimeWaiting" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Timer ID="timerRefresh" runat="server" Interval="1000" OnTick="timerRefresh_Tick">
                </asp:Timer>
                <table width="100%" align="center">
                    <tr>
                        <td align="center" valign="middle">
                            <asp:Label ID="ltTimeSpan" runat="server" Text="" Visible="false">
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="container">
            <div id="left" >
            </div>
            <asp:Panel ID="pnlWait" runat="server" Visible="true">
                <div class="right">
                    <h2>
                        You are being connected to the next
                        <%--<br />--%>
                        available agent...
                    </h2>
                    <div class="btn">
                        <asp:Button ID="btnCancel" runat="server" Width="100" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlAgentsBusy" runat="server" Visible="false">
                <div class="right">
                    <h2>
                        All agents are currently busy.
                        <br />
                        The next available Agent will be with you in a moment...
                        <br />
                        Would you like to keep waiting?
                        <br />
                    </h2>
                    <div class="btn">
                        <asp:Button ID="btnYes" runat="server" Width="100" Text="Yes" OnClick="btnYes_Click" />
                        <asp:Button ID="btnNo" runat="server" Width="100" Text="No" OnClick="btnNo_Click" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
