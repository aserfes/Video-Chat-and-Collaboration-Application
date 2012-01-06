<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LanguageProfile.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.LanguageProfile" %>

<asp:ObjectDataSource ID="objectdatasourceEdit" Runat="server"
    TypeName="UCENTRIK.LIB.BllProxy.BllProxyLanguage"
    SelectMethod="SelectLanguage"
    InsertMethod="InsertLanguage"
    UpdateMethod="UpdateLanguage"
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
                        DataKeyNames="language_id"
                        
                        OnDataBound="dvControl_DataBound"
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
                              
                            <asp:TemplateField HeaderText="Language name"
                              SortExpression="language_name">
                              
                                <ItemTemplate>
                                    <asp:Label ID="lblLanguageName" runat="server"
                                        Text='<%# Bind("language_name") %>'>
                                        >
                                    </asp:Label>
                                </ItemTemplate>
                              
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLanguageName" runat="server"
                                        Text='<%# Bind("language_name") %>'>
                                    </asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="rfvLanguageName"
                                      runat="server"
                                        ControlToValidate="txtLanguageName"
                                        ValidationGroup="Edit"
                                        ErrorMessage="Required Field"
                                        >
                                        Required
                                    </asp:RequiredFieldValidator>
                                    
                                </EditItemTemplate>
                                
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Agents"
                              InsertVisible="false"
                              SortExpression="agent_cnt">
                              
                                <ItemTemplate>
                                    
                                    <asp:Label ID="lblAgentCnt" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "agent_cnt")%>'
                                    >
                                    </asp:Label>
                                    
                                    &nbsp;&nbsp;&nbsp;
                                    
                                    <asp:LinkButton ID="lbManageAgents" runat="server"
                                        CommandArgument='<%# Eval("language_id")%>'
                                        Visible="false"
                                        onclick="lbManageAgents_Click"
                                    >
                                        Click here to manage agents
                                    </asp:LinkButton>                                    
                                    
                                    
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                                                            
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

