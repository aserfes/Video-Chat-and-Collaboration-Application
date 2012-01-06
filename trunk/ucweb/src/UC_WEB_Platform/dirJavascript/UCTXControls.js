var screenPublisherStatus = '';

function OnScreenPublisherStatusChanged(obj, newStatus) {
    var status_inactive = (newStatus == 'off' || newStatus == 'destroyed');
    document.getElementById('ButtonStartAppShare').disabled = !status_inactive;
    document.getElementById('ButtonStopAppShare').disabled = status_inactive;

    document.getElementById('hrefViewAppshare').style.display = (status_inactive) ? 'inline' : 'none';

    document.getElementById('hrefViewAppshareInactive').style.display = (status_inactive) ? 'none' : 'inline';
    
    if (screenPublisherStatus == 'active' && newStatus != 'active') 
        CleanupScreenSharingObjects();

    screenPublisherStatus = newStatus;
}

function OnAppShareStarted() {
    document.getElementById('ButtonStartAppShare').disabled = true;
    document.getElementById('ButtonStopAppShare').disabled = true;
    document.getElementById('hrefViewAppshare').style.display = 'none';
    document.getElementById('hrefViewAppshareInactive').style.display = 'inline';
}

function OnAppShareStopped() {
    document.getElementById('ButtonStartAppShare').disabled = false;
    document.getElementById('ButtonStopAppShare').disabled = true;
    document.getElementById('hrefViewAppshare').style.display = 'inline';
    document.getElementById('hrefViewAppshareInactive').style.display = 'none';
}