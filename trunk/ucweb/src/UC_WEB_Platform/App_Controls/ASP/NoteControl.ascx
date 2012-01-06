<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteControl.ascx.cs" Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.ASP.NoteControl" %>



    <table width="100%" cellpadding="0" cellspacing="0" border="0">



        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <br />
                
            </td>
        </tr>
        
        <tr>
            <td>
                <br />
            </td>
        </tr>

            
        <asp:Panel ID="pnlNotes" runat="server"
            Width="100%"
            BorderWidth="0px"
            Visible="true"
        >
            
	        <tr>
		        <td>

                    <table width="100%" cellpadding="0" cellspacing="0" border="0">


                        <tr>
                            <td width="10%"></td>
                            <td width="90%"></td>
                        </tr>

                        <asp:Repeater ID="rptNote" runat="server"
                            Visible="true"
                        >
                            <HeaderTemplate>
                                    <tr>
	                                    <td colspan="2"></td>
                                    </tr>
                            </HeaderTemplate>
                            
                            <ItemTemplate>









                                    <tr>
	                                    <td colspan="2">
		                                
                                            <table width="100%" height="20px" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblUser" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "user_full_name") %>'
                                                            CssClass="TextUnimportant"
                                                        >
                                                        </asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblDate" runat="server"
                                                            Text='<%# this.formatDateTime(DataBinder.Eval(Container.DataItem, "date_created")) %>'
                                                            CssClass="TextUnimportant"
                                                        >
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                            </table>

	                                    </td>
                                    </tr>


                                    <tr>
                                        <td></td>
	                                    <td>
                                                
                                            <table width="100%" height="20px" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td width="98%" align="left">
                                                    
		                                                <p align="justify">
                                                            <asp:Label ID="lblNote" runat="server"
                                                                Text='<%# this.formatNote(DataBinder.Eval(Container.DataItem, "note")) %>'
                                                            >
                                                            </asp:Label>
                                                         </p>
                                                         
                                                    </td>
                                                    
                                                    <td width="2%" align="right">
                                                    </td>
                                                    
                                                </tr>
                                            </table>
                                                
                                                
                                            
	                                    </td>
                                    </tr>

                	                
                	                
                                    <tr height="20px">
                                        <td colspan="2"></td>
                                    </tr>
                                    
                            </ItemTemplate>
                            
                            <FooterTemplate>
                                    <tr>
	                                    <td colspan="2">
	                                        <br />
	                                        <br />
	                                    </td>
                                    </tr>
                            </FooterTemplate>
                        </asp:Repeater>
                    
   
                        <asp:Panel ID="pnlEmpty" runat="server"
                            Width="100%"
                            BorderWidth="0px"
                            Visible="false"
                        >
                        
                        
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
There are no notes for this call
                                    </td>
                                </tr>
                            </table>        

                        </asp:Panel>

                            
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        
                        
                    </table>

		        </td>
	        </tr>
    	    
            <tr>
                <td>
                </td>
            </tr>
        
            <tr>
                <td>
        
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnAddNewNote" runat="server"
                                            
                                    Width="100px"
                                    Height="24px"
                                    CssClass="UcButton"
                        
                                    Text="Add Note"
                                    OnClick="btnAddNewNote_Click"
                                />
                            </td>
                        </tr>
                    </table>
        
                </td>
            </tr>
            


        </asp:Panel>






        <asp:Panel ID="pnlNewNote" runat="server"
            Width="100%"
            BorderWidth="0px"
            Visible="false"
        >

            <tr>
                <td>

                    <asp:TextBox ID="txtNote" runat="server"
                        Text='<%# Bind("note") %>'
                        TextMode="MultiLine"
                        Wrap="true"
                        Width="800px"
                        Height="200px"
                    >
                    </asp:TextBox>
                     
                    <asp:RequiredFieldValidator ID="rfvNote"
                        runat="server"
                        ControlToValidate="txtNote"
                        ValidationGroup="Edit"
                        ErrorMessage="Required Field"
                        Enabled="false"
                        >
                        Required
                    </asp:RequiredFieldValidator>        
                </td>
            </tr>

            <tr>
                <td>
        
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button ID="btnNewNoteCancel" runat="server"
                        
                                    Width="100px"
                                    Height="24px"
                                    CssClass="UcButton"
                        
                                    Text="Cancel"
                                    OnClick="btnNewNoteCancel_Click"
                                />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNewNoteAdd" runat="server"
                        
                                    Width="100px"
                                    Height="24px"
                                    CssClass="UcButton"
                                    
                                    
                                    Text="Add Note"
                                    OnClick="btnNewNoteAdd_Click"
                                />
                            </td>
                        </tr>
                    </table>
        
                </td>
            </tr>
        
        </asp:Panel>
        





        <tr>
            <td>
                <br />
                <br />
                <br />
            </td>
        </tr>        


                
        


        
    </table>
