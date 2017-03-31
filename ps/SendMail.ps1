$to = Read-Host 'To'
$title = Read-Host 'Title'
$mesage = Read-Host 'Message'

$smtp = New-Object Net.Mail.SmtpClient("mailserver") 
$smtp.Send($from,$to ,$title, $message)
