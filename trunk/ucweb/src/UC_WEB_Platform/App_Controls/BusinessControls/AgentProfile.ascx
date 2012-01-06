<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgentProfile.ascx.cs"
    Inherits="UcentrikWeb.App_Controls.BusinessControls.AgentProfile" %>
<asp:ObjectDataSource ID="objectdatasourceEdit" runat="server" TypeName="UCENTRIK.LIB.BllProxy.BllProxyAgent"
    SelectMethod="SelectAgent" InsertMethod="InsertAgent" UpdateMethod="UpdateAgent">
</asp:ObjectDataSource>
<table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
    border="0">
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
            <asp:DetailsView ID="dvControl" runat="server" DataKeyNames="agent_id, user_id" OnDataBound="dvControl_DataBound" 
            OnItemInserting="dvControl_ItemInserting" 
            OnItemInserted="dvControl_ItemInserted" 
            OnItemUpdating="dvControl_ItemUpdating"
            OnItemUpdated="dvControl_ItemUpdated">
                <HeaderStyle Width="150px" />
                <RowStyle Height="30px" />
                <Fields>
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
                    <asp:TemplateField HeaderText="First name" SortExpression="first_name">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstname" runat="server" Text='<%# Bind("first_name") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstname" runat="server" Text='<%# Bind("first_name") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="txtFirstname"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last name" SortExpression="last_name">
                        <ItemTemplate>
                            <asp:Label ID="lblLastname" runat="server" Text='<%# Bind("last_name") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLastname" runat="server" Text='<%# Bind("last_name") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLastname" runat="server" ControlToValidate="txtLastname"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" SortExpression="email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>' MaxLength="256">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Email is not valid"
                                ControlToValidate="txtEmail" ValidationExpression="^([a-zA-Z0-9_\-\.\&\%\[\]\!\?\#\$\*]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ValidationGroup="Edit" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone" SortExpression="last_name">
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
<%--                    <asp:TemplateField HeaderText="Public Enabled" SortExpression="public_enabled">
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkboxPublicEnabled" runat="server" Checked='<%# Bind("public_enabled") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
--%>                    
<%--<asp:BoundField HeaderText="Public Enabled" DataField="public_enabled" ReadOnly="true" Visible="true" />--%>
                    <asp:BoundField HeaderText="GUID" DataField="agent_guid" ReadOnly="true" InsertVisible="false"
                        Visible="false" />
                    <asp:TemplateField HeaderText="Groups" InsertVisible="false" SortExpression="group_cnt">
                        <ItemTemplate>
                            <asp:Label ID="lblGroupCnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "group_cnt")%>'>
                            </asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbManageGroups" runat="server" CommandArgument='<%# Eval("agent_id")%>'
                                Visible="false" OnClick="lbManageGroups_Click">
                                        Click here to manage groups
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Skills" InsertVisible="false" SortExpression="skill_cnt">
                        <ItemTemplate>
                            <asp:Label ID="lblSkillCnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "skill_cnt")%>'>
                            </asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbManageSkills" runat="server" CommandArgument='<%# Eval("agent_id")%>'
                                Visible="false" OnClick="lbManageSkills_Click">
                                        Click here to manage skills
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Languages" InsertVisible="false" SortExpression="language_cnt">
                        <ItemTemplate>
                            <asp:Label ID="lblLanguageCnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "language_cnt")%>'>
                            </asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbManageLanguages" runat="server" CommandArgument='<%# Eval("agent_id")%>'
                                Visible="false" OnClick="lbManageLanguages_Click">
                                        Click here to manage languages
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
