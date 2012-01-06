<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionProfile.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.QuestionProfile" %>



          <asp:ObjectDataSource ID="objectdatasourceEdit" Runat="server"
            TypeName="UCENTRIK.LIB.BllProxy.BllProxyQuestion"
            SelectMethod="SelectQuestion"
            InsertMethod="InsertQuestion"
            UpdateMethod="UpdateQuestion"
            >

          </asp:ObjectDataSource>
                      



	<table width="100%" height="100%" align="center" cellSpacing="0" cellPadding="0" border="0">


            
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
                        DataKeyNames="question_id"
                        
                        OnDataBound="dvControl_DataBound"
                        OnItemUpdating="dvControl_ItemUpdating"
                        >
                        
                        <HeaderStyle Width="150px" />
                        <RowStyle Height="30px" />
                        
                        

                        <Fields>
                        




                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfQuestionTypeId" runat="server"     Value='<%# Bind("type_id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        






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
                              
                                              
                                              






                            <asp:TemplateField HeaderText="Question">
                              
                                <ItemTemplate>
                                    <asp:Label ID="lblQuestionText" runat="server"
                                        Text='<%# Bind("question_text") %>'>
                                        >
                                    </asp:Label>
                                </ItemTemplate>
                              
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtQuestionText" runat="server"
                                        TextMode="MultiLine"
                                        Rows="3"
                                        Width="400"
                                        MaxLength="200"
                                        Text='<%# Bind("question_text") %>'>
                                    </asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="rfvQuestionText"
                                      runat="server"
                                        ControlToValidate="txtQuestionText"
                                        ValidationGroup="Edit"
                                        ErrorMessage="Required Field"
                                        >
                                        Required
                                    </asp:RequiredFieldValidator>
                                    
                                </EditItemTemplate>
                                
                            </asp:TemplateField>
         
         
         
         



                        <asp:TemplateField HeaderText="Type"
                          Visible="true">
                          

                            <ItemTemplate>
                                <asp:Label ID="lblQuestionType" runat="server"
                                    Text='<%# Bind("question_type_name") %>'
                                    Visible="false"
                                    >
                                </asp:Label>
                            </ItemTemplate>

                            <EditItemTemplate>
                                
                                <asp:DropDownList ID="ddlQuestionTypes" runat="server"
                                    AutoPostBack="true"
                                    Width="200"
                                    DataTextField="question_type_name"
                                    DataValueField="question_type_id"
                                    OnSelectedIndexChanged="ddlQuestionTypes_SelectedIndexChanged"
                                    >
                                </asp:DropDownList>
                                
                                <asp:RequiredFieldValidator ID="rfvQuestionType"
                                  runat="server"
                                    ControlToValidate="ddlQuestionTypes"
                                    ValidationGroup="Edit"
                                    ErrorMessage="Required Field"
                                    >
                                    Required
                                </asp:RequiredFieldValidator>
                                
                                
                            </EditItemTemplate>
                            
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

