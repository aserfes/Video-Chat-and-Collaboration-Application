//CREATE VIDEO PUBLISHER
function StartVideoPublisher(purpose_, conf_id, user_id, is_master, view_control_, theoraBitrate, theoraQuality, theoraKeyframe, videoWidth, videoHeight, timePerFrame, videoDeviceID, refreshMethod) {

    if (isStarted == false) {
        AddDelayFunction(delayFunctions, "StartVideoPublisher(" + purpose_ + "," + conf_id + "," + user_id + "," + is_master + ",'" + view_control_ + "'," + theoraBitrate + "," + theoraQuality + "," + theoraKeyframe + "," + videoWidth + "," + videoHeight + "," + timePerFrame + "," + videoDeviceID + ",'" + refreshMethod + "');");
        return;
    }

    var oidConn = KEY_CONN + purpose_ + SEP + conf_id + SEP + user_id;
    var objConn = list_obj[oidConn];
    if (objConn == null) {

        objConn = CreateConnectionObj(oidConn);
		list_obj.conv = objConn;

        var oidVDS = KEY_VDS_;
        var objVDS = CreateVideoSourceObj(oidVDS, videoDeviceID, videoWidth, videoHeight, timePerFrame);
        VideoSourceCreate(oidVDS);

        var oidVP = KEY_VTHP + objConn.internal_id_conn + SEP + 1;
        var objVP = CreateVideoPublisherObj(oidVP, theoraBitrate, theoraQuality, theoraKeyframe, view_control_, refreshMethod);
        objVP["vidp.source"] = oidVDS;

        AddDelayFunction(objConn.delayFunctions, "VideoSourceCreate('" + oidVDS + "');");
        AddDelayFunction(objConn.delayFunctions, "VideoPublisherCreate('" + oidConn + "');");
        AddDelayFunction(objConn.delayFunctions, "ExecuteListResolutionEvent();");

        conn_Create(oidConn, purpose_, conf_id, user_id, is_master);
    }
    else {
        var oidVP = KEY_VTHP + objConn.internal_id_conn + SEP + 1;
        var objVP = list_obj[oidVP];
        if (objVP == null) {
            var oidVDS = KEY_VDS_;
            var objVDS = CreateVideoSourceObj(oidVDS, videoDeviceID, videoWidth, videoHeight, timePerFrame);
            VideoSourceCreate(oidVDS);

            var oidVP = KEY_VTHP + objConn.internal_id_conn + SEP + 1;
            var objVP = CreateVideoPublisherObj(oidVP, theoraBitrate, theoraQuality, theoraKeyframe, view_control_, refreshMethod);
            objVP["vidp.source"] = oidVDS;

            if (objConn.status == "active") {
                VideoPublisherCreate(oidConn);
            }
            else {
                AddDelayFunction(objConn.delayFunctions, "VideoPublisherCreate('" + oidConn + "');");
				AddDelayFunction(objConn.delayFunctions, "ExecuteListResolutionEvent();");
            }
        }
        else {
            if (objVP.status == "off" || objVP.status == "ready") {
                start_obj(oidVP);
            }
        }
    }
}

function StopVideoPublisher(oid) {
    stop_obj(oid);
}

function VideoSourceCreate(oid) {
    Execute("\n.New " + oid + "=VideoSource");
}

function SetVideoSourceSettings(obj) {
    SetCurrent(list_obj[obj.oid]);

    ExecuteReset(0);
}

function VideoPublisherCreate(oid) {
    var obj = list_obj[oid];
    var channelID = "1";
    var oidVP = KEY_VTHP + obj.internal_id_conn + SEP + channelID;

    Execute
		("\n.Set " + oidVP + "." + "vidp.id.channel=" + channelID
		+ "\n" + obj.oid + ".New " + oidVP + "=" + "VideoPublisherTheora"
		);
}

function SetVideoPublisherSettings(obj) {
    SetCurrent(list_obj[obj.oid]);

    ExecuteReset(1);

    var control = wye_uic(obj.view_control);
        if (control != null) {
        wye_console.ConnectExternal(obj["vidp.source"], control);
            control.SetMode(7);
        }
    }

//VIDEO SUBSCRIBER

