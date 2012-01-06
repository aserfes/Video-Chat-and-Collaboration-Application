<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true"
    CodeBehind="settings.aspx.cs" Inherits="UCENTRIK.WEB.PLATFORM.dirAdmin.settings" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Settings" Src="../App_Controls/ASP/Settings.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Settings" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    <table width="100%" height="1%" align="center" cellspacing="0" cellpadding="0" border="0">
        <tr height="30px">
            <td>
                <asp:Menu ID="menuTabs" Width="157px" runat="server" Orientation="Horizontal"
                    StaticEnableDefaultPopOutImage="False" StaticDisplayLevels="1" StaticSubMenuIndent="0"
                    CssClass="HMenu" StaticItemFormatString="&nbsp;&nbsp;&nbsp;{0}" StaticSelectedStyle-HorizontalPadding="0"
                    StaticMenuItemStyle-CssClass="HStaticMenuItem" StaticSelectedStyle-CssClass="HSelectedMenuItem"
                    StaticHoverStyle-CssClass="HHoverMenuItem" OnMenuItemClick="menuTabs_MenuItemClick">
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlIncidentSubControls" runat="server" Width="100%" Height="100%"
                    CssClass="ProfilePanel">
                    <table width="100%" height="100%" align="center" cellspacing="10" cellpadding="0"
                        border="0">
                        <tr>
                            <td align="center" valign="top">
                                <asp:MultiView ID="mvSettings" runat="server" ActiveViewIndex="0" OnActiveViewChanged="mvSettings_ActiveViewChanged">
                                    <asp:View ID="ViewCS" runat="server">
                                        <ucentrik:Settings ID="SettingsCS" runat="server" />
                                    </asp:View>
                                    <asp:View ID="ViewPlatform" runat="server">
                                        <ucentrik:Settings ID="SettingsPlatform" runat="server" />
                                    </asp:View>
                                    <asp:View ID="ViewKiosk" runat="server">
                                        <ucentrik:Settings ID="SettingsKiosk" runat="server" />
                                    </asp:View>
                                </asp:MultiView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
