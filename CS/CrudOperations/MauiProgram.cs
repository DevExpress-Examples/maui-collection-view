using CommunityToolkit.Maui;
using DevExpress.Maui;
using DevExpress.Maui.Core;
using static CrudOperations.App;

namespace CrudOperations;

public static class MauiProgram {
	public static MauiApp CreateMauiApp() 	{
        ThemeManager.ApplyThemeToSystemBars = true;
        ThemeManager.Theme = new Theme(ThemeSeedColor.Purple);
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.UseDevExpressCollectionView()
			.UseDevExpressControls()
			.UseDevExpressEditors()
            .UseDevExpress()
            .ConfigureFonts(fonts => {
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        return builder.Build();
	}
}

