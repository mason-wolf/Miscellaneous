

function showBoxes(frm){
   var i;
   var message = "Items :\n\n"

   for (i = 0; i < frm.Music.length; i++)
      if (frm.Music[i].checked){
         message = message + frm.Music[i].value + "\n"
      }
   
}



/*

<input type='checkbox' name='items' value='item 1'> item 1 </input>
<input type='checkbox' name='items' value='item 2'> item 2 </input>
<input type='button' value='get' onclick='showBoxes(this.form)'>


*/
