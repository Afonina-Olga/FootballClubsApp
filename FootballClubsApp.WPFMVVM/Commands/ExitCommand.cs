using System.Windows;

namespace FootballClubsApp.WPFMVVM.Commands
{
	public class ExitCommand : SyncCommandBase
	{
		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			Application.Current.Shutdown();
		}
	}
}
