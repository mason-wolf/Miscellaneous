$computer = Read-Host "Host"
$comment = Read-Host "Comment"
Shutdown /r /f /m \\$computer /t 0 /c $comment
