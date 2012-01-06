<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageTitle.ascx.cs" Inherits="UcentrikWeb.App_Controls.CommonControls.PageTitle" %>


    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>


            <td width="50px" align="left" valign="bottom">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server"
                    DynamicLayout="false"
                    DisplayAfter="0"
                    >
                    
                    <ProgressTemplate>
                        <div id="Update">
                            &nbsp;
                        </div>                        
                    </ProgressTemplate>
                    
                </asp:UpdateProgress>
            </td>



            <td class="TitleText" valign="bottom">
                <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>