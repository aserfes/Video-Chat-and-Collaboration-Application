<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="UcentrikWeb.App_Controls.CommonControls.Login" %>
<div>
    <table id="login">
        <tr>
            <td>
                Username:
            </td>
            <td>
                <asp:TextBox ID="tbUserName" runat="server" ValidationGroup="LogInInfo" size="20"
                    Text="" />
            </td>
        </tr>
        <tr>
            <td>
                Password:
            </td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server" ValidationGroup="LogInInfo"
                    TextMode="Password" Text="" size="21"/>
            </td>
        </tr>
    </table>
    <div>
        <div class="validationColumn">
            <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="tbUserName"
                ValidationGroup="LogInInfo" Display="Dynamic" EnableClientScript="true" ErrorMessage="User Name is a required field"
                Text="User Name is a required field." />
            <asp:RegularExpressionValidator ID="revFullName" runat="server" ControlToValidate="tbUserName"
                ValidationGroup="LogInInfo" Display="Dynamic" EnableClientScript="true" ValidationExpression=".{0,256}"
                ErrorMessage="Length of User Name cannot exceed 256 symbols" Text="Length of User Name cannot exceed 256 symbols." />
            <asp:RegularExpressionValidator ID="revFullNameFormat" runat="server" ControlToValidate="tbUserName"
                ValidationGroup="LogInInfo" Display="Dynamic" EnableClientScript="true" ValidationExpression="[\w\s\-\;\:\*\.\,\)\(\/\\]*"
                ErrorMessage="Format of User Name is not valid" Text="Format of User Name is not valid" />
        </div>
        <div>
            <asp:PlaceHolder ID="plhLogInInvalid" runat="server" Visible="false">
                <div class="errorMessage">
                    Invalid username or password</div>
            </asp:PlaceHolder>
        </div>
        <div class="validators">
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword"
                ValidationGroup="LogInInfo" Display="Dynamic" EnableClientScript="true" ErrorMessage="Password is a required field"
                Text="Password is a required field." />
            <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="tbPassword"
                ValidationExpression=".{4}.*" ValidationGroup="LogInInfo" Display="Dynamic" EnableClientScript="true"
                ErrorMessage="Password must be at least 4 characters long" Text="Password must be at least 4 characters long." />
            <asp:RegularExpressionValidator ID="revPasswordLength" runat="server" ControlToValidate="tbPassword"
                ValidationGroup="LogInInfo" Display="Dynamic" EnableClientScript="true" ValidationExpression=".{0,50}"
                ErrorMessage="Length of Password cannot exceed 50 symbols" Text="Length of Password cannot exceed 50 symbols." />
            <asp:RegularExpressionValidator ID="revPasswordFormat" runat="server" ControlToValidate="tbPassword"
                ValidationGroup="LogInInfo" Display="Dynamic" EnableClientScript="true" ValidationExpression="[\w\s\-\;\:\*\.\,\)\(\/\\]*"
                ErrorMessage="Format of Password is not valid" Text="Format of Password is not valid" />
        </div>
    </div>
    <div id="helper">
        Forgot your
        <asp:HyperLink ID="HyperLink1" runat="server" Text="username" NavigateUrl='<%# this.RestorePasswordUrl %>' />
        or
        <asp:HyperLink ID="HyperLink2" runat="server" Text="password" NavigateUrl='<%# this.RestorePasswordUrl %>' />
        ?
        <asp:Button ID="btnLogin" runat="server" ValidationGroup="LogInInfo" OnClick="btnLogin_Click"
            Text="Log In" CssClass="customButton" />
    </div>
</div>
