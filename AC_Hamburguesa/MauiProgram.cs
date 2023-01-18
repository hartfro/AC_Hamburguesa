using AC_Hamburguesa.ACServices;
using AC_Hamburguesa.ACViewModels;
using AC_Hamburguesa.ACViews;

namespace AC_Hamburguesa;

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

        // Data
        builder.Services.AddSingleton<ACIBurgerServices, ACBurgerServices>();

        // Views
        builder.Services.AddSingleton<ACBurgerListPage>();
        builder.Services.AddTransient<ACBurgerItemPage>();

        // ViewModels
        builder.Services.AddSingleton<ACBurgerListPageViewModel>();
        builder.Services.AddTransient<ACBurgerItemViewModel>();


        return builder.Build();

	}
}
