<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ViewChatControl.ascx.cs"
    Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.ConferenceControls.ViewChatControl" %>
<table border="0" style="width: 100%; height: 100%">
    <tr>
        <td style="width: 100%; height: 90px; vertical-align: bottom">
            <asp:UpdatePanel ID="upMessageList" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:Repeater ID="rptTextChat" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
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
                            <br />
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td style="width: 100%; height: 20px;">
            <asp:UpdatePanel ID="upMessageBox" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnlTextChat" runat="server" Width="100%" Wrap="false" CssClass="ViewChatSendPanel"
                        DefaultButton="ibSend">
                        <asp:TextBox ID="txtMessage" runat="server" Width="180" MaxLength="250" TextMode="SingleLine"
                            Text="">
                        </asp:TextBox>
                        <asp:Button ID="ibSend" runat="server" ValidationGroup="Message" Width="50px" Height="21px"
                            OnClick="btnSend_Click" Text="Send" />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
