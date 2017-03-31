
function submitInventory(frm){
	var inventory = "";
	var usr = document.getElementById("usr").value;
	var comments = document.getElementById("comments").value;
	
   for (i = 0; i < frm.tools.length; i++)
      if (frm.tools[i].checked){
        inventory = inventory + frm.tools[i].value + "\n";
      }
	window.location = "Inventory.php?technician=" + usr + "&inventory=" + inventory + "&comments=" +comments;

}
