$computer = Read-Host "Computer Name"
Get-WmiObject Win32_Printer -cn $computer -ErrorAction SilentlyContinue |
Where-Object {($_.Name -notlike "*Adobe*") -and
              ($_.Name -notlike "*OneNote*") -and 
              ($_.Name -notlike "*Microsoft*") -and 
              ($_.Name -notlike "Fax")} |
              Select Name, SystemName
