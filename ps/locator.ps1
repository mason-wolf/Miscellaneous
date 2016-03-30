$domain = "T1U9VHluZGFsbCBBRkIsT1U9QUZDT05VU0VBU1QsT1U9QmFzZXMsREM9QVJFQTUyLERDPUFGTk9BUFBTLERDPVVTQUYsREM9TUlM"
$objDomain = [adsi]("LDAP://" + $domain)
$Computer = Read-Host "Computer Name"
    $search = New-Object System.DirectoryServices.DirectorySearcher
    $search.SearchRoot = $objDomain
    $search.Filter = "(&(objectClass=computer)(cn=*$Computer*))"
    $search.SearchScope = "Subtree"
    $results = $search.FindAll()
    ForEach($item in $results)
    {
        $objComputer = $item.GetDirectoryEntry()
        $Name = $objComputer.cn
        $Loc = $objComputer.Location
        Write-Host "$Name; $Loc"
    }
