using System.Diagnostics;

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
        Debug.WriteLine(button.Text);
        Navigation.PushAsync(new GamePage(button.Text));
    }
    private void OnViewPrevousGamesChosen(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PreviousGames());
    }
}

