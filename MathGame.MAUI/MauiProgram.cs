using MathGame.MAUI.Data;

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
				fonts.AddFont("CaveatBrush-Regular.ttf", "CaveatBrushRegular");
				//fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//path where to db is located
		// Dependency Injection to get access this var in other parts of program
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "game.db");

		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<GameRepository>(s, dbPath));

		return builder.Build();
	}
}
