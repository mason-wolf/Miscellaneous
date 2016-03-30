$computerName = Read-Host "Computer Name"
try {
Import-Csv \\server\$ComputerName.csv
}
catch {
echo "Workstation not found. It either doesn't exist or computer name is mispelled."
}
