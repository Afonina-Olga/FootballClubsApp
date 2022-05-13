using FootballClubsApp.WPFMVVM.Commands;
using System.Collections.ObjectModel;

namespace FootballClubsApp.WPFMVVM.ViewModel
{
	public class MainViewModel
	{
		public ObservableCollection<MenuItemViewModel> MenuItems { get; set; } = new ObservableCollection<MenuItemViewModel>();
		public string Content { get; set; }

		public MainViewModel()
		{
			new LoadCommand(this).Execute(null);
		}
	}
}
