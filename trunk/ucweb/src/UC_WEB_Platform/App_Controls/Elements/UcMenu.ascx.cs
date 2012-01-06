using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

namespace UCENTRIK.WEB.PLATFORM.App_Controls.Elements
{
	public partial class UcMenu : UcAppBaseControl
	{
		public bool UpdateMenu()
		{
			this.showMenu();
			return true;
		}

		protected void Page_Load( object sender, EventArgs e )
		{

		}

		protected void Page_PreRender( object sender, EventArgs e )
		{
			bool c = Convert.ToBoolean( HttpContext.Current.Items[ "IsInAsyncPostBack" ] );
			if( !c )
				this.showMenu();
		}

		protected void showMenu()
		{
			UcAppBasePage page = this.UcAppPage;

			string siteMapProviderName = "DefaultSiteMapProvider";
			switch( page.UserRoleId )
			{
			case 1: //ADMIN
				siteMapProviderName = "RoleAdminSiteMapProvider";
				break;

			case 2: //AGENT
				siteMapProviderName = "RoleAgentSiteMapProvider";
				break;

			case 5: //SUPERVISOR
				siteMapProviderName = "RoleSupervisorSiteMapProvider";
				break;
			}

			SiteMapDataSource smds = new SiteMapDataSource();
			smds.SiteMapProvider = siteMapProviderName;
			smds.ShowStartingNode = false;

			ucSideMenu.DataSource = smds;
			ucSideMenu.DataBind();

			SiteMapNode currentSiteMapNode = SiteMap.Providers[ siteMapProviderName ].CurrentNode;
			for( int i = 0; i < ucSideMenu.Items.Count; i++ )
			{
				MenuItem menu_item = ucSideMenu.Items[ i ];
	
				if( currentSiteMapNode == null )
				{
					menu_item.ChildItems.Clear();
					continue;
				}

				string menu_item_text = menu_item.Text;

				if( currentSiteMapNode.ToString().CompareTo( menu_item_text ) == 0 )
				{
					menu_item.Selected = true;
					continue;
				}

				if( currentSiteMapNode.ParentNode == null )
				{
					menu_item.ChildItems.Clear();
					continue;
				}

				if( currentSiteMapNode.ParentNode.ToString().CompareTo( menu_item_text ) != 0 )
				{
					menu_item.ChildItems.Clear();
					continue;
				}

				menu_item.Text = "<b>" + menu_item_text + "</b>";

				for( int j = 0; j < menu_item.ChildItems.Count; j++ )
				{
					MenuItem menu_item_child = menu_item.ChildItems[ j ];
					string menu_item_child_text = menu_item_child.Text;
					if( currentSiteMapNode.ToString().CompareTo( menu_item_child_text ) == 0 )
					{
						menu_item_child.Selected = true;
					}

					//---------------------------------------------------------------------------

					if( page.UserRoleId == 2 )    //Agent
					{
						Int32 agentId = ProxyHelper.GetUserAgentId( this.UcPage.UserId );

						//==================================================================
						//IncidentDS.IncidentDSDataTable dt = BllProxyIncident.GetIncidentsByStatus(0, agentId);  // ALL
						//DataRow[] rows = dt.Select("status_id=0");  //None
						//if (menu_item_child_Text == "Call Queue")
						//    rows = dt.Select("status_id=1");  // New
						//else if (menu_item_child_Text == "My Calls")
						//    rows = dt.Select("status_id=2");  // In-Progress
						//else if (menu_item_child_Text == "Follow-Up")
						//    rows = dt.Select("status_id=5");  // Follow-Up
						//cnt = rows.Length;
						//if (cnt != 0)
						//    menu_item_child_Text = menu_item_child_Text + " [" + cnt.ToString() + "]";
						//==================================================================

						IncidentDS.IncidentDSDataTable dt = null;
						if( menu_item_child_text == "Call Queue" )
							dt = BllProxyIncident.GetIncidentQueueList( 1, agentId );  // New
						else if( menu_item_child_text == "My Calls" )
							dt = BllProxyIncident.GetIncidentsByStatus( 2, agentId );  // In-Progress
						else if( menu_item_child_text == "Follow-Up" )
							dt = BllProxyIncident.GetIncidentFollowUpList( 5, agentId );  // Follow-Up

						if( dt != null )
						{
							int cnt = dt.Rows.Count;
							if( cnt != 0 )
								menu_item_child_text += " [" + cnt.ToString() + "]";
						}

					}
					//---------------------------------------------------------------------------

					menu_item_child.Text = "&nbsp;&nbsp;&nbsp;" + menu_item_child_text;
				}
			}

			//////---------------------------------------------------------
			//for( int i = 0; i < ucSideMenu.Items.Count; i++ )
			//{
			//    if( currentSiteMapNode != null )
			//    {
			//        string menuItemText = ucSideMenu.Items[ i ].Text;
			//        if( currentSiteMapNode.ToString().CompareTo( menuItemText ) != 0 )
			//        {
			//            if( currentSiteMapNode.ParentNode != null )
			//            {
			//                if( currentSiteMapNode.ParentNode.ToString().CompareTo( menuItemText ) != 0 )
			//                {
			//                    ucSideMenu.Items[ i ].ChildItems.Clear();
			//                }
			//                else
			//                {
			//                    ucSideMenu.Items[ i ].Text = "<b>" + menuItemText + "</b>";

			//                    for( int j = 0; j < ucSideMenu.Items[ i ].ChildItems.Count; j++ )
			//                    {
			//                        string childMenuItemText = ucSideMenu.Items[ i ].ChildItems[ j ].Text;
			//                        if( currentSiteMapNode.ToString().CompareTo( childMenuItemText ) == 0 )
			//                        {
			//                            ucSideMenu.Items[ i ].ChildItems[ j ].Selected = true;
			//                        }

			//                        //---------------------------------------------------------------------------

			//                        if( page.UserRoleId == 2 )    //Agent
			//                        {
			//                            Int32 agentId = ProxyHelper.GetUserAgentId( this.UcPage.UserId );
			//                            Int32 cnt = 0;

			//                            //==================================================================
			//                            //IncidentDS.IncidentDSDataTable dt = BllProxyIncident.GetIncidentsByStatus(0, agentId);  // ALL
			//                            //DataRow[] rows = dt.Select("status_id=0");  //None
			//                            //if (childMenuItemText == "Call Queue")
			//                            //    rows = dt.Select("status_id=1");  // New
			//                            //else if (childMenuItemText == "My Calls")
			//                            //    rows = dt.Select("status_id=2");  // In-Progress
			//                            //else if (childMenuItemText == "Follow-Up")
			//                            //    rows = dt.Select("status_id=5");  // Follow-Up
			//                            //cnt = rows.Length;
			//                            //if (cnt != 0)
			//                            //    childMenuItemText = childMenuItemText + " [" + cnt.ToString() + "]";
			//                            //==================================================================

			//                            IncidentDS.IncidentDSDataTable dt = null;
			//                            if( childMenuItemText == "Call Queue" )
			//                                dt = BllProxyIncident.GetIncidentQueueList( 1, agentId );  // New
			//                            else if( childMenuItemText == "My Calls" )
			//                                dt = BllProxyIncident.GetIncidentsByStatus( 2, agentId );  // In-Progress
			//                            else if( childMenuItemText == "Follow-Up" )
			//                                dt = BllProxyIncident.GetIncidentFollowUpList( 5, agentId );  // Follow-Up

			//                            if( dt != null )
			//                            {
			//                                cnt = dt.Rows.Count;
			//                                if( cnt != 0 )
			//                                    childMenuItemText = childMenuItemText + " [" + cnt.ToString() + "]";
			//                            }

			//                        }
			//                        //---------------------------------------------------------------------------

			//                        ucSideMenu.Items[ i ].ChildItems[ j ].Text = "&nbsp;&nbsp;&nbsp;" + childMenuItemText;
			//                    }
			//                }
			//            }
			//            else
			//            {
			//                ucSideMenu.Items[ i ].ChildItems.Clear();
			//            }
			//        }
			//        else
			//        {
			//            ucSideMenu.Items[ i ].Selected = true;
			//        }
			//    }
			//    else
			//    {
			//        ucSideMenu.Items[ i ].ChildItems.Clear();
			//    }
			//}
		}

