function StartScreenPublisher(purpose_, conf_id, user_id, is_master, id_process, device, type_pixel) {
    if (isStarted == false) {
        delayFunctions.push("StartScreenPublisher(" + purpose_ + "," + conf_id + "," + user_id + "," + is_master + "," + id_process + ",'" + device + "'," + type_pixel + ");")
        return;
    }

    var conn = KEY_CONN + purpose_ + SEP + conf_id + SEP + user_id;

    //Create Connection
    var obj = CreateConnectionObj(conn);

    AddDelayFunction(obj.delayFunctions, "ScreenPublisherCreate('" + conn + "');");

    //Create Screen Publisher
    var oidSP = KEY_SCRP + obj.internal_id_conn + SEP + 1;
    var objSP =
			{ oid: oidSP
			, type: KEY_SCRP
			};

    objSP.md = md_types[objSP.type];
    objSP.md.Ctor(obj);
    objSP["scrp.id_process"] = id_process;
    objSP["scrp.device"] = device;
    objSP["scrp.type_pixel"] = type_pixel;
    objSP.internal_id_conn = obj.internal_id_conn;

    list_obj[oidSP] = objSP;

    conn_Create(conn, purpose_, conf_id, user_id, is_master);
}

function StartScreenSubscriber(purpose_, conf_id, user_id, user_id_other, is_master, view_control, view_method, refreshMethod, stopAfterCreate) {

    if (typeof stopAfterCreate == 'undefined')
        stopAfterCreate = false;

    if (isStarted == false) {
        delayFunctions.push("StartScreenSubscriber(" + purpose_ + "," + conf_id + "," + user_id + "," + user_id_other + "," + is_master + ",'" + view_control + "'," + view_method + ",'" + refreshMethod + "', " + stopAfterCreate + ");")
        return;
    }

    var conn = KEY_CONN + purpose_ + SEP + conf_id + SEP + user_id;

    var objConn = list_obj[conn];
    if (objConn == null) {

        objConn = CreateConnectionObj(conn);
        objConn.id_user_other = user_id_other;

        var oidSS = KEY_SCRS + objConn.internal_id_conn + SEP + objConn.id_user_other + SEP + 1;
        var objSS = CreateScreenSubscriberObj(oidSS, refreshMethod, view_control, view_method);

        if (typeof stopAfterCreate != 'undefined') {
            objSS.doNotStartAfterCreate = stopAfterCreate;
        }

        AddDelayFunction(objConn.delayFunctions, "ScreenSubscriberCreate('" + conn + "');");

        conn_Create(conn, purpose_, conf_id, user_id, is_master);
    }
    else {
        var oidSS = KEY_SCRS + objConn.internal_id_conn + SEP + objConn.id_user_other + SEP + 1;
        var objSS = list_obj[oidSS];
        if (objSS != null) {
            start_obj(oidSS);
        }
    }
}

function CreateScreenSubscriberObj(oid, refreshMethod, view_control, view_method) {
    var obj =
			{ oid: oid
			, type: KEY_SCRS
			};

    obj.md = md_types[obj.type];
    obj.md.Ctor(obj);

    obj.view_control = view_control;
    obj.view_method = view_method;

    if (refreshMethod != null && refreshMethod != "") {
        obj.RefreshMethod = refreshMethod;
    }

    list_obj[oid] = obj;

    return obj;
}

function StopScreenSubscriber(oid) {
    stop_obj(oid);
}

function StopScreenPublisher(oid) {
    stop_obj(oid);
}

//CREATE SCREEN PUBLISHER

function ScreenPublisherCreate(oid) {
    var obj = list_obj[oid];
    var channelID = "1";
    var oidSP = KEY_SCRP + obj.internal_id_conn + SEP + channelID;

    Execute
	(
        "\n.Set " + oidSP + "." + KEY_SCRP + ".id.channel=" + channelID +
	    "\n" + obj.oid + ".New " + oidSP + "=" + "ScreenPublisher"
	);
}

function SetScreenPublisherSettings(obj) {
    SetCurrent(list_obj[obj.oid]);

    ExecuteReset(1);
}

