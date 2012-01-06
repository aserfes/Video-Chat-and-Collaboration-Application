<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.ascx.cs" Inherits="UcentrikWeb.App_Controls.Elements.DatePicker" %>



<table cellpadding="0" cellspacing="0" border="0">
    <tr height="25px">
        <td align="left" valign="middle">
            <asp:DropDownList ID="ddlDay" Runat="server"
                Width="50"
                
                OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"
                >
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;
            of
            &nbsp;
        </td>
        <td align="left" valign="middle">
            <asp:DropDownList ID="ddlMonth" Runat="server"
                Width="120"
                AutoPostBack="true"
                
                OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"
                >
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;&nbsp;&nbsp;
        </td>
        <td align="left" valign="middle">
            <asp:DropDownList ID="ddlYear" Runat="server"
                Width="75"
                AutoPostBack="true"
                
                OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"
                >
            </asp:DropDownList>
        </td>
    </tr>
</table>