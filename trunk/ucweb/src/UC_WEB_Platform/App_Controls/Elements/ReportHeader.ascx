<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportHeader.ascx.cs" Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.Elements.ReportHeader" %>


<%@ Register TagPrefix="ucentrik" TagName="DatePicker" Src="DatePicker.ascx" %>




<table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">
    
    
    <tr height="1px">
        <td>
            <img src="../images/spacer.gif" width="960px" height="0px" border="0" /><br />
        </td>
    </tr>

    
    <tr height="10px">
        <td align="center" valign="middle" class="ReportHeader">
            
            <table width="100%" height="100%" cellpadding="2" cellspacing="0" border="0">

                <tr height="20px">
                    <td colspan="3">
                        &nbsp;
                        <asp:Label ID="lblMessage" runat="server"
                            CssClass="ErrorMessage"
                            Text=""
                        >
                        </asp:Label>
                    </td>
                </tr>


                <tr>
                    <td width="90%" valign="middle">

                        <table width="100%" height="60px" cellpadding="0" cellspacing="0" border="0">
                        
                            <tr height="50%">
                                
                                <td width="100px" align="right">
                                    Group by:
                                </td>
                                <td width="10px">&nbsp;</td>
                                <td align="left" valign="middle">

                                    <asp:DropDownList ID="ddlGroup" Runat="server"
                                        AutoPostBack="false"
                                        Width="150"
                                        
                                        OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"
                                        >
                                        <asp:ListItem Text="Agent"      Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Group"      Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Facility"   Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Contact"    Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Status"     Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Date"       Value="6"></asp:ListItem>                                            
                                        
                                    </asp:DropDownList>
                                    
                                </td>
                                
                                
                                
                                
                                <td width="25px">&nbsp;</td>                                    
                                
                                
                                
                                <td width="100px" align="right">
                                    Start:
                                </td>
                                <td width="10px">&nbsp;</td>
                                <td align="left" valign="middle">
                                    <ucentrik:DatePicker ID="datePickerStart" runat="server" />
                                </td>
                            </tr>


                            <tr height="50%">
                                <td width="100px" align="right">
                                </td>
                                <td width="10px">&nbsp;</td>
                                <td align="left" valign="middle">
                                </td>
                                
                                
                                <td width="25px">&nbsp;</td>
                                
                                
                                <td width="100px" align="right">
                                    End:
                                </td>
                                <td width="10px">&nbsp;</td>
                                <td align="left" valign="middle">
                                    <ucentrik:DatePicker ID="datePickerEnd" runat="server" />
                                </td>
                            </tr>

                        </table>
                    
                    </td>
                    
                    <td>&nbsp;</td>
                    
                    <td width="10%" align="right" valign="middle">
                        <asp:Button ID="btnViewReport" runat="server"

                            Width="150px"
                            Height="24px"
                            CssClass="UcButtonLarge"

                            Text="View Report"
                            OnClick="btnViewReport_Click"
                        />
                    </td>
                    
                    <td>&nbsp;</td>
                </tr>
                

                <tr height="5px">
                    <td colspan="3"></td>
                </tr>
                                    
            </table>
            
        </td>
    </tr>

</table>