<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="UCENTRIK.WEB.KIOSK.Connect.Home" %>
<table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
    border="0">
    <tr height="100px">
        <td>
            <asp:UpdatePanel ID="upWorkingHours" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer ID="timerRefresh" runat="server" Interval="1000" OnTick="timerRefresh_Tick">
                    </asp:Timer>
                    <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
                        border="0">
                        <tr height="50px">
                            <td align="center" valign="middle" class="KioskText">
                                <asp:Label ID="ltTimeSpan" runat="server" Text="0:00" Visible="false">
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="upWork" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
                        border="0">
                        <asp:Panel ID="pnlKioskOpen" runat="server" Visible="false">
                            <tr height="300px">
                                <td align="center">
                                    <div id="KioskOpen">
                                    </div>
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlKioskClosed" runat="server" Visible="false">
                            <tr height="300px">
                                <td align="center">
                                    <div id="KioskClosed">
                                    </div>
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlKioskInactive" runat="server" Visible="false">
                            <tr height="300px">
                                <td align="center">
                                    <div id="KioskInactive">
                                    </div>
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr height="50px">
                            <td align="center" valign="middle" class="KioskText">
                                <asp:Literal ID="ltMessage" runat="server" Visible="false">
                                </asp:Literal>
                            </td>
                        </tr>
                        <tr height="50px">
                            <td>
                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td align="center" valign="middle">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelSkill" runat="server" Text="Skill(Test Mode):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList 
                                            ID="ddlSkill" 
                                            runat="server" 
                                            DataTextField="skill_name"
                                            DataValueField="skill_id">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelLanguage" runat="server" Text="Language(Test Mode):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList 
                                            ID="ddlLanguage" 
                                            runat="server" 
                                            DataTextField="language_name"
                                            DataValueField="language_id">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr height="50px">
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="rptGroups" runat="server">
                                    <HeaderTemplate>
                                        <table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td width="50%">
                                                </td>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <td width="0%">
                                            <img src="../images/spacer.gif" width="10px" border="0" />
                                        </td>
                                        <td width="0%" align="center">
                                            <asp:Button ID="btnStart" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "group_name")%>'
                                                Width="150" Height="75" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "group_id")%>'
                                                Visible="true" OnClick="btnStart_Click" />
                                        </td>
                                        <td width="0%">
                                            <img src="../images/spacer.gif" width="10px" border="0" />
                                        </td>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <td width="50%">
                                        </td>
                                        </tr> </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                        <tr height="50px">
                            <td align="center" valign="middle">
                                <asp:Button ID="btnStart" runat="server" Text="Click Here To Connect" Width="240"
                                    Height="50" CommandArgument="0" Visible="false" OnClick="btnStart_Click" />
                            </td>
                        </tr>
                        <tr height="50px">
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
