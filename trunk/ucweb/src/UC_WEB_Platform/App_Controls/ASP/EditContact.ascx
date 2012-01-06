<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditContact.ascx.cs" Inherits="UCENTRIK.UserControls.ASP.EditContact" %>

            <asp:ObjectDataSource ID="objectdatasourceEdit" Runat="server"
                TypeName="UCENTRIK.LIB.BllProxy.BllProxyContact"
                SelectMethod="SelectContact"
                InsertMethod="InsertContact"
                UpdateMethod="UpdateContact"
                >
            </asp:ObjectDataSource>




<asp:Panel ID="pnlContact" runat="server"
    BorderWidth="0px"
    BorderColor="#A0A0A0"
>


    <table width="100%" align="center" valign="top" cellSpacing="2" cellPadding="0" border="0">

	    <tr>
		    <td width="30%"></td>
		    <td width="60%"></td>
		    <td width="10%"></td>
	    </tr>


	    <tr>
		    <td colspan="3">
		        <asp:HiddenField ID="hfContactId" runat="server" />
		    </td>
	    </tr>




        <asp:Panel ID="pnlAnonymous" runat="server"
            Width="100%"
            BorderWidth="0px"
            Visible="false"
        >

	    <tr>
		    <td align="center">
                <asp:CheckBox ID="chkbxAnonymous" runat="server" />
		    </td>
		    <td align="left">
                Anonymous Contact   
		    </td>
		    <td align="right">
		    </td>
	    </tr>

        </asp:Panel>




        <asp:Panel ID="pnlFind" runat="server"
            Width="100%"
            BorderWidth="0px"
            Visible="false"
        >
    	
    	
    	
    	

        <tr>
		    <td colspan="3">
		        <br />
		    </td>
	    </tr>



	    <tr>
		    <td>
		    </td>
		    <td align="left">
                Phone Number:
                &nbsp;
                <asp:TextBox ID="txtPhoneNumber" runat="server"
                    Width="200"
                >
                </asp:TextBox>
		    </td>
		    <td align="right">
                <asp:Button ID="btnFind" runat="server" 
                    Text="Find Contact"
                        
                        Width="100px"
                        Height="24px"
                        CssClass="UcButton"
                        
                    onClick="btnFind_Click"
                />
		    </td>
	    </tr>
    	
    	
        
        
    	
	    <tr>
		    <td colspan="3">
		        <br />
		    </td>
	    </tr>
	    </asp:Panel>



        <asp:Panel ID="pnlSearchResults" runat="server"
            Width="100%"
            BorderWidth="0px"
            Visible="false"
        >
        
	    <tr>
		    <td colspan="3">

            <asp:Repeater ID="rptContacts" runat="server">
            <HeaderTemplate>
                <table width="100%" align="center" cellSpacing="0" cellPadding="0" border="0">
	                <tr>
		                <td colspan="3">
		                    <br />
		                </td>
	                </tr>
            
            </HeaderTemplate>
            
            <ItemTemplate>
	                <tr>
		                <td colspan="2">
		                    <%# DataBinder.Eval(Container.DataItem, "first_name") %>
		                    &nbsp;&nbsp;&nbsp;
		                    <%# DataBinder.Eval(Container.DataItem, "last_name")%>
		                </td>
		                <td>
                            <asp:LinkButton ID="LinkButton1" runat="server"
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "contact_id") %>'
                                OnClick="btnContact_Click"
                            >
                            <%# DataBinder.Eval(Container.DataItem, "email") %>
                            </asp:LinkButton>
		                </td>
	                </tr><td colspan="3">
            </ItemTemplate>
            
            <FooterTemplate>
	                <tr>
		                <td colspan="3">
		                    <br />
		                </td>
	                </tr>
                </table>	            
            </FooterTemplate>
            </asp:Repeater>
        
		    </td>
	    </tr>

        </asp:Panel>	



        <asp:Panel ID="pnlContactDetails" runat="server"
            Visible="false"
        >

	    <tr>
		    <td colspan="3">
        

                <asp:DetailsView ID="dvControl" runat="server"
                    DataKeyNames="contact_id"
                    
                    OnItemInserting="dvControl_ItemInserting"
                    OnItemUpdating="dvControl_ItemUpdating"
                    >
                    
                    <HeaderStyle Width="150px" />
                    <RowStyle Height="30px" />
                    
                         
                            <Fields>
                            
                                <asp:BoundField HeaderText="ID" DataField="contact_id"
                                  SortExpression="contact_id"
                                  InsertVisible="false"
                                  ReadOnly="false"
                                  Visible="false"
                                  />

                                  


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
                                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="50"
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
                                
                                


                                <asp:BoundField HeaderText="MEMO" DataField="memo"
                                  ReadOnly="false"
                                  InsertVisible="true"
                                  Visible="false" />                                               




                                
                                

                            </Fields>
                        
                </asp:DetailsView>		    


		    </td>
	    </tr>
    	
    	
        </asp:Panel>	



        <asp:Panel ID="pnlNotFound" runat="server"
            Width="100%"
            BorderWidth="0px"
            Visible="false"
        >
        
	    <tr>
		    <td colspan="3" class="ErrorMessage">
    		
    No contacts found

		    </td>
	    </tr>

        </asp:Panel>	



        <asp:Panel ID="pnlAdd" runat="server"
            BorderWidth="0px"
            Visible="false"
        >

    	
	    <tr>
		    <td colspan="3">
		        <br />
		    </td>
	    </tr>
    	
    	


	    <tr>
		    <td colspan="2">
		    </td>
		    <td align="right">
                <asp:Button ID="btnAdd" runat="server" 
                    Text="Add New Contact"
                        
                        Width="100px"
                        Height="24px"
                        CssClass="UcButton"
                        
                    onClick="btnAdd_Click"
                />
		    </td>
	    </tr>

        </asp:Panel>
    	
    	
    	
	    <tr>
		    <td colspan="3">
		        <br />
		    </td>
	    </tr>
    	
    		
    	
    </table>

</asp:Panel>