//CREATE SCREEN SUBSCRIBER
function ScreenSubscriberCreate(oid) {
    var obj = list_obj[oid];
    var channel = "1";
    var oidSS = KEY_SCRS + obj.internal_id_conn + SEP + obj.id_user_other + SEP + channel;

    Execute
		("\n.Set " + oidSS + "." + KEY_SCRS + ".id.channel_user=" + obj.id_user_other
		+ "\n.Set " + oidSS + "." + KEY_SCRS + ".id.channel=" + channel
		+ "\n" + obj.oid + ".New " + oidSS + "=" + "ScreenSubscriber"
		);
}

function SetScreenSubscriberSettings(obj) {
    Execute("\n" + obj.oid + ".Start");
}

function ShowScreenSubscriber(obj) {
    var control = wye_uic(obj.view_control);
    if (control != null) {
        wye_console.ConnectExternal(obj.oid, control);
        control.SetMode(obj.view_method);
    }
}

function ScreenSubscriberControlBy(oidConn_, oidSS_) {
    var objSS = list_obj[oidSS_];
    var objConn = list_obj[oidConn_];
    if (objSS != null && objConn != null) {
        Execute("\n" + oidConn_ + ".SendEvent "
		    + EVENT_CONTROL + objSS.id_channel_user
		    + EVENT_SEP + objSS.id_channel
		    + EVENT_SEP + (objSS.id_user == objSS.id_control_by ? objSS.id_channel_user : objSS.id_user)
		    );
    }
}

function SendStartAppshareRequest(connectionObjectId, publisherUserId, subscriberUserId) {
    var objConn = list_obj[connectionObjectId];
    if (objConn != null) {
        Execute("\n" + connectionObjectId + ".SendEvent "
		+ EVENT_REQUEST_START_APPSHARE + publisherUserId
		+ EVENT_SEP + subscriberUserId);
    }
}

function SendStopAppshareRequest(connectionObjectId, publisherUserId, subscriberUserId) {
    var objConn = list_obj[connectionObjectId];
    if (objConn != null) {
        Execute("\n" + connectionObjectId + ".SendEvent "
		+ EVENT_REQUEST_STOP_APPSHARE + publisherUserId
		+ EVENT_SEP + subscriberUserId);
    }
}

function SendAppshareStartedEvent(connectionObjectId, publisherUserId, subscriberUserId) {
    var objConn = list_obj[connectionObjectId];
    if (objConn != null) {
        Execute("\n" + connectionObjectId + ".SendEvent "
		+ EVENT_APPSHARE_STARTED + publisherUserId
		+ EVENT_SEP + subscriberUserId);
    }
}

function SendAppshareStoppedEvent(connectionObjectId, publisherUserId, subscriberUserId) {
    var objConn = list_obj[connectionObjectId];
    if (objConn != null) {
        Execute("\n" + connectionObjectId + ".SendEvent "
		+ EVENT_APPSHARE_STOPPED + publisherUserId
		+ EVENT_SEP + subscriberUserId);
    }
}

md_types.conn.on_event[EVENT_CONTROL] = function (obj, value) {
    var a = value.split(EVENT_SEP);

    if (a[0] != obj.id_user)
        return;

    var oid = KEY_SCRP + obj.internal_id_conn + SEP + a[1];

    if (list_obj[oid] == null)
        return;

    Execute("\n" + oid + ".ControlBy " + a[2]);
}

md_types.conn.on_event[EVENT_REQUEST_START_APPSHARE] = function (obj, value) {
    if (typeof OnStartAppShareRequest != 'undefined') {
        OnStartAppShareRequest();
    }
}

md_types.conn.on_event[EVENT_REQUEST_STOP_APPSHARE] = function (obj, value) {
    if (typeof OnStopAppShareRequest != 'undefined') {
        OnStopAppShareRequest();
    }
}

md_types.conn.on_event[EVENT_APPSHARE_STARTED] = function (obj, value) {
    if (typeof OnAppShareStarted != 'undefined') {
        OnAppShareStarted();
    }
}

md_types.conn.on_event[EVENT_APPSHARE_STOPPED] = function (obj, value) {
    if (typeof OnAppShareStopped != 'undefined') {
        OnAppShareStopped();
    }
}

function CleanupScreenSharingObjects() {
    for (var oid in list_obj) {
        if (oid.indexOf("scrp5_") == 0 || oid.indexOf("scrs5_") == 0 || oid.indexOf("conn5_") == 0) {
            stop_obj(oid);
            DestroyObject(oid);
        }
    }
}


