function PopupCenter(pageURL, name, w, h)
{
	var params = 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=' + w + ', height=' + h
		+ ', top=' + ( ( screen.height - h ) / 2 )
		+ ', left=' + ( ( screen.width - w ) / 2 )
		;
    //var targetWin =
    window.open( pageURL, name, params );
}
function PopupDown(pageURL, name, w, h)
{
	var params = 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=' + w + ', height=' + h
		+ ', top=' + ( screen.height - h )
		+ ', left=' + ( screen.width - w )
		;
    //var targetWin =
    window.open( pageURL, name, params );
}

function URL(url) {
    url = url || "";
    this.parse(url);
}

URL.prototype = {
    href: "",
    protocol: "",
    host: "",
    hostname: "",
    port: "",
    pathname: "",
    search: "",
    hash: "",

    parse: function (url) {
        url = url || this.href;
        var pattern = "^(([^:/\\?#]+):)?(//(([^:/\\?#]*)(?::([^/\\?#]*))?))?([^\\?#]*)(\\?([^#]*))?(#(.*))?$";
        var rx = new RegExp(pattern);
        var parts = rx.exec(url);

        this.href = parts[0] || "";
        this.protocol = parts[1] || "";
        this.host = parts[4] || "";
        this.hostname = parts[5] || "";
        this.port = parts[6] || "";
        this.pathname = parts[7] || "/";
        this.search = parts[8] || "";
        this.hash = parts[10] || "";

        this.validate();
    },

    validate: function () {
        if (this.port == "") {
            if (this.protocol == "http:") {
                this.port = "80";
            }
            if (this.protocol == "https:") {
                this.port = "443";
            }
        }
    }
}
