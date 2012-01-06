<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LogOnUser.ascx.cs" Inherits="UcentrikWeb.App_Controls.CommonControls.LogOnUser" %>
<% if (this.IsAuthorized) { %>
        Welcome <b><%= HttpUtility.HtmlEncode((this.UserName.Length <= 20) ? this.UserName : this.UserName.Substring(0, 20) + "...")%></b>
        [ <asp:LinkButton ID="LinkButton1" runat="server" Text="Log Off" OnClick="lbLogOff_Click" CssClass="customLink" /> ]
<% } else { %> 
        [ <asp:HyperLink ID="lnkLogOn" runat="server" Text="Log On" NavigateUrl='<%# this.LogOnUrl %>' CssClass="customLink" /> ]
<% } %>
