using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;


namespace HelloWPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public static class Argument { public static string s; }

	public partial class App :Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			Trace.WriteLine("Starting WPF app");
			if (e.Args.Length > 0) Argument.s = e.Args[0];
			base.OnStartup(e);
		}
	}
}
