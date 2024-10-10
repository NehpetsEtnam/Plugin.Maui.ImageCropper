using Microsoft.Extensions.Logging;
using Plugin.Maui.ImageCropper;

namespace ImageCropper.Demo;

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
			})
			.UseImageCropper();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

