var SEP = "_";
var KEY_CONN = "conn";
var KEY_SCRP = "scrp";
var KEY_SCRS = "scrs";
var KEY_ASRC = "asrc";
var KEY_AUDP = "audp";
var KEY_ASPP = "aspp";
var KEY_AUDS = "auds";
var KEY_VIDP = "vidp";
var KEY_VTHP = "vthp";
var KEY_VP8P = "vp8p";
var KEY_VIDS = "vids";
var KEY_VDS_ = "vds_";
var KEY_VDSJ = "vdsj";
var KEY_VFAK = "vfak";
var KEY_REC_ = "rec_";

var EVENT_CONTROL = 'C';
var EVENT_CHAT = 'c';
var EVENT_SEP = '.';
//var EVENT_PUBLISH = 'p';
var EVENT_LIST_RESOLUTION = 'R';
var EVENT_RESOLUTION = 'r';
var EVENT_REQUEST_START_APPSHARE = 'A';
var EVENT_REQUEST_STOP_APPSHARE = 'a';
var EVENT_APPSHARE_STARTED = 'S';
var EVENT_APPSHARE_STOPPED = 's';

//var md_publishers =
//	[
//		{ publisher_type: KEY_SCRP
//		, publisher_prefix: KEY_SCRP
//		, publisher_create: "ScreenPublisher"
//		, subscriber_type: KEY_SCRS
//		, subscriber_create: "ScreenSubscriber"
//		, display: "Screen"
//		}
//	,
//		{ publisher_type: KEY_ASPP
//		, publisher_prefix: KEY_AUDP
//		, publisher_create: "AudioPublisherSpeex"
//		, subscriber_type: KEY_AUDS
//		, subscriber_create: "AudioSubscriber"
//		, display: "Audio Speex"
//		}
//	,
//		{ publisher_type: KEY_VTHP
//		, publisher_prefix: KEY_VIDP
//		, publisher_create: "VideoPublisherTheora"
//		, subscriber_type: KEY_VIDS
//		, subscriber_create: "VideoSubscriber"
//		, display: "Video Theora"
//		}
//	,
//		{ publisher_type: KEY_VP8P
//		, publisher_prefix: KEY_VIDP
//		, publisher_create: "VideoPublisherVP8"
//		, subscriber_type: KEY_VIDS
//		, subscriber_create: "VideoSubscriber"
//		, display: "Video VP8"
//		}
//	];
//var md_publishers_index = {};
var md_types =
	{ _: {}
	, conn: { on_event: {} }
	, scrp: { reset: [ "scrp.id_process", "scrp.device", "scrp.type_pixel" ] }
	, scrs: {}
	, aspp: { reset: [ "audp.source", "speex.quality" ] }
	, auds: { reset: [ "auds.id.device" ] }
	, vthp: { reset: [ "vidp.source", "theora.bitrate", "theora.quality", "theora.keyframe" ] }
	, vp8p: { reset: [ "vidp.source", "vp8.bitrate", "vp8.keyframe" ] }
	, vids: {}
	, vds_: { reset: [ "vds.id.device", "vds.width", "vds.height", "vds.time_per_frame" ] }
	, asrc: { reset: [ "asrc.id.device", "asrc.samples_per_sec" ] }
	, rec_: { reset: [ "rec.path", "rec.source", "mp3.quality", "mp3.bitrate" ] }
	};

var list_obj = {};
var delayFunctions = [];

var iter = 0;

function wye_console::OnMessage( oid, cmd, value )
{
	Log( "<div class='cb'>" + oid + "." + cmd + "(" + value + ")</div>" );

	if( oid == null || oid.length == 0 )
	{
		if( md_types._[ cmd ] != null )
			md_types._[ cmd ]( value );
		return;
	}

	var obj = list_obj[ oid ];
	if( obj == null )
	{
		obj =
			{ oid: oid
			, type: oid.substr( 0, 4 )
			};
		obj.md = md_types[ obj.type ];
		obj.md.Ctor( obj );
		list_obj[ oid ] = obj;

		//RefreshObjects();

		if( obj.id_channel_user == null ) // ignore subscribers
			SetCurrent( obj );
	}

	if( obj.md[ cmd ] != null )
		obj.md[ cmd ]( obj, value );

    if(obj.RefreshMethod != null){
        eval(obj.RefreshMethod + "('" + obj.oid + "');");
    }
}

