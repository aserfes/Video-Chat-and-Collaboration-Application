<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMenu.ascx.cs" Inherits="UCENTRIK.WEB.PLATFORM.App_Controls.Elements.UcMenu" %>






    <table width="100%"  height="100%" cellSpacing="0" cellPadding="0" border="0">

        <tr>
            <td align="center"> 

                <asp:Panel ID="pnlMenu" runat="server"
                    Width="220px"
                    
                    BorderColor="White"
                    BorderWidth="0px"
                    HorizontalAlign="Left"
                    >
            
                    <asp:Menu ID="ucSideMenu" runat="server"
                        DataSourceID=""
                        StaticDisplayLevels="3"
                        StaticSubMenuIndent="0"
                        CssClass="Menu"
                        
                        StaticItemFormatString="&nbsp;&nbsp;&nbsp;{0}"
                        StaticSelectedStyle-HorizontalPadding="0"
                        
                        
                        StaticMenuItemStyle-CssClass="StaticMenuItem"
                        StaticSelectedStyle-CssClass="SelectedMenuItem"
                        StaticHoverStyle-CssClass="HoverMenuItem"
                        
                        onmenuitemdatabound="ucSideMenu_MenuItemDataBound"
                        >
                        
                        <levelmenuitemstyles>
                          <asp:menuitemstyle CssClass="LevelMenuItem1" />
                          <asp:menuitemstyle CssClass="LevelMenuItem2" />
                        </levelmenuitemstyles>
                        
                        <LevelSelectedStyles>
                          <asp:menuitemstyle CssClass="LevelSelectedMenuItem" />
                          <asp:menuitemstyle CssClass="LevelSelectedMenuItem" />
                        </LevelSelectedStyles>
                        
                    </asp:Menu>
                    
                </asp:Panel>

            </td>
        </tr>

    </table>


