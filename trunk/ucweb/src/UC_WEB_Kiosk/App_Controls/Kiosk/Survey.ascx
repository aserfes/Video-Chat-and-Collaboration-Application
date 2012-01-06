<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Survey.ascx.cs" Inherits="UCENTRIK.WEB.KIOSK.Connect.Survey" %>
<%@ Register TagPrefix="ucentrik" TagName="SurveyQuestion" Src="../Survey/KioskSurveyQuestion.ascx" %>
<table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
    border="0">
    <tr height="50px">
        <td>
            <asp:UpdatePanel ID="upTimeWaiting" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer ID="timerRefresh" runat="server" Interval="1000" OnTick="timerRefresh_Tick">
                    </asp:Timer>
                    <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
                        border="0">
                        <tr height="20px">
                            <td align="center" valign="middle" class="KioskText">
                                <asp:Label ID="ltTimeSpan" runat="server" Text="0:00"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
                border="0">
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upSurvey" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
                                    border="0">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td valign="top">
                                            <asp:Repeater ID="rptSurveyQuestions" runat="server">
                                                <HeaderTemplate>
                                                    <table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <ucentrik:SurveyQuestion ID="SurveyQuestion" runat="server" QuestionId='<%# DataBinder.Eval(Container.DataItem, "question_id") %>'
                                                                QuestionTitle='<%# DataBinder.Eval(Container.DataItem, "question_text") %>' QuestionType='<%# DataBinder.Eval(Container.DataItem, "type_id") %>'
                                                                OnAnswerEntered="SurveyQuestion_AnswerEntered" />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tr>
                                                        <td>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <asp:Button ID="btnFinish" runat="server" Text="Done" Width="100" OnClick="btnFinish_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