function OnStatusChanged( obj, value )
{
	if( value == "off" )
	{
	}
	else
	if( value == "ready" )
	{
	}
	else
	if( value == "active" )
	{
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}

/////

md_types._.OnStatusChanged = function( value )
{
	if( value == "ready" )
	{
		var cmd
			= "\n.Set scrp.type_pixel=1"
            + "\n.Set scrp.timer_span=" + conferenceSettings.timerSpan
            + "\n.Set scrp.dif_frame_count=" + conferenceSettings.difFrameCount
			+ "\n.Set server.host=" + conferenceSettings.host
			+ "\n.Set server.port=" + conferenceSettings.portTCP
			+ "\n.Set server.port_ssl=" + conferenceSettings.portSSL
			+ "\n.Set server.port_http=" + conferenceSettings.portHTTP
            + "\n.Set server.key=" + ""
			+ "\n.Set protocol.key=" + conferenceSettings.serverApiKey
			+ "\n.Set h264.annexb=1"
			+ "\n.Set connect_timeout_seconds=1"
			+ "\n.Set proxy.settings=DIRECT; SOCKS localhost:1080; HTTP localhost:8080; HTTP localhost:3128;"
			+ "\n.Set autodetect_sequence=tcp; tcp socks4 config; tcp socks5 config; tcp http_proxy config; http_tunnel; http_tunnel socks4 config; http_tunnel socks5 config; http_tunnel http_proxy config;"
			;

		Execute( cmd );

        isStarted = true;

        if(delayFunctions.length > 0) {
            for(var i = 0; i < delayFunctions.length; i++) {
                eval(delayFunctions[i]);
                //setTimeout(delayFunctions[i], 0);
            }
        }
        delayFunctions = [];

		//panel_menu.className = "";
	}
	else
	if( value == "destroyed")
	{
	}
}

/////

md_types.conn.Ctor = function( obj )
{
	var a = obj.oid.substr( 4 ).split( SEP );
	obj.id_purpose = a[ 0 ];
	obj.id_conference = a[ 1 ];
	obj.id_user = a[ 2 ];
	obj.display = obj.id_purpose + "C" + obj.id_conference + "U" + obj.id_user;
	obj.internal_id_conn = obj.id_purpose + SEP + obj.id_conference + SEP + obj.id_user;
}

md_types.conn.OnStatusChanged = function( obj, value )
{
	if( value == "off" )
	{
		if( obj.status == null )
		{
			Execute( "\n" + obj.oid + ".Connect" );
		}
        else 
        if( obj.status == "ready")
        {
            //alert('Connect to Conference Server is failed.');
        }
	}
	else
	if( value == "ready" )
	{
	}
	else
	if( value == "active" )
	{
        OnConnectionActive(obj);
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}
md_types.conn.OnEvent = function( obj, value )
{
    var cmd = md_types.conn.on_event[ value.charAt( 0 ) ];
    if( cmd == null ) return; // error???
    cmd( obj, value.substr( 1 ) );
}
//md_types.conn.on_event[ EVENT_CONTROL ] = function( obj, value )
//{
//	var a = value.split( EVENT_SEP );

//	if( a[ 0 ] != obj.id_user )
//		return;

//	var oid = KEY_SCRP + obj.internal_id_conn + SEP + a[ 1 ];

//	if( list_obj[ oid ] == null )
//		return;

//	Execute( "\n" + oid + ".ControlBy " + a[ 2 ] );
//}
md_types.conn.OnConnectionIn = function( obj, value )
{
	var s = "";
	for( var oid in list_obj )
	{
		var i = list_obj[ oid ];
		if( i.post_notify == null ) continue;
		if( i.internal_id_conn != obj.internal_id_conn ) continue;
		s += i.post_notify;
	}
	if( s.length > 0 )
		Execute( s );
}

/////

md_types.scrp.Ctor = function( obj )
{
	InitAsPublisher( obj, "Screen" );
	obj.id_control_by = obj.id_user;
}

md_types.scrp.OnStatusChanged = function( obj, value )
{
    if (typeof OnScreenPublisherStatusChanged != 'undefined') {
        OnScreenPublisherStatusChanged(obj, value);
    }

	if( value == "off" )
	{
        if(obj.status == null)
        {
            SetScreenPublisherSettings(obj);
        }
	}
	else
	if( value == "ready" )
	{
	}
	else
	if( value == "active" )
	{
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}


md_types.scrp.OnControlBy = function( obj, value )
{
	obj.id_control_by = value;
}

/////

md_types.scrs.Ctor = function( obj )
{
	InitAsSubscriber( obj, "Screen" );
}

md_types.scrs.OnStatusChanged = function( obj, value )
{
    if (typeof OnScreenSubscriberStatusChanged != 'undefined') {
        OnScreenSubscriberStatusChanged(obj, value);
    }

	if( value == "off" )
	{
        if (obj.status == null)
        {
            if (obj.doNotStartAfterCreate != true) {
                SetScreenSubscriberSettings(obj);
            }
        }
	}
	else
	if( value == "ready" )
	{
        ShowScreenSubscriber(obj);
	}
	else
	if( value == "active" )
	{
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}

md_types.scrs.OnControlBy = function( obj, value )
{
	obj.id_control_by = value;
}

/////

md_types.asrc.Ctor = function( obj )
{
	obj.display = obj.oid;
	obj.audio_source = true;
	obj[ "asrc.id_device" ] = "0";
	obj[ "asrc.samples_per_sec" ] = "16000";
}

md_types.asrc.OnStatusChanged = function( obj, value )
{
	if( value == "off" )
	{
        if(obj.status == null)
        {
            SetAudioSourceSettings(obj);
        }
    }
	else
	if( value == "ready" )
	{
	}
	else
	if( value == "active" )
	{
        AudioRecording(obj, "Start");
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}

/////

md_types.aspp.Ctor = function( obj )
{
	InitAsPublisher( obj, "AudioSpeex" );
}

md_types.aspp.OnStatusChanged = function( obj, value )
{
	if( value == "off" )
	{
        if(obj.status == null)
        {
            SetAudioPublisherSettings(obj);
        }
	}
	else
	if( value == "ready" )
	{
//        if(obj.status == "active")
//        {
//            AudioRecording(obj, "Stop");
//        }
	}
	else
	if( value == "active" )
	{
	}
	else
	if( value == "destroyed" )
	{
		AudioRecording(obj, "Stop");
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}

function AudioRecording(obj, command)
{
    var rec = obj["audioRecorder"];
    if(rec != null)
    {
       Execute( "\n" + rec + "." + command );
    }
}

/////

md_types.auds.Ctor = function( obj )
{
	InitAsSubscriber( obj, "Audio" );
}

md_types.auds.OnStatusChanged = function( obj, value )
{
	if( value == "off" )
	{
        if(obj.status == null)
        {
            SetAudioSubscriberSettings(obj);
        }
	}
	else
	if( value == "ready" )
	{
	}
	else
	if( value == "active" )
	{
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}

/////

md_types.vds_.Ctor = function( obj )
{
	obj.display = obj.oid;
	obj.video_source = true;
	obj[ "vds.id.device" ] = "0";
	obj[ "vds.width" ] = "176";
	obj[ "vds.height" ] = "144";
	obj[ "vds.time_per_frame" ] = "2000000";
}

md_types.vds_.OnStatusChanged = function( obj, value )
{
	if( value == "off" )
	{
        if(obj.status == null)
        {
            SetVideoSourceSettings(obj);
        }
	}
	else
	if( value == "ready" )
	{
	}
	else
	if( value == "active" )
	{
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}

/////

md_types.vthp.Ctor = function( obj )
{
	InitAsPublisher( obj, "VideoTheora" );
}

md_types.vthp.OnStatusChanged = function( obj, value )
{
	if( value == "off" )
	{
        if(obj.status == null)
        {
            SetVideoPublisherSettings(obj);
        }
	}
	else
	if( value == "ready" )
	{
	}
	else
	if( value == "active" )
	{
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}

/////

md_types.vp8p.Ctor = function( obj )
{
	InitAsPublisher( obj, "VideoVP8" );
}

md_types.vp8p.OnStatusChanged = OnStatusChanged;

/////

md_types.vids.Ctor = function( obj )
{
	InitAsSubscriber( obj, "Video" );
}

md_types.vids.OnStatusChanged = function( obj, value )
{
	if( value == "off" )
	{
        if(obj.status == null)
        {
            SetVideoSubscriberSettings(obj);
        }
	}
	else
	if( value == "ready" )
	{
        ShowVideoSubscriber(obj);
	}
	else
	if( value == "active" )
	{
        
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}

/////

md_types.rec_.Ctor = function( obj )
{
	obj.display = obj.oid;
}

md_types.rec_.OnStatusChanged = function( obj, value )
{
	if( value == "off" )
	{
        if(obj.status == null)
        {
            SetAudioRecorderSettings(obj);
        }
	}
	else
	if( value == "ready" )
	{
	}
	else
	if( value == "active" )
	{
	}
	else
	if( value == "destroyed" )
	{
		RemoveObject( obj );
		return;
	}

	obj.status = value;
}

/////

function Log( s )
{
}
function Execute( s )
{
   Log( "<pre>" + s + "</pre>" );

    if( typeof(wye_util) != "undefined" && typeof(wye_util) != "unknown" )
	    wye_util.LogInfo("Command", s);

    if( typeof(wye_console) != "undefined" && typeof(wye_console) != "unknown")
	    wye_console.Execute( s );
}

window.onload = function()
{
//	for( var i = 0; i < md_publishers.length; i++ )
//	{
//		var mdp = md_publishers[ i ];
//		md_publishers_index[ mdp.publisher_type ] = mdp;
//	}

	Execute( "\n.Start" );
}
window.onunload = function()
{
	Destroy();
}

function Destroy(){
    if (typeof OnDestroy != 'undefined')
        OnDestroy();

    if( wye_uif != null )
		wye_uif.Close();

	Execute( "\n.Destroy" );
	// we are subscribing on OnMessage event, but don't wait for last message
	// should catch it in order not to have crash
    if( typeof(wye_console) != "undefined" && typeof(wye_console) != "unknown")
	    wye_console.WaitForStopped( 500 );
}

var current_obj = null;

function SetCurrent( obj, panel )
{
    current_obj = obj;    
}

function InitAsPublisher( obj, display_type )
{
	var a = obj.oid.substr( 4 ).split( SEP );
	obj.id_purpose = a[ 0 ];
	obj.id_conference = a[ 1 ];
	obj.id_user = a[ 2 ];
	obj.id_channel = a[ 3 ];
	obj.internal_id_conn = obj.id_purpose + SEP + obj.id_conference + SEP + obj.id_user;
	var conn = list_obj[ KEY_CONN + obj.internal_id_conn ];
	obj.display = conn.display + ":" + display_type + obj.id_channel;
	//obj.post_notify = "\n" + conn.oid + ".SendEvent " + EVENT_PUBLISH + obj.type
	//	+ EVENT_SEP + obj.id_user + EVENT_SEP + obj.id_channel;
}

function InitAsSubscriber( obj, display_type )
{
	var a = obj.oid.substr( 4 ).split( SEP );
	obj.id_purpose = a[ 0 ];
	obj.id_conference = a[ 1 ];
	obj.id_user = a[ 2 ];
	obj.id_channel_user = a[ 3 ];
	obj.id_channel = a[ 4 ];
	obj.internal_id_conn = obj.id_purpose + SEP + obj.id_conference + SEP + obj.id_user;
	var conn = list_obj[ KEY_CONN + obj.internal_id_conn ];
	obj.display = conn.display + "->U" + obj.id_channel_user + display_type + obj.id_channel;
}

function RefreshObjects()
{
}

function RemoveObject( obj )
{
	delete list_obj[ obj.oid ];
	if( current_obj == obj )
		SetCurrent( null );
}

function SetSettings(){
    var cmd = "";

	var list = current_obj.md.reset;
	if( list != null )
	{
		for( var i = 0; i < list.length; i++ )
		{
			s = list[ i ];
			cmd += "\n.Set " + current_obj.oid + "." + s + "=" + current_obj[ s ];
		}
	}

    Execute( cmd );
}

function ExecuteReset( is_start )
{
    SetSettings();

	var cmd = "";
	var s;

	cmd += "\n" + current_obj.oid + ( is_start != 0 ? ".Start" : ".Reset" );

	if( is_start != 0 )
	{
		s = current_obj.post_notify;
		if( s != null )
			cmd += s;
	}

	Execute( cmd );
}

var wye_uif = null;
function click_Portion()
{
	if( wye_uif == null )
		wye_uif = wye_ui.CreateUIFilter();

	wye_uif.SetText( current_obj.oid + " %dx%d" );
	wye_console.ConnectExternal( current_obj.oid, wye_uif );
	wye_uif.Show();
}

function conn_Create(oidConn_, purpose_, conf_id_, user_id_, is_master_)
{
//	if( list_obj[ oidConn_ ] )
//	{
//		alert( "This object already exists." );
//		return;
//	}

	Execute
		( "\n.Set " + oidConn_ + ".id.conference=" + conf_id_
		+ "\n.Set " + oidConn_ + ".id.user=" + user_id_
		+ "\n.Set " + oidConn_ + ".protocol.is_master=" + is_master_
		+ "\n.Set " + oidConn_ + ".protocol.purpose=" + purpose_
		+ "\n.New " + oidConn_ + "=Connection"
		);
}

var isStarted = false;

function OnConnectionActive(obj) {

	for( var i = 0; i < obj.delayFunctions.length; i++ )
	{
        eval(obj.delayFunctions[i]);
	}
}

function stop_obj(oid)
{
	Execute( "\n" + oid + ".Stop" );
}

function start_obj(oid)
{
	Execute( "\n" + oid + ".Start" );
}

var conferenceSettings = {};
function setConferenceSetting(host_, portTCP_, portSSL_, portHTTP_, timerSpan_, difFrameCount, serverApiKey_) {
    conferenceSettings.host = host_;
    conferenceSettings.portTCP = portTCP_;
    conferenceSettings.portSSL = portSSL_;
    conferenceSettings.portHTTP = portHTTP_;
    conferenceSettings.timerSpan = timerSpan_;
    conferenceSettings.serverApiKey = serverApiKey_;
    conferenceSettings.difFrameCount = difFrameCount;
}

function wye_uic(control) { return document.getElementById(control) };

function SetRefreshMethod(oid, method) {
    var obj = list_obj[oid];
    if(obj != null){
        obj.RefreshMethod = method;
    }
}

function CreateConnectionObj(oid) {
    var obj =
			{ oid: oid
			, type: KEY_CONN
			};

    obj.md = md_types[obj.type];
    obj.md.Ctor(obj);

    obj.delayFunctions = [];

    list_obj[oid] = obj;

    return obj;
}

function AddDelayFunction(delayFunctions, func) {
    for (var i = 0; i < delayFunctions.length; i++) {
        if (delayFunctions[i] == func) {
            return;
        }
    }

    delayFunctions.push(func);
}

function DestroyObject(objectId) {
    Execute( "\n" + objectId + ".Destroy" );
}

function CloseConnection(connectionId) {
    Execute( "\n" + connectionId + ".Disconnect" );
}
