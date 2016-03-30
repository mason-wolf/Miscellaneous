
    var letters = 'ghijklabvwxyzABCDEFef)_+|<>?:mnQRSTU~!@#$%^VWXYZ`1234567opGHIJKLu./;' + "'" + '[]MNOP890-=' + '\\' + '&*("{},cdqrst ' + "\n";
    var split = letters.split("");
    var num = '';
    var c = '';
    var encrypted = '';

    function encrypt(it) {
        var b = '0';
        var chars = it.split("");
        while (b < it.length) {
            c = '0';
            while (c < letters.length) {
                if (split[c] == chars[b]) {
                    if (c == "0") {
                        c = "";
                    }
                    if (eval(c + 10) >= letters.length) {
                        num = eval(10 - (letters.length - c));
                        encrypted += split[num];
                    } else {
                        num = eval(c + 10);
                        encrypted += split[num];
                    }
                }
                c++;
            }
            b++;
        }
        document.forms[0].data.value = encrypted;
        encrypted = '';
    }
    function decrypt(it) {
        var b = '0';
        var chars = it.split("");
        while (b < it.length) {
            c = '0';
            while (c < letters.length) {
                if (split[c] == chars[b]) {
                    if (c == "0") {
                        c = "";
                    }
                    if (eval(c - 10) < 0) {
                        num = eval(letters.length - (10 - c));
                        encrypted += split[num];
                    } else {
                        num = eval(c - 10);
                        encrypted += split[num];
                    }
                }
                c++;
            }
            b++;
        }
        document.forms[0].data.value = encrypted;
        encrypted = '';
    }
 
 
 /*
 
 <form>
    <textarea rows=9 cols=60 name='data' wrap='virtual'></textarea>
    <br> <input type='button' value='Encrypt' onClick="encrypt(document.forms[0].data.value)">
    <input type='button' value='Decrypt' onClick="decrypt(document.forms[0].data.value)">
 </form>
   

*/
