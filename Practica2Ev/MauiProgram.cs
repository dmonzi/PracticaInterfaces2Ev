using Practica2Ev.Database;

namespace Practica2Ev;

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

        String ruta = pathdb.devolverRuta("Usuarios.db");
        builder.Services.AddSingleton<Repository>(
            s => ActivatorUtilities.CreateInstance<Repository>(s, ruta)
            );

        return builder.Build();
	}
}
