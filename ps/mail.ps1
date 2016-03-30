$WebClient = new-object System.Net.WebClient 
$WebClient.Credentials = new-object System.Net.NetworkCredential("email, "");
[xml]$xml = $WebClient.DownloadString("https://mail.google.com/mail/feed/atom")
$format = @{Expression={$_.summary};Label="Title"},
		  @{Expression={$_.author.email};Label="Sender"}
		  
$xml.feed.entry | format-table $format
