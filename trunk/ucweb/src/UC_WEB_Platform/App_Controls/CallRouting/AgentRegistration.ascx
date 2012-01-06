<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgentRegistration.ascx.cs" Inherits="UcentrikWeb.App_Controls.CallRouting.AgentRegistration" %>





    <table width="320px" cellpadding="0" cellspacing="0" border="0">

        <tr height="20px">

            <td width="60px" align="center" valign="middle" rowspan="2">

                <asp:Panel ID="pnlNotRegistered" runat="server"
                    Visible="false"
                >
                    <div id="AgentNotRegistered">
                    </div>
                    
                </asp:Panel>

                <asp:Panel ID="pnlIncomingCall" runat="server"
                    Visible="false"
                >
                    <div id="AgentReserved">
                    </div>
                    
                    <BGSOUND SRC="../sounds/alert.wav">
                </asp:Panel>

                <asp:Panel ID="pnlBusy" runat="server"
                    Visible="false"
                >
                    <div id="AgentBusy">
                    </div>
                </asp:Panel>
                
                <asp:Panel ID="pnlConnected" runat="server"
                    Visible="false"
                >
                    <div id="AgentConnected">
                    </div>
                </asp:Panel>


                <asp:Panel ID="pnlAvailable" runat="server"
                    Visible="false"
                >
                    <div id="AgentAvailable">
                    </div>
                </asp:Panel>
                
                <asp:Panel ID="pnlUnavailable" runat="server"
                    Visible="false"
                >
                    <div id="AgentUnavailable">
                    </div>
                </asp:Panel>

            </td>
            
            <td>&nbsp;</td>
            
            <td align="left" class="Text">
                <asp:Literal ID="ltMessage" runat="server">
                    Checking status...
                </asp:Literal>
            </td>

        </tr>


        <tr height="40px">
            
            
            <td>&nbsp;</td>
            
            <td align="left">


                <asp:Button ID="btnRegister" runat="server"
                    Text="Register"
                    
                    Width="100px"
                    Height="24px"
                    CssClass="UcButton"
                    
                    Visible="false"
                    CommandName="Register"
                    CommandArgument="Register"
                    UseSubmitBehavior="false"
                    OnClick="btnRegister_Click"
                />
                <asp:Button ID="btnTakeCall" runat="server"
                    Text="Take Call"

                    Width="100px"
                    Height="24px"
                    CssClass="UcButton"

                    Visible="false"
                    CommandName="TakeCall"
                    CommandArgument="TakeCall"
                    UseSubmitBehavior="false"
                    OnClick="btnTakeCall_Click"
                />
                <asp:Button ID="btnReset" runat="server"
                    Text="Reset"

                    Width="100px"
                    Height="24px"
                    CssClass="UcButton"

                    Visible="false"
                    CommandName="Busy"
                    CommandArgument="Busy"
                    UseSubmitBehavior="false"
                    OnClick="btnReset_Click"
                />
                <asp:Button ID="btnSetAvailable" runat="server"
                    Text="Turn On"

                    Width="100px"
                    Height="24px"
                    CssClass="UcButton"

                    Visible="false"
                    CommandName="Register"
                    CommandArgument="Register"
                    UseSubmitBehavior="false"
                    OnClick="btnSetAvailable_Click"
                />
                <asp:Button ID="btnUnRegister" runat="server"
                    Text="Turn Off"

                    Width="100px"
                    Height="24px"
                    CssClass="UcButton"

                    Visible="false"
                    CommandName="UnRegister"
                    CommandArgument="UnRegister"
                    UseSubmitBehavior="false"
                    OnClick="btnUnRegister_Click"
                />
            </td>

        </tr>

    </table>
