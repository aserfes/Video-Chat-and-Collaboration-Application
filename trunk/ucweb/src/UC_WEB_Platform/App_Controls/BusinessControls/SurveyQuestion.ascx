<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyQuestion.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.SurveyQuestion" %>






          <asp:ObjectDataSource ID="objectdatasourceList" Runat="server"
            TypeName="UCENTRIK.LIB.BllProxy.BllProxySurveyQuestion"
            SelectMethod=""
            DeleteMethod="DeleteQuestion"
            OnSelected="dataSelected"
            >
          </asp:ObjectDataSource>




<table width="100%" cellpadding="0" cellspacing="0" border="0">

    

    <tr>
        <td>
            <br />
        </td>
    </tr>



    <tr height="25">
        <td align="left">
            Survey Question management:&nbsp;
            <asp:Label ID="lblSurveyName" runat="server"
                Text="">
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <br />
            <br />
            <br />
        </td>
    </tr>
    
    
    


    <tr height="25">
        <td align="left">
            <asp:Label ID="lblMessage" runat="server"
                Text="">
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>



  


    <tr>
        <td align="center" colspan="2">
        
            <asp:GridView id="gvList" runat="server"
                DataKeyNames="question_id, survey_id"
                
                OnRowCreated="gvList_RowCreated"
                
                OnRowEditing="gvList_RowEditing"
                OnRowDeleting="gvList_RowDeleting"
                
                >


                
                <columns>

                    <asp:boundfield datafield="question_text"
                        headertext="Question" 
                        HeaderStyle-HorizontalAlign="Left"
                        readonly="true"
                        SortExpression="question_text"
                        />
                        
                        
                        

                    
                    <asp:boundfield datafield="question_type_name"
                        HeaderText="Type" 
                        HeaderStyle-HorizontalAlign="Left"
                        
                        ItemStyle-Width="75"
                        ItemStyle-Wrap="false"
                        
                        
                        readonly="true"
                        SortExpression="question_type_name"
                        />
                                                
                        

                    <asp:TemplateField
                        ConvertEmptyStringToNull="true"
                        
                        HeaderText="In Survey"
                        HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Wrap="false"
                        
                        ItemStyle-Width="75"
                        ItemStyle-Wrap="false"
                        ItemStyle-HorizontalAlign="Center"
                        
                        
                        SortExpression="survey_id"
                        Visible="true"
                        >
                        <ItemTemplate>
                        
                            <asp:CheckBox ID="chkboxInSurvey" runat="server"
                                Enabled="false"
                                Checked='<%# !(Eval("survey_id") is System.DBNull) %>'
                            />
                            
                        </ItemTemplate>
                    </asp:TemplateField>




                    <asp:CommandField 
                        HeaderText="Command"
                        ShowHeader="True"
                        HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-Width="50"
                        ItemStyle-Wrap="false"
                        ItemStyle-HorizontalAlign="Center"
                        
                        ShowCancelButton="false"
                        ShowEditButton="true"
                        ShowDeleteButton="true"
                        
                        EditText="Add"
                        DeleteText="Remove"
                        />

                </columns>

                


            </asp:GridView>
        
        </td>
    </tr>


    
    <tr>
        <td>
            <br />
            <br />
            
        </td>
    </tr>
    

	<tr>
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
	</tr>    
            
</table>