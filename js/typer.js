
    var outMsg = "";
    var i = 0;
    var lineNo = 1;
    var timerDM = null;
    var msg = " ";

    function typer() {}
    var ScreenLine =  new Array();
    
    ScreenLine[1] = ""
    ScreenLine[2] = ""

    var msgNum = 1; 
    var msgCnt = 2; 
    var typeSpeed = 70; // typing rate in milliseconds
    var pageLen = 5; // set to page size, usually number of ROWS in TEXTAREA
    var delay = typeSpeed;
    var r = 0;
    var cr = "\r\n"
    if ("3" <= navigator.appVersion.charAt(0)) {
        var cr = "\n"
    }
    for (x = 1; x <= (msgCnt); x++) {
        ScreenLine[x] = ScreenLine[x] + cr;
    }
    msg = ScreenLine[1];

    function DisplayMsg() {
        if (msg.length <= i || msg.charAt(i) == "\f") {
            r = i;
            i = 0;
            ChangeMsg();
        }
        outMsg = outMsg + msg.charAt(i);
        i++;
        if (msg.charAt(i) == "\f" || (lineNo == pageLen && i == msg.length)) {
            delay = 4000;
        } else {
            if (msg.charAt(i) == cr && msg != " " + cr) {
                delay = 2000;
            } else {
                delay = typeSpeed;
            }
        }
        self.document.forms[0].elements[0].value = outMsg;
        timerDM = setTimeout("DisplayMsg()", delay);
    }

    function ChangeMsg() {
        msgNum++;
        if (msgCnt < msgNum) {
            msgNum = 1;
        }
        lineNo++;
        if (pageLen < lineNo || msg.charAt(r) == "\f") {
            outMsg = ScreenLine[msgNum].charAt(i);
            i++;
            lineNo = 1;
        }
        msg = ScreenLine[msgNum];
    }


