namespace MathGame.MAUI;

public partial class PreviousGames : ContentPage
{
	public PreviousGames()
	{
		InitializeComponent();
		gamesList.ItemsSource = App.GameRepository.GetAllGames(); // add data to Prev page
	}

	private void OnDelete(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		App.GameRepository.Delete((int)button.BindingContext);
		gamesList.ItemsSource = App.GameRepository.GetAllGames();
	}
}