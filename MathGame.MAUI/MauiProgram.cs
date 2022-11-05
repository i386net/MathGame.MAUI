namespace MathGame.MAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//path where to db is located
		// Dependency Injection to get access this var in other parts of program
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "game.db");

		return builder.Build();
	}
}
