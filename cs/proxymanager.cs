using System;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.IO;

[assembly: AssemblyTitle("Proxy Manager")]

public class ProxyManager {

	
	static void Main() {

		while (true)
		{
			var p = new System.Diagnostics.Process();
			p.StartInfo.FileName = "reg";
			p.StartInfo.Arguments = @"add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings"" /v proxyServer /t REG_SZ /d tyndall.proxy.us.af.mil:8080 /f";
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.CreateNoWindow = true;
			p.Start();
		    Thread.Sleep(5000);
		}
	}
}
