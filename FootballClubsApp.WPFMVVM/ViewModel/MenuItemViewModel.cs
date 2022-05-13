using System.Collections.Generic;
using System.Windows.Input;

namespace FootballClubsApp.WPFMVVM.ViewModel
{
	public class MenuItemViewModel
	{
		public string Header { get; set; }

		public string FilePath { get; set; }

		public List<MenuItemViewModel> Children { get; set; }

		public ICommand ExecuteCommand { get; set; }
	}
}
