<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Facility.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.Facility" %>

<%@ Register TagPrefix="ucentrik" TagName="FacilityProfile" Src="FacilityProfile.ascx" %>

<asp:ObjectDataSource ID="objectdatasourceList" Runat="server"
    TypeName="UCENTRIK.LIB.BllProxy.BllProxyFacility"
    SelectMethod=""
    DeleteMethod="DeleteFacility"
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
                    Facilities:&nbsp;
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
                
                    <asp:GridView ID="gvList" runat="server"
                        DataKeyNames="facility_id"
                        OnRowEditing="gvList_RowEditing"
                        >
                        
                        <Columns>
                            <asp:TemplateField
                                ConvertEmptyStringToNull="true"
                                HeaderText="Name"
                                HeaderStyle-HorizontalAlign="Left"
                                SortExpression="facility_name"
                                Visible="true"
                                >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbFacilityB" runat="server"
                                        CommandArgument='<%# Eval("facility_id")%>'
                                        OnClick="lbFacility_Click"
                                        >
                                        <%# Eval("facility_name")%>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField
								DataField="facility_name"
                                HeaderText="Name" 
                                HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true"
                                SortExpression="facility_name"
                                />
                            <asp:TemplateField
                                ConvertEmptyStringToNull="true"
                                HeaderText="Agent"
                                HeaderStyle-HorizontalAlign="Left"
                                SortExpression="agent_first_name,agent_last_name"
                                Visible="false"
                                ItemStyle-Width="200"
                                >
                                <ItemTemplate>
                                    <%# Eval("agent_first_name")%>
                                    <%# Eval("agent_last_name")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField
                                DataField="status"
                                HeaderText="Status" 
                                HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true"
                                SortExpression="status"
                                ItemStyle-Width="100"
                                />
                            <asp:CheckBoxField
								DataField="active"
                                HeaderText="Active" 

                                ShowHeader="True"
                                HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="50"
                                
                                ItemStyle-Width="50"
                                ItemStyle-Wrap="false"
                                ItemStyle-HorizontalAlign="Center"
                                
                                ReadOnly="true"
                                SortExpression="active"
                                />
                            <asp:TemplateField
                                HeaderText="Command"
                                HeaderStyle-HorizontalAlign="Left"
                                Visible="false"
                                HeaderStyle-Width="170"
                                >
                                <ItemTemplate>
									<a href="javascript:ViewFacilityScreen(<%# Eval("facility_id")%>)">View Screen</a>
                                    <asp:LinkButton ID="btn_call" runat="server"
                                        CommandArgument='<%# Eval("facility_id")%>'
                                        OnClick="btn_call_Click"
                                        >Call</asp:LinkButton>
                                    <asp:LinkButton ID="btn_release" runat="server"
                                        CommandArgument='<%# Eval("facility_id")%>'
                                        OnClick="btn_release_Click"
                                        >Release</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="facility_guid"
                                HeaderText="Guid" 
                                HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true"
                                SortExpression="facility_guid"
                                Visible="false"
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
                        </Columns>

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
                <td align="center" valign="top">
                    <ucentrik:FacilityProfile ID="profileControl" runat="server"
                        
                        OnManageGroups="sosFacility_ManageGroups"
                        
                        OnProfileSaveButton="view_Save"
                        OnProfileBackButton="view_Back"
                    />
                </td>
            </tr>
        </table>            
    
    </asp:View>

</asp:MultiView>


    

