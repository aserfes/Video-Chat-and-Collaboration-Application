<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InfoAboutCall.ascx.cs"
    Inherits="UCENTRIK.UserControls.ASP.InfoAboutCall" %>
<asp:ObjectDataSource ID="objectdatasourceEdit" runat="server" TypeName="UCENTRIK.LIB.BllProxy.BllProxyLog"
    SelectMethod="SelectLog" UpdateMethod="UpdateLog" EnableViewState="true"></asp:ObjectDataSource>
<table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
    <tr>
        <td>
            <br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:DetailsView ID="dvControl" runat="server" AutoGenerateRows="False" DataKeyNames="incident_id">
                <HeaderStyle Width="150px" />
                <RowStyle Height="30px" />
                <Fields>
                    <asp:BoundField DataField="incident_id" HeaderText="Call ID" Visible="false" />
                    <asp:BoundField HeaderText="User ID" DataField="consumer_name" ReadOnly="true" />
                    <%-- asp:TemplateField HeaderText="Customer Satisfaction">
                        <ItemTemplate>
                            <asp:Label ID="LabelCustSatisf" runat="server" Text='<%# Bind("customer_satisfaction") %>' ></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxCustSatisf" runat="server" Text='<%# Bind("customer_satisfaction") %>'
                                MaxLength="100" Width="400" >
                            </asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField--%>
                    <asp:TemplateField HeaderText="Subject Notes">
                        <ItemTemplate>
                            <asp:Label ID="LabelSubjectNotes" runat="server" Text='<%# Bind("subject_notes") %>' ></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxSubjectNotes" runat="server" Text='<%# Bind("subject_notes") %>' 
                                MaxLength="100" Width="400"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%-- asp:TemplateField HeaderText="Issue Found">
                        <ItemTemplate>
                            <asp:Label ID="LabelIssueFound" runat="server" Text='<%# Bind("issue_found") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxIssueFound" runat="server" Text='<%# Bind("issue_found") %>'
                                MaxLength="100" Width="400"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issue Resolved">
                        <ItemTemplate>
                            <asp:Label ID="LabelIssueResolved" runat="server" Text='<%# Bind("issue_resolved") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxIssueResolved" runat="server" Text='<%# Bind("issue_resolved") %>'
                                MaxLength="100" Width="400"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status of kiosk">
                        <ItemTemplate>
                            <asp:Label ID="LabelStatusKiosk" runat="server" Text='<%# Bind("kiosk_status_after_transaction") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxStatusKiosk" runat="server" Text='<%# Bind("kiosk_status_after_transaction") %>'
                                MaxLength="50" Width="400"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="kiosk_malfunction" HeaderText="Kiosk Malfunction" />
                    <asp:CheckBoxField DataField="engineering_work_order_opened" HeaderText="Engineering work order opened" />
                    <asp:CheckBoxField DataField="device_in_database" HeaderText="Device in database" />
                    <asp:TemplateField HeaderText="Transaction Status" Visible="true">
                        <ItemTemplate>
                            <asp:RadioButtonList ID="rblStatus" runat="server" SelectedIndex='<%# Bind("transaction_status_id") %>'
                                RepeatDirection="Horizontal" RepeatLayout="Table" Enabled="false" >
                                <asp:ListItem>Completed </asp:ListItem>
                                <asp:ListItem>Failed </asp:ListItem>
                                <asp:ListItem>Issued </asp:ListItem>
                            </asp:RadioButtonList>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:RadioButtonList ID="rblStatus" runat="server" SelectedIndex='<%# Bind("transaction_status_id") %>'
                                RepeatDirection="Horizontal" RepeatLayout="Table">
                                <asp:ListItem>Completed </asp:ListItem>
                                <asp:ListItem>Failed </asp:ListItem>
                                <asp:ListItem>Issued </asp:ListItem>
                            </asp:RadioButtonList>
                        </EditItemTemplate>
                    </asp:TemplateField--%>
                    <asp:BoundField HeaderText="Kiosk ID" DataField="kiosk_id" ReadOnly="true" />
                    <asp:BoundField HeaderText="Kiosk Name" DataField="kiosk_name" ReadOnly="true" />
                    <asp:BoundField HeaderText="Kiosk Location" DataField="kiosk_location" ReadOnly="true" />
                    <asp:BoundField HeaderText="Device Make" DataField="device_make" ReadOnly="true" Visible="false"/>
                    <asp:BoundField HeaderText="Device Model" DataField="device_model" ReadOnly="true" Visible="false"/>
                    <asp:BoundField HeaderText="Device Type" DataField="device_type" ReadOnly="true" Visible="false"/>
                    <asp:BoundField HeaderText="Device Value" DataField="device_value" ReadOnly="true" Visible="false"/>
                    <asp:BoundField HeaderText="Screen user help" DataField="screen_user_help" ReadOnly="true" Visible="false"/>
                    <asp:BoundField HeaderText="Transaction Value" DataField="transaction_value" ReadOnly="true" Visible="false"/>
                    <asp:TemplateField HeaderText="Audio record">
                        <ItemTemplate>
                            <asp:hyperlink ID="HyperlinkAudioRecord" runat="server" Target="_new" NavigateUrl='<%# GetAudioLink() %>'><%# GetAudioLinkName() %></asp:hyperlink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </td>
    </tr>
</table>
