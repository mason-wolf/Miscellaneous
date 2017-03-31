string TransferDateThreshold = Properties.Settings.Default.TransferDateThreshold.ToString();

DateTime Date = (Convert.ToDateTime(TransferDateThreshold));

string day = Date.Day.ToString();
string month = Date.Month.ToString();
string year = Date.Year.ToString();
