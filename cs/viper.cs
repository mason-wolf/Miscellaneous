using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections;
using System.Net;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Security.Principal;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections.Generic;

[assembly: AssemblyTitle("Viper 1.5")]
[assembly: AssemblyDescription("Vulnerability Incident Patch and Evaluation Remedy - Scans, cleans and performs updates for Standard Desktop Configurations.")]
[assembly: AssemblyCompany("USAF")]
[assembly: AssemblyProduct("Viper")]
[assembly: AssemblyCopyright("SrA Mason Wolf - Client Systems Technician, Tyndall AFB FL")]
[assembly: AssemblyVersion("1.5.0.0")]
[assembly: CLSCompliant(true)]

class Patcher: Catalyst {

	// Check to see if user is an administrator
	public static bool IdentityCheck() {
		WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
		WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
		return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
	}
	static void Main() {
	
	
		Console.WindowLeft = Console.WindowTop = 0;
		Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
		Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
		Console.BackgroundColor = ConsoleColor.Blue;
		Console.ForegroundColor = ConsoleColor.White;
		Console.Clear();
		Console.Title = "Viper 1.5";
		bool Role = IdentityCheck();
		if (Role == true) {
			Catalyst Incident = new Catalyst();
			Settings ParameterCheck = new Settings();
			ParameterCheck.Preinstall();
			Incident.ScanMachine();
		} else {
			Console.WriteLine("Please run as an administrator.");
			Console.ReadLine();
		}
	}
}
// Push commands through cmd.exe and to redirect the output to the console
public class Catalyst {
	public void cmd(string command) {
		int exitCode;
		ProcessStartInfo processInfo;
		Process process;
		processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
		processInfo.CreateNoWindow = true;
		processInfo.UseShellExecute = false;
		processInfo.RedirectStandardError = true;
		processInfo.RedirectStandardOutput = true;
		process = Process.Start(processInfo);
		process.WaitForExit();
		string output = process.StandardOutput.ReadToEnd();
		string error = process.StandardError.ReadToEnd();
		exitCode = process.ExitCode;
		// Display exit code and error information if needed
		// Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
		// Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
		// Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
		process.Close();
	}
	
