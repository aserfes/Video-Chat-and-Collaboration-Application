<%@ Page Title="" Language="C#" MasterPageFile="~/Kiosk.Master" AutoEventWireup="true"
    CodeBehind="UcKioskConnect.aspx.cs" Inherits="UCENTRIK.WEB.KIOSK.dirKiosk.UcKioskConnect" %>

<%@ Register TagPrefix="ucentrik" TagName="Home" Src="../App_Controls/Kiosk/Home.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="LiveConnect" Src="../App_Controls/Kiosk/LiveConnectAPlus.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="WaitScreen" Src="../App_Controls/Kiosk/WaitScreen.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Survey" Src="../App_Controls/Kiosk/Survey.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Finish" Src="../App_Controls/Kiosk/Finish.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Error" Src="../App_Controls/Kiosk/Error.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="KioskContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="upPage" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" height="100%" cellspacing="0" cellpadding="0"
                border="0">
                <tr height="0px">
                    <td valign="middle" class="KioskTitle">
                        <asp:Literal ID="ltFacilityName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:MultiView ID="mvConference" runat="server" ActiveViewIndex="0" OnActiveViewChanged="mvConference_ActiveViewChanged">
                            <asp:View ID="viewHome" runat="server">
                                <ucentrik:Home ID="Home" runat="server" OnConnectNext="Home_KioskEntered" OnConnectError="Connect_Error" />
                            </asp:View>
                            <asp:View ID="viewWait" runat="server">
                                <ucentrik:WaitScreen ID="WaitScreen" runat="server" OnConnectNext="WaitScreen_SessionStarted"
                                    OnConnectBack="WaitScreen_SessionCanceled" OnConnectError="Connect_Error" />
                            </asp:View>
                            <asp:View ID="viewConnect" runat="server">
                                <ucentrik:LiveConnect ID="LiveConnect" runat="server" OnConnectNext="LiveConnect_SessionFinished"
                                    OnConnectError="Connect_Error" />
                            </asp:View>
                            <asp:View ID="viewSurvey" runat="server">
                                <ucentrik:Survey ID="Survey" runat="server" OnConnectNext="Survey_SurveyFinished"
                                    OnConnectError="Connect_Error" />
                            </asp:View>
                            <asp:View ID="viewError" runat="server">
                                <ucentrik:Error ID="ErrorControl" runat="server" OnConnectNext="Error_Handled" />
                            </asp:View>
                            <asp:View ID="viewFinish" runat="server">
                                <ucentrik:Finish ID="Finish" runat="server" OnConnectError="Connect_Error" />
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
