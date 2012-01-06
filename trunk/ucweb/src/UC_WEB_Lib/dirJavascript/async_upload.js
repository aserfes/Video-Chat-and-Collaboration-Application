var klog = "!!!";

var params = {}; // // id, by, file + path_local
// var url_upload = { host: '{0}', port: {1}, path: '{2}' };"

var root =
{ OnFailedCreate:
	function( value )
	{
		wye_util.LogError( klog, "FAILED CREATE: " + value );
		wye_console.Execute( "\n.Destroy" );
	}
, OnFailedCommand:
	function( value )
	{
		wye_util.LogError( klog, "FAILED COMMAND: " + value );
		wye_console.Execute( "\n.Destroy" );
	}
, OnStatusChanged:
	function (value)
	{
		if( value == "ready" )
		{
			wye_console.Execute( "\n.New req=HttpRequest" );
		}
		else if( value == "destroyed" )
		{
			root = null; //// exiting
		}
	}
, req:
	{ status: null
	, OnStatusChanged:
		function( value )
		{
			if( value == "off" )
			{
				if( root.req.status == null )
				{
					wye_console.Execute
						( "\x08.Set req.http.headers="
							+ "UploadId: " + params.id + "\r\n"
							+ "UploadBy: " + params.by + "\r\n"
						+ "\x08.Set http.host=" + url_upload.host
						+ "\x08.Set http.port=" + url_upload.port
						+ "\x08.Set http.page=" + url_upload.path
						+ "\x08.Set http.file.input=" + params.path_local
						+ "\x08.Set http.method=POST"
						+ "\x08req.Start"
						);
					SetStatus( "Uploading" );
				}
				else
				{
					wye_console.Execute( "\n.Destroy" );
					SetStatus( "Uploaded" );
					wye_util.Query( "DeleteFile", params.path_local );
					window.close();
				}
				root.req.status = value;
			}
			else if( value == "ready" )
			{
			}
			else if( value == "destroyed" )
			{
			}
		}
	, OnError:
		function( value )
		{
			wye_util.LogError( klog, "ERROR: " + value );
			wye_console.Execute( "\n.Destroy" );
			SetStatus( "Error" );
			window.close();
		}
	}
};

function wye_console::OnMessage( oid, cmd, value )
{
	var obj = oid == "" ? root : root[ oid ];
	wye_util.LogInfo( klog, oid + "." + cmd + "(" + value + ")" );
	var cmd = obj[ cmd ]
	if( cmd == null ) return;
	cmd( value );
}

function SetStatus( status )
{
	document.getElementById( "SpanStatus" ).innerHTML = status;
}

window.onload = function()
{
	var p = window.location.search.substring( 1 ).split( "&" );

	for( var i = 0; i < p.length; i++ ) 
	{
		var val = p[ i ].split( "=" );
		params[ val[ 0 ] ] = unescape( val[ 1 ] );
	}

	if(
		params.file == null ||
		params.id == null ||
		params.by == null ||
		url_upload.host == null ||
		url_upload.port == null ||
		url_upload.path == null
		)
	{
		alert( "Upload parameters missing." );
		return;
	}

    params.path_local
		= wye_util.Query( "EnvironmentVariable", "TEMP" )
		+ "\\"
		+ params.file 
		;

	document.getElementById( "SpanPathFileUpload" ).innerHTML = params.path_local;
	wye_console.Execute( "\n.Start" );
}
