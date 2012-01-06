<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="User.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.User" %>

<%@ Register TagPrefix="ucentrik" TagName="UserProfile" Src="UserProfile.ascx" %>





          <asp:ObjectDataSource ID="objectdatasourceList" Runat="server"
            TypeName="UCENTRIK.LIB.BllProxy.BllProxyUser"
            SelectMethod=""
            DeleteMethod="DeleteUser"
            OnSelected="dataSelected"
            >
          </asp:ObjectDataSource>





<asp:MultiView ID="mvControl" runat="server"
        ActiveViewIndex="0"
        >

    <asp:View ID="viewList" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">

            
            <tr height="25">
                <td align="left" colspan="2">
                    <asp:Label ID="lblMessage" runat="server"
                        Text="">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>

            
            <tr>
                <td align="left">
                    
                </td>
                <td align="right">
                    Users:&nbsp;
                    <asp:Label ID="lblCount" runat="server"
                        Text="">
                    </asp:Label>

                </td>
            </tr>


            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>

            
            <tr>
                <td colspan="2">
                    <asp:PlaceHolder ID="phControls" runat="server">
                    </asp:PlaceHolder>
                </td>
            </tr>



            <tr>
                <td colspan="2">
                    <br />
                    <br />
                </td>
            </tr>



          


            <tr>
                <td align="center" colspan="2">
                
                    <asp:GridView id="gvList" runat="server"
                        DataKeyNames="user_id"
                        OnRowEditing="gvList_RowEditing" 
                        >


                        
                        
                        <columns>



                            <asp:TemplateField
                                ConvertEmptyStringToNull="true"
                                HeaderText="UserName"
                                HeaderStyle-HorizontalAlign="Left"
                                SortExpression="username"
                                Visible="true"
                                >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbUser" runat="server"
                                        CommandArgument='<%# Eval("user_id")%>'
                                        onclick="lbUser_Click"
                                    >
                                        <%# Eval("username")%>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="username"
                                HeaderText="UserName" 
                                HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true"
                                SortExpression="username"
                                />










                            <asp:BoundField DataField="full_name"
                                HeaderText="Name" 
                                HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true"
                                SortExpression="full_name"
                                />



                            <asp:boundfield DataField="user_role_name"
                                HeaderText="Role" 
                                HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true"
                                SortExpression="user_role_name"
                                />
                                                            

                            <asp:boundfield DataField="date_last_login" 
                                
                                DataFormatString="{0:MMMM d, yyyy}" 
                                HtmlEncode="false"
                                
                                ConvertEmptyStringToNull="true"
                                HeaderText="Last Login"
                                HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true"
                                SortExpression="date_last_login"
                                />






                            <asp:CommandField 
                                HeaderText="Command"
                                ShowHeader="True"
                                HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="50"
                                
                                ItemStyle-Width="50"
                                ItemStyle-Wrap="false"
                                ItemStyle-HorizontalAlign="Center"
                                
                                ShowCancelButton="false"
                                ShowEditButton="true"
                                ShowDeleteButton="true"
                                EditText="Edit"
                                DeleteText="Delete"
                                />

                                
                        </columns>
                        
                        


                    </asp:GridView>
                
                </td>
            </tr>


            <tr>
                <td colspan="2">
                    <br />
                    <br />
                </td>
            </tr>





            <asp:Panel ID="pnlAdd" runat="server" Visible="false">
            <tr>
                <td align="left">
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" 
                        Text="Add"
                        Width="50"
                        onclick="btnAdd_Click"
                        />
                </td>
            </tr>
            </asp:Panel>


        </table>
    </asp:View>
    
    
    <asp:View ID="viewEdit" runat="server">
        
            
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    <ucentrik:UserProfile ID="profileControl" runat="server"
                        OnProfileSaveButton="view_Save"
                        OnProfileBackButton="view_Back"
                    />
                </td>
            </tr>
        </table>            
        
    
    
    </asp:View>

</asp:MultiView>


    

