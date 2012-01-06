<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestorePassword.ascx.cs"
    Inherits="UcentrikWeb.App_Controls.CommonControls.RestorePassword" %>
<div class="restorePasswordControl">
    <asp:PlaceHolder ID="plhPasswordRestoring" runat="server">
        <p>
            Forgot your username or password?</p>
        <p>
            Enter the email address associated with your account.</p>
        <br />
        <p>
            Email:
            <asp:TextBox ID="tbEmail" runat="server" ValidationGroup="RestorePasswordControl"
                size="32" />
        </p>
        <div>
            <div class="validators" style="display: inline-block">
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail"
                    ValidationGroup="RestorePasswordControl" Display="Dynamic" EnableClientScript="true"
                    ErrorMessage="Email is a required field" Text="Email is a required field." />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmail"
                    ValidationGroup="RestorePasswordControl" ValidationExpression="^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|([a-zA-Z-]+\.)+[a-zA-Z]{2,4})$"
                    Display="Dynamic" EnableClientScript="true" ErrorMessage="Email is not valid"
                    Text="Email is not valid." />
                <asp:RegularExpressionValidator ID="revEmailLength" runat="server" ControlToValidate="tbEmail"
                    ValidationGroup="RestorePasswordControl" Display="Dynamic" EnableClientScript="true"
                    ValidationExpression=".{0,256}" ErrorMessage="Length of Email cannot exceed 256 symbols"
                    Text="Length of Email cannot exceed 256 symbols." />
            </div>
            <asp:PlaceHolder ID="plhAccountDoesNotExist" runat="server" Visible="false">
                <div class="errorMessage">
                    Agent account does not exist</div>
            </asp:PlaceHolder>
        </div>
        <div>
            <asp:Button ID="btnRestorePassword" runat="server" ValidationGroup="RestorePasswordControl"
                OnClick="btnRestorePassword_Click" Text="Restore password" CssClass="customButton" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="customButton"
                OnClick="btnCancel_Click" Text="Cancel" />
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="plhPasswordRestored" runat="server" Visible="false">
        <p>
            Thank you; you will receive an email address with your user name and password shortly...
        </p>
        <asp:HyperLink ID="hplGoToLoginPage" runat="server" NavigateUrl='<%# this.LoginPageUrl %>'
            CssClass="goToLoginPageLink" Text="Go to login page" />
    </asp:PlaceHolder>
</div>