function StartVideoSubscriber(purpose_, conf_id, user_id, user_id_other, is_master, view_control_, viewMethod, refreshMethod) {

    if (isStarted == false) {
        AddDelayFunction(delayFunctions, "StartVideoSubscriber(" + purpose_ + "," + conf_id + "," + user_id + "," + user_id_other + "," + is_master + ",'" + view_control_ + "'," + viewMethod + ",'" + refreshMethod + "');");
        return;
    }

    var oidConn = KEY_CONN + purpose_ + SEP + conf_id + SEP + user_id;
    var objConn = list_obj[oidConn];
    if (objConn == null) {

        objConn = CreateConnectionObj(oidConn);
		list_obj.conv = objConn;
        objConn.id_user_other = user_id_other;
//        objConn.stream_type = "video";
//        objConn.publisher_type = "subscriber";

        var oidVS = KEY_VIDS + objConn.internal_id_conn + SEP + objConn.id_user_other + SEP + 1;
        var objVS = CreateVideoSubscriberObj(oidVS, view_control_, viewMethod, refreshMethod);

        AddDelayFunction(objConn.delayFunctions, "VideoSubscriberCreate('" + oidConn + "');");

        conn_Create(oidConn, purpose_, conf_id, user_id, is_master);
    }
    else {
        objConn.id_user_other = user_id_other;
        var oidVS = KEY_VIDS + objConn.internal_id_conn + SEP + objConn.id_user_other + SEP + 1;
        var objVS = list_obj[oidVS];
        if (objVS == null) {
            var oidVS = KEY_VIDS + objConn.internal_id_conn + SEP + objConn.id_user_other + SEP + 1;
            objVS = CreateVideoSubscriberObj(oidVS, view_control_, viewMethod, refreshMethod);

            if (objConn.status == "active") {
                VideoSubscriberCreate(oidConn);
            }
            else {
                AddDelayFunction(objConn.delayFunctions, "VideoSubscriberCreate('" + oidConn + "');");
            }
        }
        else {
            if (objVS.status == "off" || objVS.status == "ready") {
                start_obj(oidVS);
            }
        }
    }
}

function StopVideoSubscriber(oid) {
    stop_obj(oid);
}

function VideoSubscriberCreate(oid) {
    var obj = list_obj[oid];

    var susbcrType = KEY_VIDS;
    var channel = "1";
    var oidVS = susbcrType + obj.internal_id_conn + SEP + obj.id_user_other + SEP + channel;

    Execute
		("\n.Set " + oidVS + "." + susbcrType + ".id.channel_user=" + obj.id_user_other
		+ "\n.Set " + oidVS + "." + susbcrType + ".id.channel=" + channel
		+ "\n" + obj.oid + ".New " + oidVS + "=" + "VideoSubscriber"
		);
}

function SetVideoSubscriberSettings(obj) {
    Execute("\n" + obj.oid + ".Start");
}

function ShowVideoSubscriber(obj) {
    var control = wye_uic(obj.view_control);
    if (control != null) {
        wye_console.ConnectExternal(obj.oid, control);
        control.SetMode(obj.viewMethod);
    }
}


function CreateVideoPublisherObj(oid, theoraBitrate, theoraQuality, theoraKeyframe, view_control_, refreshMethod) {
    var objVP =
			{ oid: oid
			, type: KEY_VTHP
			};

    objVP.md = md_types[objVP.type];
    objVP.md.Ctor(objVP);

    objVP["theora.bitrate"] = theoraBitrate;
    objVP["theora.quality"] = theoraQuality;
    objVP["theora.keyframe"] = theoraKeyframe;
    objVP.view_control = view_control_;

    if (refreshMethod != null && refreshMethod != "") {
        objVP.RefreshMethod = refreshMethod;
    }

    list_obj[oid] = objVP;

    return objVP;
}

function CreateVideoSourceObj(oid, videoDeviceID, videoWidth, videoHeight, timePerFrame) {
    var objVDS =
			{ oid: oid
			, type: KEY_VDS_
			};

    objVDS.md = md_types[objVDS.type];
    objVDS.md.Ctor(objVDS);

    objVDS["vds.id.device"] = videoDeviceID;
    objVDS["vds.width"] = videoWidth;
    objVDS["vds.height"] = videoHeight;
    objVDS["vds.time_per_frame"] = timePerFrame;

    list_obj[oid] = objVDS;

    ctrl_resolution_Refresh();

    return objVDS;
}

