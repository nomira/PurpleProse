using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace StoryPlanner
{
	class Program
	{
		//System.ComponentModel		NotifyPropertyChanging	INotifyPropertyChanged

		static void Main(string[] args)
		{
			texteditor = "D:\\Documents\\Visual Studio 2015\\Projects\\Project_Purple_Prose\\HelloWPF\\HelloWPF\\bin\\Debug\\HelloWPF.exe";
			string[] directories = {
				"Forename_Surname",				//"D:\\Documents\\Visual Studio 2015\\Projects\\Project_Purple_Prose\\Program_resources\\Forename_Surname.txt",
				"D:\\Documents\\Visual Studio 2015\\Projects\\Project_Purple_Prose\\Program_resources\\Appearence.txt",
				"D:\\Documents\\Visual Studio 2015\\Projects\\Project_Purple_Prose\\Program_resources\\Story.txt",
				"Picture"
			};
			//Console.ReadLine();
			Object Doll = new Object(directories[0], directories[1], directories[2]);
			Open(Doll.DescrptS);

			//Essence.attributes.Add(new Object.Attribute("Family", "Last"));
			//Console.ReadLine();
		}

		static public void Open(string file) {
			Process.Start(texteditor, "\"" + file + "\"");
			/*
			// Prepare the process to run
			ProcessStartInfo start = new ProcessStartInfo();
			// Enter in the command line arguments, everything you would enter after the executable name itself
			start.Arguments = file; 
			// Enter the executable to run, including the complete path
			start.FileName = texteditor;
			// Do you want to show a console window?
			//start.WindowStyle = ProcessWindowStyle.Normal;
			//start.CreateNoWindow = true;
			int exitCode;


			// Run the external process & wait for it to finish
			using (Process proc = Process.Start(start))
			{
				 proc.WaitForExit();

				 // Retrieve the app's exit code
				 exitCode = proc.ExitCode;
			}
			*/
		}

		static string texteditor;

	}
}
