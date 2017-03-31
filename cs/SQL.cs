using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;

class db {

	static void Main(string[] args) {
		db db = new db();
		
	try {
		if (args[0] == "newdb") {
			db.newdb(args[1]);
		}
		if (args[0] == "delete") {
			db.deletedb(args[1]);
		}
		if (args[0] == "select") {
			db.selectdb(args[1], args[2], args[3]);
		}
		if (args[0] == "within") {
			db.within(args[1], args[2], args[3], args[4], args[5]);
		}
		if (args[0] =="--help") {
			db.help();
		}
	}
		catch(Exception e) {
				Console.WriteLine("\nMissing parameter(s). Type --help for more info\n" + e);
			}
	}

	public void newdb(string dbname){
		try {
			Directory.CreateDirectory(dbname);
		//	Console.WriteLine("\nSuccessfully created database '" + dbname + "'.");
		}
		catch(Exception) { 
			Console.WriteLine("\nFailed to created directory.");
		}
	} 
	
	public void deletedb(string dbname){
		try {
			Directory.Delete(dbname, true);
			Console.WriteLine("\nDatabase '" + dbname + "' deleted.");
		}
		catch(DirectoryNotFoundException) {
			Console.WriteLine("\nDatabase not found.");
		}
		catch(Exception) {
			Console.WriteLine("\nUnable to delete database.");
		}
	}
	
	public void help() {
		string[] helpmsg = {
			"\nwdb - unofficial standard desktop configuration simple database system\n", 
			"creating new:				newdb DATABASE_NAME",
			"deleting:				delete DATABASE_NAME",
			"add entity:				select DATABASE_NAME add ENTITY_NAME",
			"create record w/ entity:		within DATABASE_NAME ENTITY_NAME add RECORD_NAME CONTENTS",
			"delete record w/ entity:		within DATABASE_NAME ENTITY_NAME delete RECORD_NAME record",
			"append record w/ entity:		within DATABASE_NAME ENTITY_NAME append RECORD_NAME CONTENTS",
			"retrieve record w/ entity:		within DATABASE_NAME ENTITY_NAME get RECORD_NAME record",
			"view all entities:			select DATABASE_NAME get all",
			"delete entity:				select DATABASE_NAME delete ENTITY_NAME\n"
		};
		foreach(string element in helpmsg) {
			Console.WriteLine(element);
		}
	}
	public void selectdb(string whichdb, string whichfunction, string entity) {

		if(whichfunction =="add") {
			Directory.CreateDirectory(whichdb + "\\" + entity);
		//	Console.WriteLine("\nAdded '" + entity + "' to database '" + whichdb + "'.");
		}
		if(whichfunction =="delete") {
			Directory.Delete(whichdb + "\\" + entity, true);
		//	Console.WriteLine("\nDeleted '" + entity + "' from datbase '" + whichdb + "'.");
		}
		if(whichfunction =="get") {
			try {
			if(entity == "all") {
				bool dirExists = Directory.Exists(whichdb);
				if(dirExists == true){
				string[] dir = Directory.GetDirectories(whichdb);
				Directory.CreateDirectory("temp");
				var dbr = File.Create("temp\\log.dbr");
				dbr.Close();
				foreach (string element in dir) {
					// only returns name of directories without the backslashes
					string alldb = element.Replace(whichdb + "\\", "");
					Console.WriteLine(alldb);
					using (StreamWriter log = File.AppendText("temp\\log.dbr")) {
						log.WriteLine(alldb);
					}

				}
	
				}
				else {
					Console.WriteLine("Database does not exist.");
					log("Database does not exist.");
				}
			}
			else {
				string[] dir = Directory.GetFiles(whichdb + "\\" + entity);
				foreach (string element in dir) {
					Console.WriteLine(element);
				}
			}
		}
					catch (Exception e) {
				Console.WriteLine(e);
			}
		if(whichfunction =="check") {
			bool dircheck = Directory.Exists(whichdb);
			log(dircheck.ToString());
		}
	}
	}

	public static string within(string whichdb, string whichselected, string whichfunction, string filename, string contents) {
		string value = "";

		if(whichfunction =="add") {
			var dbr = File.Create(whichdb + "\\" + whichselected + "\\" + filename + ".dbr");
			dbr.Close();
			File.WriteAllText(whichdb + "\\" + whichselected + "\\" + filename + ".dbr", contents);
			value = contents;
		//	Console.WriteLine("\nAdded '" + filename + "' to entity '" + whichselected + "' in database '" + whichdb + "'");
		}
			if(whichfunction =="delete") {
				File.Delete(whichdb + "\\" + whichselected + "\\" + filename + ".dbr");
				value = filename;
		//		Console.WriteLine("\nRecord '" + filename + "' deleted from entity '" + whichselected + "' in database '" + whichdb + "'."); 
			}
	
		if(whichfunction =="append") {
			using (StreamWriter dbra = File.AppendText(whichdb + "\\" + whichselected + "\\" + filename + ".dbr")) 
        {
            dbra.WriteLine("\n" + contents);
        }	
           value = filename;
        	//	Console.WriteLine("\nAppended '" + contents + "' to record '" + filename + "' in entity '" + whichselected + "' within database '" + whichdb + "'");
		}
		if(whichfunction =="get") {
			try {
			string record = File.ReadAllText(whichdb + "\\" + whichselected + "\\" + filename + ".dbr");
			value = record;
			}
			catch(Exception) {
				var exception = "Record does not exist.";
				Console.WriteLine(exception);
	
			}
		}
	return value;
	}

	public void log(string result) {
			Directory.CreateDirectory("temp");
			var dbr = File.Create("temp\\log.dbr");
			dbr.Close();
			File.WriteAllText("temp\\log.dbr", result);
	}

}

