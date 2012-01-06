function StartAudioPublisher(purpose_, conf_id, user_id, is_master, audioDeviceID, samplesPerSec, speexQuality, audioRecFilePath, refreshMethod) {

    if (isStarted == false) {
        delayFunctions.push("StartAudioPublisher(" + purpose_ + "," + conf_id + "," + user_id + "," + is_master + "," + audioDeviceID + "," + samplesPerSec + "," + speexQuality + "," + audioRecFilePath + ",'" + refreshMethod + "');")
        return;
    }

    var oidConn = KEY_CONN + purpose_ + SEP + conf_id + SEP + user_id;
    var objConn = list_obj[oidConn];
    if (objConn == null) {

        objConn = CreateConnectionObj(oidConn);

        var oidVDS = KEY_ASRC + objConn.internal_id_conn;
        var objVDS = CreateAudioSourceObj(oidVDS, audioDeviceID, samplesPerSec);
        AudioSourceCreate(oidVDS);

        var oidRec = KEY_REC_ + "1";
        CreateAudioRecorderObj(oidRec, oidVDS, audioRecFilePath, 0, 32, 0, 8, 0);
        CreateAudioRecorder(oidRec);

        objVDS["audioRecorder"] = oidRec;

        var oidVP = KEY_ASPP + objConn.internal_id_conn + SEP + 1;
        var objVP = CreateAudioPublisherObj(oidVP, speexQuality, refreshMethod);
        objVP["audp.source"] = oidVDS;
        objVP["audioRecorder"] = oidRec;
        
        AddDelayFunction(objConn.delayFunctions, "AudioPublisherCreate('" + oidConn + "');");

        conn_Create(oidConn, purpose_, conf_id, user_id, is_master);
    }
    else {
        var oidVP = KEY_ASPP + objConn.internal_id_conn + SEP + 1;
        var objVP = list_obj[oidVP];
        if (objVP == null) {
            var oidVDS = KEY_ASRC + objConn.internal_id_conn;
            var objVDS = CreateAudioSourceObj(oidVDS, audioDeviceID, samplesPerSec);
            AudioSourceCreate(oidVDS);

            var oidRec = KEY_REC_ + "1";
            CreateAudioRecorderObj(oidRec, oidVDS, audioRecFilePath, 0, 32, 0, 8, 0);
            CreateAudioRecorder(oidRec);

            objVDS["audioRecorder"] = oidRec;

            var oidVP = KEY_ASPP + objConn.internal_id_conn + SEP + 1;
            var objVP = CreateAudioPublisherObj(oidVP, speexQuality, refreshMethod);
            objVP["audp.source"] = oidVDS;
            objVP["audioRecorder"] = oidRec;

            if (refreshMethod != null && refreshMethod != "") {
                objVP.RefreshMethod = refreshMethod;
            }

            if (objConn.status == "active") {
                AudioPublisherCreate(oidConn);
            }
            else {
                AddDelayFunction(objConn.delayFunctions, "AudioPublisherCreate('" + oidConn + "');");
            }
        }
        else {
            if (objVP.status == "off" || objVP.status == "ready") {
                start_obj(oidVP);
            }
        }
    }
}

function StopAudioPublisher(oid) {
    stop_obj(oid);
}

function CreateAudioSourceObj(oid, audioDeviceID, samplesPerSec) {
    var obj =
			{ oid: oid
			, type: KEY_ASRC
			};

    obj.md = md_types[obj.type];
    obj.md.Ctor(obj);

    obj["asrc.id.device"] = audioDeviceID;
    obj["asrc.samples_per_sec"] = samplesPerSec;

    list_obj[oid] = obj;

    return obj;
}

function CreateAudioPublisherObj(oid, speexQuality, refreshMethod) {
    var obj =
			{ oid: oid
			, type: KEY_ASPP
			};

    obj.md = md_types[obj.type];
    obj.md.Ctor(obj);

    if (refreshMethod != null && refreshMethod != "") {
        obj.RefreshMethod = refreshMethod;
    }

    obj["speex.quality"] = speexQuality;

    list_obj[oid] = obj;

    return obj;
}

function CreateAudioRecorderObj(oid, oidAudioSource, fileName, mp3Quality, mp3Bitrate, h264Bitrate, h264Quality, h264Keyframe) {
    var obj =
			{ oid: oid
			, type: KEY_REC_
			};

    obj.md = md_types[obj.type];
    obj.md.Ctor(obj);

    obj["rec.source"] = oidAudioSource;
    obj["rec.path"] = wye_util.Query("EnvironmentVariable", "TEMP") + "\\" + fileName;
    obj["mp3.quality"] = mp3Quality;
    obj["mp3.bitrate"] = mp3Bitrate;
   
    list_obj[oid] = obj;

    return obj;
}

