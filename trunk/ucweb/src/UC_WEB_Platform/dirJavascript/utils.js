function GetCurrentVolumeValue() {
    var value = 0;
    var res = wye_util.Query("WaveOutGetVolume", "0");
    if (res != null && res != "") {
        value = parseInt(res.substr(1));
        value = ((value & 0xFFFF) + (value >>> 16)) >>> 1;
    }
    return value;
}

function SetCurrentVolumeValue(value) {
    value += (value << 16) >>> 0;
    wye_util.Query("WaveOutSetVolume", "0 " + value);
}

function InitSlider() {
    var current = GetCurrentVolumeValue();
    $("#slider").slider({
        max: 65535,
        step: 873,
        slide: HandleSliderSlide
    });
    $("#slider").slider("option", "value", current);
};

function HandleSliderSlide(e, ui) {
    SetCurrentVolumeValue(ui.value);
}

function CheckAudioHoldStatus() {
    if (ap_status_off == false && as_status_off == false) {
        document.getElementById("ButtonASHold").disabled = false;
    }
    else {
        document.getElementById("ButtonASHold").disabled = true;
    }
}

var ap_status_off;
function OnRefreshAudioPublisher(oid) {
    var obj = list_obj[oid];
    if (obj != null) {
        ap_status_off = obj.status == "off";
        document.getElementById("ButtonAPStart").disabled = !ap_status_off;
        document.getElementById("ButtonAPStop").disabled = ap_status_off;
        document.getElementById("ButtonAPMute").disabled = ap_status_off;
        CheckAudioHoldStatus();
    }
}

var as_status_off;
function OnRefreshAudioSubscriber(oid) {
    var obj = list_obj[oid];
    if (obj != null) {
        as_status_off = obj.status == "off";
        document.getElementById("ButtonASStart").disabled = !as_status_off;
        document.getElementById("ButtonASStop").disabled = as_status_off;
        document.getElementById("ButtonASMute").disabled = as_status_off;
        CheckAudioHoldStatus();
    }
}

function OnRefreshVideoPublisher(oid) {
    var obj = list_obj[oid];
    if (obj != null) {
        var status_off = obj.status == "off";
        document.getElementById("ButtonStartVideoPub").disabled = !status_off;
        document.getElementById("ButtonStopVideoPub").disabled = status_off;
    }
}

function OnRefreshVideoSubscriber(oid) {
    var obj = list_obj[oid];
    if (obj != null) {
        var status_off = obj.status == "off";
        document.getElementById("ButtonStartVideoSubscr").disabled = !status_off;
        document.getElementById("ButtonStopVideoSubscr").disabled = status_off;
    }
}