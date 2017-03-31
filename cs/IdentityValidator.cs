using System;
using System.Security.Principal;

class identity {
	
	public static bool IdentityCheck() {
		WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
		WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
		return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
	}
	
	static void Main() {
		// False = not running as administrator
		bool Role = IdentityCheck();
		Console.WriteLine(Role);
		Console.ReadLine();
	}
}
