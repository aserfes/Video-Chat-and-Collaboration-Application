<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Question.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.Question" %>


<%@ Register TagPrefix="ucentrik" TagName="QuestionProfile" Src="QuestionProfile.ascx" %>





          <asp:ObjectDataSource ID="objectdatasourceList" Runat="server"
            TypeName="UCENTRIK.LIB.BllProxy.BllProxyQuestion"
            SelectMethod=""
            DeleteMethod="DeleteQuestion"
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
                    Questions:&nbsp;
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
                        DataKeyNames="question_id"
                        OnRowEditing="gvList_RowEditing" 
                        >


                        
                             
                        
                        <columns>





                            <asp:TemplateField
                                ConvertEmptyStringToNull="true"
                                HeaderText="Question"
                                HeaderStyle-HorizontalAlign="Left"
                                SortExpression="question_text"
                                Visible="true"
                                >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbQuestion" runat="server"
                                        CommandArgument='<%# Eval("question_id")%>'
                                        onclick="lbQuestion_Click"
                                    >
                                        <%# Eval("question_text")%>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                            
                            
                            <asp:boundfield datafield="question_text"
                                headertext="Question" 
                                HeaderStyle-HorizontalAlign="Left"
                                readonly="true"
                                SortExpression="question_text"
                                />
                                
                                
                            
                            
                            
                            
                            <asp:boundfield datafield="question_type_name"
                                headertext="Type" 
                                HeaderStyle-HorizontalAlign="Left"
                                readonly="true"
                                SortExpression="question_type_name"
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
                    <ucentrik:QuestionProfile ID="profileControl" runat="server"
                        OnProfileSaveButton="view_Save"
                        OnProfileBackButton="view_Back"
                    />
                </td>
            </tr>
        </table>            
        
    
    
    </asp:View>

</asp:MultiView>


    

