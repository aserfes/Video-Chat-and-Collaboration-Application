<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KioskSurveyQuestion.ascx.cs"
    Inherits="UCENTRIK.WEB.KIOSK.Kiosk.UcKioskSurveyQuestion" %>
<asp:Panel ID="Panel1" runat="server" BorderWidth="1px" Width="100%" CssClass="KioskPanel">
    <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
        border="0">
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td width="90%" valign="top">
                <asp:Label ID="lblQuestionTitle" runat="server" CssClass="KioskText" Text="">
                </asp:Label>
                <br />
            </td>
            <td width="10%" align="right" nowrap>
                <asp:Panel ID="pnlTypeText" runat="server" Visible="false">
                    <asp:TextBox ID="txtAnswer" runat="server" Width="300" CssClass="KioskTextBox"
                        OnTextChanged="txtAnswer_TextChanged">
                    </asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="pnlTypeYesNo" runat="server" Visible="false">
                    <asp:Button ID="btnYes" runat="server" Width="50" Text="Yes" CommandArgument="YES"
                        CssClass="KioskTextButton" OnClick="btnYesNo_Click" />
                    <asp:Button ID="btnNo" runat="server" Width="50" Text="No" CommandArgument="NO"
                        CssClass="KioskTextButton" OnClick="btnYesNo_Click" />
                </asp:Panel>
                <asp:Panel ID="pnlTypeRank" runat="server" Visible="false">
                    <asp:Button ID="btnRank1" runat="server" Width="50" Text="1" CommandArgument="1"
                        CssClass="KioskTextButton" OnClick="btnRank_Click" />
                    <asp:Button ID="btnRank2" runat="server" Width="50" Text="2" CommandArgument="2"
                        CssClass="KioskTextButton" OnClick="btnRank_Click" />
                    <asp:Button ID="btnRank3" runat="server" Width="50" Text="3" CommandArgument="3"
                        CssClass="KioskTextButton" OnClick="btnRank_Click" />
                    <asp:Button ID="btnRank4" runat="server" Width="50" Text="4" CommandArgument="4"
                        CssClass="KioskTextButton" OnClick="btnRank_Click" />
                    <asp:Button ID="btnRank5" runat="server" Width="50" Text="5" CommandArgument="5"
                        CssClass="KioskTextButton" OnClick="btnRank_Click" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
    </table>
</asp:Panel>
