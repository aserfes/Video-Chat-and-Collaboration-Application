<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingItem.ascx.cs" Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.Elements.SettingItem" %>



<table width="100%" align="center" cellSpacing="0" cellPadding="0" border="0">
    <tr>
    
        <td width="150px" align="right" nowrap>
            <asp:Label ID="lblName" runat="server"
                Text=""
            >
            </asp:Label>
        </td>
        
        <td>&nbsp;&nbsp;&nbsp;</td>
        
        <td width="10%" align="left">
            <asp:HiddenField ID="hfSettingCategory" runat="server" />
            <asp:TextBox ID="txtValue" runat="server"
                Width="450"
                MaxLength="250"
                Text="" ToolTip="Help Message"
            ></asp:TextBox>
        </td>
        
        
        <td>&nbsp;&nbsp;&nbsp;</td>

        <td align="center">
        
            <asp:RequiredFieldValidator ID="rfSettingValue" runat="server"
                ControlToValidate="txtValue"
                Display="Static"
                Text="*"
                ValidationGroup="Setting"
                ErrorMessage="RequiredFieldValidator"
            >
            </asp:RequiredFieldValidator>
            
            
        </td>

        <td>&nbsp;&nbsp;&nbsp;</td>

        <td width="10%" align="left">
            <asp:Button ID="btnSave" runat="server"
                Width="75px"
                Text="Save"
                ValidationGroup="Setting"
                Enabled="true"
                
                OnClick="btnSave_Click"
            />
        </td>

        <td>&nbsp;&nbsp;&nbsp;</td>

        <td width="80%" align="left">
            <asp:Label ID="lblMessage" runat="server"
                CssClass="ErrorMessage"
                Text=""
            >
            </asp:Label>
        </td>


        
    </tr>
</table>