	public void ScanMachine() {
	// Utilize wmic call to retrieve list of installed software
		Catalyst Incident = new Catalyst();
		string InstalledPrograms = "wmic product list brief";
		Incident.cmd(InstalledPrograms + "> C:\\Windows\\Temp\\ViperLog.txt");
		try {
			using(StreamReader sr = new StreamReader("C:\\Windows\\Temp\\ViperLog.txt")) {
				String line = sr.ReadToEnd();
				Console.WriteLine(line);
			}
		} catch (Exception e) {
			Console.WriteLine("The file could not be read:");
			Console.WriteLine(e.Message);
		}
		Thread.Sleep(1000);
		Catalyst Detection = new Catalyst();
	}
}
public class Settings {
	public void Preinstall() {
		int i;
		int ProductCount;
		string StringCount;
		string Products;
		string Version;
		IniParser parser = new IniParser("settings.ini");
		Version = parser.GetSetting("VIPER", "SDC_VERSION");
		string[] StartUpMessage = {
			" \n Vulnerability Incident Patch & Evaluation Remedy 1.5\n",
				" ********************************************************\n",
				" For use with patching Standard Desktop Configuration " + Version,
				" and below. Viper will scan for missing packages and push",
				" updates pre-configured in the settings.ini file. It also",
				" scans for and removes remnants of previously installed &",
				" out-dated products.\n\n",
				"The following updates will be applied:\n"
		};
		try {
			// Return the total number of products the user configures to install, which returns as a string
			StringCount = parser.GetSetting("VIPER", "NUMPRODUCTS");
			// Convert the string to int type, now we have the total number of products
			ProductCount = Int32.Parse(StringCount);
			for (i = 0; i < StartUpMessage.Length; i++) {
				Console.WriteLine(StartUpMessage[i]);
			}
			for (i = 0; i < ProductCount; i++) {
				Products = parser.GetSetting(i.ToString(), "PRODUCT_NAME");
				string[] ProductList = Products.Split(new char[] {
					','
				});

				// List the name of the packages 
				foreach(string ProductName in ProductList) {

					Console.Write(ProductName + "\n");

				}
			}
			Console.WriteLine("\n");
			Console.WriteLine("Press enter to continue..\n");
			Console.Write("> ");
			Console.ReadLine();
			Installation Initiate = new Installation();
			Initiate.Install();

		} catch {

			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("There's a problem with the settings file. Please check configuration.\n\n");
			Console.ReadLine();
		}
	}
}
public class Installation: Settings {

public static void ColorizeConsoleMessage(string message)
    {
        MatchCollection matches = Regex.Matches(message, "&+([0-9a-f])([^&]+)");
        ConsoleColor def = Console.ForegroundColor;
        foreach (Match match in matches)
        {
            switch (match.Groups[1].Value[0])
            {
                case '0':
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case '1':
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case '2':
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case '3':
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case '4':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case '5':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case '6':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case '7':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            string str_to_print = match.Groups[2].Value;
            Console.Write(str_to_print);
        }
        Console.WriteLine();
        Console.ForegroundColor = def;
    }
	
	public void Install() {

		Console.WriteLine("Scanning machine..");
		// Initiate another wmic call to scan for obsolete product IDs
		int i;
		int ProductCount;
		int isInstalled;
		char Quote = '"';
		string ForwardSlash_i = "/i ";
		string FilePath;
		string StringCount;
		string Products;
		string ProductScan = "wmic product list brief";
		string LogFile;
		string ProductID;
		string Version;
		string UserInput;
		Catalyst Install = new Catalyst();
		Install.cmd(ProductScan + "> C:\\Windows\\Temp\\ViperLog.txt");
		Console.WriteLine("Removing obsolete registry entries..");
		string[] CleanUp = new string[] {
			//	"msiexec.exe /qn /uninstall {AC194855-F7AC-4D04-B4C9-07BA46FCB697} /norestart",	//ActivClient 6.1
			//	"msiexec.exe /qn /uninstall {86E45973-5352-439F-A115-2E8EE4D40140} /norestart",	//ActivClient 6.2
			//	"msiexec.exe /qn /uninstall {1BE8806A-84F8-4655-A381-0D5524430944} /norestart",	//ActivClient 6.2
			//	"msiexec.exe /qn /uninstall {A0BBF7AB-2F47-47DC-BB02-4C826F2BC73C} /norestart",	// IBM Lotus Forms Viewer 3.5
			//	"msiexec.exe /qn /uninstall {48462CC7-7DF3-4107-9459-12D3A11C6D80} /norestart",	// IBM Forms Viewer 4.0
			// Old versions of Java
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F83217051FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416001FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416002FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416003FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416004FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416005FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416006FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416007FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416008FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416009FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416010FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416011FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416012FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416013FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416014FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416015FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416016FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416017FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416018FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416019FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416020FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416021FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416022FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416023FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416024FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416025FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416026FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416027FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416028FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416029FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416030FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416031FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416032FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416033FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416034FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416035FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416036FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416037FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416038FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416039FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416040FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416041FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416042FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416043FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416044FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416045FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86416046FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417001FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417002FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417003FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417004FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417005FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417006FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417007FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417008FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417009FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417010FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417011FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417012FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417013FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417014FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417015FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417016FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417017FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417018FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417019FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417020FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417021FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417022FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417023FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417024FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417025FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417026FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417027FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417028FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417029FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417030FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417031FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417032FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417033FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417034FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417035FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417036FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417037FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417038FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417039FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417040FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417041FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417042FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417043FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417044FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417045FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417046FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417047FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417048FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417049FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417050FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417051FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417052FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417053FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417054FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417055FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417056FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417057FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417058FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417059FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417060FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417061FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417062FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F86417063FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417064FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417065FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417066FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417067FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417068FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417069FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417070FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417071FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417072FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417073FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417074FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417075FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417076FF} /norestart",
				"msiexec.exe /qn /uninstall {26A24AE4-039D-4CA4-87B4-2F06417077FF} /norestart",
			// Old versions of Adobe Reader
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A81200000003} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A90000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A91000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A91100000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A91200000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A91300000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A91400000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A91500000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A92000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A92100000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A92200000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A92300000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A92400000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A92500000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A93000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A93100000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A93200000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A93300000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A93400000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A93500000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A94000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A94100000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A94200000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A94300000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A94400000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-A94500000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA0000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA0100000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA0200000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA0300000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA0400000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA0500000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA1000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA1100000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA1200000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA1300000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA1400000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA1500000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA2000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA2100000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA2200000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA2300000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA2400000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AA2500000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB0000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB0100000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB0200000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB0300000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB0400000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB0500000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB1000000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB1100000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB1200000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB1300000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB1400000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-7AD7-1033-7B44-AB1500000001} /norestart",
				"msiexec.exe /qn /uninstall {AC76BA86-1033-0000-7760-000000000005} /norestart"
		};
		
		foreach(string element in CleanUp) {
			Install.cmd(element);
		}
		
		try {
			using(StreamReader sr = new StreamReader("C:\\Windows\\Temp\\ViperLog.txt")) {
				String line = sr.ReadToEnd();
				Console.WriteLine(line);
			}
		} catch (Exception) {
			ColorizeConsoleMessage("&4 Failed to list installed programs and features.");
			Console.ReadLine();
		}
		Thread.Sleep(1000);
		// Read the settings file, retrieve the SDC Version, number of products, filepath and product ID
		IniParser parser = new IniParser("settings.ini");
		Version = parser.GetSetting("VIPER", "SDC_VERSION");
		StringCount = parser.GetSetting("VIPER", "NUMPRODUCTS");
		ProductCount = Int32.Parse(StringCount);
		// Based upon the result of the number of products assigned in the settings file,
		// perform a loop to retrieve each setting
		for (i = 0; i < ProductCount; i++) {
			Products = parser.GetSetting(i.ToString(), "PRODUCT_NAME");
			FilePath = parser.GetSetting(i.ToString(), "FILEPATH");
			ProductID = parser.GetSetting(i.ToString(), "PRODUCT_ID");
			string[] ProductList = Products.Split(new char[] {
				','
			});
			string[] FilePaths = FilePath.Split(new char[] {
				','
			});
			string[] ProductIDs = ProductID.Split(new char[] {
				','
			});
			foreach(string ProductName in ProductList) {
				foreach(string Path in FilePaths) {
					foreach(string ProductIdentifier in ProductIDs) {
						isInstalled = File.ReadAllText("C:\\Windows\\Temp\\ViperLog.txt").Contains(ProductIdentifier) ? 1 : 0;
						if (isInstalled == 1) {

						ColorizeConsoleMessage("&5" + ProductName + " is already installed.");
							Thread.Sleep(3000);

						} else {
							if (File.Exists(Path)) {
								ColorizeConsoleMessage("&4" + ProductName + " is not installed.");
								Console.WriteLine("Installing..");
								string InstallFrom = Quote + Path + Quote + " ";
								string InstallParam = "/quiet /L*v " + Quote + "C:\\Windows\\Temp\\" + ProductName + "_log.txt" + Quote;
								Install.cmd("msiexec.exe " + ForwardSlash_i + InstallFrom + InstallParam);
								LogFile = File.ReadAllText("C:\\Windows\\Temp\\" + ProductName + "_log.txt");

								Process[] procs = Process.GetProcessesByName("msiexec.exe");
								if (procs.Count() == 0) {
									Console.WriteLine(LogFile);
									Console.WriteLine(ProductName + " configured.\n\n");
									Thread.Sleep(3000);
								}

							} else {
								Console.WriteLine("Invalid filepath for " + ProductName + ". Check configuration file.");
								Thread.Sleep(3000);
							}
						}
					}
				}
			}
		}
		Install.cmd("del C:\\Windows\\Temp\\ViperLog.txt");

		Console.WriteLine("SDC " + Version + " is up to date. Restart? (y/n)");
		Console.Write("> ");
		UserInput = Console.ReadLine();
		if (UserInput == "y") {
			Install.cmd("shutdown /f /r");
		} else if (UserInput == "n") {

			Catalyst Incident = new Catalyst();
			Settings ParameterCheck = new Settings();
			ParameterCheck.Preinstall();
		} else {

		}
	}

}


