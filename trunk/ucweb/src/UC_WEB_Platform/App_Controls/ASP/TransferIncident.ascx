<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransferIncident.ascx.cs" Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.ASP.TransferIncident" %>



<%@ Register TagPrefix="ucentrik" TagName="GroupRadioButton" Src="../Elements/GroupRadioButton.ascx" %>


<%@ Register TagPrefix="uc" Namespace="UCENTRIK.LIB.App_Controls.ServerControls" Assembly="UCENTRIK.LIB" %>





    <table width="100%" cellpadding="0" cellspacing="0" border="0">



        <tr>
            <td>
Select the agent with the required knowledge level and transfer the incident to the selected agent.
            </td>
        </tr>
        


        <tr>
            <td>
                <br />
                
            </td>
        </tr>
        
        
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <br />
                
            </td>
        </tr>
        





            
        <asp:Panel ID="pnlAgentPool" runat="server"
            Width="100%"
            BorderWidth="0px"
            Visible="true"
        >
        
	    <tr>
		    <td>



<asp:UpdatePanel ID="upWork" runat="server"
    UpdateMode="Conditional"
    >
    <ContentTemplate>

                <table width="100%" cellpadding="0" cellspacing="0" border="0">

                    <tr>
                        <td width="1%"></td>
                        <td width="4%"></td>
                        <td width="25%"></td>
                        <td width="20%"></td>
                        <td width="20%"></td>
                        <td width="30%"></td>
                    </tr>



                        <asp:Repeater ID="rptAgentPool" runat="server">
                            <HeaderTemplate>
	                                <tr>
		                                <td colspan="6">
		                                </td>
	                                </tr>
                            
                            </HeaderTemplate>
                            
                            <ItemTemplate>







                                <asp:Panel ID="Panel1" runat="server"
                                    Visible='<%# DataBinder.Eval(Container.DataItem, "agent_id").Equals(this.currentAgentId()) ? false : true %>'
                                >
	                                <tr>
	                                    
	                                    <td>
                                            <asp:HiddenField ID="hfAgentId" runat="server"
                                                Value='<%# DataBinder.Eval(Container.DataItem, "agent_id") %>'
                                            />
	                                    </td>
	                                    
	                                    
		                                <td>
                                            <uc:UcGroupRadioButton id="ucGroupRadioButton" runat="server"
                                                Enabled='<%# DataBinder.Eval(Container.DataItem, "is_available") %>'                            

                                                Text='<%# DataBinder.Eval(Container.DataItem, "agent_full_name") %>'
                                                UcValue='<%# DataBinder.Eval(Container.DataItem, "agent_id") %>'
                                                
                                                GroupName="AGENTS"
                                                OnCheckedChanged="rb_CheckedChanged"
                                            />
		                                </td>

	                                    
		                                <td>
                                            <asp:Label ID="lblAgentName" runat="server"
                                                Text='<%# DataBinder.Eval(Container.DataItem, "agent_full_name") %>'
                                                Enabled='<%# DataBinder.Eval(Container.DataItem, "is_available") %>'
                                            >
                                            </asp:Label>
		                                </td>


		                                <td>
                                            <asp:Label ID="lblAgentAvailable" runat="server"
                                                Text='<%# DataBinder.Eval(Container.DataItem, "is_available").Equals(true) ? "Available" : "Unavailable" %>'
                                            >
                                            </asp:Label>
		                                </td>
                		                

		                                <td>
                                            <asp:Label ID="lblAgentBusy" runat="server"
                                                Text='<%# DataBinder.Eval(Container.DataItem, "is_busy").Equals(true) ? "Busy" : "" %>'
                                            >
                                            </asp:Label>
		                                </td>
                		                
                		                
                		                <td></td>
                		                
	                                </tr>
                                </asp:Panel>            
                	                

                	                
                	                
                                    <tr height="10px">
                                        <td colspan="6"></td>
                                    </tr>
                                    
                            </ItemTemplate>
                            
                            <FooterTemplate>
	                                <tr>
		                                <td colspan="6">
		                                    <br />
		                                </td>
	                                </tr>
                            </FooterTemplate>
                        </asp:Repeater>

                     
                     
                     
                     
                                         
                    <tr>
                        <td colspan="6">
                            <br />
                            
                        </td>
                    </tr>
                    
                    
                </table>
                
    </ContentTemplate>
</asp:UpdatePanel>



                

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






        <tr>
            <td align="right">
            
                <asp:Button ID="btnTransfer" runat="server"
                        
                    Width="100px"
                    Height="24px"
                    CssClass="UcButton"
                    
                    
                    Text="Transfer"
                    OnClick="btnTransfer_Click"
                />
                    
            </td>
        </tr>        
                
        
    </table>


