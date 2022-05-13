using FootballClubsApp.WPFMVVM.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace FootballClubsApp.WPFMVVM.Commands
{
	public class LoadCommand : SyncCommandBase
	{
		private readonly MainViewModel _mainModel;

		public LoadCommand(MainViewModel mainModel)
		{
			_mainModel = mainModel;
		}

		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			var currentDirectory = Directory.GetCurrentDirectory();
			var workingDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
			var dataFolder = Path.Combine(workingDirectory, @"Data\");

			_mainModel.MenuItems = new ObservableCollection<MenuItemViewModel>
			{
				new MenuItemViewModel()
				{
					Header = "Футбольные клубы",
					Children = GetFirstLevelChildren(dataFolder)
				}
			};
		}

		private List<MenuItemViewModel> GetFirstLevelChildren(string dataFolder)
		{
			var res = new List<MenuItemViewModel>();

			foreach (string directory in Directory.GetDirectories(dataFolder))
			{
				var children = new MenuItemViewModel()
				{
					Header = Path.GetFileName(Path.GetDirectoryName(directory + "\\")),
					FilePath = directory,
					Children = GetChildren(directory)
				};

				res.Add(children);
			}

			res.Add(new MenuItemViewModel() { Header = "Выход", ExecuteCommand = new ExitCommand() });

			return res;
		}

		private List<MenuItemViewModel> GetChildren(string directory)
		{
			var children = new List<MenuItemViewModel>();
			foreach (var file in Directory.GetFiles(directory))
			{
				var item = new MenuItemViewModel()
				{
					Header = Path.GetFileNameWithoutExtension(file),
				};
				item.ExecuteCommand = new LoadContentCommand(_mainModel, item);
				children.Add(item);
			}
			return children;
		}
	}
}
