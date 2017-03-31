var color = new Array('00','20','40','60','80','a0','c0','ff');

for (i = 0; i < 8; i++) {
	document.write("<table border=1 cellpadding=8>");
	for (j = 0; j < 8; j++) {
		document.write("<tr>");
		for (k = 0; k < 8; k++) {
			document.write('<td bgcolor="#'+clr[i]+clr[j]+clr[k]+'">');
			document.write('<tt> ');
			document.write(clr[i]+clr[j]+clr[k]+' </tt></td>');
		}
	}
}
