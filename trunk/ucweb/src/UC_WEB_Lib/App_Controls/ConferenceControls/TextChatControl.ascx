<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextChatControl.ascx.cs" Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.ConferenceControls.TextChatControl" %>



            



<table width="100%" align="center" cellSpacing="0" cellPadding="0" border="0">

	<tr>
		<td>
		    <br />
		</td>
	</tr>




	<tr>
		<td>

<asp:UpdatePanel ID="upMessageList" runat="server"
    UpdateMode="Always"
>
    <ContentTemplate>

        <asp:Panel ID="pnlMessageList" runat="server"
            Width="100%"
            Height="240px"
            ScrollBars="Auto"
            BorderWidth="1px"
            BorderColor="#A0A0A0"
        >


<table width="100%" height="100%" cellSpacing="10" cellPadding="0" border="0">
	<tr>
		<td valign="bottom">

        <asp:Repeater ID="rptTextChat" runat="server">
            
            <HeaderTemplate>
                <table width="100%" align="center" cellSpacing="0" cellPadding="0" border="0">
	                <tr height="1px">
		                <td>
		                    <img src="../images/spacer.gif" width="150px" height="1px" border="0" />
		                </td>
		                <td>
		                    &nbsp;&nbsp;&nbsp;
		                </td>
		                <td>
		                </td>
	                </tr>
            </HeaderTemplate>


            <ItemTemplate>
	                <tr>
		                <td width="10%" align="right" valign="top" nowrap>
                            <asp:Label ID="lblMessageSender" runat="server"
                                CssClass='<%# getMessageSenderCssClass(DataBinder.Eval(Container.DataItem, "chat_sender"))%>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "chat_sender")%>'
                            >
                            </asp:Label>
		                </td>
		                
		                <td>&nbsp;</td>
		                
		                <td width="80%" align="left" valign="top">
                            <asp:Label ID="lblMessageText" runat="server"
                                Text='<%# getWrappedMessage(DataBinder.Eval(Container.DataItem, "chat_message"))%>'
                            >
                            </asp:Label>
		                </td>
		                
		                <td>&nbsp;</td>
		                
		                <td width="10%" align="center" valign="top" nowrap>
                            <asp:Label ID="lblTime" runat="server"
                                Text='<%# getChatTime(DataBinder.Eval(Container.DataItem, "chat_datetime"))%>'
                            >
                            </asp:Label>
		                </td>
		                
		                <td>&nbsp;</td>
		                
		                <td width="10%" align="center" valign="top" nowrap>
                            <asp:Label ID="lblDate" runat="server"
                                CssClass="TextUnimportant"
                                Text='<%# getChatDate(DataBinder.Eval(Container.DataItem, "chat_datetime"))%>'
                            >
                            </asp:Label>
		                </td>

	                </tr>
            </ItemTemplate>

            
            <FooterTemplate>
	                <tr height="1px">
		                <td>
		                    <img src="../images/spacer.gif" width="100px" height="1px" border="0" />
		                </td>
		                <td>
		                    &nbsp;&nbsp;&nbsp;
		                </td>
		                <td>
		                </td>
	                </tr>
                </table>
            </FooterTemplate>
            
        </asp:Repeater>

		</td>
	</tr>
</table>


        </asp:Panel>


    </ContentTemplate>
</asp:UpdatePanel>

		</td>
	</tr>






	<tr>
		<td>
		    <br />
		</td>
	</tr>






	<tr>
		<td>

<asp:UpdatePanel ID="upMessageBox" runat="server"
UpdateMode="Conditional"
>
    <ContentTemplate>

        <table width="100%" align="center" cellSpacing="0" cellPadding="0" border="0">
	        <tr>
	        
		        <td width="5%">
                    <asp:TextBox ID="txtMessage" runat="server"
                        Width="320"
                        MaxLength="250"
                        Text=""
                    >
                    </asp:TextBox>
                    
                    
		        </td>
		        <td width="5%">
                    <asp:TextBox ID="txtNull" runat="server" style="visibility:hidden"
                        Width="0"
                        ValidationGroup="Message"
                        Visible="true"
                        Enabled="false"
                    >
                    </asp:TextBox>
		            &nbsp;
		        </td>
		        
		        
		        
		        <td width="5%">
                    <asp:RequiredFieldValidator ID="rfvMessage"
                        runat="server"
                        ControlToValidate="txtMessage"
                        ValidationGroup="Message"
                        ErrorMessage="Required Field"
                        Display="Static"
                        Visible="false"
                    >
                    *
                    </asp:RequiredFieldValidator>
		        </td>
		        
		        <td>&nbsp;</td>
		        
		        <td width="80%">
                    <asp:Button ID="btnSend" runat="server"
                        ValidationGroup="Message"
                        UseSubmitBehavior="true"

                        Width="100px"
                        Height="24px"
                        CssClass="UcButton"
                        
                        
                        Text="Send"
                        OnClick="btnSend_Click"
                    />
		        </td>
	        </tr>
        </table>

    </ContentTemplate>
</asp:UpdatePanel>

		</td>
	</tr>



	<tr>
		<td>
		    <br />
		</td>
	</tr>

	<tr>
		<td>
		    <br />
		</td>
	</tr>


</table>