public class IniParser {
	private Hashtable keyPairs = new Hashtable();
	private String iniFilePath;

	private struct SectionPair {
		public String Section;
		public String Key;
	}

	// Opens the INI file at the given path and enumerates the values in the IniParser.

	public IniParser(String iniPath) {
		TextReader iniFile = null;
		String strLine = null;
		String currentRoot = null;
		String[] keyPair = null;

		iniFilePath = iniPath;

		if (File.Exists(iniPath)) {
			try {
				iniFile = new StreamReader(iniPath);

				strLine = iniFile.ReadLine();

				while (strLine != null) {
					strLine = strLine.Trim().ToUpper();

					if (strLine != "") {
						if (strLine.StartsWith("[") && strLine.EndsWith("]")) {
							currentRoot = strLine.Substring(1, strLine.Length - 2);
						} else {
							keyPair = strLine.Split(new char[] {
								'='
							}, 2);

							SectionPair sectionPair;
							String value = null;

							if (currentRoot == null) currentRoot = "ROOT";

							sectionPair.Section = currentRoot;
							sectionPair.Key = keyPair[0];

							if (keyPair.Length > 1) value = keyPair[1];

							keyPairs.Add(sectionPair, value);
						}
					}

					strLine = iniFile.ReadLine();
				}

			} catch (Exception ex) {
				throw ex;
			} finally {
				if (iniFile != null) iniFile.Close();
			}
		} else throw new FileNotFoundException("Unable to locate " + iniPath);

	}

	// Returns the value for the given section, key pair.

	public String GetSetting(String sectionName, String settingName) {
		SectionPair sectionPair;
		sectionPair.Section = sectionName.ToUpper();
		sectionPair.Key = settingName.ToUpper();

		return (String) keyPairs[sectionPair];
	}


	// Enumerates all lines for given section.

	public String[] EnumSection(String sectionName) {
		ArrayList tmpArray = new ArrayList();

		foreach(SectionPair pair in keyPairs.Keys) {
			if (pair.Section == sectionName.ToUpper()) tmpArray.Add(pair.Key);
		}

		return (String[]) tmpArray.ToArray(typeof(String));
	}

}
