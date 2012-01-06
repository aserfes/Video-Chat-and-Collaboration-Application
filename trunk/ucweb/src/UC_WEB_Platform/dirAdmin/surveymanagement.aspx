<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="surveymanagement.aspx.cs" Inherits="UcentrikWeb.dirAdmin.surveymanagement" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Survey" Src="../App_Controls/BusinessControls/Survey.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="SurveyQuestion" Src="../App_Controls/BusinessControls/SurveyQuestion.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">


</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Survey" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">



    <asp:MultiView ID="mvSurvey" runat="server"
        ActiveViewIndex="0"
        OnActiveViewChanged="mvSurvey_ActiveViewChanged"
        >

        <asp:View ID="ViewSurveyList" runat="server">
            <ucentrik:Survey ID="sosSurvey" runat="server"
                UcDataSourceSelectMethod="GetAllSurveys"
                AllowDelete="true"
                ReadOnly="false"
                SortExpression="survey_name"
                SortDirection="Ascending"
                
                OnManageQuestions="sosSurvey_ManageQuestions"
                
                OnNext="sosSurvey_Next"
            />
        </asp:View>



        <asp:View ID="ViewSurveyQuestionList" runat="server">
            <ucentrik:SurveyQuestion ID="sosSurveyQuestion" runat="server"
                
                UcDataSourceSelectMethod="GetAllSurveyQuestions"
                
                SortExpression="question_text"
                SortDirection="Ascending"
                
                OnBackToList="sosSurvey_Back"
            />
            
        </asp:View>        
        
    </asp:MultiView> 


    
    
</asp:Content>
