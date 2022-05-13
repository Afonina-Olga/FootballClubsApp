using FootballClubsApp.WPFMVVM.ViewModel;
using System.IO;

namespace FootballClubsApp.WPFMVVM.Commands
{
	public class LoadContentCommand : SyncCommandBase
	{
		private readonly MainViewModel _mainModel;
		private readonly MenuItemViewModel _itemModel;

		public LoadContentCommand(MainViewModel mainModel, MenuItemViewModel itemModel)
		{
			_itemModel = itemModel;
		}

		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			_mainModel.Content = File.ReadAllText(_itemModel.FilePath);
		}
	}
}
