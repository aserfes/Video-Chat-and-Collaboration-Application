<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="questions.aspx.cs" Inherits="UcentrikWeb.dirAdmin.questions" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Question" Src="../App_Controls/BusinessControls/Question.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">


</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Questions" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">


        <ucentrik:Question ID="sosQuestion" runat="server"
            UcDataSourceSelectMethod="GetAllQuestions"
            AllowDelete="true"
            ReadOnly="false"
            SortExpression="question_name"
            SortDirection="Ascending"
        />
    
    
</asp:Content>
