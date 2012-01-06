<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scrs.aspx.cs" Inherits="UCENTRIK.WEB.PLATFORM.dirAgent.scrs"
EnableTheming = "False" StylesheetTheme="" Theme=""
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=name%></title>
    <object id="wye_util"
        classid="clsid:E9BA40CC-AB0D-4554-88C3-E6B95B86C0FD"
        codebase="<%=uctx_cab%>"
        ></object>
    <object id="wye_console"
        classid="clsid:E604E28F-732B-4C67-9D39-2D6DC9D9010C"
        ></object>
    <script type="text/jscript">
var klog = "aspx.scrs";
var ctrl = {};
var root =
{ OnFailedCreate:
	function( value )
	{
		//util.LogError( klog, "FAILED CREATE: " + value );
		wye_console.Execute( "\n.Destroy" );
	}
, OnFailedCommand:
	function( value )
	{
		//util.LogError( klog, "FAILED COMMAND: " + value );
		wye_console.Execute( "\n.Destroy" );
	}
, OnStatusChanged:
	function( value )
	{
		if( value == "ready" )
		{
			wye_console.Execute 
<%
	for( int i = 0; i < settings.Length; i += 2 )
		Response.Write( string.Format( "\r\n\t\t\t\t{0} \"\\n.Set {1}={2}\"", i == 0 ? "(" : "+", settings[ i ], settings[ i + 1 ] ) );
%>
				+ "\n.Set connect_timeout_seconds=1"
				+ "\n.Set proxy.settings=DIRECT;"
				+ "\n.Set autodetect_sequence=tcp; tcp socks4 ie; tcp socks5 ie; tcp http_proxy ie; http_tunnel; http_tunnel socks4 ie; http_tunnel socks5 ie; http_tunnel http_proxy ie;"
				+ "\n.Set scrs.id.channel=1"
				+ "\n#.Set scrs.id.channel_user={id.other}"
				+ "\n#.Event root.con.id_user='{id.user}';"
				+ "\n.New con=Connection"
				);
		}
		else
		if( value == "destroyed")
		{
			//root = null; // // exiting
		}
	}
, OnEvent:
	function( value )
	{
		eval( value );
	}
, con:
	{ status: null
	, OnStatusChanged:
		function( value )
		{
			if( value == "off" )
			{
				if( root.con.status == null )
					wye_console.Execute
						( "\ncon.Connect"
						);
			}
			else if( value == "active" )
			{
				wye_console.Execute
					( "\ncon.New scrs=ScreenSubscriber"
					);
			}

			root.con.status = value;
		}
	}
, scrs:
	{ status: null
	, OnStatusChanged:
		function( value )
		{
			if( value == "off" )
			{
				if( root.scrs.status == null )
				{
					wye_console.Execute( "\nscrs.Start" );
					wye_console.ConnectExternal( "scrs", ctrl.wye_uic );
				}
			}
			else if( value == "active" )
			{
			}

			root.scrs.status = value;
			ctrl_Refresh();
		}
	, OnControlBy:
		function( value )
		{
			root.scrs.control_by = value;
			ctrl_Refresh();
		}
	}
};
function ctrl_Refresh()
{
	var is_active = root.scrs.status == "active";
	var is_control = root.scrs.control_by == root.con.id_user;

	ctrl.btn_start.disabled = !is_active || is_control;
	ctrl.btn_stop.disabled = !is_active || !is_control;
}
function wye_console::OnMessage( oid, cmd, value )
{
	var obj = oid == "" ? root : root[ oid ];
	wye_util.LogInfo( klog, oid + "." + cmd + "(" + value + ")" );
	var cmd = obj[ cmd ];
	if( cmd == null ) return;
	cmd( value );
}
window.onload = function()
{
	ctrl.wye_uic = document.getElementById( "wye_uic" );
	ctrl.btn_start = document.getElementById( "btn_start" );
	ctrl.btn_stop = document.getElementById( "btn_stop" );
	ctrl.btn_close = document.getElementById( "btn_close" );
	ctrl.div_panel = document.getElementById( "panel" );

	resize();

	ctrl.btn_start.onclick = function()
	{
		wye_console.Execute( "\ncon.SendEvent P" );
	}
	ctrl.btn_stop.onclick = function()
	{
		wye_console.Execute( "\ncon.SendEvent p" );
	}
	ctrl.btn_close.onclick = function()
	{
		document.location.href = "scrs.aspx?id=<%=facility_id%>&release=1";
	}

	wye_console.Execute( "\n.Start" );
}
window.onunload = function()
{
	document.location.href = "scrs.aspx?id=<%=facility_id%>&release=1";
}
function resize()
{
	ctrl.wye_uic.height
		= document.documentElement.clientHeight
		- ctrl.div_panel.offsetTop - ctrl.div_panel.offsetHeight
		;
	ctrl.wye_uic.width = document.documentElement.clientWidth
		;
	window.event.cancelBubble = true;
    window.event.returnValue = false;
}
window.onresize = resize;
    </script>
	<style type="text/css">
body
{
	margin: 0;
}
div#panel
{
	padding: 5px;
	background: gray;
}
	</style>
</head>
<body>
<%
	if( error != null )
	{
%>
	<div style="background-color:Red;color:White;font-family:Verdana,Tahoma;font-size:16px;padding:5px;">
	<%=error%>
	</div>
<%		
	}
	else
	{
%>
	<div id="panel">
		<button id="btn_start" disabled="disabled">Start Control</button>
		<button id="btn_stop" disabled="disabled">Stop Control</button>
		<button id="btn_close">Close</button>
	</div>
	<object id="wye_uic"
		classid="clsid:748C7CED-885E-4733-ADA6-890A0C94CBC6"
		width="200"
		height="200"
		>
	</object>
	<!-->
    <form id="form1" runat="server">
    </form>
	<!-->
<%
	}
%>
</body>
</html>
