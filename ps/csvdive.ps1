$Path = "\\server\"
echo ""
$Text = Read-Host "IP Address or Username"
echo ""
echo "Searching.."
echo ""
$PathArray = @()
$Results = "C:\temp\test.txt"



Get-ChildItem $Path -Filter "*.csv" |
   Where-Object { $_.Attributes -ne "Directory"} |
      ForEach-Object {
         If (Get-Content $_.FullName | Select-String -Pattern $Text) {
            $PathArray += $_.FullName
         }
      }

try {
Import-Csv $PathArray
}
catch {
echo "Unable to locate host with designated IP address."
}
