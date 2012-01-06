<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactProfile.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.ContactProfile" %>




          <asp:ObjectDataSource ID="objectdatasourceEdit" Runat="server"
            TypeName="UCENTRIK.LIB.BllProxy.BllProxyContact"
            SelectMethod="SelectContact"
            InsertMethod="InsertContact"
            UpdateMethod="UpdateContact"
            >

          </asp:ObjectDataSource>
                      
                      
                      
                      

	<table width="100%" height="320px" align="center" cellSpacing="0" cellPadding="0" border="0">


            
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
                <td colspan="2" valign="top">
            
                    <asp:DetailsView ID="dvControl" runat="server"
                        DataKeyNames="contact_id, user_id"
                        
                        OnItemUpdating="dvControl_ItemUpdating"
                        >
                        
                        <HeaderStyle Width="150px" />
                        <RowStyle Height="30px" />
                        
                        
                        
                        <Fields>
                        
                        



                            <asp:TemplateField HeaderText="Created"
                              SortExpression="date_created"
                              Visible="true">
                              
                                <ItemTemplate>
                                    <%# this.formatDateTime(DataBinder.Eval(Container.DataItem, "date_created"))%>
                                </ItemTemplate>
                                
                            </asp:TemplateField>

                              
                            <asp:TemplateField HeaderText="Updated"
                              SortExpression="date_updated"
                              Visible="true">
                              
                                <ItemTemplate>
                                    <%# this.formatDateTime(DataBinder.Eval(Container.DataItem, "date_updated"))%>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                              





                                                      
                        
                                                      


                            <asp:TemplateField HeaderText="First name"
                              SortExpression="first_name">
                              
                              
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstname" runat="server"
                                        Text='<%# Bind("first_name") %>'>
                                        >
                                    </asp:Label>
                                </ItemTemplate>
                              
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFirstname" runat="server"
                                        MaxLength="25"
                                        Text='<%# Bind("first_name") %>'>
                                    </asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="rfvFirstname"
                                      runat="server"
                                        ControlToValidate="txtFirstname"
                                        ValidationGroup="Edit"
                                        ErrorMessage="Required Field"
                                        >
                                        Required
                                    </asp:RequiredFieldValidator>
                                    
                                </EditItemTemplate>
                                
                            </asp:TemplateField>
 
                            
                            <asp:TemplateField HeaderText="Last name"
                              SortExpression="last_name">
                              
                                <ItemTemplate>
                                    <asp:Label ID="lblLastname" runat="server"
                                        Text='<%# Bind("last_name") %>'>
                                        >
                                    </asp:Label>
                                </ItemTemplate>
                              
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLastname" runat="server"
                                        MaxLength="25"
                                        Text='<%# Bind("last_name") %>'>
                                    </asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="rfvLastname"
                                      runat="server"
                                        ControlToValidate="txtLastname"
                                        ValidationGroup="Edit"
                                        ErrorMessage="Required Field"
                                        >
                                        Required
                                    </asp:RequiredFieldValidator>
                                    
                                </EditItemTemplate>
                                
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Email"
                              SortExpression="email">
                              
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server"
                                        Text='<%# Bind("email") %>'>
                                        >
                                    </asp:Label>
                                </ItemTemplate>
                              
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmail" runat="server"
                                        MaxLength="50"
                                        Text='<%# Bind("email") %>'>
                                    </asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="rfvEmail"
                                      runat="server"
                                        ControlToValidate="txtEmail"
                                        ValidationGroup="Edit"
                                        ErrorMessage="Required Field"
                                        >
                                        Required
                                    </asp:RequiredFieldValidator>
                                    
                                </EditItemTemplate>
                                
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Phone"
                              SortExpression="last_name">
                              
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" runat="server"
                                        Text='<%# Bind("phone") %>'>
                                        >
                                    </asp:Label>
                                </ItemTemplate>
                              
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPhone" runat="server"
                                        MaxLength="25"
                                        Text='<%# Bind("phone") %>'>
                                    </asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="rfvPhone"
                                      runat="server"
                                        ControlToValidate="txtPhone"
                                        ValidationGroup="Edit"
                                        ErrorMessage="Required Field"
                                        >
                                        Required
                                    </asp:RequiredFieldValidator>
                                    
                                </EditItemTemplate>
                                
                            </asp:TemplateField>     









                            <asp:TemplateField HeaderText="MEMO"
                              SortExpression="last_name">
                              
                                <ItemTemplate>
                                    <asp:Label ID="lblMemo" runat="server"
                                        Text='<%# Bind("memo") %>'>
                                        >
                                    </asp:Label>
                                </ItemTemplate>
                              
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMemo" runat="server"
                                        MaxLength="50"
                                        Text='<%# Bind("memo") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                
                            </asp:TemplateField>  





                            <asp:BoundField HeaderText="GUID" DataField="contact_guid"
                              ReadOnly="true"
                              InsertVisible="false"
                              Visible="false" />
                                               
                                                                                           

                        </Fields>
                        


                    </asp:DetailsView>
                    
                </td>
            </tr>
            
            


			<tr>
				<td colspan="2">
				    <br />
				</td>
			</tr>







			<tr>
				<td colspan="2" valign="bottom" class="separator">
                    <table width="100%" height="100%" align="center" cellSpacing="2" cellPadding="0" border="0">
			            <tr>
			                <td width="5px"></td>
                            <td align="left">
                                <asp:Button ID="btnBack" runat="server" 
                                    Text="BACK"

                    Width="100px"
                    Height="24px"
                    CssClass="UcButton"

                                    UseSubmitBehavior="false"
                                    OnClick="btnBack_Click"
                                    />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSave" runat="server" 
                                    Text="SAVE"

                    Width="100px"
                    Height="24px"
                    CssClass="UcButton"

                                    ValidationGroup="Edit"
                                    UseSubmitBehavior="true"
                                    OnClick="btnSave_Click"
                                    />
                            </td>
                            <td width="5px"></td>
			            </tr>
                    </table>
				</td>
			</tr>



			

    </table>

