// xcopy wrapper

public void PerformTransfer(string SolutionDirectory, string TargetDirectory)
{
    StreamReader reader;

    using (Process p = new Process())
    {
        p.StartInfo.FileName = "xcopy";
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.Arguments = SolutionDirectory + " " + TargetDirectory + " " + @"/s /y /I /c ";
        p.Start();

        try
        {
            using (reader = p.StandardOutput)
            {
                while (reader != null)
                {
                    string result = reader.ReadLine();

                    TransferStatusField.Invoke((Action)delegate
                    {
                        if (result != null)
                        {
                            if (result.Contains("copied"))
                            {
                                TransferStatusField.Clear();
                                TransferStatusField.Text = "Restoration complete.";
                                CancelButton.Enabled = false;
                                RestoreButton.Enabled = false;
                            }
                            else
                            {
                                TransferStatusField.Clear();
                                TransferStatusField.Text = result.Remove(0, 19);
                                TransferStatusField.SelectionStart = TransferStatusField.Text.Length;
                            }
                        }
                        else
                        {
                            reader.Close();
                        }
                    });
                }
            }
        }
        catch
        {

        }
        p.Close();
        p.Dispose();
    }
}
