using CommunityToolkit.Maui;
using DevExpress.Maui;
using DevExpress.Maui.Core;

namespace CollectionViewFilteringUI {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            ThemeManager.ApplyThemeToSystemBars = true;
            ThemeManager.Theme = new Theme(ThemeSeedColor.DarkGreen);
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .UseDevExpressCollectionView()
                .UseDevExpressEditors()
                .UseDevExpressControls()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                });

            return builder.Build();
        }
    }
}