<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditIncident.ascx.cs"
    Inherits="UCENTRIK.UserControls.ASP.EditIncident" %>
<asp:ObjectDataSource ID="objectdatasourceEdit" runat="server" TypeName="UCENTRIK.LIB.BllProxy.BllProxyIncident"
    SelectMethod="SelectIncident" UpdateMethod="UpdateIncident" 
    EnableViewState="true"></asp:ObjectDataSource>
<table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
    <tr>
        <td>
            <br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:DetailsView ID="dvControl" runat="server" DataKeyNames="incident_id, agent_id"
                OnDataBound="dvControl_DataBound" OnItemUpdating="dvControl_ItemUpdating">
                <HeaderStyle Width="150px" />
                <RowStyle Height="30px" />
                <Fields>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfStatusId" runat="server" Value='<%# Bind("status_id") %>' />
                            <asp:HiddenField ID="hfContactBId" runat="server" Value='<%# Bind("contact_id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="ID" DataField="incident_id" ReadOnly="true" InsertVisible="false"
                        Visible="true" />
                    <asp:TemplateField HeaderText="Call Created" SortExpression="date_created" Visible="true">
                        <ItemTemplate>
                            <%# this.formatDateTime(DataBinder.Eval(Container.DataItem, "date_created"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Call Open" SortExpression="date_open" Visible="true">
                        <ItemTemplate>
                            <%# this.formatDateTime(DataBinder.Eval(Container.DataItem, "date_open"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Status" DataField="incident_status_name" ReadOnly="true"
                        InsertVisible="false" Visible="true" />
                    <asp:TemplateField HeaderText="Status" Visible="true">
                        <ItemTemplate>
                            <asp:RadioButtonList ID="rblStatus" runat="server" DataTextField="incident_status_name"
                                DataValueField="incident_status_id" RepeatDirection="Horizontal" RepeatLayout="Table"
                                OnPreRender="rblStatus_PreRender" OnSelectedIndexChanged="rblStatus_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Group" DataField="group_name" ReadOnly="true" InsertVisible="false"
                        Visible="true" />
                    <asp:BoundField HeaderText="Facility" DataField="facility_name" ReadOnly="true" InsertVisible="false"
                        Visible="true" />
                    <asp:TemplateField HeaderText="Agent" Visible="true">
                        <ItemTemplate>
                            <%# Eval("agent_first_name")%>&nbsp;<%# Eval("agent_last_name")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject">
                        <ItemTemplate>
                            <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("subject") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSubject" runat="server" Text='<%# Bind("subject") %>' MaxLength="100"
                                Width="400">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
                                ValidationGroup="Edit" ErrorMessage="Required Field" Enabled="false">
                                    Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="GUID" DataField="incident_guid" ReadOnly="true" InsertVisible="false"
                        Visible="false" />
                    <asp:BoundField HeaderText="ContactID" DataField="contact_id" Visible="false" />
                </Fields>
            </asp:DetailsView>
        </td>
    </tr>
</table>
