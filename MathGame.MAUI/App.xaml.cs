using MathGame.MAUI.Data;

namespace MathGame.MAUI;

public partial class App : Application
{
	// Prop for GameResopitory class
	// made it static to get access to its methods
	public static GameRepository GameRepository { get; private set; }
	public App(GameRepository gameRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();
		GameRepository = gameRepository;

	}
}