		protected void ucSideMenu_MenuItemDataBound( object sender, MenuEventArgs e )
		{
			string menuItemTitle = e.Item.Text;

			////---------------------------------------------------------------------------
			//UcAppBasePage page = this.UcAppPage;
			//if( page.UserRoleId == 2 )    //Agent
			//{
			//    Int32 agentId = ProxyHelper.GetUserAgentId( this.UcPage.UserId );
			//    Int32 cnt = 0;
			//    IncidentDS.IncidentDSDataTable dt = new IncidentDS.IncidentDSDataTable();
			//    if( menuItemTitle == "Call Queue" )
			//        dt = BllProxyIncident.GetIncidentsByStatus( 1, agentId );  // New
			//    else if( menuItemTitle == "Follow-Up" )
			//        dt = BllProxyIncident.GetIncidentsByStatus( 5, agentId );  // Follow-Up
			//    else if( menuItemTitle == "My Incidents" )
			//        dt = BllProxyIncident.GetIncidentsByStatus( 2, agentId );  // In-Progress
			//    cnt = dt.Rows.Count;
			//    if( cnt != 0 )
			//        menuItemTitle = menuItemTitle + " [" + cnt.ToString() + "]";
			//}
			////---------------------------------------------------------------------------

			e.Item.Text = menuItemTitle;
		}
	}
}