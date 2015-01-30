using System;
using System.Diagnostics;
using System.Threading;
using System.Text;

namespace Idktest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Title = "Mein Server";
			Console.SetWindowSize (90, Console.WindowHeight);
			while (true) {
				Console.Clear ();
				Console.WriteLine("What do you want to do?");
				string line = Console.ReadLine();
				if (line.ToLower () == "start") {
					StartGame ();
				} else if (line.ToLower () == "logs") {
					Process.Start (@"logs\\latest.log");
				} else if (line.ToLower () == "config") {
					Process.Start (@"server.properties");
				} else if (line.ToLower () == "ops") {
					Process.Start (@"ops.json");
				} else if (line.ToLower () == "whitelist") {
					Process.Start (@"whitelist.json");
				} else if (line.ToLower() == "help"){
					Console.WriteLine("Valid Options are :" + System.Environment.NewLine);
					Console.WriteLine("\t Start \t\t- Starts the server");
					Console.WriteLine("\t logs \t\t- Opens the Latest server logs in your default Text Editor");
					Console.WriteLine("\t config \t- Opens the Server Configs in your default Text Editor");
					Console.WriteLine("\t ops \t\t- Opens the ops Configs in your default Text Editor");
					Console.WriteLine("\t whitelist \t- Opens the whitelist Configs in your default Text Editor" + System.Environment.NewLine);
					Console.WriteLine ("Press any key to continue....");
					Console.ReadLine();
				} else {
					Console.Clear ();
					Console.WriteLine ("Please use an option i know!");
					Console.WriteLine ("Press any key to continue....");
					Console.ReadLine();
				}
			}
		}

		public static void StartGame()
		{
			Process process = new Process();
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
			process.StartInfo.CreateNoWindow = false;
			process.StartInfo.FileName = "C:\\Program Files\\Java\\jre1.8.0_25\\bin\\java.exe";
			process.StartInfo.Arguments = "-Xmx1024M -Xms1024M -jar jars\\minecraft.jar nogui";
			process.Start();
			while (process.HasExited == false) {
				Console.Write (process.StandardOutput.ReadLine () + System.Environment.NewLine);
			}
		}
	}
}
