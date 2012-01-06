<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupFacility.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.GroupFacility" %>






          <asp:ObjectDataSource ID="objectdatasourceList" Runat="server"
            TypeName="UCENTRIK.LIB.BllProxy.BllProxyGroupFacility"
            SelectMethod=""
            DeleteMethod=""
            OnSelected="dataSelected"
            >
          </asp:ObjectDataSource>




<table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">

    


    <tr height="25">
        <td align="left">
            Group Facility management:&nbsp;
            <asp:Label ID="lblGroupName" runat="server"
                Text="">
            </asp:Label>
        </td>
    </tr>
    

    <tr height="15px">
        <td></td>
    </tr>    
    
    


    <tr height="25">
        <td align="left">
            <asp:Label ID="lblMessage" runat="server"
                Text="">
            </asp:Label>
        </td>
    </tr>



    <tr height="15px">
        <td></td>
    </tr>


  


    <tr>
        <td align="center" valign="top" colspan="2">

        
            <asp:GridView id="gvList" runat="server"
                DataKeyNames="facility_id, group_id"
                
                OnRowCreated="gvList_RowCreated"
                
                OnRowEditing="gvList_RowEditing"
                OnRowDeleting="gvList_RowDeleting"
                
                >


                
                <columns>

                    <asp:boundfield datafield="facility_name"
                        headertext="Facility" 
                        HeaderStyle-HorizontalAlign="Left"
                        readonly="true"
                        SortExpression="facility_name"
                        />

                    <asp:TemplateField
                        ConvertEmptyStringToNull="true"
                        
                        HeaderText="In Group"
                        HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Wrap="false"
                        
                        ItemStyle-Width="50"
                        ItemStyle-Wrap="false"
                        ItemStyle-HorizontalAlign="Center"
                        
                        
                        SortExpression="group_id"
                        Visible="true"
                        >
                        <ItemTemplate>
                        
                            <asp:CheckBox ID="chkboxInGroup" runat="server"
                                Enabled="false"
                                Checked='<%# !(Eval("group_id") is System.DBNull) %>'
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
        </td>
    </tr>
    





    <tr height="15px">
        <td></td>
    </tr>
	



	<tr>
		<td valign="bottom" class="separator">
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
                    </td>
                    
                    <td width="5px"></td>
	            </tr>
            </table>
		</td>
	</tr>
	
            
</table>