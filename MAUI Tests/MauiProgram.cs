using MAUI_Tests.Services;
using MAUI_Tests.ViewModel;

namespace MAUI_Tests;

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
		builder.Services.AddSingleton<SaveService>();
        builder.Services.AddSingleton<TaskService>();
        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();
		
		builder.Services.AddSingleton(Connectivity.Current);
		builder.Services.AddSingleton(FileSystem.Current);
        builder.Services.AddTransient<CreatePage>();
        builder.Services.AddTransient<CreateViewModel>();

        builder.Services.AddTransient<DetailPage>();
		builder.Services.AddTransient<DetailViewModel>();
		return builder.Build();
	}
}