function CreateAudioRecorder(oid) {
    Execute("\n.New " + oid + "=RecorderMP3");
}

function SetAudioRecorderSettings(obj) {
    SetCurrent(list_obj[obj.oid]);
    SetSettings();
}

//CREATE AUDIO PUBLISHER

function AudioSourceCreate(oid) {
    Execute("\n.New " + oid + "=AudioSource");
}

function SetAudioSourceSettings(obj) {
    SetCurrent(list_obj[obj.oid]);
    ExecuteReset(0);
}

function AudioPublisherCreate(oid) {
    var objConn = list_obj[oid];
    var channelID = "1";
    var oidAP = KEY_ASPP + objConn.internal_id_conn + SEP + channelID;

    Execute
		("\n.Set " + oidAP + "." + KEY_AUDP + ".id.channel=" + channelID
		+ "\n" + objConn.oid + ".New " + oidAP + "=" + "AudioPublisherSpeex"
		);
}

function SetAudioPublisherSettings(obj) {
    SetCurrent(list_obj[obj.oid]);
    ExecuteReset(1);
}

//AUDIO SUBSCRIBER
function StartAudioSubscriber(purpose_, conf_id, user_id, user_id_other, is_master, audioOutputDeviceID, refreshMethod) {

    if (isStarted == false) {
        delayFunctions.push("StartAudioSubscriber(" + purpose_ + "," + conf_id + "," + user_id + "," + user_id_other + "," + is_master + "," + audioOutputDeviceID + ",'" + refreshMethod  + "');")
        return;
    }

    var oidConn = KEY_CONN + purpose_ + SEP + conf_id + SEP + user_id;
    var objConn = list_obj[oidConn];
    if (objConn == null) {

        objConn = CreateConnectionObj(oidConn);
        objConn.id_user_other = user_id_other;

        var oidVS = KEY_AUDS + objConn.internal_id_conn + SEP + objConn.id_user_other + SEP + 1;
        var objVS = CreateAudioSubscriberObj(oidVS, audioOutputDeviceID, refreshMethod);

        AddDelayFunction(objConn.delayFunctions, "AudioSubscriberCreate('" + oidConn + "');");

        conn_Create(oidConn, purpose_, conf_id, user_id, is_master);
    }
    else {
        objConn.id_user_other = user_id_other;
        var oidVS = KEY_AUDS + objConn.internal_id_conn + SEP + objConn.id_user_other + SEP + 1;
        var objVS = list_obj[oidVS];
        if (objVS == null) {
            var oidVS = KEY_AUDS + objConn.internal_id_conn + SEP + objConn.id_user_other + SEP + 1;
            objVS = CreateAudioSubscriberObj(oidVS, audioOutputDeviceID, refreshMethod);

            if (objConn.status == "active") {
                AudioSubscriberCreate(oidConn);
            }
            else {
                AddDelayFunction(objConn.delayFunctions, "AudioSubscriberCreate('" + oidConn + "');");
            }
        }
        else {
            if (objVS.status == "off" || objVS.status == "ready") {
                start_obj(oidVS);
            }
        }
    }
}

function StopAudioSubscriber(oid) {
    stop_obj(oid);
}

function CreateAudioSubscriberObj(oid, audioOutputDeviceID, refreshMethod) {
    var obj =
			{ oid: oid
			, type: KEY_AUDS
			};

    obj.md = md_types[obj.type];
    obj.md.Ctor(obj);

    if (refreshMethod != null && refreshMethod != "") {
        obj.RefreshMethod = refreshMethod;
    }

    obj["auds.id.device"] = audioOutputDeviceID;

    list_obj[oid] = obj;

    return obj;
}

function AudioSubscriberCreate(oidConn) {
    var objConn = list_obj[oidConn];
    var susbcrType = KEY_AUDS;
    var channel = "1";
    var oidAS = susbcrType + objConn.internal_id_conn + SEP + objConn.id_user_other + SEP + channel;

    Execute
		("\n.Set " + oidAS + "." + susbcrType + ".id.channel_user=" + objConn.id_user_other
		+ "\n.Set " + oidAS + "." + susbcrType + ".id.channel=" + channel
		+ "\n" + objConn.oid + ".New " + oidAS + "=" + "AudioSubscriber"
		);
}

function SetAudioSubscriberSettings(obj) {
    SetCurrent(list_obj[obj.oid]);
    ExecuteReset(1);
}
