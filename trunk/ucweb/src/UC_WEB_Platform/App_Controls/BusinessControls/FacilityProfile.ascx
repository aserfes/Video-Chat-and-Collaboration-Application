<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityProfile.ascx.cs"
    Inherits="UcentrikWeb.App_Controls.BusinessControls.FacilityProfile" %>
<asp:ObjectDataSource ID="objectdatasourceEdit" runat="server" TypeName="UCENTRIK.LIB.BllProxy.BllProxyFacility"
    SelectMethod="SelectFacility" InsertMethod="InsertFacility" UpdateMethod="UpdateFacility">
</asp:ObjectDataSource>
<table width="100%" height="320px" align="center" cellspacing="0" cellpadding="0"
    border="0">
    <tr>
        <td width="50%">
            <asp:Panel ID="pnlVideoChat" runat="server" BorderWidth="0px" Width="182px" Height="162px"
                Visible="false">
                <%--<ucentrik:ConfVideo ID="ConfVideo" runat="server" />--%>
            </asp:Panel>
        </td>
        <td width="50%">
            <asp:Panel ID="pnlScreenCast" runat="server" BorderWidth="0px" Width="182px" Height="162px"
                ScrollBars="Both" Visible="false">
                <%--<ucentrik:ScreenCast ID="ScreenCast" runat="server" />--%>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <br />
        </td>
    </tr>
    <tr height="25">
        <td align="left" colspan="2">
            <asp:Label ID="lblMessage" runat="server" Text="">
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
            <asp:DetailsView ID="dvControl" runat="server" DataKeyNames="facility_id" OnDataBound="dvControl_DataBound"
                OnItemUpdating="dvControl_ItemUpdating">
                <HeaderStyle Width="150px" />
                <RowStyle Height="30px" />
                <Fields>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfUserId" runat="server" Value='<%# Bind("user_id") %>' />
                            <asp:HiddenField ID="hfSurveyId" runat="server" Value='<%# Bind("survey_id") %>' />
                            <asp:HiddenField ID="hfFacilityGuid" runat="server" Value='<%# Bind("facility_guid") %>' />
                            <asp:HiddenField ID="hfAgentId" runat="server" Value='<%# Bind("agent_id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created" SortExpression="date_created" Visible="true">
                        <ItemTemplate>
                            <%# this.formatDateTime(DataBinder.Eval(Container.DataItem, "date_created"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Updated" SortExpression="date_updated" Visible="true">
                        <ItemTemplate>
                            <%# this.formatDateTime(DataBinder.Eval(Container.DataItem, "date_updated"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblFacility" runat="server" Text='<%# Bind("facility_name") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFacility" runat="server" Text='<%# Bind("facility_name") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFacility" runat="server" ControlToValidate="txtFacility"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                    Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Active" SortExpression="active">
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkboxActive" runat="server" Checked='<%# Bind("active") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("address") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("address") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                    Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("phone") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPhone" runat="server" Text='<%# Bind("phone") %>' MaxLength="50">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                    Required
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPhone" runat="server" ErrorMessage="Phone number is not valid"
                                ControlToValidate="txtPhone" ValidationExpression="[0-9\s+()-]*" ValidationGroup="Edit" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblUser" runat="server" Text='<%# Bind("user_full_name") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlManagers" runat="server" AutoPostBack="true" Width="200"
                                DataTextField="username" DataValueField="user_id" OnSelectedIndexChanged="ddlManagers_SelectedIndexChanged">
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Survey" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblSurvey" runat="server" Text='<%# Bind("survey_name") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlSurvey" runat="server" AutoPostBack="true" Width="200" DataTextField="survey_name"
                                DataValueField="survey_id" OnSelectedIndexChanged="ddlSurvey_SelectedIndexChanged">
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="GUID" DataField="facility_guid" ReadOnly="true" InsertVisible="false"
                        Visible="false" />
                    <asp:TemplateField HeaderText="Groups" InsertVisible="false" SortExpression="group_cnt">
                        <ItemTemplate>
                            <asp:Label ID="lblGroupCnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "group_cnt")%>'>
                            </asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbManageGroups" runat="server" CommandArgument='<%# Eval("facility_id")%>'
                                Visible="false" OnClick="lbManageGroups_Click">
                                    Click here to manage groups
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IP Address" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblIpAddress" runat="server" Text='<%# Bind("ip_address") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIpAddress" runat="server" MaxLength="16" Text='<%# Bind("ip_address") %>'>
                            </asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Web Referrer" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblWebReferrer" runat="server" Text='<%# Bind("web_referrer") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtWebReferrer" runat="server" MaxLength="100" Text='<%# Bind("web_referrer") %>'>
                            </asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Command">
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_release" runat="server" CommandArgument='<%# Eval("facility_id")%>'
                                OnClick="btn_release_Click"
								>Release</asp:LinkButton>
							(<%# Eval("agent_first_name")%> <%# Eval("agent_last_name")%>)
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
            <table width="100%" height="100%" align="center" cellspacing="2" cellpadding="0"
                border="0">
                <tr>
                    <td width="5px">
                    </td>
                    <td align="left">
                        <asp:Button ID="btnBack" runat="server" Text="BACK" Width="100px" Height="24px" CssClass="UcButton"
                            UseSubmitBehavior="false" OnClick="btnBack_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSave" runat="server" Text="SAVE" Width="100px" Height="24px" CssClass="UcButton"
                            ValidationGroup="Edit" UseSubmitBehavior="true" OnClick="btnSave_Click" />
                    </td>
                    <td width="5px">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
