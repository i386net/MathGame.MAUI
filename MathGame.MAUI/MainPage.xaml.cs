namespace MathGame.MAUI;

public partial class MainPage : ContentPage
{
	public MainPage() //constructor
	{
		InitializeComponent();
	}

	private void OnGameChosen(object sender, EventArgs e)
	{
		Button button = (Button)sender; //cast sender to Button
		Navigation.PushAsync(new GamePage(button.Text));
	}
}

