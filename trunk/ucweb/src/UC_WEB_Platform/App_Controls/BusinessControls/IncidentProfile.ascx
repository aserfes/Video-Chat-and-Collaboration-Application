<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IncidentProfile.ascx.cs"
    Inherits="UcentrikWeb.App_Controls.BusinessControls.IncidentProfile" %>
<%@ Register TagPrefix="ucentrik" TagName="EditIncident" Src="../ASP/EditIncident.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="InfoAboutCall" Src="../ASP/InfoAboutCall.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="EditContact" Src="../ASP/EditContact.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="NoteControl" Src="../ASP/NoteControl.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="TransferIncident" Src="../ASP/TransferIncident.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="TextChatControl" Src="../ConferenceControls/TextChatControl.ascx" %>
<%--<%@ Register TagPrefix="ucentrik" TagName="AppShare" Src="../ConferenceControls/UcAppShareViewer.ascx" %>--%>
<table width="100%" height="1%" align="center" cellspacing="2" cellpadding="0" border="0">
    <tr>
        <td colspan="2">
            <table width="100%" height="1%" align="center" cellspacing="0" cellpadding="0" border="0">
                <tr height="30px">
                    <td>
                        <asp:Menu ID="menuIncidentTabs" Width="157px" runat="server" Orientation="Horizontal"
                            StaticEnableDefaultPopOutImage="False" StaticDisplayLevels="1" StaticSubMenuIndent="0"
                            CssClass="HMenu" StaticItemFormatString="&nbsp;&nbsp;&nbsp;{0}" StaticSelectedStyle-HorizontalPadding="0"
                            StaticMenuItemStyle-CssClass="HStaticMenuItem" StaticSelectedStyle-CssClass="HSelectedMenuItem"
                            StaticHoverStyle-CssClass="HHoverMenuItem" OnMenuItemClick="menuIncidentTabs_MenuItemClick">
                        </asp:Menu>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlIncidentSubControls" runat="server" Width="100%" Height="100%"
                            CssClass="ProfilePanel">
                            <table width="100%" height="100%" align="center" cellspacing="10" cellpadding="0"
                                border="0">
                                <tr height="25px">
                                    <td align="left">
                                        <asp:Label ID="lblMessage" runat="server" Text="">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr height="20px">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <asp:MultiView ID="mvOpenSession" runat="server" ActiveViewIndex="0" OnActiveViewChanged="mvOpenSession_ActiveViewChanged">
                                            <asp:View ID="View01" runat="server">
                                                <table width="100%" height="320px" align="center" cellspacing="0" cellpadding="0"
                                                    border="0">
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Button ID="ButtonCloseAndExit" runat="server" Text="CLOSE & EXIT" Width="150px" Height="24px"
                                                                CssClass="UcButtonLarge" ValidationGroup="Edit" UseSubmitBehavior="false" OnClick="btnCloseAndExit_Click" />
                                                            &nbsp;&nbsp;
                                                            <asp:Button ID="ButtonSaveAndExit" runat="server" Text="SAVE & EXIT" Width="150px" Height="24px"
                                                                CssClass="UcButtonLarge" ValidationGroup="Edit" UseSubmitBehavior="false" OnClick="btnSave_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <ucentrik:EditIncident ID="EditIncident" runat="server" />
                                                            <br />
                                                            <ucentrik:InfoAboutCall ID="InfoAboutCall" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View02" runat="server">
                                                <table width="100%" height="320px" align="center" cellspacing="0" cellpadding="0"
                                                    border="0">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <ucentrik:EditContact ID="EditContact" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View03" runat="server">
                                                <table width="100%" height="320px" align="center" cellspacing="0" cellpadding="0"
                                                    border="0">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <%--<ucentrik:VideoChatControl ID="VideoChatControl" runat="server" />--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View04" runat="server">
                                                <table width="100%" height="320px" align="center" cellspacing="0" cellpadding="0"
                                                    border="0">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <ucentrik:TextChatControl ID="TextChatControl" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View05" runat="server">
                                                <table width="100%" height="640px" align="center" cellspacing="0" cellpadding="0"
                                                    border="0">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <%--<ucentrik:AppShare ID="AppShareControl" runat="server"/>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View06" runat="server">
                                                <table width="100%" height="320px" align="center" cellspacing="0" cellpadding="0"
                                                    border="0">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <ucentrik:TransferIncident ID="TransferIncident" runat="server" OnProfileNextButton="TransferIncident_Next" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View07" runat="server">
                                                <table width="100%" height="320px" align="center" cellspacing="0" cellpadding="0"
                                                    border="0">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <ucentrik:NoteControl ID="NoteControl" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View08" runat="server">
                                            </asp:View>
                                            <asp:View ID="View09" runat="server">
                                            </asp:View>
                                            <asp:View ID="View10" runat="server">
                                            </asp:View>
                                        </asp:MultiView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="separator">
            <table width="100%" height="100%" align="center" cellspacing="2" cellpadding="0"
                border="0">
                <tr>
                    <td width="5px">
                    </td>
                    <td align="left">
                        <asp:Button ID="btnBack" runat="server" Text="BACK" Width="100px" Height="24px" CssClass="UcButton"
                            UseSubmitBehavior="false" OnClick="btnBack_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSave" runat="server" Text="SAVE & EXIT" Width="150px" Height="24px"
                            CssClass="UcButtonLarge" ValidationGroup="Edit" UseSubmitBehavior="false" OnClick="btnSave_Click" />
                    </td>
                    <td width="5px">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
