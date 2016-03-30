using System;
using System.IO;
using System.Reflection;

class embedres {
	static void Main() {
		
		string[] assemblyData = Assembly.GetExecutingAssembly().GetManifestResourceNames();
		for(int i = 0; i < assemblyData.Length; i++) {
			Console.WriteLine(assemblyData[i]);
		}
		try {
			Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("app.exe");
			FileStream fileStream = new FileStream("app.exe", FileMode.CreateNew);
			
			for (int i = 0; i < stream.Length; i++)
			
				fileStream.WriteByte((byte)stream.ReadByte());
				fileStream.Close();
		}
			catch (Exception) {
				Console.ReadLine();
			}
		}
	}


  
