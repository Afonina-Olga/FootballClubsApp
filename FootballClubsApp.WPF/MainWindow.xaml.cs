using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FootballClubsApp.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Dictionary<string, List<string>> Storage { get; set; } = new Dictionary<string, List<string>>();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadData();
			CreateMenu();
		}

		private void CreateMenu()
		{
			foreach (string key in Storage.Keys)
			{
				var menuItem = new MenuItem() { Header = Path.GetFileName(key) };

				foreach (var file in Storage.GetValueOrDefault(key))
				{
					var innerMenuItem = new MenuItem()
					{
						Header = Path.GetFileName(file),
						Tag = file
					};
					innerMenuItem.Click += OnInnerMenuItemClick;
					menuItem.Items.Add(innerMenuItem);
				}

				MainMenu.Items.Add(menuItem);
			}

			var exitItem = new MenuItem() { Header = "Выход" };
			exitItem.Click += new RoutedEventHandler(OnMenuItemExitClick);
			MainMenu.Items.Add(exitItem);
		}

		private void OnInnerMenuItemClick(object sender, RoutedEventArgs e)
		{
			var menuItem = (MenuItem)sender;
			TextContainer.Document.Blocks.Clear();
			TextContainer.AppendText(File.ReadAllText(menuItem.Tag.ToString()));
		}

		public void OnMenuItemExitClick(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void LoadData()
		{
			var currentDirectory = Directory.GetCurrentDirectory();
			var workingDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
			var dataFolder = Path.Combine(workingDirectory, @"Data\");

			foreach (string directory in Directory.GetDirectories(dataFolder))
			{
				Storage.Add(Path.GetDirectoryName(directory + "\\"), Directory.GetFiles(directory).ToList());
			}
		}
	}
}
