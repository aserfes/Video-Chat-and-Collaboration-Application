<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LiveConnect.ascx.cs"
    Inherits="UCENTRIK.WEB.KIOSK.Connect.LiveConnect" %>

<%@ Register TagPrefix="ucentrik" TagName="ViewChatControl" Src="../ConferenceControls/ViewChatControl.ascx" %> 

<table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
    border="0">
    <tr height="500px">
        <td width="20%">
            <asp:UpdatePanel ID="upTimeSpent" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer ID="timerRefresh" runat="server" Interval="1000" OnTick="timerRefresh_Tick">
                    </asp:Timer>
                    <table width="100%" height="1%" align="center" cellspacing="0" cellpadding="0" border="0">
                        <tr height="20px">
                            <td align="center" valign="middle">
                                <asp:Label ID="ltTimeSpan" runat="server" Text="0:00"></asp:Label>
                            </td>
                        </tr>
                        <tr height="20px">
                            <td align="center" valign="middle">
                                <asp:Label ID="lblAgentName" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr height="58px">
                            <td align="center" valign="middle">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="false" DisplayAfter="1000">
                                    <ProgressTemplate>
                                        <div id="Update">
                                            &nbsp;
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td width="60%">
            <table width="720px" height="500px" align="center" cellspacing="0" cellpadding="0"
                border="0">
                <tr>
                    <td align="center" valign="middle">
                        <asp:UpdatePanel ID="upReceiver" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="pnlVideoReceiver" runat="server" BorderWidth="1px" Width="320px" Height="240px"
                                    Visible="true">
                                    <object id="wye_uic_video_subscriber" classid="clsid:748C7CED-885E-4733-ADA6-890A0C94CBC6"
                                        codebase="<%=uctx_cab%>" width="320" height="240">
                                    </object>
                                    <%--<ucentrik:VideoReceiver ID="ucVideoReceiver" runat="server" />--%>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </td>
        <td width="20%">
            <asp:UpdatePanel ID="upConnectionStatus" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table align="center" cellspacing="0" cellpadding="0" border="0">
                        <tr height="10px">
                            <td>
                            </td>
                        </tr>
                        <asp:Panel ID="pnlConnected" runat="server" Visible="false">
                            <tr valign="top">
                                <td colspan="3" align="center">
                                    <div id="uButton">
                                    </div>
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlDisconnected" runat="server" Visible="true">
                            <tr valign="top">
                                <td colspan="3" align="center">
                                    <div id="uButtonDisabled">
                                    </div>
                                </td>
                            </tr>
                        </asp:Panel>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td width="20%">
        </td>
        <td align="center" valign="bottom">
            <table width="640px" align="center" cellspacing="0" cellpadding="0" border="0">
                <tr height="400px">
                    <td align="left" valign="bottom">
                        <asp:Panel ID="pnlChat" runat="server" Height="400px" ScrollBars="None" BorderWidth="1px">
                            <table height="400px" cellspacing="5" cellpadding="5" border="0">
                                <tr>
                                    <td>
                                         <ucentrik:ViewChatControl ID="ViewChatControl" runat="server" RowsToShow="15" /> 
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
        <td width="20%">
            <asp:UpdatePanel ID="upDiconnect" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table align="center" cellspacing="0" cellpadding="0" border="0">
                        <tr height="50px">
                            <td>
                            </td>
                        </tr>
                        <asp:Panel ID="pnlDisconnect" runat="server" Visible="false">
                            <tr align="center" valign="middle">
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <br />
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td colspan="3" align="center">
                                    <asp:Button ID="btnDisconnect" runat="server" Text="Disconnect" CommandName="DISCONNECT"
                                        Width="240" Height="50" OnClick="btnDisconnect_Click" />
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlDisconnectConfirm" runat="server" Visible="false">
                            <tr align="center" valign="middle">
                                <td colspan="3">
                                    Do you want to disconnect?
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <br />
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td align="center">
                                    <asp:Button ID="btnDisconnectYes" runat="server" Text="Yes" CommandName="CONFIRM"
                                        Width="120" Height="50" OnClick="btnDisconnect_Click" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnDisconnectNo" runat="server" Text="No" CommandName="CANCEL" Width="120"
                                        Height="50" OnClick="btnDisconnect_Click" />
                                </td>
                            </tr>
                        </asp:Panel>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <asp:Panel ID="pnlHidden" runat="server" Visible="false">
        <tr height="1%">
            <td width="20%">
            </td>
            <td>
                <table width="100%" height="1%" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td align="center">
                            <asp:UpdatePanel ID="upContent" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlNew" runat="server" Visible="false">
                                        <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr height="10px">
                                                <td width="10%" bgcolor="#ffffff">
                                                </td>
                                                <td width="80%" align="center" bgcolor="#ffffff">
                                                    <br />
                                                    <font color="red" size="4">Welcome to Ucentrik Live Kiosk </font>
                                                    <br />
                                                </td>
                                                <td width="10%" bgcolor="#ffffff">
                                                </td>
                                            </tr>
                                            <tr height="10px">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr valign="top" height="100px">
                                                <td colspan="3" align="center">
                                                    <div id="UcentrikLogo">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr height="40px">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr height="10px">
                                                <td bgcolor="#ffffff">
                                                </td>
                                                <td align="center" bgcolor="#ffffff">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr height="10px">
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <font color="#033d62"><b>U</b></font><font color="#004f88"><b>centrik's</b></font>
                                                                applications deliver a highly engaging user experience through the use of live video,
                                                                audio and collaboration that can be deployed on websites, kiosks and digital signage.
                                                                <br />
                                                                <br />
                                                                <font color="#033d62"><b>U</b></font><font color="#004f88"><b>centrik's</b></font>
                                                                market-proven technology allows people to connect, communicate and collaborate with
                                                                an online ‘face to face’ interaction for virtually any type of use case, such as,
                                                                online meetings and webinars, sales and customer service with live ‘virtual agents’,
                                                                remote technical support, and individual or group training.
                                                                <br />
                                                                <br />
                                                                Our applications include bi-directional video, audio and rich screen collaboration
                                                                along with powerful management and analytic tools on the back end.
                                                                <br />
                                                                <br />
                                                                <font color="#033d62"><b>U</b></font><font color="#004f88"><b>centrik's</b></font>
                                                                products are easily deployed, turnkey applications that provide the type of full
                                                                conferencing and collaboration capability and robust “back-end” that you’d expect
                                                                from the big names in the market without the big prices.
                                                                <br />
                                                                <br />
                                                                Whether you’re a Retailer, Contact Center, in Business, Financial, Health Care,
                                                                Hospitality, Government or Educational Services, you’ll get all the functionality
                                                                you need at an SMB price with our Vertical Specific Solutions.
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td bgcolor="#ffffff">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlContent" runat="server" Visible="false">
                                        <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr>
                                                <td width="10%" bgcolor="#ffffff">
                                                </td>
                                                <td width="80%" align="center" bgcolor="#ffffff">
                                                    <br />
                                                    <font color="red" size="4">Thanks for using Ucentrik Live Kiosk </font>
                                                    <br />
                                                </td>
                                                <td width="10%" bgcolor="#ffffff">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#ffffff">
                                                </td>
                                                <td align="left" bgcolor="#ffffff">
                                                    <br />
                                                    Ucentrik Inc. is a software development company based in Toronto, Ontario, Canada.
                                                    Our rich media application development platform - the Ucentrik CTX - is a modular
                                                    software engine that enables organizations to bring products to life - and to market
                                                    - quickly and easily with high-quality, real-time video, audio and robust collaborative
                                                    modules.
                                                    <br />
                                                    Ucentrik's solution delivers a user experience that:
                                                    <br />
                                                    <li>Measurably deepens customer experience and satisfaction</li>
                                                    <li>Generates revenue by increasing the lifetime value of the customer</li>
                                                    <li>Creates market differentiation</li>
                                                    <li>Reduces costs</li>
                                                    <br />
                                                    Ucentrik's solution is leading the market in the way companies interact with customers,
                                                    employees, end users, channel partners or other key stakeholder groups. Learn more
                                                    <br />
                                                </td>
                                                <td bgcolor="#ffffff">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlScreenCast" runat="server" Visible="false">
                                        <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr>
                                                <td width="1%">
                                                </td>
                                                <td width="98%">
                                                    <%--<ucentrik:AppShare ID="AppShareControl" runat="server" />--%>
                                                </td>
                                                <td width="1%">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAppShareSend" runat="server" Visible="false">
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAppShareReceive" runat="server" Visible="false">
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="20%">
            </td>
        </tr>
    </asp:Panel>
    <tr height="1px">
        <td bgcolor="#ffffff">
        </td>
        <td bgcolor="#ffffff">
        </td>
        <td bgcolor="#ffffff" align="right">
            <asp:UpdatePanel ID="upTransmitter" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnlVideoTransmitter" runat="server" BorderWidth="1px" Width="0px"
                        Height="0px" Visible="true">
                        <object id="wye_uic_video_publisher" classid="clsid:748C7CED-885E-4733-ADA6-890A0C94CBC6"
                            codebase="<%=uctx_cab%>" width="320" height="240">
                        </object>
                        <%--<ucentrik:VideoTransmitter ID="ucVideoTransmitter" runat="server" />--%>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
