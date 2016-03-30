
    function jshtml(val) {
        var i;
        val.value = val.value.replace(/"/gi, "&#34;")
        val.value = val.value.replace(/'/gi, "&#39;")
        var valArr = encodeURI(val.value).split("%0D%0A")
        val.value = ""
        for (i = 0; i < valArr.length; i++) {
            val.value += (i == 0) ? "<script>\ninfo=" : ""
            val.value += "\"" + decodeURI(valArr[i])
            val.value += (i != valArr.length - 1) ? "\" + \n" : "\"\n"
        }
        val.value += "\ndocument.write(info)\n<\/script>"
    }

     
/*

 <center>
    <form name="f">
        <input type="button" value="html to js" onclick="jshtml(document.f.t)" />
        <input type="reset" value="Reset">
        <br />
        <textarea name="t" cols="20" rows="20"></textarea>
        <br />
    </form>
 </center> 
 
 */
