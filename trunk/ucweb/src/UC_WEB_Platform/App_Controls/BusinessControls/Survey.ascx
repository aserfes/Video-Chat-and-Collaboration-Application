<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Survey.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.Survey" %>

<%@ Register TagPrefix="ucentrik" TagName="SurveyProfile" Src="SurveyProfile.ascx" %>





          <asp:ObjectDataSource ID="objectdatasourceList" Runat="server"
            TypeName="UCENTRIK.LIB.BllProxy.BllProxySurvey"
            SelectMethod=""
            DeleteMethod="DeleteSurvey"
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
                    Surveys:&nbsp;
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
                        DataKeyNames="survey_id"
                        OnRowEditing="gvList_RowEditing" 
                        >


                        
                        
                        <columns>



                            <asp:TemplateField
                                ConvertEmptyStringToNull="true"
                                HeaderText="Survey"
                                HeaderStyle-HorizontalAlign="Left"
                                SortExpression="survey_name"
                                Visible="true"
                                >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbSurvey" runat="server"
                                        CommandArgument='<%# Eval("survey_name")%>'
                                        onclick="lbSurvey_Click"
                                    >
                                        <%# Eval("survey_name")%>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                            
                            
                            

                            
                            
                            <asp:boundfield datafield="survey_name"
                                headertext="Survey" 
                                HeaderStyle-HorizontalAlign="Left"
                                readonly="true"
                                SortExpression="survey_name"
                                />
                                
                                


                                                        
                            

                            
                            <asp:BoundField DataField="question_cnt"
                                HeaderText="Questions"
                                HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Wrap="false"
                                HeaderStyle-Width="100"

                                ItemStyle-Width="100"
                                ItemStyle-Wrap="false"
                                ItemStyle-HorizontalAlign="Center"
                                
                                ReadOnly="true"
                                SortExpression="question_cnt"
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
                    <ucentrik:SurveyProfile ID="profileControl" runat="server"
                        OnManageQuestions="sosSurvey_ManageQuestions"
                        
                        OnProfileSaveButton="view_Save"
                        OnProfileBackButton="view_Back"
                    />
                </td>
            </tr>
        </table>            
        
    
    
    </asp:View>

</asp:MultiView>


    

