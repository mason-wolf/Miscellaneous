Process p = new Process();
p.StartInfo.FileName = "taskkill";
p.StartInfo.CreateNoWindow = true;
p.StartInfo.UseShellExecute = false;
p.StartInfo.RedirectStandardOutput = true;
p.StartInfo.Arguments = @"/im xcopy.exe /f";
p.Start();
