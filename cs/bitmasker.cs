using System;
using System.IO;

class bitmasker {
	static void Main(string[] args) {
		bitmasker bm = new bitmasker();
		if (args[0] == "mask")
		{
			bm.mask(args[1]);
		}
		if (args[0] == "unmask") {
			bm.unmask(args[1], args[2]);
		}
	}
	public void mask(string filename) {
		try {
			byte[] bytes = System.IO.File.ReadAllBytes(filename);
			string result = Convert.ToBase64String(bytes);
			var r = File.Create(filename + ".txt");
			r.Close();
			File.WriteAllText(filename + ".txt", result);
			Console.WriteLine(filename + " converted to Base64 format. \n");
			Console.WriteLine("Conversion successful.");
		}
		catch(Exception e) {
			Console.WriteLine(e);
		}
	}
	public void unmask(string filename, string destination) {
		try {
			string file = File.ReadAllText(filename);
			var buffer = Convert.FromBase64String(file);
			File.WriteAllBytes(destination, buffer);
			Console.WriteLine("Success.");
	} 
	catch(Exception e) {
		Console.WriteLine(e);
		Console.ReadLine();
	}
	}
}
