DateTime CreationDateThreshold = Properties.Settings.Default.TransferDateThreshold; // dd-mm-yyyy

var lastModifiedDate = new DirectoryInfo(user);

DateTime created = lastModifiedDate.LastWriteTime;
