

function SaveScrollPosition() {
    var chat = document.getElementById("pnlMessages");
    if (chat != null) {
        var intX = chat.scrollLeft;
        var intY = chat.scrollTop;
        document.title = intY;
        document.cookie = "ChatScrollPos=!~" + intX + "," + intY + "~!";
    }
}

function RestoreScrollPosition() {
    var chat = document.getElementById("pnlMessages");
    if (chat != null) {
        var strCook = document.cookie;
        if (strCook.indexOf("!~") != 0) {
            var intS = strCook.indexOf("!~");
            var intE = strCook.indexOf("~!");
            var strPos = strCook.substring(intS + 2, intE);
            var intSep = strPos.indexOf(",");
            var intX = strPos.substring(0, intSep);
            var intY = strPos.substring(intSep + 1);
            chat.scrollLeft = intX;
            chat.scrollTop = intY;
        }
    }
}

var prm = Sys.WebForms.PageRequestManager.getInstance();
if (prm != null) {
    prm.add_beginRequest(function (sender, e) {
        if (sender._postBackSettings.async) {
            SaveScrollPosition();
        }
    });
}
prm.add_endRequest(function (sender, e) {
    if (sender._postBackSettings.panelsToUpdate != null) {
        RestoreScrollPosition();
    }
});