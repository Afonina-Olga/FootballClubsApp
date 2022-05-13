using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FootballClubsApp
{
	public partial class Form1 : Form
	{
		public Dictionary<string, List<string>> Storage { get; set; }
		
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			var currentDirectory = Directory.GetCurrentDirectory();
			var workingDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
			var dataFolder = Path.Combine(workingDirectory, "Data");

			foreach (string directory in Directory.GetDirectories(dataFolder))
			{
				Storage.Add(directory, Directory.GetFiles(directory).ToList());
			}

			base.OnLoad(e);
		}
	}
}
