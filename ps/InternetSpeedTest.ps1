echo ""
echo "Terminating instances of Internet Explorer.."
echo ""
taskkill /F /IM iexplore.exe 
echo ""
start-sleep -s 3
cls
echo "Initiating network speed test, contacting Dallas, Texas servers.."
echo ""
# url for the server to test network speeds
$ErrorActionPreference = "SilentlyContinue"
$URL = "http://dallas2.testmy.net/dl-1.4MB"
$ie = New-Object -com InternetExplorer.Application
$ie.silent=$true
$ie.navigate($URL) 
while($ie.ReadyState -ne 4) {start-sleep -s 5}

# once the bluecoat landing page is hit, click on the 'I Trust This Website Link'
$link = $ie.Document.getElementsByTagName('A') | where-object {$_.innerText -match 'I Trust This Website'}
$link.click() 

# wait for the speed test to commence and complete, retrieve the contents of the test results
start-sleep -s 10
$link2 = $ie.Document.getElementsByTagName('A') | where-object {$_.innerText -match 'Result Details'}
$link2.click()
echo ""
$result = $ie.Document.getElementById('contactForm').innerHTML
echo ""

# formatting to highlight the important information, negating the html output from the web page

filter ColorWord {
    param(
        [string] $word,
        [string] $fgcolor,
        [string] $bgcolor
    )
    $line = $_
    $index = $line.IndexOf($word, [System.StringComparison]::InvariantCultureIgnoreCase)
    while($index -ge 0){
        Write-Host $line.Substring(0,$index) -NoNewline
        Write-Host $line.Substring($index, $word.Length) -NoNewline -ForegroundColor $fgcolor -BackgroundColor $bgcolor
        $used = $word.Length + $index
        $remain = $line.Length - $used
        $line = $line.Substring($used, $remain)
        $index = $line.IndexOf($word, [System.StringComparison]::InvariantCultureIgnoreCase)
    }
    Write-Host $line
}


$result | Format-Table| Out-String| ColorWord -word "Download Connection Speed::" -fgcolor black -bgcolor yellow
echo ""