function CreateVideoSubscriberObj(oid, view_control, viewMethod, refreshMethod) {
    var obj =
			{ oid: oid
			, type: KEY_VIDS
			};

    obj.md = md_types[obj.type];
    obj.md.Ctor(obj);

    obj.view_control = view_control;
    obj.viewMethod = viewMethod;

    if (refreshMethod != null && refreshMethod != "") {
        obj.RefreshMethod = refreshMethod;
    }

    list_obj[oid] = obj;

    return obj;
}

md_types.conn.on_event[EVENT_LIST_RESOLUTION] = function (obj, value) 
{
    var ctrl = document.getElementById("ctrl_kiosk_resolution");
    if (ctrl == null) return;
    ctrl.innerHTML = "";

    value = value.substr(1).split(value.charAt(0));
    ctrl.disabled = value.length == 0;
    for (var i = 0; i < value.length; i++) {
        ctrl.options.add(new Option(resolutions[value[i]], value[i]));
        if (resolutions[value[i]] == defaultResolution) {
            ctrl.value = value[i];
        }
    }
}
md_types.conn.on_event[EVENT_RESOLUTION] = function (obj, value) 
{
	var vsrc = list_obj[ KEY_VDS_ ];
	if( vsrc == null ) return;

	var settings = value.split("x");
	vsrc["vds.width"] = settings[0];
	vsrc["vds.height"] = settings[1];
	vsrc["vds.time_per_frame"] = settings[2];
	SetCurrent(vsrc);
	ExecuteReset( false );
}
function ExecuteListResolutionEvent() 
{
	var vsrc = list_obj[ KEY_VDS_ ];
	if( vsrc == null || list_obj.conv == null ) return;

	Execute
		( "\x08" + list_obj.conv.oid + ".SendEvent " + EVENT_LIST_RESOLUTION
		+ GetListResolution()
		);
}
md_types.conn.OnConnectionIn = function( obj, value )
{
	if( obj == list_obj.conv )
		ExecuteListResolutionEvent();
}
function ctrl_kiosk_resolution_OnChange()
{
	Execute
		( "\n" + list_obj.conv.oid + ".SendEvent "
		+ EVENT_RESOLUTION + document.getElementById( "ctrl_kiosk_resolution" ).value
		);
}
function ctrl_resolution_OnChange()
{
	var vsrc = list_obj[ KEY_VDS_ ];
	if( vsrc == null ) return;

	var value = document.getElementById( "ctrl_resolution" ).value;
	var settings = value.split("x");
	vsrc["vds.width"] = settings[0];
	vsrc["vds.height"] = settings[1];
	vsrc["vds.time_per_frame"] = settings[2];
	SetCurrent( vsrc );
	ExecuteReset( false );
}
function ctrl_resolution_Refresh() 
{
	var vsrc = list_obj[ KEY_VDS_ ];
	if( vsrc == null ) return;

	var ctrl = document.getElementById( "ctrl_resolution" );
	if( ctrl == null ) return;
	ctrl.innerHTML = "";

	var value = GetListResolution();
	value = value.substr( 1 ).split( value.charAt( 0 ) );
	ctrl.disabled = value.length == 0;
	for (var i = 0; i < value.length; i++) {
	    ctrl.options.add(new Option(resolutions[value[i]], value[i]));
	    if (resolutions[value[i]] == defaultResolution) {
	        ctrl.value = value[i];
	    }
	}
}

var resolutions = new Array();
var defaultResolution = "320x240";

function GetListResolution() {
    if (typeof (wye_util) != "undefined" && typeof (wye_util) != "unknown") {
        var list = wye_util.Query("ListResolution", list_obj[KEY_VDS_]["vds.id.device"]);
        list = list.substr(1).split(list.charAt(0));
        for (var i = 0; i < list.length; i++) {
            var timePerFrame = null;
            if (list[i] == "160x120")
                timePerFrame = "2000000"; // 5 fps
            else if (list[i] == "176x144")
                timePerFrame = "1000000"; // 10 fps
            else if (list[i] == "320x240")
                timePerFrame = "666666"; // 15 fps
            else
                timePerFrame = "666666"; // 15 fps

            var resolution = list[i] + "x" + timePerFrame;
            resolutions[resolution] = list[i];
        }
    }

    var sep = "\n";
    var result = "";
    for (resolut in resolutions)
        result += sep + resolut;
    return result;
}

