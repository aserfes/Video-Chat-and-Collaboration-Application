<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.Contact" %>


<%@ Register TagPrefix="ucentrik" TagName="ContactProfile" Src="ContactProfile.ascx" %>





          <asp:ObjectDataSource ID="objectdatasourceList" Runat="server"
            TypeName="UCENTRIK.LIB.BllProxy.BllProxyContact"
            SelectMethod=""
            DeleteMethod="DeleteContact"
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
                    Contacts:&nbsp;
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
                        DataKeyNames="contact_id"
                        OnRowEditing="gvList_RowEditing" 
                        >


                        
                        
                        <columns>




                            <asp:TemplateField
                                ConvertEmptyStringToNull="true"
                                HeaderText="Contact"
                                HeaderStyle-HorizontalAlign="Left"
                                SortExpression="full_name"
                                Visible="true"
                                >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbContact" runat="server"
                                        CommandArgument='<%# Eval("contact_id")%>'
                                        onclick="lbContact_Click"
                                    >
                                        <%# Eval("full_name")%>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:boundfield datafield="full_name"
                                headertext="Contact" 
                                HeaderStyle-HorizontalAlign="Left"
                                readonly="true"
                                SortExpression="full_name"
                                />
                            
                            
                            
                            
                            
                            
                            
                            
                                

                            <asp:boundfield datafield="contact_guid"
                                headertext="GUID" 
                                HeaderStyle-HorizontalAlign="Left"
                                readonly="true"
                                SortExpression="contact_guid"
                                Visible="false"
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

                    Width="100px"
                    Height="24px"
                    CssClass="UcButton"

                        onclick="btnAdd_Click"
                        />
                </td>
            </tr>
            </asp:Panel>


        </table>
    </asp:View>
    
    
    <asp:View ID="viewEdit" runat="server">
        
            
        <table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td valign="top">
                    <ucentrik:ContactProfile ID="profileControl" runat="server"
                        OnProfileSaveButton="view_Save"
                        OnProfileBackButton="view_Back"
                    />
                </td>
            </tr>
        </table>            
        
    
    
    </asp:View>

</asp:MultiView>


    

