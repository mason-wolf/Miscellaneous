<?php

function getImageFormat($path) {

$gettype = exif_imagetype($path);
$type = "";
if($type = 1) {
$type = ".gif";
}
else if($type = 2) {
$type = ".jpeg";
}
else if($type = 3) {
$type = ".png"; 
}
else if($type = 6) {
$type = ".bmp";
}

return $type;
}

?>