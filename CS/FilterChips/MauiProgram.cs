using CommunityToolkit.Maui;
using DevExpress.Maui;
using DevExpress.Maui.Core;

namespace FilterChips {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            ThemeManager.UseAndroidSystemColor = false;
            ThemeManager.Theme = new Theme(ThemeSeedColor.Purple);
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseDevExpressCollectionView()
                .UseDevExpressControls()
                .UseDevExpressEditors()
                .UseDevExpress(useLocalization: true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                });

            return builder.Build();
        }
    }
}