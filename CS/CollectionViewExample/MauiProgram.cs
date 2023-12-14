using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using DevExpress.Maui;
using DevExpress.Maui.CollectionView;
using DevExpress.Maui.Core;

namespace CollectionViewExample {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            ThemeManager.UseAndroidSystemColor = false;
            ThemeManager.Theme = new Theme(ThemeSeedColor.Purple);
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            return builder.Build();
        }
    }
}