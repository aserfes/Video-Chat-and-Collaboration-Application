<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ViewChatControl.ascx.cs"
    Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.ConferenceControls.ViewChatControl" %>
<table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
    border="0">
    <tr>
        <td valign="bottom">
            <asp:UpdatePanel ID="upMessageList" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:Repeater ID="rptTextChat" runat="server">
                        <HeaderTemplate>
                            <table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMessageSender" runat="server" CssClass='<%# getMessageSenderCssClass(DataBinder.Eval(Container.DataItem, "chat_sender"))%>'
                                        Text='<%# getMessageSenderName(DataBinder.Eval(Container.DataItem, "chat_sender"))%>'>
                                    </asp:Label>
                                    <asp:Label ID="Label1" runat="server" CssClass='<%# getMessageSenderCssClass(DataBinder.Eval(Container.DataItem, "chat_sender"))%>'
                                        Text=":">
                                    </asp:Label>
                                    &nbsp;
                                    <asp:Label ID="lblMessageText" runat="server" CssClass='<%# getMessageSenderTextCssClass(DataBinder.Eval(Container.DataItem, "chat_sender"))%>'
                                        Text='<%# getWrappedMessage(DataBinder.Eval(Container.DataItem, "chat_message"))%>'>
                                    </asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr height="4px">
        <td>
        </td>
    </tr>
    <tr height="20px">
        <td valign="bottom">
            <asp:UpdatePanel ID="upMessageBox" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table width="100%" height="20px" align="left" cellspacing="0" cellpadding="0" border="0">
                        <tr height="5px">
                            <td align="left" valign="middle" class="ViewChatSendPanel">
                            </td>
                        </tr>
                        <tr height="10px">
                            <td align="left" valign="bottom" class="ViewChatSendPanel">
                                <asp:Panel ID="pnlTextChat" runat="server" Width="100%" Wrap="false" CssClass="ViewChatSendPanel"
                                    DefaultButton="ibSend">
<%--                                    <asp:Image ID="imgNull" runat="server" Width="1px" Height="1px" BorderWidth="0px"
                                        ImageUrl="../../images/spacer.gif" />
--%>                                    <asp:TextBox ID="txtMessage" runat="server" Width="180" MaxLength="250" TextMode="SingleLine"
                                        Text="">
                                    </asp:TextBox>
                                    <asp:Button ID="ibSend" runat="server" ValidationGroup="Message" Width="50px"
                                        Height="21px" OnClick="btnSend_Click" Text="Send"/>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
