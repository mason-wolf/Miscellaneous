var thresholdcolors=[['20%','darkred'], ['10%','red']] 
var uncheckedkeycodes=/(8)|(13)|(16)|(17)|(18)/  

thresholdcolors.sort(function(a,b){return parseInt(a[0])-parseInt(b[0])}) 

function setformfieldsize($fields, optsize, optoutputdiv){
	var $=jQuery
	$fields.each(function(i){
		var $field=$(this)
		$field.data('maxsize', optsize || parseInt($field.attr('data-maxsize'))) 
		var statusdivid=optoutputdiv || $field.attr('data-output') 
		$field.data('$statusdiv', $('#'+statusdivid).length==1? $('#'+statusdivid) : null)
		$field.unbind('keypress.restrict').bind('keypress.restrict', function(e){
			setformfieldsize.restrict($field, e)
		})
		$field.unbind('keyup.show').bind('keyup.show', function(e){
			setformfieldsize.showlimit($field)
		})
		setformfieldsize.showlimit($field) 
	})
}

setformfieldsize.restrict=function($field, e){
	var keyunicode=e.charCode || e.keyCode
	if (!uncheckedkeycodes.test(keyunicode)){
		if ($field.val().length >= $field.data('maxsize')){ 
			if (e.preventDefault)
				e.preventDefault()
			return false
		}
	}
}

setformfieldsize.showlimit=function($field){
	if ($field.val().length > $field.data('maxsize')){
		var trimmedtext=$field.val().substring(0, $field.data('maxsize'))
		$field.val(trimmedtext)
	}
	if ($field.data('$statusdiv')){
		$field.data('$statusdiv').css('color', '').html($field.val().length)
		var pctremaining=($field.data('maxsize')-$field.val().length)/$field.data('maxsize')*100 
		for (var i=0; i<thresholdcolors.length; i++){
			if (pctremaining<=parseInt(thresholdcolors[i][0])){
				$field.data('$statusdiv').css('color', thresholdcolors[i][1])
				break
			}
		}
	}
}

jQuery(document).ready(function($){ 
	var $targetfields=$("input[data-maxsize], textarea[data-maxsize]") 
	setformfieldsize($targetfields)
})


/*


<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>

<script type="text/javascript" src="../js/maxlength.js"></script>

<form>

<p>Enter your hobbies (<50 characters)</p>
  <textarea style="width:300px; height:150px" data-maxsize="50" data-output="status1" wrap="virtual"></textarea><br />
  <div id="status1" style="width:300px;font-weight:bold;text-align:right"></div><br />

<p>Enter your postal code (<6 characters)</p>
  <input type="text" name="T1" size="15" data-maxsize="6">

</form>

*/
