$computer = Read-Host "Host"
$message = Read-Host "Message"
REG ADD "\\$computer\HKLM\SYSTEM\CurrentControlSet\Control\Terminal Server" /v AllowRemoteRPC /t REG_DWORD /d 1 /f
MSG console /Server:$computer /Time:6000 $Message
