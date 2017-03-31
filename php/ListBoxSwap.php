//<![CDATA[ 
    $(window).load(function(){
    $('#inventory').click(function(){
    $('#inventory option:selected').appendTo('#kit');
});

$('#kit').click(function(){
    $('#kit option:selected').appendTo('#inventory');
});

});//]]>  

function getValues() {
	var kitNumber = document.getElementById("kitNumber").value;
	if(kitNumber == "") {
		return;
	}
	else {
    var x = document.getElementById("kit");
    var txt = "";
    var i;
    for (i = 0; i < x.length; i++) {
        txt = txt + "," + x.options[i].value;
    }
	var array = txt.split(",");

for(i = 1; i < array.length; i++) {
 var newdiv = document.createElement('div');
 newdiv.innerHTML = "<br><input type='hidden' name='" + "inputs[]" + "' value='" + array[i] + "'>";
 document.getElementById("tools").appendChild(newdiv);

	}
}
}
