namespace MathGame.MAUI;

public partial class PreviousGames : ContentPage
{
	public PreviousGames()
	{
		InitializeComponent();
		gamesList.ItemsSource = App.GameRepository.GetAllGames(); // add data to Prev page
	}
}