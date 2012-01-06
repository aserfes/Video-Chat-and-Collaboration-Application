<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="settings.ascx.cs" Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.ASP.settings" %>
<%@ Register TagPrefix="ucentrik" TagName="SettingItem" Src="../Elements/SettingItem.ascx" %>
<table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
    <tr>
        <td>
            <br />
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
              <%--  <tr>
                    <td class="Title">
                        CONF_SERVER
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="rptSettingsConfServer" runat="server">
                            <HeaderTemplate>
                                <table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
                                    <tr height="1px">
                                        <td>
                                            &nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr height="30px">
                                    <td>
                                        <ucentrik:SettingItem ID="SettingItem" runat="server" SettingName='<%# DataBinder.Eval(Container.DataItem, "name")%>'
                                            SettingValue='<%# DataBinder.Eval(Container.DataItem, "value")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tr height="1px">
                                    <td>
                                        &nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Repeater ID="rptSettingsCtxServer" runat="server">
                            <HeaderTemplate>
                                <table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
                                    <tr height="1px">
                                        <td>
                                            &nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr height="30px">
                                    <td>
                                        <ucentrik:SettingItem ID="SettingItem" runat="server" 
                                            SettingName='<%# DataBinder.Eval(Container.DataItem, "name")%>'
                                            SettingValue='<%# DataBinder.Eval(Container.DataItem, "value")%>' 
                                            SettingTooltip='<%# DataBinder.Eval(Container.DataItem, "tooltip")%>'
                                            SettingCategory='<%# DataBinder.Eval(Container.DataItem, "category")%>'/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tr height="1px">
                                    <td>
                                        &nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
              <%--  <tr>
                    <td class="Title">
                        SESSION_PARAMS
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="rptSettingsSessionParams" runat="server">
                            <HeaderTemplate>
                                <table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
                                    <tr height="1px">
                                        <td>
                                            &nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr height="30px">
                                    <td>
                                        <ucentrik:SettingItem ID="SettingItem" runat="server" SettingName='<%# DataBinder.Eval(Container.DataItem, "name")%>'
                                            SettingValue='<%# DataBinder.Eval(Container.DataItem, "value")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tr height="1px">
                                    <td>
                                        &nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>--%>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
</table>
